using System;
using System.Runtime.InteropServices;

namespace HaatosWorldTool.Core
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct cItemDataHeader
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public char[] magic;
        public int nItemDataArrayLength;
    }

    public enum ItemFlag : int
    {
        Default = 2 >> 1,
        QuestOnly = 2 << 0,
        Unknown = 2 << 1,
        Consumable = 2 << 2,
        Appraisal = 2 << 3,
        Unknown1 = 2 << 4,
        Mega = 2 << 5,
        LevelOne = 2 << 6,
        LevelTwo = 2 << 7,
        LevelThree = 2 << 8,
        Glitter = 2 << 9,
        Deliverable = 2 << 10,
        Invisible = 2 << 11
    }

    public enum ItemType : int
    {
        Item,
        Material,
        Endemic,
        Ammo,
        Jewel,
        Furniture
    }

    public enum IconId : int
    {
        Sac,
        Mushroom,
        Egg,
        Honey,
        Herb,
        Potion,
        Sharpening,
        Meat,
        Dung,
        Gem,
        Barrel,
        TrapBox,
        Trap,
        Powder,
        MediumBarrel,
        Fish,
        Berry,
        Ammo,
        Phial,
        FullPhial,
        Web,
        Seed,
        Ore,
        Bug,
        Bomb,
        Coin,
        Ticket,
        Pickaxe,
        BugCatcher,
        Rod,
        Boomerang,
        unknown,
        Binocles,
        Knife,
        BBQ,
        unknown1,
        Book,
        unknown2,
        unknown3,
        Jewel
    }

    public enum IconColor : byte
    {
        White,
        Red,
        Green,
        Blue,
        Yellow,
        Purple,
        Cyan,
        Orange,
        Pink,
        DarkYellow,
        Grey,
        LightOrange,
        LightBlue,
        DarkGreen,
        DarkPink,
        DarkBlue,
        DarkPurple,
        LighterBlue,
        LightPink,
        Blurple,
        OceanBlue,
        Teal,
        Salmon,
        LightYellow,
        LighterYellow,
        DarkOrange,
        Emerald,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct cItemData
    {
        public int Id { get; set; }
        public byte subType { get; set; }
        public ItemType Type { get; set; }
        public byte rarity { get; set; }
        public byte carryLimit { get; set; }
        public byte unk3 { get; set; }
        public short unk4 { get; set; }
        public ItemFlag Flags { get; set; }
        public int IconId { get; set; }
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
