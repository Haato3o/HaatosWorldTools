﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HaatosWorldTool.Core
{
    static public class Native
    {

        public class ItemsData
        {
            [DllImport("HaatosNativeTools.dll", EntryPoint = "DeserializeItemsData")]
            public static extern bool Deserialize(string path, ref cItemDataFile fileStructure);

            [DllImport("HaatosNativeTools.dll")]
            public static extern bool Free(ref cItemDataFile fileStructure);
        }

        public static void MarshalToArray<T>(IntPtr unmanagedArray, int length, out T[] mangagedArray)
        {
            var size = Marshal.SizeOf(typeof(T));
            mangagedArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                IntPtr ins = new IntPtr(unmanagedArray.ToInt64() + i * size);
                mangagedArray[i] = Marshal.PtrToStructure<T>(ins);
            }
        }
    }
}