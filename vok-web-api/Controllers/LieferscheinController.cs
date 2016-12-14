using Dapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using vok_web_api.DataAccess;
using vok_web_api.Model;

namespace vok_web_api.Controllers
{
    [Route("api")]
    public class LieferscheinController : Controller
    {
        private ILieferscheinStore store = null;

        public LieferscheinController(ILieferscheinStore store)
        {
            this.store = store;
        }

        [Route("lieferscheine")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LieferscheinAggregiert>))]
        public async Task<IActionResult> GetAllLieferscheinAggregiertAsync()
        {
            var result = await this.store.GetAllAsync();
            return this.Ok(result);
        }
    }
}
