#pragma once
#include "pch.h"
#include <fstream>
#include "ItemsData.h"

// Ensure our structure is packed tightly like in the serialized file
#pragma pack(push, 1)
struct cItemData
{
    int Id;
    char unk0;
    char unk1;
    short unk_2;
    short unk_3;
    char unk2;
    char unk3;
    short unkn4; // ?
    char unk4Flag1;
    char unk4Flag2;
    char unk4Flag3;
    char unk4Flag4;
    int IconId;
    char IconColor;
    char unk6Flag2;
    int SellPrice;
    int BuyPrice;
};
#pragma pack(pop)

struct cItemDataHeader
{
    char magic[4];
    short unk4;
    short nItemDataArrayLength;
    short unk5;
};

struct cItemDataFile
{
    cItemDataHeader header;
    cItemData* items;
};

DLLEXPORT bool DeserializeItemsData(char* filePath, cItemDataFile* fileStructure)
{
    
    std::ifstream stream(filePath, std::ifstream::binary);
    
    stream.seekg(0, stream.end);
    int filesize = stream.tellg();
    stream.seekg(0, stream.beg);

    char* buffer = (char*)malloc(filesize);
    stream.read(buffer, filesize);
    stream.close();

    memcpy(fileStructure, buffer, sizeof(cItemDataHeader));

    fileStructure->items = (cItemData*)malloc(sizeof(cItemData) * ((cItemDataFile*)buffer)->header.nItemDataArrayLength);
    memcpy(fileStructure->items, &buffer[sizeof(cItemDataHeader)], sizeof(cItemData) * ((cItemDataFile*)buffer)->header.nItemDataArrayLength);

	return true;
}

DLLEXPORT void Free(cItemDataFile* ptr)
{
    free(ptr->items);
}