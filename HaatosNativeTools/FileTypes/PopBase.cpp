#pragma once
#include "..\pch.h"
#include <fstream>
#include "PopBase.h"

DLLEXPORT bool DeserializePopBase(char* filepath, cPopBaseFile* file)
{
	const char magic[] = { 0x01, 0x10, 0x09, 0x18, 0x2E, 0x00 };

	std::ifstream stream(filepath, std::ifstream::binary);

	stream.seekg(0, stream.end);
	int fileSize = stream.tellg();
	stream.seekg(0, stream.beg);

	char* buffer = (char*)malloc(fileSize);
	stream.read(buffer, fileSize);

	if (memcmp(buffer, magic, sizeof(magic)) == 0)
	{

		memcpy(file, buffer, sizeof(cPopBaseHeader));

		file->elements = (cPopBase*)malloc(file->header.nElements * sizeof(cPopBase));
		
		memcpy(file->elements, &buffer[sizeof(cPopBaseHeader)], file->header.nElements * sizeof(cPopBase));

		free(buffer);

		return true;
	}

	free(buffer);

	return false;
}

DLLEXPORT void FreePopBase(cPopBaseFile* file)
{
	free(file->elements);
}