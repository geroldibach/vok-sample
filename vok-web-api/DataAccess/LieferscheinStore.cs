using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using vok_web_api.Model;

namespace vok_web_api.DataAccess
{
    public class LieferscheinStore : ILieferscheinStore
    {
        public async Task<IEnumerable<LieferscheinAggregiert>> GetAllAsync()
        {
            using (var conn = new SqlConnection("Server=tcp:pcm-prototype-server.database.windows.net,1433;Initial Catalog=vok;Persist Security Info=False;User ID=...;Password=...;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                await conn.OpenAsync();

                var result = await conn.QueryAsync<LieferscheinAggregiert>(@"
                    select	ls.DSID, ls.Lieferscheinnummer, 'Lieferant ' + ls.Lieferantennummer as Lieferantenname,
		                    ls.Liefertermin, coalesce(sum(p.Preis * p.Menge), 0) as SummeNetto,
		                    coalesce(sum(p.Preis * p.Menge * (1 + p.Steuersatz)), 0) as SummeBrutto
                    from	dbo.tblVkoLs ls
		                    inner join dbo.tblVKoLsPos p on p.LsId = ls.DSID
                    group by ls.DSID, ls.Lieferscheinnummer, ls.Lieferantennummer,
		                    ls.Liefertermin");

                return result;
            }
        }
    }
}
