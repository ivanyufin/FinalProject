using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Entities;
using Trial_Lesson.DAL.Interfaces;

namespace Trial_Lesson.DAL
{
    public class dbTrial_LessonDAO : ITrial_LessonDAO
    {
        private static SqlConnection _connection = Objects.Connection;
        public bool Add(FinalProject.Entities.TrialLesson trialLesson)
        {
            var query = "INSERT INTO [dbo].[trial_lesson](Name, Phone, Email) " +
                    "VALUES(@Name, @Phone, @Email)";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Name", trialLesson.Name);
            command.Parameters.AddWithValue("@Phone", trialLesson.Phone);
            command.Parameters.AddWithValue("@Email", trialLesson.Email);

            var result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public IEnumerable<TrialLesson> GetAll()
        {
            var query = "SELECT Id, Name, Phone, Email FROM [trial_lesson]";

            var command = new SqlCommand(query, _connection);


            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                yield return new TrialLesson()
                {
                    ID = (int)reader["Id"],
                    Name = reader["Name"] as string,
                    Phone = reader["Phone"] as string,
                    Email = reader["Email"] as string
                };
            }
            reader.Close();
        }
    }
}
