using static GTA5_VH.SigScan;
using static GTA5_VH.GetAddress;
using static GTA5_VH.Bools;
namespace GTA5_VH
{
    internal static class Player
    {
        public static void ToggleGodMode()
        {
            player_godmode = pGodmode ? 0 : 1;
            pGodmode = !pGodmode;
        }
        public static string wanted_level_ = "8E8";
        public static string player_health_ = "280";     
        public static string player_armor_ = "150C";
        public static string player_godmode_ = "189";
        public static string player_coord_x_ = "50";
        public static string player_visual_coord_x_ = "90";
        public static string player_coord_y_ = "54";
        public static string player_visual_coord_y_ = "94";
        public static string player_coord_z_ = "58";
        public static string player_visual_coord_z_ = "98";
        public static float player_coord_z
        {
            get => MemLib.ReadFloat(CNavigation + "+" + player_coord_z_);
            set => MemLib.WriteMemory(CNavigation + "+" + player_coord_z_, "float", value.ToString());
        }
        public static float player_coord_y
        {
            get => MemLib.ReadFloat(CNavigation + "+" + player_coord_y_);
            set => MemLib.WriteMemory(CNavigation + "+" + player_coord_y_, "float", value.ToString());
        }
        public static float player_coord_x
        {
            get => MemLib.ReadFloat(CNavigation + "+" + player_coord_x_);
            set => MemLib.WriteMemory(CNavigation + "+" + player_coord_x_, "float", value.ToString());
        }
        public static float player_visual_coord_z
        {
            get => MemLib.ReadFloat(CPed + "+" + player_visual_coord_z_);
            set => MemLib.WriteMemory(CPed + "+" + player_visual_coord_z_, "float", value.ToString());
        }
        public static float player_visual_coord_y
        {
            get => MemLib.ReadFloat(CPed + "+" + player_visual_coord_y_);
            set => MemLib.WriteMemory(CPed + "+" + player_visual_coord_y_, "float", value.ToString());
        }
        public static float player_visual_coord_x
        {
            get => MemLib.ReadFloat(CPed + "+" + player_visual_coord_x_);
            set => MemLib.WriteMemory(CPed + "+" + player_visual_coord_x_, "float", value.ToString());
        }
        public static int wanted_level
        {
            get => MemLib.ReadInt(CPlayerInfo + "+" + wanted_level_);
            set => MemLib.WriteMemory(CPlayerInfo + "+" + wanted_level_, "int", value.ToString());
        }
        public static float player_health
        {
            get => MemLib.ReadFloat(CPed + "+" + player_health_);
            set => MemLib.WriteMemory(CPed + "+" + player_health_, "float", value.ToString());
        }
        public static float player_armor
        {
            get => MemLib.ReadFloat(CPed + "+" + player_armor_);
            set => MemLib.WriteMemory(CPed + "+" + player_armor_, "float", value.ToString());
        }
        public static int player_godmode
        {
            get => MemLib.ReadInt(CPed + "+" + player_godmode_);
            set => MemLib.WriteMemory(CPed + "+" + player_godmode_, "int", value.ToString());
        }     
    }
}
