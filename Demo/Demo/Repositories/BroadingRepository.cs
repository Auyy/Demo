using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Demo.Models;
using MySqlConnector;

namespace Demo.Repositories
{
    public class BroadingRepository
    {
        private string connectionString = "Server=localhost;Port=3306;Database=Movies;Uid=root;Pwd=;";

        public BroadingRepository()
        {

        }

        public IEnumerable<Broading> GetAll()
        {
            var models = new List<Broading>();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Broading>("SELECT * FROM Broading").ToList();
            }
            return models;
        } // run ทุกอย่างออกมา

        public Broading GetById(int id)
        {
            var models = new Broading();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Broading>("SELECT * FROM Broading WHERE Id = @Id", new
                {
                    Id = id
                }).FirstOrDefault();
            }
            return models;
        } // run เลือกดูอย่าง detail 


        public int Add(Broading broading)
        {
            var response = 0;
            var sqlCommand = string.Format(@"INSERT INTO Broading
                                                       (FK_MovieId
                                                       ,FK_TheaterId)
                                                 VALUES
                                                       (@FK_MovieId
                                                       ,@FK_TheaterId)");
            using (var db = new MySqlConnection(connectionString))
            {
                response = db.Execute(sqlCommand, new
                {
                    FK_MovieId = broading.FK_MovieId,
                    FK_TheaterId = broading.FK_TheaterId
                });
            }
            return response;
        } // สร้างเพิ่มขึ้นมา

        public int Update(Broading broading, int id)
        {
            var models = 0;
            var sqlCommand = string.Format(@"UPDATE Broading SET FK_MovieId=@FK_MovieId ,FK_TheaterId=@FK_TheaterId WHERE Id = @Id");

            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Execute(sqlCommand, new
                {
                    FK_MovieId = broading.FK_MovieId,
                    FK_TheaterId = broading.FK_TheaterId,
                    Id = id
                });
            }
            return models;
        }// แก้ไขได้

        public Broading Delete(int id)
        {
            var models = new Broading();
            using (var db = new MySqlConnection(connectionString))
            {
                models = db.Query<Broading>("DELETE FROM Broading WHERE Id = @Id", new
                {
                    Id = id
                }).FirstOrDefault();
            }
            return models;
        } // ลบข้อมูล 
    }
}
