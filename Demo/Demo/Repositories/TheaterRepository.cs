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

        public int Update(Theater theater, int id)
        {
            var models = 0;
            var sqlCommand = string.Format(@"UPDATE Theater SET Room=@Room ,IsActive=@IsActive WHERE Id = @Id");

            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Execute(sqlCommand, new
                {
                    Room = theater.Room,
                    IsActive = theater.IsActive,
                    Id = id
                });
            }
            return models;
        }// แก้ไขได้


        public Theater Delete(int id)
        {
            var models = new Theater();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Theater>("DELETE FROM Theater WHERE Id = @Id", new
                {
                    Id = id
                }).FirstOrDefault();
            }
            return models;
        } // ลบข้อมูล 
    }
}
