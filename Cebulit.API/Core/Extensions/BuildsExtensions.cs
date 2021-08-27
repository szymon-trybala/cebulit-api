using System.Collections.Generic;
using System.Linq;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Core.Extensions
{
    public static class BuildsExtensions
    {
        public static List<Build> OrderByTagMatches(this ICollection<Build> builds)
        {
            return builds.OrderByDescending(x => GetTagMatchesSum(x.BuildTagMatches)).ToList();
        }

        private static double GetTagMatchesSum(ICollection<Build.BuildTagMatch> tagMatches)
        {
            return tagMatches.Sum(x => x.MatchLevel);
        }
    }
}