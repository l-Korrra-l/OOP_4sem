using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
    public class AppSettings
    {
        private static AppSettings instance;
        public string settings;
        protected AppSettings(string settings)
        {
            this.settings = settings;
        }
        public static AppSettings GetInstance(string settings)
        {
            if (instance == null)
                instance = new AppSettings(settings);
            return instance;
        }
    }
}
