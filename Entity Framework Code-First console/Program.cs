using System;
using System.Data.Entity;

namespace CodeFirstDemo
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

namespace CodeFirstDemo
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentDbContext())
            {
                // Create the database
                db.Database.CreateIfNotExists();

                // Add a student
                var student = new Student
                {
                    Name = "John Doe",
                    DateOfBirth = new DateTime(2000, 1, 1)
                };

                db.Students.Add(student);
                db.SaveChanges();

                Console.WriteLine("Student added successfully.");
            }

            Console.ReadLine();
        }
    }
}
