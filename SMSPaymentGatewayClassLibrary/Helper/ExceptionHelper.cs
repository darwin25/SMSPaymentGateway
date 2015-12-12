
using Microsoft.VisualBasic;
using System;
using  Web.Exceptions;
using DBDataProvider;

namespace Web.Helper
{
    public class ExceptionHelper
    {
        public ExceptionHelper()
        {
        }


        public static void ExceptionHandler(System.Exception e, Int16 ErrType)
        {
            if (e is System.Data.OleDb.OleDbException)
            {

                if (Strings.InStr(e.Message, "violation of primary", CompareMethod.Text) > 0)
                {
                    throw new DuplicateKeyException(Web.Constants.MessageAlert.DUPLICATE_ERROR);
                }
                else
                {
                    switch (ErrType)
                    {
                        case Web.Constants.ErrorType.ADD:
                            throw new MySQLDBException(Web.Constants.MessageAlert.ADD_GENERAL_ERROR);
                        case Web.Constants.ErrorType.EDIT:
                            throw new MySQLDBException(Web.Constants.MessageAlert.EDIT_GENERAL_ERROR);
                        case Web.Constants.ErrorType.DELETE:
                            throw new MySQLDBException(Web.Constants.MessageAlert.DELETE_GENERAL_ERROR);
                        case Web.Constants.ErrorType.SEARCH:

                            throw new MySQLDBException(Web.Constants.MessageAlert.SEARCH_GENERAL_ERROR);
                    }

                }
            }
            else if (e is MySql.Data.MySqlClient.MySqlException)
            {
                if (Strings.InStr(e.Message, "violation of primary", CompareMethod.Text) > 0)
                {
                    throw new DuplicateKeyException(Web.Constants.MessageAlert.DUPLICATE_ERROR);
                }
                else
                {
                    switch (ErrType)
                    {
                        case Web.Constants.ErrorType.ADD:
                            throw new MySQLDBException(Web.Constants.MessageAlert.ADD_GENERAL_ERROR);
                        case Web.Constants.ErrorType.EDIT:
                            throw new MySQLDBException(Web.Constants.MessageAlert.EDIT_GENERAL_ERROR);
                        case Web.Constants.ErrorType.DELETE:
                            throw new MySQLDBException(Web.Constants.MessageAlert.DELETE_GENERAL_ERROR);
                        case Web.Constants.ErrorType.SEARCH:
                            throw new MySQLDBException(Web.Constants.MessageAlert.SEARCH_GENERAL_ERROR);
                        case Web.Constants.ErrorType.ACTION:
                            throw new MySQLDBException(Web.Constants.MessageAlert.ACTION_GENERAL_ERROR);
                    }

                }
            }
            else if (e is System.Exception)
            {
                switch (ErrType)
                {
                    case Web.Constants.ErrorType.ADD:
                        throw new AddException(Web.Constants.MessageAlert.ADD_GENERAL_ERROR);
                    case Web.Constants.ErrorType.EDIT:
                        throw new EditException(Web.Constants.MessageAlert.EDIT_GENERAL_ERROR);
                    case Web.Constants.ErrorType.DELETE:
                        throw new DeleteException(Web.Constants.MessageAlert.DELETE_GENERAL_ERROR);
                    case Web.Constants.ErrorType.SEARCH:
                        throw new SearchException(Web.Constants.MessageAlert.SEARCH_GENERAL_ERROR);
                    case Web.Constants.ErrorType.ACTION:
                        throw new ActionExceptions(Web.Constants.MessageAlert.ACTION_GENERAL_ERROR);
                    case Web.Constants.ErrorType.WEBPAGE:
                        throw new PageException(Web.Constants.MessageAlert.PAGE_GENERAL_ERROR);
                    case Web.Constants.ErrorType.PARSING:

                        throw new PageException(Web.Constants.MessageAlert.PARSING_GENERAL_ERROR);
                }
            }
        }
    }
}
