using SimpleCRM.Contracts;
using NLog;
using ILogger = NLog.ILogger;

namespace SimpleCRM.LoggerService
{
	/// <summary>
	/// LoggerManager is responsible for logging messages of various severity levels.
	/// It implements the ILoggerManager interface.
	/// </summary>
	public class LoggerManager : ILoggerManager
	{
		private static ILogger logger = LogManager.GetCurrentClassLogger();

		/// <summary>
		/// Logs an informational message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		public void LogInfo(string message) => logger.Info(message);

		/// <summary>
		/// Logs a debug message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		public void LogDebug(string message) => logger.Debug(message);

		/// <summary>
		/// Logs a warning message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		public void LogWarn(string message) => logger.Warn(message);

		/// <summary>
		/// Logs an error message.
		/// </summary>
		/// <param name="message">The message to log.</param>
		public void LogError(string message) => logger.Error(message);
	}
}