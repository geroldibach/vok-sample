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
            using (var conn = new SqlConnection(StoreConstants.DbConnectionString))
            {
                await conn.OpenAsync();

                var result = await conn.QueryAsync<LieferscheinAggregiert>(@"
                    select	ls.DSID, ls.Lieferscheinnummer, 'Lieferant ' + cast(ls.MaKredId as varchar(max)) as Lieferantenname,
		                    ls.Liefertermin, coalesce(sum(p.Preis * p.Menge), 0) as SummeNetto,
		                    coalesce(sum(p.Preis * p.Menge * (1 + p.Steuersatz)), 0) as SummeBrutto
                    from	dbo.tblVkoLs ls
		                    inner join dbo.tblVKoLsPos p on p.LsId = ls.DSID
                    group by ls.DSID, ls.Lieferscheinnummer, ls.MaKredId,
		                    ls.Liefertermin");

                return result;
            }
        }
    }
}
