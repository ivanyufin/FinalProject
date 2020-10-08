using System.Collections.Generic;
using FinalProject.Entities;

namespace Table_DayLesson.BLL.Interfaces
{
    public interface ITable_DayLessonLogic
    {
        int AddDay(DayLesson dayLesson);

        bool DeleteDay(DayLesson dayLesson);

        IEnumerable<table_DayLesson> GetDaysLesson();

        bool ExistDay(DayLesson dayLesson);
    }
}
