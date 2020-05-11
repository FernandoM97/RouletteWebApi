using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebApi.DTO
{
    public class CreateRouleteForm
    {
        [JsonProperty("open")]
        public string Open { get; set; }

        [JsonProperty("openDate")]
        public string OpenDate { get; set; }

        [JsonProperty("closeDate")]
        public string CloseDate { get; set; }
    }
}
