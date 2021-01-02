#pragma once
#include "..\pch.h"
#include <fstream>
#include "ItemsData.h"

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

        fileStructure->elements = (cItemData*)malloc(sizeof(cItemData) * fileStructure->header.nElements);
        memcpy(fileStructure->elements, &buffer[sizeof(cItemDataHeader)], sizeof(cItemData) * fileStructure->header.nElements);
        
        free(buffer);

        return true;
    }

    free(buffer);

	return false;
}

DLLEXPORT void FreeItemData(cItemDataFile* ptr)
{
    free(ptr->elements);
}