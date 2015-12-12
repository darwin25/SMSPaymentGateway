using DBDataProvider;
namespace Web.DAO
{
    public class BaseDAO
    {
        private MySqlDatabase _sqldb;

        protected MySqlDatabase sqldb
        {
            get
            {
                if (_sqldb == null)
                {
                    var config = new ConnValues();
                    _sqldb = new MySqlDatabase(config.conn());
                }
                return _sqldb;
            }
        }

    }
}