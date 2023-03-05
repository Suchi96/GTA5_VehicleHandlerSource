using System;
using System.Threading.Tasks;
using static GTA5_VH.GetAddress;
using static GTA5_VH.Globals;
using static GTA5_VH.Bools;
using static GTA5_VH.Vehicle;
using static GTA5_VH.SigScan;
namespace GTA5_VH
{
    internal static class Tasks
    {
        public static async Task AttemptOpenProcess()
        {
            if (!IsProcessOpen && !IsConnectionAttempting)
            {
                IsConnectionAttempting = true;
                if (MemLib.OpenProcess("GTA5"))
                {
                    IsProcessOpen = true;
                    await ConnectWorld();
                    GTA_PROCESS = MemLib.mProc.Process;
                }
                IsConnectionAttempting = false;
            }
        }
        public static async Task RainbowTireSmoke_Loop()
        {
            if (IsRainbowTireSmokeLooperEnabled)
            {
                RainbowTireSmoke_Loop_IsLooping = true;
                Random random = new Random();
                while (IsRainbowTireSmokeLooperEnabled)
                {
                    byte[] color1 = { (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255) };                   
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_tiresmoke_r_, color1);
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_tiresmoke_g_, color1);
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_tiresmoke_b_, color1);              
                    await Task.Delay(100);
                }
                RainbowTireSmoke_Loop_IsLooping = false;
            }
        }
        public static async Task CarRainbowNeon_Loop()
        {
            if (IsRainbowNeonLooperEnabled)
            {
                RainbowNeon_Loop_IsLooping = true;
                Random random = new Random();
                while (IsRainbowNeonLooperEnabled)
                {
                    byte[] color1 = { (byte)random.Next(0, 255) };
                    byte[] color2 = { (byte)random.Next(0, 255) };
                    byte[] color3 = { (byte)random.Next(0, 255) };
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_neon_r_, color1);
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_neon_g_, color2);
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_neon_b_, color3);
                    await Task.Delay(100);
                }
                RainbowNeon_Loop_IsLooping = false;
            }
        }
        public static async Task RainbowXenon_Loop()
        {
            if (IsRainbowXenonLooperEnabled)
            {
                RainbowXenon_Loop_IsLooping = true;
                Random random = new Random();
                while (IsRainbowXenonLooperEnabled)
                {
                    byte[] color1 = { (byte)random.Next(0, 12) };
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_xenoncolor_, color1);
                    await Task.Delay(250);
                    byte[] color2 = { (byte)random.Next(0, 12) };
                    MemLib.WriteBytes(CVehicleDrawHandler + "+" + vehicle_xenoncolor_, color2);
                    await Task.Delay(250);
                }
                RainbowXenon_Loop_IsLooping = false;
            }
        }
        public static async Task RainbowCar_Loop()
        {
            if (IsRainbowLooperEnabled && !Rainbow_Loop_IsLooping)
            {
                Rainbow_Loop_IsLooping = true;
                Random random = new Random();
                while (IsRainbowLooperEnabled)
                {
                    byte[] color1 = { (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255) };
                    byte[] color2 = { (byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255) };
                    MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color1_r_, color1);
                    MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color2_r_, color2);
                    MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color1_g_, color1);
                    MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color2_g_, color2);
                    MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color1_b_, color1);
                    MemLib.WriteBytes(CVehicleVisual + "+" + vehicle_color2_b_, color2);
                    await Task.Delay(100);
                }
                Rainbow_Loop_IsLooping = false;
            }
        }
    }
    
}
