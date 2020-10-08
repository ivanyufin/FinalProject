using Day_Lesson.BLL;
using Day_Lesson.BLL.Interfaces;
using Day_Lesson.DAL;
using Day_Lesson.DAL.Interfaces;
using Table_DayLesson.BLL;
using Table_DayLesson.BLL.Interfaces;
using Table_DayLesson.DAL;
using Table_DayLesson.DAL.Interfaces;
using Time_Lesson.BLL;
using Time_Lesson.BLL.Interfaces;
using Time_Lesson.DAL;
using Time_Lesson.DAL.Interfaces;
using Trial_Lesson.BLL;
using Trial_Lesson.BLL.Interfaces;
using Trial_Lesson.DAL;
using Trial_Lesson.DAL.Interfaces;
using Users.BLL;
using Users.BLL.Interfaces;
using Users.DAL;
using Users.DAL.Interfaces;
using Users_TimeLesson.BLL;
using Users_TimeLesson.BLL.Interfaces;
using Users_TimeLesson.DAL;
using Users_TimeLesson.DAL.Interfaces;

namespace FinalProject.Common
{
    public static class DependencyResolver
    {
        private static readonly IUsersLogic _usersLogic;
        private static readonly IUsersDAO _usersDAO;
        private static readonly IDay_LessonLogic _dayLessonLogic;
        private static readonly IDay_LessonDAO _day_LessonDAO;
        private static readonly ITime_LessonLogic _time_LessonLogic;
        private static readonly ITime_LessonDAO _time_LessonDAO;
        private static readonly IUsers_TimeLessonLogic _users_TimeLessonLogic;
        private static readonly IUsers_TimeLessonDAO _users_TimeLessonDAO;
        private static readonly ITable_DayLessonLogic _table_DayLessonLogic;
        private static readonly ITable_DayLessonDAO _table_DayLessonDAO;
        private static readonly ITrial_LessonLogic _trial_LessonLogic;
        private static readonly ITrial_LessonDAO _trial_LessonDAO;

        public static IUsersLogic UsersLogic => _usersLogic;

        public static IUsersDAO UsersDAO => _usersDAO;

        public static IDay_LessonLogic Day_LessonLogic => _dayLessonLogic;

        public static IDay_LessonDAO Day_LessonDAO => _day_LessonDAO;

        public static ITime_LessonLogic Time_LessonLogic => _time_LessonLogic;

        public static ITime_LessonDAO Time_LessonDAO => _time_LessonDAO;

        public static IUsers_TimeLessonLogic Users_TimeLessonLogic => _users_TimeLessonLogic;

        public static IUsers_TimeLessonDAO Users_TimeLessonDAO => _users_TimeLessonDAO;

        public static ITable_DayLessonLogic Table_DayLessonLogic => _table_DayLessonLogic;

        public static ITable_DayLessonDAO Table_DayLessonDAO => _table_DayLessonDAO;

        public static ITrial_LessonLogic Trial_LessonLogic => _trial_LessonLogic;

        public static ITrial_LessonDAO Trial_LessonDAO => _trial_LessonDAO;

        static DependencyResolver()
        {
            _usersDAO = new dbUsersDAO();
            _usersLogic = new UsersLogic(_usersDAO);
            _day_LessonDAO = new dbDay_LessonDAO();
            _dayLessonLogic = new Day_LessonLogic(_day_LessonDAO);
            _time_LessonDAO = new dbTime_LessonDAO();
            _time_LessonLogic = new Time_LessonLogic(_time_LessonDAO);
            _users_TimeLessonDAO = new dbUsers_TimeLessonDAO();
            _users_TimeLessonLogic = new Users_TimeLessonLogic(_users_TimeLessonDAO);
            _table_DayLessonDAO = new dbTable_DayLessonDAO();
            _table_DayLessonLogic = new Table_DayLessonLogic(_table_DayLessonDAO);
            _trial_LessonDAO = new dbTrial_LessonDAO();
            _trial_LessonLogic = new Trial_LessonLogic(_trial_LessonDAO);
        }
    }
}
