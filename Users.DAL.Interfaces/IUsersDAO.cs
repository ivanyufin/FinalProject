﻿using System.Collections.Generic;
using FinalProject.Entities;

namespace Users.DAL.Interfaces
{
    public interface IUsersDAO
    {
        bool Add(User user);

        IEnumerable<User> GetAll();

        bool DeleteByID(int ID);

        User GetUserByID(int ID);

        bool Update(User user, string lastName, string firstName, string patronymic, string email, string phone, string password);

        bool SignIN(string login, string password);

        int GetID(string email);
    }
}
