using System.Collections.Generic;
using Cebulit.API.Core.Models;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.Tests.RepositoriesImplementations
{
    public class MockData
    {
        public List<Build> MockBuilds = new List<Build>()
        {
            new Build
            {
                Id = 1,
                Name = "Test1",
                BuildTagMatches = new List<Build.BuildTagMatch>()
                {
                    new Build.BuildTagMatch()
                    {
                        Tag = new Tag()
                        {
                            Id = 1,
                            Name = "gaming"
                        },
                        MatchLevel = 1.5
                    },
                    new Build.BuildTagMatch()
                    {
                        Tag = new Tag()
                        {
                            Id = 2,
                            Name = "home"
                        },
                        MatchLevel = 1.4
                    },
                    new Build.BuildTagMatch()
                    {
                        Tag = new Tag()
                        {
                            Id = 2,
                            Name = "photoshop"
                        },
                        MatchLevel = 0.8
                    }
                }
            },
            new Build
            {
                Id = 2,
                Name = "Test2",
                BuildTagMatches = new List<Build.BuildTagMatch>()
                {
                    new Build.BuildTagMatch()
                    {
                        Tag = new Tag()
                        {
                            Id = 1,
                            Name = "gaming"
                        },
                        MatchLevel = 0.5
                    },
                    new Build.BuildTagMatch()
                    {
                        Tag = new Tag()
                        {
                            Id = 4,
                            Name = "home office"
                        },
                        MatchLevel = 2.0
                    },
                    new Build.BuildTagMatch()
                    {
                        Tag = new Tag()
                        {
                            Id = 5,
                            Name = "silence"
                        },
                        MatchLevel = 1.8
                    }
                }
            }
        };
        
    }
}