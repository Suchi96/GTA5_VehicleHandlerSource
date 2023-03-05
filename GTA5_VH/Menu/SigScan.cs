using System.Diagnostics;
using System.Threading.Tasks;
using static GTA5_VH.Bools;
namespace GTA5_VH
{
    internal class SigScan
    {
        public static Process GTA_PROCESS = null;
        public static Mem MemLib = new Mem();    
        public static string GlobalAssemblyAddress = "";
        public static string GlobalBaseAddress = "";
        public static string WorldAssemblyAddress = "";
        public static string WorldBaseAddress = "";
        public static string WeatherAssemblyAddress = "";
        public static string WeatherBaseAddress = "";
        public static string TimeAssemblyAddress = "";
        public static string TimeBaseAddress = "";
        public static string TimeBPAssemblyAddress = "";
        public static string TimeBPBaseAddress = "";
        public static async Task ConnectWorld()
        {
            if (!IsWorldConnectionAttempting)
            {
                IsWorldConnectionAttempting = true;

                var WorldHook = await MemLib.AoBScan(MemLib.mProc.MainModule.BaseAddress.ToInt64(),
                MemLib.mProc.MainModule.BaseAddress.ToInt64() + MemLib.mProc.MainModule.ModuleMemorySize,
                "48 8B 05 ?? ?? ?? ?? 45 ?? ?? ?? ?? 48 8B 48 08 48 85 C9 74 07", true, true, true, "");

                long Address = WorldHook[0];
                WorldAssemblyAddress = (Address.ToString("X2"));
                WorldBaseAddress = (Address + MemLib.ReadInt((Address + 3).ToString("X2")) + 7).ToString("X2");

                var GlobalHook = await MemLib.AoBScan(MemLib.mProc.MainModule.BaseAddress.ToInt64(),
                MemLib.mProc.MainModule.BaseAddress.ToInt64() + MemLib.mProc.MainModule.ModuleMemorySize,
                "48 8D 3D ?? ?? ?? 0? 80 3E", true, true, true, "");

                Address = GlobalHook[0];
                GlobalAssemblyAddress = (Address.ToString("X2"));
                GlobalBaseAddress = (Address + MemLib.ReadInt((Address + 3).ToString("X2")) + 7).ToString("X2");

                var WeatherHook = await MemLib.AoBScan(MemLib.mProc.MainModule.BaseAddress.ToInt64(),
                MemLib.mProc.MainModule.BaseAddress.ToInt64() + MemLib.mProc.MainModule.ModuleMemorySize,
                "48 83 EC ? 8B 05 ? ? ? ? 8B 3D ? ? ? ? 49", true, true, true, "");

                Address = WeatherHook[0];
                WeatherAssemblyAddress = (Address.ToString("X2"));
                WeatherBaseAddress = (Address + MemLib.ReadInt((Address + 6).ToString("X2")) + 10).ToString("X2");

                var TimeHook = await MemLib.AoBScan(MemLib.mProc.MainModule.BaseAddress.ToInt64(),
                MemLib.mProc.MainModule.BaseAddress.ToInt64() + MemLib.mProc.MainModule.ModuleMemorySize,
                "48 8B D9 48 8D 0D ? ? ? ? BA ? ? ? 00 E8 ? ? ? ? 89", true, true, true, "");

                Address = TimeHook[0];
                TimeAssemblyAddress = (Address.ToString("X2"));
                TimeBaseAddress = (Address + MemLib.ReadInt((Address + 6).ToString("X2")) + 10).ToString("X2");

                var TimeBP = await MemLib.AoBScan(MemLib.mProc.MainModule.BaseAddress.ToInt64(),
                MemLib.mProc.MainModule.BaseAddress.ToInt64() + MemLib.mProc.MainModule.ModuleMemorySize,
                "48 8B D9 48 8D 0D ? ? ? ? BA ? ? ? 00 E8 ? ? ? ? 89", true, true, true, "");

                Address = TimeBP[0];
                TimeBPAssemblyAddress = (Address.ToString("X2"));
                TimeBPBaseAddress = (Address + MemLib.ReadInt((Address + 13).ToString("X2")) + 20 + 0x4ECE00DE).ToString("X2");


                IsWorldConnectionAttempting = false;

            }
        }
    }
}
