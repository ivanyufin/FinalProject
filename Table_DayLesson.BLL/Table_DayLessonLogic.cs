using System;
using System.Collections.Generic;
using FinalProject.Entities;
using Table_DayLesson.BLL.Interfaces;
using Table_DayLesson.DAL.Interfaces;

namespace Table_DayLesson.BLL
{
    public class Table_DayLessonLogic : ITable_DayLessonLogic
    {
        private readonly ITable_DayLessonDAO _table_DayLessonDAO;

        public Table_DayLessonLogic(ITable_DayLessonDAO table_DayLessonDAO)
        {
            _table_DayLessonDAO = table_DayLessonDAO;
            Logger.InitLogger();
        }

        public int AddDay(DayLesson dayLesson)
        {
            try
            {
                if (!ExistDay(dayLesson))
                {
                    return _table_DayLessonDAO.AddDay(dayLesson);
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

        public bool DeleteDay(DayLesson dayLesson)
        {
            try
            {
                return _table_DayLessonDAO.DeleteDay(dayLesson);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool ExistDay(DayLesson dayLesson)
        {
            try
            {
                return _table_DayLessonDAO.ExistDay(dayLesson);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return true;
            }

        }

        public IEnumerable<table_DayLesson> GetDaysLesson()
        {
            try
            {
                return _table_DayLessonDAO.GetDaysLesson();
            }

            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return null;
            }
        }
    }
}
