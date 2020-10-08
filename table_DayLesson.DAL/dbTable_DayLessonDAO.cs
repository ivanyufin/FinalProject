using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FinalProject.Entities;
using Table_DayLesson.DAL.Interfaces;

namespace Table_DayLesson.DAL
{
    public class dbTable_DayLessonDAO : ITable_DayLessonDAO
    {
        private static SqlConnection _connection = Objects.Connection;
        public int AddDay(DayLesson dayLesson)
        {
            var query = "INSERT INTO dbo.[table_DayLesson](Day_Lesson) " +
                    "VALUES(@Day_Lesson)";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Day_Lesson", dayLesson.Day_Lesson);
            var result = command.ExecuteNonQuery();
            return result;
        }

        public bool DeleteDay(DayLesson dayLesson)
        {
            string timeLessonSQL = dayLesson.Day_Lesson.Year + "-" + dayLesson.Day_Lesson.Month + "-" + dayLesson.Day_Lesson.Day + " " + "00:00:00.00";

            var query = "DELETE FROM [table_DayLesson] WHERE Day_Lesson = \'" + timeLessonSQL + "\'";
            var command = new SqlCommand(query, _connection);
            command.ExecuteNonQuery();
            return true;
        }

        public bool ExistDay(DayLesson dayLesson)
        {
            string dayLessonSQL = dayLesson.Day_Lesson.Year + "-" + dayLesson.Day_Lesson.Month + "-" + dayLesson.Day_Lesson.Day;
            var query = "SELECT * FROM [table_DayLesson] WHERE Day_Lesson = \'" + dayLessonSQL + "\'";

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

        public IEnumerable<table_DayLesson> GetDaysLesson()
        {
            var query = "SELECT Id, Day_Lesson FROM [table_DayLesson]";

            var command = new SqlCommand(query, _connection);

            var reader = command.ExecuteReader();

            List<table_DayLesson> daysLesson = new List<table_DayLesson>();

            while (reader.Read())
            {
                daysLesson.Add(new table_DayLesson() { ID = (int)reader["Id"], DayLesson = (DateTime)reader["Day_Lesson"] });
            }
            reader.Close();
            return daysLesson;
        }
    }
}
