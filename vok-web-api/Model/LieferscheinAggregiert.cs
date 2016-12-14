using System;

namespace vok_web_api.Model
{
    public class LieferscheinAggregiert
    {
        public int DSID { get; set; }

        public string Lieferscheinnummer { get; set; }

        public string Lieferantenname { get; set; }

        public DateTime Liefertermin { get; set; }

        public decimal SummeNetto { get; set; }

        public decimal SummeBrutto { get; set; }
    }
}
