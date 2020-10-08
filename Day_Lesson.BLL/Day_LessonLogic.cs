using System;
using System.Collections.Generic;
using Day_Lesson.BLL.Interfaces;
using Day_Lesson.DAL.Interfaces;
using FinalProject.Entities;

namespace Day_Lesson.BLL
{
    public class Day_LessonLogic : IDay_LessonLogic
    {
        private readonly IDay_LessonDAO _day_LessonDAO;

        public Day_LessonLogic(IDay_LessonDAO day_LessonDAO)
        {
            _day_LessonDAO = day_LessonDAO;
            Logger.InitLogger();
        }

        public bool Add(DayLesson number_day)
        {
            try
            {
                return _day_LessonDAO.Add(number_day);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool DeleteDay(DayLesson dayLesson)
        {
            try
            {
                return _day_LessonDAO.DeleteDay(dayLesson);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool DeleteTime(DayLesson dayLesson, DateTime timeLesson)
        {
            try
            {
                _day_LessonDAO.DeleteTime(dayLesson, timeLesson);
                if (EmptyDay(dayLesson))
                    DeleteDay(dayLesson);
                return true;
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool EmptyDay(DayLesson dayLesson)
        {
            try
            {
                return _day_LessonDAO.EmptyDay(dayLesson);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool ExistDay(DayLesson dayLesson)
        {
            try
            {
                return _day_LessonDAO.ExistDay(dayLesson);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool ExistTime(DayLesson dayLesson, DateTime timeLesson)
        {
            try
            {
                return _day_LessonDAO.ExistTime(dayLesson, timeLesson);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public IEnumerable<DateTime> GetTimeLesson(DayLesson dayLesson)
        {
            try
            {
                if (ExistDay(dayLesson))
                    return _day_LessonDAO.GetTimeLesson(dayLesson);
                else
                    return null;
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return null;
            }
        }

        public int SetTimeLesson(DayLesson dayLesson, DateTime timeLesson)
        {
            try
            {
                if (ExistDay(dayLesson))
                {
                    if (!ExistTime(dayLesson, timeLesson))
                        return _day_LessonDAO.SetTimeLesson(dayLesson, timeLesson);
                    else
                        return 0;
                }
                else
                {
                    Add(dayLesson);
                    return _day_LessonDAO.SetTimeLesson(dayLesson, timeLesson);
                }
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return -1;
            }
        }
    }
}
