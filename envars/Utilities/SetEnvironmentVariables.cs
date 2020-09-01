using System;
using System.Collections.Generic;

namespace envars.Utilities
{
    public static class SetEnvironmentVariables
    {
        public static void Set(Dictionary<string, string> vars, bool overWriteVariables = true)
        {
            foreach (var keyValuePair in vars)
            {
                if (overWriteVariables || Environment.GetEnvironmentVariable(keyValuePair.Key) == null)
                {
                    Environment.SetEnvironmentVariable(keyValuePair.Key, keyValuePair.Value);
                }
            }
        }
    }
}
