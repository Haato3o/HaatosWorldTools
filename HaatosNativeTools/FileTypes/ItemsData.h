#pragma once
#include "../Helper.h"

#pragma pack(push, 1)

struct cItemDataHeader
{
	uint8_t magic[6];
	uint32_t nElements;
};

struct cItemData
{
	uint32_t index;
	uint8_t sub_type; // sub type?
	uint32_t type; // Type?
	uint8_t rarity;
	uint8_t carry_limit;
	uint8_t unk3; // limit for something?
	uint16_t unk4;
	uint32_t flags;
	uint32_t icon_id;
	uint8_t icon_color;
	uint8_t unk5;
	uint32_t sell_price;
	uint32_t buy_price;
};

#pragma pack(pop)

struct cItemDataFile
{
	cItemDataHeader header;
	cItemData* elements;
};

DLLEXPORT bool DeserializeItemsData(char* filePath, cItemDataFile* fileStructure);
DLLEXPORT void FreeItemData(cItemDataFile* ptr);

