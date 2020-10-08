using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Entities;

namespace Trial_Lesson.DAL.Interfaces
{
    public interface ITrial_LessonDAO
    {
        bool Add(TrialLesson trialLesson);

        IEnumerable<TrialLesson> GetAll();
    }
}
