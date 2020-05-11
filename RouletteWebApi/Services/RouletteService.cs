using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using RouletteWebApi.DTO;
using RouletteWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebApi.Services
{
    public class RouletteService
    {
        private readonly IMongoCollection<Roulette> _roulettes;
        private readonly IMongoCollection<Bet> _bets;

        public RouletteService(IRouletteDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _roulettes = database.GetCollection<Roulette>(settings.RoulettesCollectionName);
            _bets = database.GetCollection<Bet>(settings.BetsCollectionName);
        }

        /// <summary>
        /// Returns the list of Roulettes in database
        /// </summary>
        public List<Roulette> Get() =>
            _roulettes.Find(roulette => true).ToList();

        /// <summary>
        /// Find the roulette with the id 
        /// </summary>
        public Roulette Get(string id) =>
            _roulettes.Find<Roulette>(roulette => roulette.Id == id).FirstOrDefault();

        /// <summary>
        /// Returns the list of bets in database
        /// </summary>
        public List<Bet> GetBet() =>
           _bets.Find(bet => true).ToList();

        /// <summary>
        /// Inserts a roulette in database
        /// </summary>
        public Roulette Create(Roulette roulette)
        {
            _roulettes.InsertOne(roulette);
            return roulette;
        }

        /// <summary>
        /// Update a roulette in database
        /// </summary>
        public void Update(string id, Roulette rouletteIn) =>
            _roulettes.ReplaceOne(roulette => roulette.Id == id, rouletteIn);


        /// <summary>
        /// Removes a roulette from database
        /// </summary>
        public void Remove(Roulette rouletteIn) =>
            _roulettes.DeleteOne(roulette => roulette.Id == rouletteIn.Id);

        /// <summary>
        /// Removes a roulette that match the id from database
        /// </summary>
        public void Remove(string id) =>
            _roulettes.DeleteOne(roulette => roulette.Id == id);

        /// <summary>
        /// Close a roulette and returns its bets
        /// </summary>
        public List<Bet> CloseRoulette(Roulette roulette)
        {
            Roulette db_roulette = Get(roulette.Id);
            db_roulette.CloseDate = roulette.CloseDate;
            db_roulette.Open = roulette.Open;
            Update(db_roulette.Id, db_roulette);
            return GetRouleteBets(db_roulette);
        }

        /// <summary>
        /// Insert a bet into database
        /// </summary>
        public Bet CreateBet(Bet bet)
        {
            _bets.InsertOne(bet);
            return bet;
        }

        /// <summary>
        /// Returns a list with the bets made on a roulette
        /// </summary>
        private List<Bet> GetRouleteBets(Roulette roulette)
        {
            var open = DateTime.Parse(roulette.OpenDate);
            var close = DateTime.Parse(roulette.CloseDate);
            List<Bet> bets =  _bets.Find(bet => bet.RouletteId == roulette.Id).ToList();

            return bets.FindAll(bet => GetDate(bet.DateMade) <= close && GetDate(bet.DateMade) >= open);
        }

        /// <summary>
        /// Returns a dateTime from string
        /// </summary>
        private DateTime GetDate(string dateString)
        {
            return DateTime.Parse(dateString);
        }
    }
}

