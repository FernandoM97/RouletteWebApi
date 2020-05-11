using System;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RouletteWebApi.Services;
using RouletteWebApi.DTO;
using Newtonsoft.Json;
using System.Text;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RouletteWebApi.Models;
using System.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace RouletteWebApiTest
{
    public class UnitTest1
    {
        private TestServer _server;
        public HttpClient Client { get; private set; }
        public IConfigurationRoot Configuration { get; private set; }

        public string Roulette0 { get; private set; }
        public string Roulette1 { get; private set; }
        



        public UnitTest1()
        {
            SetUpClient();
        }

        public void Dispose()
        {

        }

        public async Task SeedData()
        {

            // Create new roulette
            var response0 = await Client.GetAsync("/roulette/create");
            Roulette0 = response0.Content.ReadAsStringAsync().Result;
            var response1 = await Client.GetAsync("/roulette/create");
            Roulette1 = response1.Content.ReadAsStringAsync().Result;
        }

        // TEST NAME - CreateRoulette
        // TEST DESCRIPTION - A new roulette should be created
        [Fact]
        public async Task TestCase0()
        {
            var response0 = await Client.GetAsync("/roulette/create");
            response0.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult0;
            var realData0 = response0.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData0, out idResult0));

            var response1 = await Client.GetAsync("/roulette/create");
            response1.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult1;
            var realData1 = response1.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData1, out idResult1));

            var response2 = await Client.GetAsync("/roulette/create");
            response2.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult2;
            var realData2 = response2.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData2, out idResult2));

            var response3 = await Client.GetAsync("/roulette/create");
            response3.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult3;
            var realData3 = response3.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData3, out idResult3));

        }


        // TEST NAME - OpenRoulettes
        // TEST DESCRIPTION - A roulette should be open
        [Fact]
        public async Task TestCase1()
        {
            await SeedData();

            //open Roulettes
            var response0 = await Client.GetAsync("roulette/open/" + Roulette0);
            response0.StatusCode.Should().BeEquivalentTo(200);

            var response1 = await Client.GetAsync("roulette/open/" + Roulette1);
            response1.StatusCode.Should().BeEquivalentTo(200);

            //Making Bets
            var createForm0 = GenerateCreateBetForm(Roulette0, 5000, "20");
            var response2 = await Client.PostAsync("/roulette/bet/5", new StringContent(JsonConvert.SerializeObject(createForm0), Encoding.UTF8, "application/json"));
            response2.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult0;
            var realData2 = response2.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData2, out idResult0));

            var createForm1 = GenerateCreateBetForm(Roulette0, 8000, "16");
            var response3 = await Client.PostAsync("/roulette/bet/2", new StringContent(JsonConvert.SerializeObject(createForm1), Encoding.UTF8, "application/json"));
            response3.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult1;
            var realData3 = response3.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData3, out idResult1));

            var createForm2 = GenerateCreateBetForm(Roulette0, 2600, "7");
            var response4 = await Client.PostAsync("/roulette/bet/8", new StringContent(JsonConvert.SerializeObject(createForm2), Encoding.UTF8, "application/json"));
            response4.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult2;
            var realData4 = response4.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData4, out idResult2));

            var createForm3 = GenerateCreateBetForm(Roulette0, 3800, "red");
            var response5 = await Client.PostAsync("/roulette/bet/15", new StringContent(JsonConvert.SerializeObject(createForm3), Encoding.UTF8, "application/json"));
            response5.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult3;
            var realData5 = response5.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData5, out idResult3));

            var createForm4 = GenerateCreateBetForm(Roulette1, 9000, "21");
            var response6 = await Client.PostAsync("/roulette/bet/20", new StringContent(JsonConvert.SerializeObject(createForm4), Encoding.UTF8, "application/json"));
            response6.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult4;
            var realData6 = response6.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData6, out idResult4));

            var createForm5 = GenerateCreateBetForm(Roulette1, 6400, "black");
            var response7 = await Client.PostAsync("/roulette/bet/60", new StringContent(JsonConvert.SerializeObject(createForm5), Encoding.UTF8, "application/json"));
            response7.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult5;
            var realData7 = response7.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData7, out idResult5));

            var createForm6 = GenerateCreateBetForm(Roulette1, 8500, "28");
            var response8 = await Client.PostAsync("/roulette/bet/11", new StringContent(JsonConvert.SerializeObject(createForm6), Encoding.UTF8, "application/json"));
            response8.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult6;
            var realData8 = response8.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData8, out idResult6));

            var createForm7 = GenerateCreateBetForm(Roulette1, 10000, "12");
            var response9 = await Client.PostAsync("/roulette/bet/16", new StringContent(JsonConvert.SerializeObject(createForm7), Encoding.UTF8, "application/json"));
            response9.StatusCode.Should().BeEquivalentTo(201);

            ObjectId idResult7;
            var realData9 = response9.Content.ReadAsStringAsync().Result;
            Assert.True(ObjectId.TryParse(realData9, out idResult7));

            //Close Reoulette0
            var response10 = await Client.GetAsync("roulette/close/" + Roulette0);
            response10.StatusCode.Should().BeEquivalentTo(200);

            //Bets Expected Results for Reoulette0
            string bet0 = CreateJsonExpectedResponse(Roulette0, "5", createForm0);
            string bet1 = CreateJsonExpectedResponse(Roulette0, "2", createForm1);
            string bet2 = CreateJsonExpectedResponse(Roulette0, "8", createForm2);
            string bet3 = CreateJsonExpectedResponse(Roulette0, "15", createForm3);
            var expectedData1 = JsonConvert.DeserializeObject("[" + bet0 + "," + bet1 + "," + bet2 + "," + bet3 + "]");

            //Real Data Respopnse
            var realData10 = JsonConvert.DeserializeObject(response10.Content.ReadAsStringAsync().Result);
            realData10.Should().BeEquivalentTo(expectedData1);

            //Close Roulette1
            var response11 = await Client.GetAsync("roulette/close/" + Roulette1);
            response11.StatusCode.Should().BeEquivalentTo(200);

            //Bets results expected for Roulette1
            string bet4 = CreateJsonExpectedResponse(Roulette1, "20", createForm4);
            string bet5 = CreateJsonExpectedResponse(Roulette1, "60", createForm5);
            string bet6 = CreateJsonExpectedResponse(Roulette1, "11", createForm6);
            string bet7 = CreateJsonExpectedResponse(Roulette0, "16", createForm7);
            var expectedData2 = JsonConvert.DeserializeObject("[" + bet4 + "," + bet5 + "," + bet6 + "," + bet7 + "]");

            //Real Data Response
            var realData11 = JsonConvert.DeserializeObject(response11.Content.ReadAsStringAsync().Result);
            realData11.Should().BeEquivalentTo(expectedData2);
    
        }
        private void SetUpClient()
        {

            var builder = new WebHostBuilder()
                .UseStartup<RouletteWebApi.Startup>()
                .ConfigureServices(services =>
                {
                    var configurationBuilder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables();
                    Configuration = configurationBuilder.Build();

                    services.Configure<RouletteDatabaseSettings>(Configuration.GetSection(nameof(RouletteDatabaseSettings)));

                    services.RemoveAll(typeof(IRouletteDatabaseSettings));
                    services.AddSingleton<IRouletteDatabaseSettings>(sp =>
                        sp.GetRequiredService<IOptions<RouletteDatabaseSettings>>().Value);


                });

            _server = new TestServer(builder);

            Client = _server.CreateClient();
        }

        private CreateRouleteForm GenerateCreateRouletteForm(string open, string openDate, string CloseDate)
        {
            return new CreateRouleteForm()
            {
                Open = open,
                OpenDate = openDate,
                CloseDate = CloseDate

            };
        }

        private CreateBetForm GenerateCreateBetForm(string rouletteId, int ammount, string box)
        {
            return new CreateBetForm()
            {
                RouletteId = rouletteId,
                BetAmmount = ammount,
                BetBox = box,
                DateMade = DateTime.Now.ToString()
            };

        }

        private string CreateJsonExpectedResponse(string betId, string userId, CreateBetForm bet)
        {
            return "{\"id\":\"" + betId + "\",\"rouletteId\":\"" + Roulette0 + "\",\"userId\":\"" + userId + "\"," +
                "\"betAmount\":" + bet.BetAmmount + ",\"betBox\": \"" + bet.BetBox + "\", \"dateMade\":\"" + bet.DateMade + "\"}";
        }
    }
}
