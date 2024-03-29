﻿using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using RainbowApp.Application.Interfaces;
using System.Linq;

namespace RainbowApp.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IConfiguration _configuration;

        public TaskRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //public async Task<int> Add(Core.Entities.Task entity)
        //{
        //    entity.DateCreated = DateTime.Now;
        //    var sql = "INSERT INTO Tasks (Name, Description, Status, DueDate, DateCreated) Values (@Name, @Description, @Status, @DueDate, @DateCreated);";
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var affectedRows = await connection.ExecuteAsync(sql, entity);
        //        return affectedRows;
        //    }
        //}

        //public async Task<int> Delete(int id)
        //{
        //    var sql = "DELETE FROM Tasks WHERE Id = @Id;";
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
        //        return affectedRows;
        //    }
        //}

        public async Task<Core.Entities.ServiceProvider> Get(string mgtNo)
        {
            var sql = "SELECT * FROM tblServiceProvider WHERE MgtNo = @MgtNo;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Core.Entities.ServiceProvider>(sql, new { MgtNo = mgtNo });
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Core.Entities.ServiceProvider>> GetAll()
        {
            var sql = "SELECT * FROM tblServiceProvider;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Core.Entities.ServiceProvider>(sql);
                return result;
            }
        }

        //public async Task<int> Update(Core.Entities.Task entity)
        //{
        //    entity.DateModified = DateTime.Now;
        //    var sql = "UPDATE Tasks SET Name = @Name, Description = @Description, Status = @Status, DueDate = @DueDate, DateModified = @DateModified WHERE Id = @Id;";
        //    using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
        //    {
        //        connection.Open();
        //        var affectedRows = await connection.ExecuteAsync(sql, entity);
        //        return affectedRows;
        //    }
        //}
    }
}