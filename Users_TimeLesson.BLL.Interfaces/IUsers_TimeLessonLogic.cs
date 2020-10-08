using System;
using System.Collections.Generic;
using FinalProject.Entities;

namespace Users_TimeLesson.BLL.Interfaces
{
    public interface IUsers_TimeLessonLogic
    {
        bool SubscribeUser(DateTime timeLesson, int ID);

        bool UnscribeUser(DateTime timeLesson, int ID);

        IEnumerable<User> GetSubscribeUsers(DateTime timeLesson);

        bool ExistSubscribe(DateTime timeLesson, int ID);

        bool UnscribeAll(DateTime timeLesson);
    }
}
