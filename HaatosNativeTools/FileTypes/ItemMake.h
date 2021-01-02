#pragma once
#include "../Helper.h"

#pragma pack(push, 1)

struct cItemMakeHeader
{
	uint8_t magic[6];
	uint32_t nElements;
};

struct cItemMake
{
	uint32_t index;
	uint16_t unk0;
	uint32_t primary_material;
	uint32_t secondary_material;
	uint32_t output_id;
	uint32_t output_quantity;
	uint32_t unk3;
	uint32_t unk4;
	uint8_t unk5;
};

#pragma pack(pop)

struct cItemMakeFile
{
	cItemMakeHeader header;
	cItemMake* elements;
};

DLLEXPORT bool DeserializeItemMake(char* filepath, cItemMakeFile* itemMake);
DLLEXPORT void FreeItemMake(cItemMakeFile* itemMake);