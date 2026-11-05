using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.Logging
{
	public static class Log
	{
		private static readonly object _lock = new object();

		private static void WriteLog(string message,string RepoName,ConsoleColor color)
		{
			lock (_lock)
			{
				var timestmp= DateTime.Now.ToString("HH:mm:ss.fff");
				var thread= Thread.CurrentThread.ManagedThreadId;
				Console.ForegroundColor = color;
				Console.WriteLine($"[{timestmp}] [Thread-{thread}] {RepoName}-> {message}");
			}
		}
		public static void Info(string message,string RepoName)
		{
			WriteLog(message, RepoName, ConsoleColor.Gray);
		}
		public static void Success(string message, string RepoName)
		{
			WriteLog(message, RepoName, ConsoleColor.Green);
		}
		public static void Error(string message, string RepoName)
		{
			WriteLog(message, RepoName, ConsoleColor.Red);
		}
	}
}
