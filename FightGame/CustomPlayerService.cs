using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FightGame
{

    public interface IPlayerService
    {
        List<Player> GetPlayers();

    }
    public class ApiPlayerService : IPlayerService
    {
        private const string ApiUrl = "https://swapi.co/api/people/";
        public List<Player> GetPlayers()
        {
            var httpClient = new HttpClient();
            Task<string> task = httpClient.GetStringAsync(ApiUrl);
            //Forma 1 de recuperar valor
            //Task.Run(async () =>
            //{
            //   string result = await httpClient.GetStringAsync(ApiUrl);
            //});
            //Forma 2 de recuperar valor
            string result = task.Result;
            StarsWarsPeople people = JsonConvert.DeserializeObject<StarsWarsPeople>(result);
            //Convertir List<Person> en nuestro List<Player>
            //var players = new List<Player>();
            //foreach(var person in people.results)
            //{
            //    players.Add(new Player {
            //        Id = ++Game.LastId,
            //        Name = person.name,
            //        Gender = person.gender == "male" ? Gender.Male : Gender.Female,
            //        Lives = Game.DefaultLives,
            //        Power = Game.DefaultPower

            //    });
            //}
            //return players;

            // Metodo con Linq
            var players = people.results.Select(person => new Player 
                {
                   Id = ++Game.LastId,
                   Name = person.name,
                   Gender = person.gender == "male" ? Gender.Male : Gender.Female,
                   Lives = Game.DefaultLives,
                   Power = Game.DefaultPower

                });
            return players.ToList();



        }
    }
    class CustomPlayerService : IPlayerService
    {
        public List<Player> GetPlayers()
        {
            return new List<Player>
            {

                new Player
                {
                    Id = ++Game.LastId,
                    Name = "Gaspar",
                    Gender = Gender.Male,
                    Lives = Game.DefaultLives,
                    Power = Game.DefaultPower
                },
                new Player
                {
                    Id =++Game.LastId,
                    Name = "Alex",
                    Gender = Gender.Male,
                    Lives = Game.DefaultLives,
                    Power = Game.DefaultPower
                },
                new Player
                {
                    Id = ++Game.LastId,
                    Name = "Carolina",
                    Gender = Gender.Female,
                    Lives = Game.DefaultLives,
                    Power = Game.DefaultPower
                },
                new Player
                {
                    Id = ++Game.LastId,
                    Name = "Alberto",
                    Gender = Gender.Male,
                    Lives = Game.DefaultLives,
                    Power = Game.DefaultPower
                },
            };
        }
    }
}
