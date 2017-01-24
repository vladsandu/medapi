using System;

namespace DataAccess.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public int Cnp { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeceaseDate { get; set; }
    }
}