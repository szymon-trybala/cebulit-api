using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Cebulit.API.Core.Models;
using Cebulit.API.Models.Auth;
using Cebulit.API.Models.Products.PcParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Cebulit.API.Core.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static Task<List<Build>> IncludePartsAndToListAsync(this IQueryable<Build> builds)
        {
            return builds
                .Include(x => x.Processor)
                .Include(x => x.Motherboard)
                .Include(x => x.Memory)
                .Include(x => x.GraphicsCard)
                .Include(x => x.Storage)
                .Include(x => x.PowerSupply)
                .Include(x => x.Case)
                .ToListAsync();
        }
        
        public static Task<List<Build>> IncludeEverythingAndToListAsync(this IQueryable<Build> builds)
        {
            return builds
                .Include(x => x.Processor)
                .Include(x => x.Motherboard)
                .Include(x => x.Memory)
                .Include(x => x.GraphicsCard)
                .Include(x => x.Storage)
                .Include(x => x.PowerSupply)
                .Include(x => x.Case)
                .Include(x => x.BuildTagMatches)
                .ThenInclude(tagMatch => tagMatch.Tag)
                .ToListAsync();
        }

        public static IIncludableQueryable<User, Tag> ThenIncludeEverything(this IIncludableQueryable<User, ICollection<User.UserBuildOrder>> userBuilds)
        {
            return userBuilds
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.Processor)
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.Motherboard)
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.Memory)
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.GraphicsCard)
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.Storage)
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.PowerSupply)
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.Case)
                .Include(x => x.UserBuildOrders)
                .ThenInclude(x => x.Build)
                .ThenInclude(x => x.BuildTagMatches)
                .ThenInclude(x => x.Tag);
        }
        
        public static IIncludableQueryable<User, UserBuild> ThenIncludeEverything(this IIncludableQueryable<User, ICollection<User.UserGeneratedBuildOrder>> userBuilds)
        {
            return userBuilds
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild)
                .ThenInclude(x => x.Processor)
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild)
                .ThenInclude(x => x.Motherboard)
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild)
                .ThenInclude(x => x.Memory)
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild)
                .ThenInclude(x => x.GraphicsCard)
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild)
                .ThenInclude(x => x.Storage)
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild)
                .ThenInclude(x => x.PowerSupply)
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild)
                .ThenInclude(x => x.Case)
                .Include(x => x.UserGeneratedBuildOrders)
                .ThenInclude(x => x.UserGeneratedBuild);
        }

        public static async Task<List<User.UserTagMatch>> GetUserTagMatchesById(this IQueryable<User> users, int userId)
        {
            var user = await users
                .Include(x => x.UserTagMatches)
                .ThenInclude(x => x.Tag)
                .SingleAsync(x => x.Id == userId);
            return user.UserTagMatches.ToList();
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, bool condition, Expression<Func<T, bool>> whereClause)
        {
            return condition ? query.Where(whereClause) : query;
        }
        
        public static IQueryable<Build> OrderBuilds(this IQueryable<Build> query, string orderBy)
        {
            return orderBy switch
            {
                "name" => query.OrderBy(x => x.Name),
                "nameDescending" => query.OrderByDescending(x => x.Name),
                "price" => query.OrderBy(x => x.Price),
                "priceDescending" => query.OrderByDescending(x => x.Price),
                _ => query.OrderBy(x => x.Name)
            };
        }
        
        public static Dictionary<TKey, List<TElement>> GroupToDictionary<TKey, TElement>(this 
            IEnumerable<IGrouping<TKey, TElement>> group)
        {
            return group.ToDictionary(g => g.Key, e => e.ToList());
        }
    }
}