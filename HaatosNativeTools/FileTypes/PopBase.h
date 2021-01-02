#pragma once
#include <string>
#include "../ExportHelper.h"

struct cPopBaseFile;
struct cPopBaseHeader;
struct cPopBase;

DLLEXPORT bool DeserializePopBase(char* filepath, cPopBaseFile* file);
DLLEXPORT void FreePopBase(cPopBaseFile* file);