#pragma once

#include <cinttypes>

namespace core
{
	class device
	{
		public: uint32_t limit;
		public: uint32_t activity;
		
		public: device(uint32_t limit);
		public: bool execute();
	};
}
