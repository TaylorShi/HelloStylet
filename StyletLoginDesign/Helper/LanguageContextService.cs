using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StyletLoginDesign.Helper
{
    /// <summary>
    /// LanguageContextService
    /// </summary>
    public class LanguageContextService : Singleton<LanguageContextService>
    {
        /// <summary>
        /// 多语言对象
        /// </summary>
        public XmlDataProvider Provider { get; set; }
    }
}
