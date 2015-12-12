
using System;

namespace Web.Actions
{
    [Serializable()]
    public class ParameterAction
    {
        //Inherits ActionObjectInterface
        public ParameterAction()
        {
        }

        #region "ActionObjectInterface Members"

        public object handleRequest(object objInput)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
