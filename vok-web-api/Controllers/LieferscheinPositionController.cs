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
    public class LieferscheinPositionController : Controller
    {
        private ILieferscheinPositionStore store = null;

        public LieferscheinPositionController(ILieferscheinPositionStore store)
        {
            this.store = store;
        }

        [Route("lieferscheinPositionen")]
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<LieferscheinPosition>))]
        public async Task<IActionResult> GetLieferscheinPositionenAsync([FromBody] IEnumerable<int> lieferscheinIDs)
        {
            var result = await this.store.GetByLieferscheinIDsAsync(lieferscheinIDs);
            return this.Ok(result);
        }
    }
}
