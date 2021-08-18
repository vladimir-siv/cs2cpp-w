using System;

using CSApi;

namespace Core
{
	public sealed class Device : IDisposable
	{
		public Hndl Handle { get; private set; }

		public uint Limit => API.DeviceLimit(Handle);
		public uint Activity => API.DeviceActivity(Handle);

		public Device(uint limit) => Handle = API.CreateDevice(limit);
		~Device() => Dispose();

		public bool Execute() => API.DeviceExecute(Handle);

		public void Dispose()
		{
			API.DisposeDevice(Handle);
			Handle = Hndl.Invalid;
			GC.SuppressFinalize(this);
		}
	}
}
