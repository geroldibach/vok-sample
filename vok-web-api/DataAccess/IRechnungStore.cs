using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vok_web_api.Model;

namespace vok_web_api.DataAccess
{
    public interface IRechnungStore
    {
        Task<IEnumerable<RechnungAggregiert>> GetByLieferantAsync(string lieferantenname);
    }
}
