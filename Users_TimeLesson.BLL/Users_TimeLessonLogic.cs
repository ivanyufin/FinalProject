using System;
using System.Collections.Generic;
using FinalProject.Entities;
using Users_TimeLesson.BLL.Interfaces;
using Users_TimeLesson.DAL.Interfaces;

namespace Users_TimeLesson.BLL
{
    public class Users_TimeLessonLogic : IUsers_TimeLessonLogic
    {
        private readonly IUsers_TimeLessonDAO _users_TimeLessonDAO;

        public Users_TimeLessonLogic(IUsers_TimeLessonDAO users_TimeLessonDAO)
        {
            _users_TimeLessonDAO = users_TimeLessonDAO;
            Logger.InitLogger();
        }

        public bool ExistSubscribe(DateTime timeLesson, int ID)
        {
            try
            {
                return _users_TimeLessonDAO.ExistSubscribe(timeLesson, ID);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public IEnumerable<User> GetSubscribeUsers(DateTime timeLesson)
        {
            try
            {
                return _users_TimeLessonDAO.GetSubscribeUsers(timeLesson);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return null;
            }
        }

        public bool SubscribeUser(DateTime timeLesson, int ID)
        {
            try
            {
                return _users_TimeLessonDAO.SubscribeUser(timeLesson, ID);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool UnscribeAll(DateTime timeLesson)
        {
            try
            {
                return _users_TimeLessonDAO.UnscribeAll(timeLesson);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool UnscribeUser(DateTime timeLesson, int ID)
        {
            try
            {
                return _users_TimeLessonDAO.UnscribeUser(timeLesson, ID);
            }
            catch (Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }
    }
}
