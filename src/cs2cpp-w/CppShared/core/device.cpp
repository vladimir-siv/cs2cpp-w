#include "device.h"

namespace core
{
	device::device(uint32_t limit)
	{
		this->limit = limit;
		this->activity = 1u;
	}

	bool device::execute()
	{
		if (activity >= limit) return false;
		++activity;
		return true;
	}
}
