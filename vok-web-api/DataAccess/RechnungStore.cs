using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using vok_web_api.Model;
using System;
using Microsoft.ApplicationInsights;
using System.Diagnostics;

namespace vok_web_api.DataAccess
{
    public class RechnungStore : IRechnungStore
    {
        private readonly IKeyVaultConfigurationReader configurationReader;

        public RechnungStore(IKeyVaultConfigurationReader configurationReader)
        {
            this.configurationReader = configurationReader;
        }

        public async Task<IEnumerable<RechnungAggregiert>> GetByLieferantAsync(string lieferantenname)
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

                    var result = await conn.QueryAsync<RechnungAggregiert>(@"
                    select	'Lieferant ' + cast(s.KredId as varchar(max)) as Lieferantenname,
		                    s.DSID as Rechnungsnummer, s.Betrag, s.DokName as DokumentName
                    from	dbo.tblVkoScans s
                    where	'Lieferant ' + cast(s.KredId as varchar(max)) = @Lieferantenname",
                        new { Lieferantenname = lieferantenname });

                    return result;
                }
            }
            finally
            {
                timer.Stop();
                new TelemetryClient().TrackDependency("DB", $"Rechnungen für Lieferant {lieferantenname} laden", startTime, timer.Elapsed, success);
            }
        }
    }
}
