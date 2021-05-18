using System;
namespace Demo.Models
{
    public class Broading
    {
        public int Id { get; set; }
        public int FK_MovieId { get; set; }
        public int FK_TheaterId { get; set; }
    }
}
