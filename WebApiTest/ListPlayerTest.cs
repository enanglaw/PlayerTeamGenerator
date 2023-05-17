// /////////////////////////////////////////////////////////////////////////////
// TESTING AREA
// THIS IS AN AREA WHERE YOU CAN TEST YOUR WORK AND WRITE YOUR TESTS
// /////////////////////////////////////////////////////////////////////////////

using System.Threading.Tasks;

namespace WebApiTest
{
    public class ListPlayerTest : BaseTestWrapper
    {
        public override async Task Setup()
        {
            await base.Setup();
        }

        [Test]
        public async Task TestSample()
        {

            var response = await client.GetAsync("/api/player");
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
