using System;
using System.IO;

namespace CSTest
{
	public static class Log
	{
		private static readonly string LogPath;

		static Log()
		{
			LogPath = Path.Combine
			(
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				"out.log"
			);
		}

		public static bool Enabled { get; set; } = false;

		public static void Delete()
		{
			if (!Enabled) return;
			try { File.Delete(LogPath); }
			catch { }
		}

		public static void Line(string text)
		{
			if (!Enabled) return;
			try { File.AppendAllText(LogPath, $"[{DateTime.Now:G}] {text}{Environment.NewLine}"); }
			catch { }
		}
	}
}
