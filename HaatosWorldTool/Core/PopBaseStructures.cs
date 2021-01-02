using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace HaatosWorldTool.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct cPopBase
    {
        public byte unk0 { get; set; }
        public byte unk1 { get; set; }
        public byte unk2 { get; set; }
        public byte unk3 { get; set; }
        public byte unk4 { get; set; }
        public byte unk5 { get; set; }
        public byte unk6 { get; set; }
        public byte unk7 { get; set; }
        public byte unk8 { get; set; }
        public byte unk9 { get; set; }
        public byte unk10 { get; set; }
        public byte unk11 { get; set; }
        public byte unk12 { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct cPopBaseHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] magic;
        public int nElements;
    }

    public struct cPopBaseFile
    {
        public cPopBaseHeader header;
        public IntPtr elements;
    }
}
