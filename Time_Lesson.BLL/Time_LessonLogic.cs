using System;
using System.Collections.Generic;
using FinalProject.Entities;
using Time_Lesson.BLL.Interfaces;
using Time_Lesson.DAL.Interfaces;

namespace Time_Lesson.BLL
{
    public class Time_LessonLogic : ITime_LessonLogic
    {
        private readonly ITime_LessonDAO _time_LessonDAO;

        public Time_LessonLogic(ITime_LessonDAO time_LessonDAO)
        {
            _time_LessonDAO = time_LessonDAO;
            Logger.InitLogger();
        }

        public int Add(DayLesson dayLesson, DateTime timeLesson)
        {
            try
            {
                if (!ExistTimeTable(dayLesson, timeLesson))
                {
                    return _time_LessonDAO.Add(dayLesson, timeLesson);
                }
                else
                    return 0;
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return -1;
            }
        }

        public bool Delete(DayLesson dayLesson, DateTime timeLesson)
        {
            try
            {
                return _time_LessonDAO.Delete(dayLesson, timeLesson);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool ExistSubscribe(DayLesson dayLesson, DateTime timeLesson, int ID)
        {
            try
            {
                return _time_LessonDAO.ExistSubscribe(dayLesson, timeLesson, ID);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return true;
            }
        }

        public bool ExistTimeTable(DayLesson dayLesson, DateTime timeLesson)
        {
            try
            {
                return _time_LessonDAO.ExistTimeTable(dayLesson, timeLesson);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return true;
            }
        }

        public IEnumerable<int> GetSubscribeUsers(DayLesson dayLesson, DateTime timeLesson)
        {
            try
            {
                return _time_LessonDAO.GetSubscribeUsers(dayLesson, timeLesson);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return null;
            }
        }

        public bool SubscribeUser(DayLesson dayLesson, DateTime timeLesson, int ID)
        {
            try
            {
                return _time_LessonDAO.SubscribeUser(dayLesson, timeLesson, ID);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool UnscribeUser(DayLesson dayLesson, DateTime timeLesson, int ID)
        {
            try
            {
                return _time_LessonDAO.UnscribeUser(dayLesson, timeLesson, ID);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }
    }
}
