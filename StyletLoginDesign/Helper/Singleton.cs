using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletLoginDesign.Helper
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object SysLock = new object();

        public static T Instance()
        {
            if (_instance == null)
            {
                lock (SysLock)
                {
                    if (_instance == null)
                    {
                        _instance = new T();
                    }
                }
            }
            return _instance;
        }
    }
}
