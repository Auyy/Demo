using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Demo.Models;
using MySqlConnector;

namespace Demo.Repositories
{
    public class TheaterRepository
    {
        private string connectionString = "Server=localhost;Port=3306;Database=Movies;Uid=root;Pwd=;";

        public TheaterRepository()
        {
        }

        public IEnumerable<Theater> GetAll()
        {
            var models = new List<Theater>();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Theater>("SELECT * FROM Theater").ToList();
            }
            return models;
        } // run ทุกอย่างออกมา

        public Theater GetById(int id)
        {
            var models = new Theater();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Theater>("SELECT * FROM Theater WHERE Id = @Id", new
                {
                    Id = id
                }).FirstOrDefault();
            }
            return models;
        } // run เลือกดูอย่าง detail

        public int Add(Theater theater)
        {
            var response = 0;
            var sqlCommand = string.Format(@"INSERT INTO Theater
                                                       (Room
                                                       ,IsActive)
                                                 VALUES
                                                       (@Room
                                                       ,@IsActive)");
            using (var db = new MySqlConnection(connectionString))
            {
                response = db.Execute(sqlCommand, new
                {
                    Room = theater.Room,
                    IsActive = theater.IsActive
                });
            }
            return response;
        } // สร้างเพิ่มขึ้นมา
    }
}
