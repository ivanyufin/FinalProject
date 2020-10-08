using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FinalProject.Entities;
using Users_TimeLesson.DAL.Interfaces;

namespace Users_TimeLesson.DAL
{
    public class dbUsers_TimeLessonDAO : IUsers_TimeLessonDAO
    {
        private static SqlConnection _connection = Objects.Connection;
        public bool ExistSubscribe(DateTime timeLesson, int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetSubscribeUsers(DateTime timeLesson)
        {
            string timeLessonSQL = timeLesson.Year + "-" + timeLesson.Month + "-" + timeLesson.Day + " " + timeLesson.Hour + ":" + timeLesson.Minute + ":00.00";
            var query = "SELECT User_ID FROM [Users_TimeLesson] WHERE Time_Lesson = \'" + timeLessonSQL + "\'";

            var command = new SqlCommand(query, _connection);

            var reader = command.ExecuteReader();

            List<User> usersID = new List<User>();

            while (reader.Read())
            {
                usersID.Add(new User() { ID = (int)reader["User_ID"] });
            }
            reader.Close();
            return usersID;
        }

        public bool SubscribeUser(DateTime timeLesson, int ID)
        {
            var query = "INSERT INTO dbo.[Users_TimeLesson](User_ID, Time_Lesson) " +
                    "VALUES(@User_ID, @Time_Lesson)";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@User_ID", ID);
            command.Parameters.AddWithValue("@Time_Lesson", timeLesson);
            var result = command.ExecuteNonQuery();
            if(result != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UnscribeAll(DateTime timeLesson)
        {
            string timeLessonSQL = timeLesson.Year + "-" + timeLesson.Month + "-" + timeLesson.Day + " " + timeLesson.Hour + ":" + timeLesson.Minute + ":00.00";
            var query = "DELETE FROM [Users_TimeLesson] WHERE Time_Lesson = \'" + timeLessonSQL + "\'";
            var command = new SqlCommand(query, _connection);
            var result = command.ExecuteNonQuery();
            return true;
        }

        public bool UnscribeUser(DateTime timeLesson, int ID)
        {
            string timeLessonSQL = timeLesson.Year + "-" + timeLesson.Month + "-" + timeLesson.Day + " " + timeLesson.Hour + ":" + timeLesson.Minute + ":00.00";
            var query = "DELETE FROM [Users_TimeLesson] WHERE User_ID = \'" + ID + "\' AND Time_Lesson = " + "\'" + timeLessonSQL + "\'";
            var command = new SqlCommand(query, _connection);
            var result = command.ExecuteNonQuery();
            if (result != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
