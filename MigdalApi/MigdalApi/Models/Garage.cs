namespace MigdalApi.Models
{
    public class Garage
    {
        public int Id { get; set; }
        public int MisparMosach { get; set; }
        public string ShemMosach { get; set; } = null!;
        public int CodSugMosach { get; set; }
        public string SugMosach { get; set; } = null!;
        public string Ktovet { get; set; } = null!;
        public string Yishuv { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public int Mikud { get; set; }
        public int CodMiktzoa { get; set; }
        public string Miktzoa { get; set; } = null!;
        public string MenahelMiktzoa { get; set; } = null!;
        public long RashamHavarot { get; set; }
        public string? Testime { get; set; }
    }
}
