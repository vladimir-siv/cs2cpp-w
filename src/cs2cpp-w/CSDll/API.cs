using System.Runtime.InteropServices;

namespace CSApi
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct Hndl
	{
		public static readonly Hndl Invalid = new(0ul);
		private ulong ptr;
		public ulong Ptr { get => ptr; internal set => ptr = value; }
		public bool ValidHandle => Ptr != 0ul;
		internal Hndl(ulong ptr) { this.ptr = ptr; }
		public override bool Equals(object obj) => Equal(this, (Hndl)obj);
		public override int GetHashCode() => ptr.GetHashCode();
		public static bool Equal(Hndl h1, Hndl h2) => h1.ptr == h2.ptr;
		public static bool operator ==(Hndl h1, Hndl h2) => Equal(h1, h2);
		public static bool operator !=(Hndl h1, Hndl h2) => !Equal(h1, h2);
	}

	internal static class API
	{
#if DEBUG
		private const string CppApi = @"D:\Desktop\projects\#testing\cs2cpp-w\src\cs2cpp-w\CppApi\bin\x64\Debug\CppApi.dll";
#else
		private const string CppApi = @"D:\Desktop\projects\#testing\cs2cpp-w\src\cs2cpp-w\CppApi\bin\x64\Release\CppApi.dll";
#endif

		// ===== Device API =====
		[DllImport(CppApi, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		public static extern Hndl CreateDevice(uint limit);
		[DllImport(CppApi, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		public static extern void DisposeDevice(Hndl _device);
		[DllImport(CppApi, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		public static extern uint DeviceLimit(Hndl _device);
		[DllImport(CppApi, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		public static extern uint DeviceActivity(Hndl _device);
		[DllImport(CppApi, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
		public static extern bool DeviceExecute(Hndl _device);
	}
}
