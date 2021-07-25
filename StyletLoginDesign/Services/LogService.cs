using Stylet.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StyletLoginDesign.Services
{
    public class LogService : ILogService
    {
        private ILogger _logger;

        public LogService(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 记录入参日志
        /// </summary>
        /// <param name="description"></param>
        /// <param name="typePoint"></param>
        /// <param name="vo"></param>
        /// <param name="requestId"></param>
        public void LogVo(string description, Type typePoint, Object vo, string requestId)
        {
            var contentStr = vo != null ? JsonSerializer.Serialize(vo) : string.Empty;
            _logger.Info($"{description}, 入参：requestId {requestId} functionName:{ typePoint } content: {contentStr}");
        }

        /// <summary>
        /// 记录入参日志
        /// </summary>
        /// <param name="description"></param>
        /// <param name="typePoint"></param>
        /// <param name="vo"></param>
        /// <param name="requestId"></param>
        /// <param name="requestIdVo"></param>
        public void LogVo(string description, Type typePoint, Object vo, out string requestId, string requestIdVo = "")
        {
            requestId = !string.IsNullOrEmpty(requestIdVo) ? requestIdVo : Guid.NewGuid().ToString();
            var contentStr = vo != null ? JsonSerializer.Serialize(vo) : string.Empty;
            _logger.Info($"{description}, 入参：requestId {requestId} functionName:{ typePoint } content: {contentStr}");
        }

        /// <summary>
        /// 记录出参日志
        /// </summary>
        /// <param name="description"></param>
        /// <param name="requestId"></param>
        /// <param name="typePoint"></param>
        /// <param name="dto"></param>
        public void LogDo(string description, string requestId, Type typePoint, Object dto)
        {
            var contentStr = dto != null ? JsonSerializer.Serialize(dto) : string.Empty;
            _logger.Info($"{description}, 出参：requestId {requestId} functionName:{ typePoint } content: {contentStr}");
        }

        /// <summary>
        /// 记录出参日志
        /// </summary>
        /// <param name="description"></param>
        /// <param name="typePoint"></param>
        /// <param name="dto"></param>
        /// <param name="requestId"></param>
        public void LogDo(string description, Type typePoint, object dto, string requestId)
        {
            var contentStr = dto != null ? JsonSerializer.Serialize(dto) : string.Empty;
            _logger.Info($"{description}, 出参：requestId {requestId} functionName:{ typePoint } content: {contentStr}");
        }

        /// <summary>
        /// 记录出错日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="typePoint"></param>
        /// <param name="description"></param>
        /// <param name="requestId"></param>
        public void LogError(Exception ex, Type typePoint, string description, string requestId)
        {
            _logger.Error(ex, $"{description}, 来源:requestId {requestId} functionName:{ typePoint }");
        }
    }

    public interface ILogService
    {
        /// <summary>
        /// 记录入参日志
        /// </summary>
        void LogVo(string description, Type typePoint, Object vo, string requestId);

        /// <summary>
        /// 记录入参日志
        /// </summary>
        void LogVo(string description, Type typePoint, Object vo, out string requestId, string requestIdVo = "");

        /// <summary>
        /// 记录出参日志
        /// </summary>
        void LogDo(string description, string requestId, Type typePoint, Object dto);

        /// <summary>
        /// 记录出参日志
        /// </summary>
        void LogDo(string description, Type typePoint, Object dto, string requestId);

        /// <summary>
        /// 记录出错日志
        /// </summary>
        void LogError(Exception ex, Type typePoint, string description, string requestId);
    }
}
