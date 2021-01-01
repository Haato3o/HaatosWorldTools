#pragma once
#include <string>
#include "../ExportHelper.h"

struct cItemDataHeader;
struct cItemData;
struct cItemDataFile;

DLLEXPORT bool DeserializeItemsData(char* filePath, cItemDataFile* fileStructure);
DLLEXPORT void FreeItemData(cItemDataFile* ptr);

