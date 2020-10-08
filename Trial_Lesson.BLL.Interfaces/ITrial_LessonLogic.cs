using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Entities;

namespace Trial_Lesson.BLL.Interfaces
{
    public interface ITrial_LessonLogic
    {
        bool Add(TrialLesson trialLesson);

        IEnumerable<TrialLesson> GetAll();
    }
}
