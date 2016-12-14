using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using vok_web_api.Model;
using System;

namespace vok_web_api.DataAccess
{
    public class RechnungStore : IRechnungStore
    {
        public async Task<IEnumerable<RechnungAggregiert>> GetByLieferantAsync(string lieferantenname)
        {
            using (var conn = new SqlConnection(StoreConstants.DbConnectionString))
            {
                await conn.OpenAsync();

                var result = await conn.QueryAsync<RechnungAggregiert>(@"
                    select	'Lieferant ' + cast(s.KredId as varchar(max)) as Lieferantenname,
		                    s.DSID as Rechnungsnummer, s.Betrag, s.DokName as DokumentName
                    from	dbo.tblVkoScans s
                    where	'Lieferant ' + cast(s.KredId as varchar(max)) = @Lieferantenname",
                    new { Lieferantenname = lieferantenname });

                return result;
            }
        }
    }
}
