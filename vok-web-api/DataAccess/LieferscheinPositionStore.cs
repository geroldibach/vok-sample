using Dapper;
using Microsoft.ApplicationInsights;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using vok_web_api.Model;

namespace vok_web_api.DataAccess
{
    public class LieferscheinPositionStore : ILieferscheinPositionStore
    {
        private readonly IKeyVaultConfigurationReader configurationReader;

        public LieferscheinPositionStore(IKeyVaultConfigurationReader configurationReader)
        {
            this.configurationReader = configurationReader;
        }

        public async Task<IEnumerable<LieferscheinPosition>> GetByLieferscheinIDsAsync(IEnumerable<int> lieferscheinIDs)
        {
            var connectionString = await configurationReader.GetSecretAsync("vok-database");
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();

                var result = new List<LieferscheinPosition>();
                foreach (var lieferscheinID in lieferscheinIDs)
                {
                    result.AddRange(await conn.QueryAsync<LieferscheinPosition>(@"
                        select	p.DSID, p.LsId as LieferscheinID, p.LsPosID as LieferscheinPositionID, 
		                        p.Preis * p.Menge as Netto,
		                        p.Preis * p.Menge * (1 + p.Steuersatz) as Brutto,
		                        p.Artikelbezeichnung, p.Lieferantenmaterialnummer
                        from	dbo.tblVKoLsPos p
                        where	p.LsId = @LsId", new { LsId = lieferscheinID }));
                }

                return result;
            }
        }
    }
}
