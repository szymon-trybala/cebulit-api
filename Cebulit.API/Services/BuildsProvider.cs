using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cebulit.API.Core.Extensions;
using Cebulit.API.Models.Auth;
using Cebulit.API.Models.Products.PcParts;
using Cebulit.API.Params;
using Cebulit.API.Repositories;

namespace Cebulit.API.Services
{
    public class BuildsProvider : IBuildsProvider
    {
        private readonly IPcPartsRepository _pcPartsRepository;
        private readonly IUserRepository _userRepository;

        public BuildsProvider(IPcPartsRepository pcPartsRepository, IUserRepository userRepository)
        {
            _pcPartsRepository = pcPartsRepository;
            _userRepository = userRepository;
        }

        public async Task<List<Build>> GetTagMatched(List<string> tags)
        {
            if (tags == null || !tags.Any())
                return await _pcPartsRepository.GetRandomAsync(5);

            var withAnyTags = await _pcPartsRepository.GetWithTagsAsync(tags);
            return WithAllTags(withAnyTags, tags).OrderByTagMatches();
        }

        public async Task<List<Build>> GetFiltered(BuildsFiltersParams filters, int? userId = null)
        {
            var result = await _pcPartsRepository.GetFiltered(filters);

            if (filters.OrderBy != "tagMatch" || !userId.HasValue) return result;
            var userTagMatches = await _userRepository.GetTagMatchesAsync(userId.Value);
            return OrderByTagMatches(result, userTagMatches);
        }

        private List<Build> OrderByTagMatches(List<Build> builds, List<User.UserTagMatch> tagMatches)
        {
            if (!tagMatches.Any()) return builds;

            var withCalculatedMatches = builds.Select(x => new
                {
                    build = x,
                    tagsMatch = CalculateBuildUserTagMatch(x, tagMatches)
                })
                .OrderByDescending(x => x.tagsMatch);

            return withCalculatedMatches.Select(x => x.build).ToList();
        }

        private double CalculateBuildUserTagMatch(Build build, List<User.UserTagMatch> userTagMatches)
        {
            double sum = 0f;

            foreach (var userMatch in userTagMatches)
            {
                var buildMatch = build.BuildTagMatches.SingleOrDefault(x => x.Tag.Id == userMatch.Tag.Id);
                if (buildMatch != null)
                {
                    sum += userMatch.MatchLevel * buildMatch.MatchLevel;
                }
            }

            return sum;
        }

        private List<Build> WithAllTags(List<Build> builds, List<string> tags)
        {
            return builds.Where(x => BuildContainsAllTags(x, tags)).ToList();
        }

        private bool BuildContainsAllTags(Build build, List<string> tags)
        {
            return tags.All(tag => BuildContainsTag(build, tag));
        }

        private bool BuildContainsTag(Build build, string tag)
        {
            return build.BuildTagMatches.Any(tagMatch => tagMatch.Tag.Name == tag);
        }
    }
}