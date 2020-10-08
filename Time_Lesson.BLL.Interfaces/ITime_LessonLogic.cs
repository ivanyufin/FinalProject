using System;
using System.Collections.Generic;
using FinalProject.Entities;

namespace Time_Lesson.BLL.Interfaces
{
    public interface ITime_LessonLogic
    {
        int Add(DayLesson dayLesson, DateTime timeLesson);

        bool Delete(DayLesson dayLesson, DateTime timeLesson);

        bool SubscribeUser(DayLesson dayLesson, DateTime timeLesson, int ID);

        bool UnscribeUser(DayLesson dayLesson, DateTime timeLesson, int ID);

        IEnumerable<int> GetSubscribeUsers(DayLesson dayLesson, DateTime timeLesson);

        bool ExistSubscribe(DayLesson dayLesson, DateTime timeLesson, int ID);

        bool ExistTimeTable(DayLesson dayLesson, DateTime timeLesson);
    }
}
