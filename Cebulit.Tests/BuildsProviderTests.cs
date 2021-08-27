using System.Collections.Generic;
using System.Threading.Tasks;
using Cebulit.Tests.RepositoriesImplementations;
using NUnit.Framework;

namespace Cebulit.Tests
{
    public class BuildsProviderTests
    {
        private MockUsersRepository _mockUsersRepository;
        private MockPcPartsRepository _mockPcPartsRepository;
        
        [SetUp]
        public void Setup()
        {
            _mockUsersRepository = new MockUsersRepository();
            _mockPcPartsRepository = new MockPcPartsRepository();
        }

        [Test]
        public async Task TestGetTagMatchedBuilds()
        {
            var buildsProvider = new API.Services.BuildsProvider(_mockPcPartsRepository, _mockUsersRepository);
            var builds = await buildsProvider.GetTagMatched(new List<string> {"gaming", "silence"});
            Assert.That(builds.Count, Is.EqualTo(1));
            Assert.That(builds[0].Name, Is.EqualTo("Test2"));
        }
    }
}