namespace vok_web_api.Model
{
    public class LieferscheinPosition
    {
        public int DSID { get; set; }

        public int LieferscheinID { get; set; }

        public int LieferscheinPositionID { get; set; }

        public decimal Netto { get; set; }

        public decimal Brutto { get; set; }

        public string Artikelbezeichnung { get; set; }

        public string Lieferantenmaterialnummer { get; set; }
    }
}
