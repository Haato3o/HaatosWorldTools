#pragma once
#include "pch.h"
#include <fstream>
#include "FileTypes/ItemsData.h"

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
    char magic[6];
    int nItemDataArrayLength;
};

struct cItemDataFile
{
    cItemDataHeader header;
    cItemData* items;
};

DLLEXPORT bool DeserializeItemsData(char* filePath, cItemDataFile* fileStructure)
{
    const char magic[] = { 0x01, 0x10, 0x09, 0x18, 0xBD, 0x00 };

    std::ifstream stream(filePath, std::ifstream::binary);
    
    stream.seekg(0, stream.end);
    int filesize = stream.tellg();
    stream.seekg(0, stream.beg);

    char* buffer = (char*)malloc(filesize);
    stream.read(buffer, filesize);
    stream.close();

    if (memcmp(buffer, magic, sizeof(magic)) == 0)
    {

        memcpy(fileStructure, buffer, sizeof(cItemDataHeader));

        fileStructure->items = (cItemData*)malloc(sizeof(cItemData) * ((cItemDataFile*)buffer)->header.nItemDataArrayLength);
        memcpy(fileStructure->items, &buffer[sizeof(cItemDataHeader)], sizeof(cItemData) * ((cItemDataFile*)buffer)->header.nItemDataArrayLength);
        return true;
    }

    free(buffer);

	return false;
}

DLLEXPORT void FreeItemData(cItemDataFile* ptr)
{
    free(ptr->items);
}