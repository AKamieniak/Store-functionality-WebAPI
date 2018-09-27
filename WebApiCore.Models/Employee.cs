using System;

namespace WebApiCore.Models
{
    public class Employee
    {
        //--shop employee model parameters--
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PositionId { get; set; }
        public int Id { get; set; }
        public int ShopId { get; set; }
    }
}
