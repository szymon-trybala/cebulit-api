using System.Collections.Generic;
using Cebulit.API.Core.Models;
using Cebulit.API.Models.Products.PcParts;

namespace Cebulit.API.Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
        public ICollection<UserBuild> GeneratedBuilds { get; set; }
        public ICollection<UserTagMatch> UserTagMatches { get; set; }
        public ICollection<UserBuildOrder> UserBuildOrders { get; set; }
        public ICollection<UserGeneratedBuildOrder> UserGeneratedBuildOrders { get; set; }

        public class UserTagMatch : TagMatch
        {
            public int UserId { get; set; }
            public User User { get; set; }
        }

        public class UserBuildOrder : Order
        {
            public int UserId { get; set; }
            public User User { get; set; }
            public int BuildId { get; set; }
            public Build Build { get; set; }
        }
        
        public class UserGeneratedBuildOrder : Order
        {
            public int UserId { get; set; }
            public User User { get; set; }
            public int UserGeneratedBuildId { get; set; }
            public UserBuild UserGeneratedBuild { get; set; }
        }
    }
}