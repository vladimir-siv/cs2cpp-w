using Microsoft.VisualStudio.TestTools.UnitTesting;

using Core;

namespace CSTest
{
	[TestClass]
	public class Tests
	{
		[TestMethod]
		public void MainTest()
		{
			using var device = new Device(1000u);
			
			Log.Enabled = true;
			Log.Delete();

			do
			{
				Log.Line($"Device Activity: {device.Activity:0000}");
			}
			while (device.Execute());
		}
	}
}
