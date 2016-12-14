using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vok_web_api.DataAccess
{
    /// <summary>
    /// Storing the DB connection string is NOT A GOOD PRACTICE!!!
    /// Just done to keep code very simple.
    /// </summary>
    public static class StoreConstants
    {
        public const string DbConnectionString = "Server=tcp:pcm-prototype-server.database.windows.net,1433;Initial Catalog=vok;Persist Security Info=False;User ID=...;Password=...;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
