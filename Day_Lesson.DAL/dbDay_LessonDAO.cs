using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Day_Lesson.DAL.Interfaces;
using FinalProject.Entities;

namespace Day_Lesson.DAL
{
    public class dbDay_LessonDAO : IDay_LessonDAO
    {
        private static SqlConnection _connection = Objects.Connection;
        /// <summary>
        /// Создает отдельную таблицу для указанного дня
        /// </summary>
        /// <param name="number_day">День для создания таблицы</param>
        public bool Add(DayLesson number_day)
        {
            string number_dayStr = number_day.Day_Lesson.Day + "_" + number_day.Day_Lesson.Month + "_" + number_day.Day_Lesson.Year;
            var query = "CREATE TABLE [dbo].[" + number_dayStr + "]"+
            "(" +

                "[Id]          INT      NOT NULL IDENTITY," +
                "[Time_Lesson] DATETIME NOT NULL," +
                "PRIMARY KEY CLUSTERED ([Id] ASC)" +
            ")";
            var command = new SqlCommand(query, _connection);
            var result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool DeleteDay(DayLesson dayLesson)
        {
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "]";
            string timeLessonSQL = dayLesson.Day_Lesson.Year + "-" + dayLesson.Day_Lesson.Month + "-" + dayLesson.Day_Lesson.Day + " " + "00:00:00.00";
            var query = "DROP TABLE [dbo]." + dayLessonStr;
            var command = new SqlCommand(query, _connection);

            var result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool DeleteTime(DayLesson dayLesson, DateTime timeLesson)
        {
            string timeLessonSQL = dayLesson.Day_Lesson.Year + "-" + dayLesson.Day_Lesson.Month + "-" + dayLesson.Day_Lesson.Day + " " + timeLesson.Hour + ":" + timeLesson.Minute + ":00.00";
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "]";
            var query = "DELETE FROM " + dayLessonStr + " WHERE Time_Lesson = \'" + timeLessonSQL + "\'";
            var command = new SqlCommand(query, _connection);

            var result = command.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool EmptyDay(DayLesson dayLesson)
        {
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "]";
            var query = "SELECT * FROM " + dayLessonStr;

            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                return true;
            }
        }

        public bool ExistDay(DayLesson dayLesson)
        {
            string dayLessonStr = "\'" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "\'";
            var query = "SELECT * FROM Tutor.INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = " + dayLessonStr;

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

        public bool ExistTime(DayLesson dayLesson, DateTime timeLesson)
        {
            string timeLessonSQL = dayLesson.Day_Lesson.Year + "-" + dayLesson.Day_Lesson.Month + "-" + dayLesson.Day_Lesson.Day + " " + timeLesson.Hour + ":" + timeLesson.Minute + ":00.00";
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "]";
            var query = "SELECT * FROM " + dayLessonStr + " WHERE Time_Lesson = \'" + timeLessonSQL + "\'";

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

        /// <summary>
        /// Получает все записи времени на указанный день
        /// </summary>
        /// <param name="dayLesson">День, у которого необходимо получить все записи</param>
        /// <returns></returns>
        public IEnumerable<DateTime> GetTimeLesson(DayLesson dayLesson)
        {
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "]";
            var query = "SELECT Time_Lesson FROM " + dayLessonStr;

            var command = new SqlCommand(query, _connection);

            var reader = command.ExecuteReader();

            List<DateTime> timeLesson = new List<DateTime>();

            while (reader.Read())
            {
                timeLesson.Add((DateTime)reader["Time_Lesson"]);
            }
            reader.Close();
            return timeLesson;
        }

        /// <summary>
        /// Добавляет время для записи на указанный день
        /// </summary>
        /// <param name="dayLesson">День, в который необходимо добавить запись</param>
        /// <param name="timeLesson">Время, на которое необходимо добавить запись</param>
        public int SetTimeLesson(DayLesson dayLesson, DateTime timeLesson)
        {
            string dayLessonStr = "[" + dayLesson.Day_Lesson.Day + "_" + dayLesson.Day_Lesson.Month + "_" + dayLesson.Day_Lesson.Year + "]";

            var query = "INSERT INTO dbo." + dayLessonStr + "(Time_Lesson) " +
                    "VALUES(@Time_Lesson)";
            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("@Time_Lesson", timeLesson);
            var result = command.ExecuteNonQuery();
            return result;
        }
    }
}
