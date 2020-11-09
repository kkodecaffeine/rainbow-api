using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using RainbowApp.Core.Entities;

namespace RainbowApp.Infrastructure.Repositories
{
    public class NotiRepository : INotiRepository
    {
        private readonly IConfiguration _configuration;

        public NotiRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<Notification>> GetNotifications(int userId, bool bIsGetOnlyUnread)
        {
            var sql = @"SELECT
   N.*
   , FU.Name AS FromUserName
   , TU.Name AS ToUserName
FROM dbo.tblNotification N
LEFT JOIN dbo.tblMember FU ON FU.UserId = N.FromUserId
LEFT JOIN dbo.tblMember TU ON TU.UserId = N.ToUserId
WHERE ToUserId = @ToUserId";

            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            connection.Open();
            var result = await connection.QueryAsync<Notification>(sql, new { ToUserId = userId });
            return result;
        }
    }
}