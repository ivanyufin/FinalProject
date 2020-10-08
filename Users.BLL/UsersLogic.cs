using System;
using System.Collections.Generic;
using FinalProject.Entities;
using Users.BLL.Interfaces;
using Users.DAL.Interfaces;

namespace Users.BLL
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IUsersDAO _usersDAO;

        public UsersLogic(IUsersDAO usersDAO)
        {
            _usersDAO = usersDAO;
            Logger.InitLogger();
        }

        public bool Add(User user)
        {
            try
            {
                return _usersDAO.Add(user);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool DeleteByID(int ID)
        {
            try
            {
                return _usersDAO.DeleteByID(ID);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return _usersDAO.GetAll();
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return null;
            }
        }

        public int GetID(string email)
        {
            try
            {
                return _usersDAO.GetID(email);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return -1;
            }
        }

        public User GetUserByID(int ID)
        {
            try
            {
                return _usersDAO.GetUserByID(ID);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return null;
            }
        }

        public bool SignIN(string login, string password)
        {
            try
            {
                return _usersDAO.SignIN(login, password);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public bool Update(User user, string lastName, string firstName, string patronymic, string email, string phone, string password)
        {
            try
            {
                return _usersDAO.Update(user, lastName, firstName, patronymic, email, phone, password);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }
    }
}
