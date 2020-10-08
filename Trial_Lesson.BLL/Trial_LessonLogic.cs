using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalProject.Entities;
using Trial_Lesson.BLL.Interfaces;
using Trial_Lesson.DAL.Interfaces;

namespace Trial_Lesson.BLL
{
    public class Trial_LessonLogic : ITrial_LessonLogic
    {
        private readonly ITrial_LessonDAO _trial_LessonLogic;

        public Trial_LessonLogic(ITrial_LessonDAO trial_LessonLogic)
        {
            _trial_LessonLogic = trial_LessonLogic;
            Logger.InitLogger();
        }

        public bool Add(TrialLesson trialLesson)
        {
            try
            {
                return _trial_LessonLogic.Add(trialLesson);
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return false;
            }
        }

        public IEnumerable<TrialLesson> GetAll()
        {
            try
            {
                return _trial_LessonLogic.GetAll();
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex.Message);
                return null;
            }
        }
    }
}
