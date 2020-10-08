using System.Threading.Tasks;

namespace FinalProject.Common
{
    public static class Common
    {
        public static bool FatalError { get; set; }
        public static int UserID { get; set; }

        public static string TimeToNormalView(int time)
        {
            if (time < 10)
                return "0" + time.ToString();
            else
                return time.ToString();
        }
    }
}
