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
    public class LieferscheinStore : ILieferscheinStore
    {
        private readonly IKeyVaultConfigurationReader configurationReader;

        public LieferscheinStore(IKeyVaultConfigurationReader configurationReader)
        {
            this.configurationReader = configurationReader;
        }

        public async Task<IEnumerable<LieferscheinAggregiert>> GetAllAsync()
        {
            var startTime = DateTime.UtcNow;
            var timer = Stopwatch.StartNew();
            var success = false;
            try
            {
                var connectionString = await configurationReader.GetSecretAsync("vok-database");
                using (var conn = new SqlConnection(connectionString))
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

                    success = true;
                    return result;
                }
            }
            finally
            {
                timer.Stop();
                new TelemetryClient().TrackDependency("DB", "Alle Lieferscheine laden", startTime, timer.Elapsed, success);
            }
        }
    }
}
