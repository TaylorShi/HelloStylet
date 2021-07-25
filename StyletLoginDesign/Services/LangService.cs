using StyletLoginDesign.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyletLoginDesign.Services
{
    public class LangService : ILangService
    {
        private ILogService _logService;

        public LangService(ILogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// 丢失多语言上下文文档
        /// </summary>
        private readonly string MissLanguageContextDocument = "丢失多语言上下文文档";

        /// <summary>
        /// 未找到多语言文档Key
        /// </summary>
        private readonly string MissLanguageContextKey = "未找到多语言文档Key";

        /// <summary>
        /// GetXmlLocalizedString
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultMessage"></param>
        /// <returns></returns>
        public string GetXmlLocalizedString(string key, string defaultMessage = "")
        {
            if (string.IsNullOrEmpty(key))
                return defaultMessage;

            var langContent = defaultMessage;
            try
            {
                var langDocument = LanguageContextService.Instance().Provider?.Document;
                if (langDocument != null)
                {
                    var langKeyPath = $"/language/resources/{key}";
                    var langKeyNode = langDocument?.SelectSingleNode(langKeyPath);
                    if (langKeyNode != null)
                    {
                        langContent = langKeyNode?.InnerText;
                    }
                    else
                    {
                        _logService.LogError(null, GetType(), MissLanguageContextKey, Guid.NewGuid().ToString());
                    }
                }
                else
                {
                    _logService.LogError(null, GetType(), MissLanguageContextDocument, Guid.NewGuid().ToString());
                }
            }
            catch (Exception ex)
            {
                _logService.LogError(ex, GetType(), MissLanguageContextKey, Guid.NewGuid().ToString());
            }
            return langContent;
        }
    }

    public interface ILangService
    {
        /// <summary>
        /// GetXmlLocalizedString
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultMessage"></param>
        /// <returns></returns>
        string GetXmlLocalizedString(string key, string defaultMessage = "");
    }
}
