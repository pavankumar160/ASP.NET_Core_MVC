using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ASP.NetCodeFirst.Models
{
    public class StudentOperations
    {
        public static void Operations()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("AppDBContext");

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connString)   // <- requires Microsoft.EntityFrameworkCore.SqlServer package
                .Options;

            using (var db = new AppDbContext(options))
            {
                try
                {
                    /* inserting new record into the database

                    db.StudentTable.Add(new StudentDetails { Id = 5, Name = "Vishnu", Age = 22, Department = "CIVIL" });
                    Console.WriteLine(" Records inserted successfully!");
                    */

                    /* deleting existing record in the DB

                    //var std1 = db.StudentTable.Find(5);

                    //if(std1 != null)
                    //{
                    //    db.StudentTable.Remove(std1);
                    //    db.SaveChanges();
                    //    Console.WriteLine("Record Deleted Successfully");

                    //}

                    else Console.WriteLine("Record Not Found");
                    
                    */

                    /* updating record in the DB

                        var std2 = db.StudentTable.Find(4);

                        if(std2 != null)
                        {
                            std2.Age = 23;
                            db.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found");
                        }
                    */
                    


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
