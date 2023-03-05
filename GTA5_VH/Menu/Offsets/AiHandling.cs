using static GTA5_VH.SigScan;
using static GTA5_VH.GetAddress;
namespace GTA5_VH
{
    internal static class AiHandling
    {
        //Sports Car
        public static string s_min_brake_distance_ = "C";
        public static string s_max_brake_distance_ = "10";
        public static string s_max_speed_at_brake_distance_ = "14";
        public static string s_absolute_min_speed_ = "18";
        //Average Car
        public static string a_min_brake_distance_ = "3C";
        public static string a_max_brake_distance_ = "40";
        public static string a_max_speed_at_brake_distance_ = "44";
        public static string a_absolute_min_speed_ = "48";
        //Crap
        public static string c_min_brake_distance_ = "6C";
        public static string c_max_brake_distance_ = "70";
        public static string c_max_speed_at_brake_distance_ = "74";
        public static string c_absolute_min_speed_ = "78";
        //Trucks
        public static string t_min_brake_distance_ = "9C";
        public static string t_max_brake_distance_ = "A0";
        public static string t_max_speed_at_brake_distance_ = "A4";
        public static string t_absolute_min_speed_ = "A8";

        public static float s_min_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + s_min_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + s_min_brake_distance_, "float", value.ToString());
        }
        public static float s_max_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + s_max_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + s_max_brake_distance_, "float", value.ToString());
        }
        public static float s_max_speed_at_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + s_max_speed_at_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + s_max_speed_at_brake_distance_, "float", value.ToString());
        }
        public static float s_absolute_min_speed
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + s_absolute_min_speed_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + s_absolute_min_speed_, "float", value.ToString());
        }
        public static float a_min_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + a_min_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + a_min_brake_distance_, "float", value.ToString());
        }
        public static float a_max_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + a_max_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + a_max_brake_distance_, "float", value.ToString());
        }
        public static float a_max_speed_at_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + a_max_speed_at_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + a_max_speed_at_brake_distance_, "float", value.ToString());
        }
        public static float a_absolute_min_speed
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + a_absolute_min_speed_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + a_absolute_min_speed_, "float", value.ToString());
        }
        public static float c_min_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + c_min_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + c_min_brake_distance_, "float", value.ToString());
        }
        public static float c_max_speed_at_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + c_max_speed_at_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + c_max_speed_at_brake_distance_, "float", value.ToString());
        }
        public static float c_max_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + c_max_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + c_max_brake_distance_, "float", value.ToString());
        }
        public static float c_absolute_min_speed
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + c_absolute_min_speed_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + c_absolute_min_speed_, "float", value.ToString());
        }
        public static float t_min_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + t_min_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + t_min_brake_distance_, "float", value.ToString());
        }
        public static float t_max_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + t_max_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + t_max_brake_distance_, "float", value.ToString());
        }
        public static float t_max_speed_at_brake_distance
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + t_max_speed_at_brake_distance_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + t_max_speed_at_brake_distance_, "float", value.ToString());
        }
        public static float t_absolute_min_speed
        {
            get => MemLib.ReadFloat(CAIHandlingData + "+" + t_absolute_min_speed_);
            set => MemLib.WriteMemory(CAIHandlingData + "+" + t_absolute_min_speed_, "float", value.ToString());
        }
    }
}
