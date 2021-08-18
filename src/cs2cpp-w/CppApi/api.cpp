#include "api.h"

#include <core/device.h>

using namespace core;

// ===== Device API =====
dynamic Hndl CreateDevice(uint32_t limit) noexcept(false)
{
	return RC(new device(limit));
}
dynamic void DisposeDevice(Hndl _device) noexcept(false)
{
	delete RC<device>(_device);
}
dynamic uint32_t DeviceLimit(Hndl _device) noexcept(false)
{
	return RC<device>(_device)->limit;
}
dynamic uint32_t DeviceActivity(Hndl _device) noexcept(false)
{
	return RC<device>(_device)->activity;
}
dynamic bool DeviceExecute(Hndl _device) noexcept(false)
{
	return RC<device>(_device)->execute();
}
