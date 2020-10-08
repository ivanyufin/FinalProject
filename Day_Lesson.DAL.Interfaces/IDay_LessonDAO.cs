using System;
using System.Collections.Generic;
using FinalProject.Entities;

namespace Day_Lesson.DAL.Interfaces
{
    public interface IDay_LessonDAO
    {
        bool Add(DayLesson number_day);

        IEnumerable<DateTime> GetTimeLesson(DayLesson dayLesson);

        int SetTimeLesson(DayLesson dayLesson, DateTime timeLesson);

        bool ExistDay(DayLesson dayLesson);

        bool ExistTime(DayLesson dayLesson, DateTime timeLesson);

        bool DeleteTime(DayLesson dayLesson, DateTime timeLesson);

        bool EmptyDay(DayLesson dayLesson);

        bool DeleteDay(DayLesson dayLesson);
    }
}
