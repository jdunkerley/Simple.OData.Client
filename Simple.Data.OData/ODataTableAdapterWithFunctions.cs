﻿using System.Collections.Generic;

namespace Simple.Data.OData
{
    public partial class ODataTableAdapter : IAdapterWithFunctions
    {
        public bool IsValidFunction(string functionName)
        {
            return GetSchema().HasFunction(functionName);
        }

        public IEnumerable<IEnumerable<IEnumerable<KeyValuePair<string, object>>>> Execute(string functionName, IDictionary<string, object> parameters)
        {
            return ExecuteFunction(functionName, parameters, null);
        }

        public IEnumerable<IEnumerable<IEnumerable<KeyValuePair<string, object>>>> Execute(string functionName, IDictionary<string, object> parameters, IAdapterTransaction transaction)
        {
            return ExecuteFunction(functionName, parameters, transaction);
        }

        private IEnumerable<IEnumerable<IEnumerable<KeyValuePair<string, object>>>> ExecuteFunction(string functionName, IDictionary<string, object> parameters, IAdapterTransaction transaction)
        {
            return new RequestExecutor(_urlBase, _schema).ExecuteFunction(functionName, parameters);
        }
    }
}