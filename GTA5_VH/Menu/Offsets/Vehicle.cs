using static GTA5_VH.SigScan;
using static GTA5_VH.GetAddress;
using static GTA5_VH.Bools;
using System;

namespace GTA5_VH
{
    internal static class Vehicle
    {
        public static void RainbowNeonLooperEnabled()
        {
            IsRainbowNeonLooperEnabled = !IsRainbowNeonLooperEnabled;
        }
        public static void RainbowTireSmokeLooperEnabled()
        {
            IsRainbowTireSmokeLooperEnabled = !IsRainbowTireSmokeLooperEnabled;
        }
        public static void RainbowXenonLooperEnabled()
        {
            IsRainbowXenonLooperEnabled = !IsRainbowXenonLooperEnabled;
        }
        public static void RainbowCarLooperEnabled()
        {
            IsRainbowLooperEnabled = !IsRainbowLooperEnabled;
        }
        public static string vehicle_coord_x_ = "50";
        public static string vehicle_coord_y_ = "54";
        public static string vehicle_coord_z_ = "58";
        public static string vehicle_health1_ = "280";
        public static string vehicle_health2_ = "820";
        public static string vehicle_health3_ = "8E8";
        public static string vehicle_health4_ = "824";
        public static string vehicle_color1_r_ = "A6";
        public static string vehicle_color1_g_ = "A5";
        public static string vehicle_color1_b_ = "A4";
        public static string vehicle_color2_r_ = "AA";
        public static string vehicle_color2_g_ = "A9";
        public static string vehicle_color2_b_ = "A8";
        public static string mass = "0C";
        public static string initial_drag_coeff = "10";
        public static string downforce_multiplier = "14";
        public static string popup_light_rotation = "18";
        public static string buoyancy = "40";
        public static string drive_bias_rear = "44";
        public static string drive_bias_front = "48";
        public static string acceleration = "4C";
        public static string drive_inertia = "54";
        public static string upshift = "58";
        public static string downshift = "5C";
        public static string initial_drive_force = "60";
        public static string drive_max_flat_velocity = "64";
        public static string initial_drive_max_flat_vel = "68";
        public static string brake_force = "6C";
        public static string brake_bias_front = "74";
        public static string brake_bias_rear = "78";
        public static string handbrake_force = "7C";
        public static string steering_lock = "80";
        public static string steering_lock_ratio = "84";
        public static string traction_curve_max = "88";
        public static string traction_curve_lateral = "8C";
        public static string traction_curve_min = "90";
        public static string traction_curve_ratio = "94";
        public static string curve_lateral = "98";
        public static string curve_lateral_ratio = "9C";
        public static string traction_spring_delta_max = "A0";
        public static string traction_spring_delta_max_ratio = "A4";
        public static string low_speed_traction_loss_mult = "A8";
        public static string camber_stiffness = "AC";
        public static string traction_bias_front = "B0";
        public static string traction_bias_rear = "B4";
        public static string traction_loss_mult = "B8";
        public static string suspension_force = "BC";
        public static string suspension_comp_damp = "C0";
        public static string suspension_rebound_damp = "C4";
        public static string suspension_upper_limit = "C8";
        public static string suspension_lower_limit = "CC";
        public static string suspension_raise = "D0";
        public static string suspension_bias_front = "D4";
        public static string suspension_bias_rear = "D8";
        public static string anti_rollbar_force = "DC";
        public static string anti_rollbar_bias_front = "E0";
        public static string anti_rollbar_bias_rear = "E4";
        public static string roll_centre_height_front = "E8";
        public static string roll_centre_height_rear = "EC";
        public static string collision_damage_mult = "F0";
        public static string weapon_damage_mult = "F4";
        public static string deformation_mult = "F8";
        public static string engine_damage_mult = "FC";
        public static string petrol_tank_volume = "100";
        public static string oil_volume = "104";
        public static string vehicle_gravity_ = "C3C";
        public static string vehicle_extras_ = "58B";
        public static string vehicle_headlightmult_ = "9F4";
        public static string vehicle_tiresmoke_r_ = "3FC";
        public static string vehicle_tiresmoke_g_ = "3FD";
        public static string vehicle_tiresmoke_b_ = "3FE";
        public static string vehicle_neon_r_ = "3A2";
        public static string vehicle_neon_g_ = "3A1";
        public static string vehicle_neon_b_ = "3A0";
        public static string vehicle_xenon_ = "3E1";
        public static string vehicle_xenoncolor_ = "406";
        public static string vehicle_boost_ = "300";
        public static string vehicle_boost_recharge_ = "304";
        public static int vehicle_extras
        {
            get => MemLib.ReadInt(CModelInfo + "+" + vehicle_extras_);
            set => MemLib.WriteMemory(CModelInfo + "+" + vehicle_extras_, "int", value.ToString());
        }    
        public static float vehicle_coord_x
        {
            get => MemLib.ReadFloat(CVehicleStuff + "+" + vehicle_coord_x_);
            set => MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_x_, "float", value.ToString());
        }
        public static float vehicle_coord_y
        {
            get => MemLib.ReadFloat(CVehicleStuff + "+" + vehicle_coord_y_);
            set => MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_y_, "float", value.ToString());
        }
        public static float vehicle_coord_z
        {
            get => MemLib.ReadFloat(CVehicleStuff + "+" + vehicle_coord_z_);
            set => MemLib.WriteMemory(CVehicleStuff + "+" + vehicle_coord_z_, "float", value.ToString());
        }
    }
}
