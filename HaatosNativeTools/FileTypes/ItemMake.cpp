#pragma once
#include "..\pch.h"
#include "ItemMake.h"
#include <fstream>

#pragma pack(push, 1)
struct cItemMakeHeader
{
	char magic[6];
	int nElements;
};
#pragma pack(pop)

#pragma pack(push, 1)
struct cItemMake
{
	int output;
	short unk0;
	int unk1;
	int ingredient1;
	int unk2;
	int ingredient2;
	int unk3;
	int unk4;
	char unk5;
};
#pragma pack(pop)

struct cItemMakeFile
{
	cItemMakeHeader header;
	cItemMake* items;
};

DLLEXPORT bool DeserializeItemMake(char* filepath, cItemMakeFile* itemMake)
{
	const char magic[] = { 0x01, 0x10, 0x09, 0x18, 0xBC, 0x00 };
	
	std::ifstream stream(filepath, std::ifstream::binary);

	stream.seekg(0, stream.end);
	int filesize = stream.tellg();
	stream.seekg(0, stream.beg);

	char* buffer = (char*)malloc(filesize);
	stream.read(buffer, filesize);
	stream.close();

	if (memcmp(buffer, magic, sizeof(magic)) == 0)
	{
		memcpy(itemMake, buffer, sizeof(cItemMakeHeader));

		itemMake->items = (cItemMake*)malloc(sizeof(cItemMake) * itemMake->header.nElements);

		memcpy(itemMake->items, &buffer[sizeof(cItemMakeHeader)], itemMake->header.nElements * sizeof(cItemMake));

		free(buffer);

		return true;
	}

	free(buffer);
	return false;

}

DLLEXPORT void FreeItemMake(cItemMakeFile* itemMake)
{
	free(itemMake->items);
}