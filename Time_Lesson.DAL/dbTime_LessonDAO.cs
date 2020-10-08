using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FinalProject.Entities;
using Time_Lesson.DAL.Interfaces;

namespace Time_Lesson.DAL
{
    public class dbTime_LessonDAO : ITime_LessonDAO
    {
        private static SqlConnection _connection = Objects.Connection;
        public int Add(DayLesson dayLesson, DateTime timeLesson)
        {
            string number_dayStr = dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "_" + timeLesson.Hour + "_" + timeLesson.Minute;
            var query = "CREATE TABLE [dbo].[" + number_dayStr + "]" +
            "(" +

                "[Id]          INT      NOT NULL IDENTITY," +
                "[User_ID] INT NOT NULL," +
                "PRIMARY KEY CLUSTERED ([Id] ASC)" +
            ")";
            var command = new SqlCommand(query, _connection);
            command.ExecuteNonQuery();
            return 0;
        }

        public bool Delete(DayLesson dayLesson, DateTime timeLesson)
        {
            string number_dayStr = dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "_" + timeLesson.Hour + "_" + timeLesson.Minute;
            var query = "DROP TABLE [dbo].[" + number_dayStr + "]";
            var command = new SqlCommand(query, _connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool ExistSubscribe(DayLesson dayLesson, DateTime timeLesson, int ID)
        {
            //string timeLessonSQL = dayLesson.Day_Lesson.Year + "-" + dayLesson.Day_Lesson.Month + "-" + dayLesson.Day_Lesson.Day + " " + timeLesson.Hour + ":" + timeLesson.Minute + ":00.00";
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "_" + timeLesson.Hour + "_" + timeLesson.Minute + "]";
            var query = "SELECT * FROM " + dayLessonStr + " WHERE User_ID = \'" + ID + "\'";

            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public bool ExistTimeTable(DayLesson dayLesson, DateTime timeLesson)
        {
            string number_dayStr = dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "_" + timeLesson.Hour + "_" + timeLesson.Minute;
            var query = "SELECT * FROM Tutor.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = \'" + number_dayStr + "\'";

            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public IEnumerable<int> GetSubscribeUsers(DayLesson dayLesson, DateTime timeLesson)
        {
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "_" + timeLesson.Hour + "_" + timeLesson.Minute + "]";
            var query = "SELECT User_ID FROM " + dayLessonStr;

            var command = new SqlCommand(query, _connection);
            SqlDataReader reader = null;
            reader = command.ExecuteReader();
            List<int> ids = new List<int>();

            if (reader != null)
            {
                while (reader.Read())
                {
                    int id = (int)reader["User_ID"];
                    ids.Add(id);
                }
                reader.Close();
            }
            return ids;
        }

        public bool SubscribeUser(DayLesson dayLesson, DateTime timeLesson, int ID)
        {
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "_" + timeLesson.Hour + "_" + timeLesson.Minute + "]";

            var query = "INSERT INTO dbo." + dayLessonStr + "(User_ID) " +
                    "VALUES(@User_ID)";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@User_ID", ID);
            var result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool UnscribeUser(DayLesson dayLesson, DateTime timeLesson, int ID)
        {
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "_" + timeLesson.Hour + "_" + timeLesson.Minute + "]";
            var query = "DELETE FROM " + dayLessonStr + " WHERE User_ID = \'" + ID + "\'";
            var command = new SqlCommand(query, _connection);
            var result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
    }
}
