using static GTA5_VH.SigScan;
namespace GTA5_VH
{
    internal static class Globals
    {
        public static string Global_262145 => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x0).ToString("X2");
        public static string Global_toggle_snow_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x9488).ToString("X2");
        public static string Global_halloween_Horns_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x178A0).ToString("X2");
        public static string Global_christmas_Horns_ => (MemLib.ReadLong(GlobalBaseAddress + "+8") + 0x19B60).ToString("X2");
        public static int Global_christmas_Horns
        {
            get => MemLib.ReadInt(Global_christmas_Horns_);
            set => MemLib.WriteMemory(Global_christmas_Horns_, "int", value.ToString());
        } 
        public static int Global_halloween_Horns
        {
            get => MemLib.ReadInt(Global_halloween_Horns_);
            set => MemLib.WriteMemory(Global_halloween_Horns_, "int", value.ToString());
        }
        public static int Global_toggle_snow
        {
            get => MemLib.ReadInt(Global_toggle_snow_);
            set => MemLib.WriteMemory(Global_toggle_snow_, "int", value.ToString());
        }     
    }
}
