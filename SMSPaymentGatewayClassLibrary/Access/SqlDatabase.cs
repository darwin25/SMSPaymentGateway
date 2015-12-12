using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace DBDataProvider
{
    /// <summary>
    /// This class provides a fast and universal method for accessing SQL Server database.This class cannot be inherited.
    /// </summary>
    public sealed class SqlDatabase
    {

        string _connectionString;
        /// <summary>
        /// Initializes a new instance of the ADO.SqlDatabase class.
        /// </summary>
        /// <param name="connectionString">The connection used to open the SQL Server database.</param>
        public SqlDatabase(string connectionString)
        {
            _connectionString = connectionString;
        }


        /// <summary>
        /// Gets or sets the string used to open a SQL Server database.
        /// </summary>
        /// <returns>The connection string that includes the source database name, and other parameters needed to establish the initial connection.</returns>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        private void AssignParameters(SqlCommand cmd, SqlParameter[] cmdParameters)
        {
            if ((cmdParameters == null))
                return;
            foreach (var p in cmdParameters)
            {
                cmd.Parameters.Add(p);
            }
        }

        private void AssignParameters(SqlCommand cmd, object[] parameterValues)
        {
            if (cmd.Parameters.Count - 1 != parameterValues.Length)
                throw new ApplicationException("Stored procedure's parameters and parameter values does not match.");
            int i = 0;
            foreach (SqlParameter param in cmd.Parameters)
            {
                if (param.Direction != ParameterDirection.Output && param.Direction != ParameterDirection.ReturnValue)
                {
                    param.Value = parameterValues[i];
                    i += 1;
                }
            }
        }


        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <param name="cmd">The Transact-SQL statement or stored procedure to execute at the data source.</param>
        /// <param name="cmdType">A value indicating how the System.Data.SqlCommand.CommandText property is to be interpreted.</param>
        /// <param name="parameters">The parameters of the Transact-SQL statement or stored procedure.</param>
        /// <returns>The number of rows affected.</returns>
        public int ExecuteNonQuery(string cmd, CommandType cmdType, SqlParameter[] parameters = null)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            int res = -1;
            try
            {
                connection = new SqlConnection(_connectionString);
                command = new SqlCommand(cmd, connection);
                command.CommandType = cmdType;
                this.AssignParameters(command, parameters);
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                res = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (connection != null && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (command != null)
                    command.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
            return res;
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected.
        /// </summary>
        /// <param name="spname">The stored procedure to execute at the data source.</param>
        /// <param name="returnValue">The returned value from stored procedure.</param>
        /// <param name="parameterValues">The parameter values of the stored procedure.</param>
        /// <returns>The number of rows affected.</returns>
        public int ExecuteNonQuery(string spname, ref int returnValue, params object[] parameterValues)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            int res = -1;
            try
            {
                connection = new SqlConnection(_connectionString);
                command = new SqlCommand(spname, connection) { CommandType = CommandType.StoredProcedure };

                connection.Open();
                SqlCommandBuilder.DeriveParameters(command);
                this.AssignParameters(command, parameterValues);
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                res = command.ExecuteNonQuery();
                returnValue = (int)command.Parameters[0].Value;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (connection != null && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (command != null)
                    command.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
            return res;
        }


        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="cmd">The Transact-SQL statement or stored procedure to execute at the data source.</param>
        /// <param name="cmdType">A value indicating how the System.Data.SqlCommand.CommandText property is to be interpreted.</param>
        /// <param name="parameters">The parameters of the Transact-SQL statement or stored procedure.</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public object ExecuteScalar(string cmd, CommandType cmdType, SqlParameter[] parameters = null)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            object res = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                command = new SqlCommand(cmd, connection) { CommandType = cmdType };
                this.AssignParameters(command, parameters);
                connection.Open();
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                res = command.ExecuteScalar();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (connection != null && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (command != null)
                    command.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
            return res;
        }

        /// <summary>
        /// Executes the query, and returns the first column of the first row in the result set returned by the query. Additional columns or rows are ignored.
        /// </summary>
        /// <param name="spname">The stored procedure to execute at the data source.</param>
        /// <param name="returnValue">The returned value from stored procedure.</param>
        /// <param name="parameterValues">The parameter values of the stored procedure.</param>
        /// <returns>The first column of the first row in the result set, or a null reference if the result set is empty.</returns>
        public object ExecuteScalar(string spname, ref int returnValue, params object[] parameterValues)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            object res = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                command = new SqlCommand(spname, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlCommandBuilder.DeriveParameters(command);
                this.AssignParameters(command, parameterValues);
                transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                res = command.ExecuteScalar();
                returnValue = (int)command.Parameters[0].Value;
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (connection != null && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (command != null)
                    command.Dispose();
                if (transaction != null)
                    transaction.Dispose();
            }
            return res;
        }

        /// <summary>
        /// Sends the System.Data.SqlCommand.CommandText to the System.Data.SqlCommand.Connection, and builds a System.Data.SqlDataReader using one of the System.Data.CommandBehavior values.
        /// </summary>
        /// <param name="cmd">The Transact-SQL statement or stored procedure to execute at the data source.</param>
        /// <param name="cmdType">A value indicating how the System.Data.SqlCommand.CommandText property is to be interpreted.</param>
        /// <param name="parameters">The parameters of the Transact-SQL statement or stored procedure.</param>
        /// <returns>A System.Data.SqlDataReader object.</returns>
        public IDataReader ExecuteReader(string cmd, CommandType cmdType, SqlParameter[] parameters = null)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader res = null;
            try
            {
                connection = new SqlConnection(_connectionString);
                command = new SqlCommand(cmd, connection);
                command.CommandType = cmdType;
                this.AssignParameters(command, parameters);
                connection.Open();
                res = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            return (IDataReader)res;
        }

        /// <summary>
        /// Sends the System.Data.SqlCommand.CommandText to the System.Data.SqlCommand.Connection, and builds a System.Data.SqlDataReader using one of the System.Data.CommandBehavior values.
        /// </summary>
        /// <param name="spname">The stored procedure to execute at the data source.</param>
        /// <param name="returnValue">The returned value from stored procedure.</param>
        /// <param name="parameterValues">The parameter values of the stored procedure.</param>
        /// <returns>A System.Data.SqlDataReader object.</returns>
        public IDataReader ExecuteReader(string spname, ref int returnValue, params object[] parameterValues)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataReader res = null;
            try
            {
                connection = new SqlConnection(ConnectionString);
                command = new SqlCommand(spname, connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlCommandBuilder.DeriveParameters(command);
                this.AssignParameters(command, parameterValues);
                res = command.ExecuteReader(CommandBehavior.CloseConnection);
                returnValue = (int)command.Parameters[0].Value;
            }
            catch (Exception ex)
            {
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            return (IDataReader)res;
        }


        /// <summary>
        /// Adds or refreshes rows in the System.Data.DataSet to match those in the data source using the System.Data.DataSet name, and creates a System.Data.DataTable named "Table."
        /// </summary>
        /// <param name="cmd">The Transact-SQL statement or stored procedure to execute at the data source.</param>
        /// <param name="cmdType">A value indicating how the System.Data.SqlCommand.CommandText property is to be interpreted.</param>
        /// <param name="parameters">The parameters of the Transact-SQL statement or stored procedure.</param>
        /// <returns>A System.Data.Dataset object.</returns>
        public DataSet FillDataset(string cmd, CommandType cmdType, SqlParameter[] parameters = null)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            SqlDataAdapter sqlda = null;
            DataSet res = new DataSet();
            try
            {
                connection = new SqlConnection(_connectionString);
                command = new SqlCommand(cmd, connection) { CommandType = cmdType };
                AssignParameters(command, parameters);
                sqlda = new SqlDataAdapter(command);
                sqlda.Fill(res);
            }
            catch (Exception ex)
            {
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
                if (command != null)
                    command.Dispose();
                if (sqlda != null)
                    sqlda.Dispose();
            }
            return res;
        }


        /// <summary>
        /// Calls the respective INSERT, UPDATE, or DELETE statements for each inserted, updated, or deleted row in the System.Data.DataSet with the specified System.Data.DataTable name.
        /// </summary>
        /// <param name="insertCmd">A command used to insert new records into the data source.</param>
        /// <param name="updateCmd">A command used to update records in the data source.</param>
        /// <param name="deleteCmd">A command for deleting records from the data set.</param>
        /// <param name="ds">The System.Data.DataSet to use to update the data source. </param>
        /// <param name="srcTable">The name of the source table to use for table mapping.</param>
        /// <returns>The number of rows successfully updated from the System.Data.DataSet.</returns>
        public int ExecuteDataset(SqlCommand insertCmd, SqlCommand updateCmd, SqlCommand deleteCmd, DataSet ds, string srcTable)
        {
            SqlConnection connection = null;
            SqlDataAdapter sqlda = null;
            int res = 0;
            try
            {
                connection = new SqlConnection(_connectionString);
                sqlda = new SqlDataAdapter();
                if (insertCmd != null) { insertCmd.Connection = connection; sqlda.InsertCommand = insertCmd; }
                if (updateCmd != null) { updateCmd.Connection = connection; sqlda.UpdateCommand = updateCmd; }
                if (deleteCmd != null) { deleteCmd.Connection = connection; sqlda.DeleteCommand = deleteCmd; }
                res = sqlda.Update(ds, srcTable);
            }
            catch (Exception ex)
            {
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
                if (insertCmd != null)
                    insertCmd.Dispose();
                if (updateCmd != null)
                    updateCmd.Dispose();
                if (deleteCmd != null)
                    deleteCmd.Dispose();
                if (sqlda != null)
                    sqlda.Dispose();
            }
            return res;
        }

        /// <summary>
        /// Executes a SQL query file against the connection.
        /// </summary>
        /// <param name="filename">SQL query file name.</param>
        /// <param name="parameters">The parameters of the SQL query file.</param>
        public void ExecuteScript(string filename, SqlParameter[] parameters = null)
        {
            FileStream fStream = null;
            StreamReader sReader = null;
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                sReader = new StreamReader(fStream);
                connection = new SqlConnection(ConnectionString);
                command = connection.CreateCommand();
                connection.Open();
                while ((!sReader.EndOfStream))
                {
                    StringBuilder sb = new StringBuilder();
                    while ((!sReader.EndOfStream))
                    {
                        string s = sReader.ReadLine();
                        if ((!string.IsNullOrEmpty(s)) && (s.ToUpper().Trim() == "GO"))
                        {
                            break; // TODO: might not be correct. Was : Exit While
                        }
                        sb.AppendLine(s);
                    }
                    command.CommandText = sb.ToString();
                    command.CommandType = CommandType.Text;
                    AssignParameters(command, parameters);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new SqlDatabaseException(ex.Message, ex.InnerException);
            }
            finally
            {
                if ((connection != null) && (connection.State == ConnectionState.Open))
                    connection.Close();
                if (command != null)
                    command.Dispose();
                if (sReader != null)
                    sReader.Close();
                if (fStream != null)
                    fStream.Close();
            }
        }


    }
}