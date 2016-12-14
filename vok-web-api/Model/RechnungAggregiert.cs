using System;

namespace vok_web_api.Model
{
    public class RechnungAggregiert
    {
        public string Lieferantenname { get; set; }

        public int Rechnungsnummer { get; set; }

        public decimal Betrag { get; set; }

        public string DokumentName { get; set; }
    }
}
