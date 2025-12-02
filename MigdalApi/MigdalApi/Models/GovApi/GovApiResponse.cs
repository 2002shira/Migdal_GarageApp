using System.Text.Json.Serialization;

namespace MigdalApi.Models.GovApi
{
    public class GovApiResponse
    {
        public bool success { get; set; }
        public GovApiResult result { get; set; }
    }

    public class GovApiResult
    {
        public List<GovGarageRecord> records { get; set; } = new();
    }

    public class GovGarageRecord
    {
        [JsonPropertyName("_id")]
        public int Id { get; set; }

        [JsonPropertyName("mispar_mosah")]
        public int MisparMosach { get; set; }

        [JsonPropertyName("shem_mosah")]
        public string ShemMosach { get; set; }

        [JsonPropertyName("cod_sug_mosah")]
        public int CodSugMosach { get; set; }

        [JsonPropertyName("sug_mosah")]
        public string SugMosah { get; set; }

        [JsonPropertyName("ktovet")]
        public string Ktovet { get; set; }

        [JsonPropertyName("yishuv")]
        public string Yishuv { get; set; }

        [JsonPropertyName("telephone")]
        public string Telephone { get; set; }

        [JsonPropertyName("mikud")]
        public int Mikud { get; set; }

        [JsonPropertyName("cod_miktzoa")]
        public int CodMiktzoa { get; set; }

        [JsonPropertyName("miktzoa")]
        public string Miktzoa { get; set; }

        [JsonPropertyName("menahel_miktzoa")]
        public string MenahelMiktzoa { get; set; }

        [JsonPropertyName("rasham_havarot")]
        public long RashamHavarot { get; set; }

        [JsonPropertyName("TESTIME")]
        public string Testime { get; set; }
    }

}
