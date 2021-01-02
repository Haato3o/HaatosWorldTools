#pragma once
#include <string>
#include "../Helper.h"

#pragma pack(push, 1)
struct cPopBaseHeader
{
	uint8_t header[6];
	uint32_t nElements;
};

struct cPopBase
{
	uint8_t unkn[0xD];
};

#pragma pack(pop)

struct cPopBaseFile
{
	cPopBaseHeader header;
	cPopBase* elements;
};

DLLEXPORT bool DeserializePopBase(char* filepath, cPopBaseFile* file);
DLLEXPORT void FreePopBase(cPopBaseFile* file);