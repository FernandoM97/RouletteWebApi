using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebApi.DTO
{
    public class CreateBetForm
    {
        [JsonProperty("rouletteId")]
        public string RouletteId { get; set; }

        [JsonProperty("ammount")]
        public int BetAmmount { get; set; }

        [JsonProperty("box")]
        public string BetBox { get; set; }

        [JsonProperty("dateMade")]
        public string DateMade { get; set; }


    }
}
