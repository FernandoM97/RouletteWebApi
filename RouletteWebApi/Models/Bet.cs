using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebApi.Models
{
    public class Bet
    {
        /// <summary>
        /// Id of the bet
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Reoulette of the bet
        /// </summary>
        public string RouletteId { get; set; }
        /// <summary>
        /// Ammount of the bet
        /// </summary>
        public int BetAmmount { get; set; }
        /// <summary>
        /// User that make the bet
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Box to which the user bets
        /// </summary>
        public string BetBox { get; set; }
        /// <summary>
        /// The date when the bet was made
        /// </summary>
        public string DateMade { get; set; }

    }
}
