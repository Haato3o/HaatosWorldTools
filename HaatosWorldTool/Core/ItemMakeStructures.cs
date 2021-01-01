using System;
using System.Runtime.InteropServices;

namespace HaatosWorldTool.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct cItemMakeHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] magic;
        public int nElements;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct cItemMake
    {
        public int index { get; set; }
        public short unk0 { get; set; }
        public int ingredient1 { get; set; }
        public int ingredient2 { get; set; }
        public int output { get; set; }
        public int quantity { get; set; }
        public int unk3 { get; set; }
        public int unk4 { get; set; }
        public byte unk5 { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct cItemMakeFile
    {
        public cItemMakeHeader header;
        public IntPtr items;
    }
}
