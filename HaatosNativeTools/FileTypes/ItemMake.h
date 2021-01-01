#pragma once
#include "../ExportHelper.h"

struct cItemMakeFile;
struct cItemMakeHeader;
struct cItemMake;

DLLEXPORT bool DeserializeItemMake(char* filepath, cItemMakeFile* itemMake);
DLLEXPORT void FreeItemMake(cItemMakeFile* itemMake);