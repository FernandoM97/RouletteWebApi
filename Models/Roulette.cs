using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RouletteWebApi.Models
{
    public class Roulette
    {
        /// <summary>
        /// Id of the roulette
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// State of the roulette
        /// </summary>
        public string Open { get; set; }
        /// <summary>
        /// The date when the roulette is opened
        /// </summary>
        public string OpenDate { get; set; }
        /// <summary>
        /// The date when the roulette is closed
        /// </summary>
        public string CloseDate { get; set; }

    }
}
