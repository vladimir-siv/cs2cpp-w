#pragma once

#include <cinttypes>

#ifdef __CS2CPP_API__
	#define __dll __declspec(dllexport)
#else
	#define __dll __declspec(dllimport)
#endif

#define dynamic extern "C" __dll

struct __dll Hndl
{
	uint64_t ptr;
};

// RC = ReinterpretCast
template <typename T> inline Hndl RC(T* obj) { return { reinterpret_cast<uint64_t>(obj) }; }
template <typename T> inline Hndl RC(T& obj) { return RC(&obj); }
template <typename T> inline T* RC(Hndl hndl) { return reinterpret_cast<T*>(hndl.ptr); }

// ===== Device API =====
dynamic Hndl CreateDevice(uint32_t limit) noexcept(false);
dynamic void DisposeDevice(Hndl _device) noexcept(false);
dynamic uint32_t DeviceLimit(Hndl _device) noexcept(false);
dynamic uint32_t DeviceActivity(Hndl _device) noexcept(false);
dynamic bool DeviceExecute(Hndl _device) noexcept(false);
