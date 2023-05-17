// /////////////////////////////////////////////////////////////////////////////
// TESTING AREA
// THIS IS AN AREA WHERE YOU CAN TEST YOUR WORK AND WRITE YOUR TESTS
// /////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebApiTest.Base;

namespace WebApiTest
{
    public class ProcessTeamTest : BaseTestWrapper
    {

        [Test]
        public async Task TestSample()
        {
            List<TeamProcessViewModel> requestData = new List<TeamProcessViewModel>()
            {
                new TeamProcessViewModel()
                {
                    Position = "defender",
                    MainSkill = "speed",
                    NumberOfPlayers = "1"
                }
            };

            var response = await client.PostAsJsonAsync("/api/team/process", requestData);
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
