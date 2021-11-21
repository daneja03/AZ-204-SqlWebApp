using AZ_204_SqlWebApp.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AZ_204_SqlWebApp.Services
{
    public class CourseService
    {
        private readonly IConfiguration _configuration;

        public CourseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Course> GetCourses()
        {
            var courses = new List<Course>();



            // Connection String from Azure Sql Database

            var connectionString = _configuration.GetConnectionString("SqlConnection");

            // Create a connection object
            using (var connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object
                var sqlCommand = connection.CreateCommand();
                sqlCommand.CommandText = @"Select * from Course";
                sqlCommand.CommandType = System.Data.CommandType.Text;

                // Execute command and read results
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    courses.Add(new Course()
                    {
                        CourseId = reader.GetInt32(0),
                        CourseName = reader.GetString(1),
                        CourseRating = reader.GetDecimal(2)
                    });
                }

                // Close the connection
                connection.Close();
            }

            return courses;

        }
    }
}
