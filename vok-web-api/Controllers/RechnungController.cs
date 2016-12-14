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
    public class RechnungController : Controller
    {
        private IRechnungStore store = null;

        public RechnungController(IRechnungStore store)
        {
            this.store = store;
        }

        [Route("rechnungen")]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<RechnungAggregiert>))]
        public async Task<IActionResult> GetByLieferantAsync([FromQuery] string lieferantenname)
        {
            var result = await this.store.GetByLieferantAsync(lieferantenname);
            result = result.Select(r =>
            {
                r.DokumentName = $"https://pcmprototype.blob.core.windows.net/invoices/{r.DokumentName}";
                return r;
            });
            return this.Ok(result);
        }
    }
}
