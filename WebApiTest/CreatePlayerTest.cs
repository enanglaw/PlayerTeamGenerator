// /////////////////////////////////////////////////////////////////////////////
// TESTING AREA
// THIS IS AN AREA WHERE YOU CAN TEST YOUR WORK AND WRITE YOUR TESTS
// /////////////////////////////////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApi.Entities;
using WebApi.Helpers;
using WebApiTest.Base;

namespace WebApiTest
{

    public class CreatePlayerTest : BaseTestWrapper
    {

        [Test]
        public async Task TestSample()
        {
            Player player = new()
            {
                Name = "player name",
                Position = "defender",
                PlayerSkills = new()
                {
                    new() { Skill = "attack", Value = 60 },
                    new() { Skill = "speed", Value = 80 },
                }
            };

            var response = await client.PostAsJsonAsync("/api/player", player);
            try
            {
                var responseObject = await response.Content.ReadAsStringAsync();
                Assert.That(responseObject, Is.Not.Null);
            }
            catch
            {
                Assert.Fail("Invalid response object");
            }
        }
    }
}
