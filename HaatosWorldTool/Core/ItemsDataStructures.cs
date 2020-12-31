using System;
using System.Runtime.InteropServices;

namespace HaatosWorldTool.Core
{
    [StructLayout(LayoutKind.Sequential)]
    public struct cItemDataHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public char[] magic;
        public short unk4;
        public short nItemDataArrayLength;
        public short unk5;
    }

    public enum ItemRarity : byte
    {

    }

    public enum IconId : int
    {

    }

    public enum IconColor : byte
    {
        White,
        Unknown1,
        Unknown2,
        Unknown3,
        Blue,
        Unknown5,
        Unknown6,
        Unknown7,
        Unknown8,
        Unknown9,
        Unknown10,
        Unknown11,
        Unknown12,
        Unknown13,
        Unknown14,
        DarkBlue,
        Unknown15,
        Unknown16,
        Unknown17,
        Unknown18,
        Unknown19,
        Unknown20,
        Unknown21,
        Unknown22,
        Unknown23,
        Unknown24,
        Unknown25,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct cItemData
    {
        public int Id { get; set; }
        public byte unk0 { get; set; }
        public byte unk1 { get; set; }
        public byte flag1 { get; set; }
        public byte flag2 { get; set; }
        public byte flag3 { get; set; }
        public byte rarity { get; set; }
        public byte unk2 { get; set; }
        public byte unk3 { get; set; }
        public short unk3_1 { get; set; } // ?
        public byte flagUnk1 { get; set; }
        public byte flagUnk2 { get; set; }
        public byte flagUnk3 { get; set; }
        public byte flagUnk4 { get; set; }
        public IconId IconId { get; set; }
        public IconColor IconColor { get; set; }
        public byte unk6Flag2 { get; set; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct cItemDataFile
    {
        public cItemDataHeader header;
        public IntPtr items;
    }
}
