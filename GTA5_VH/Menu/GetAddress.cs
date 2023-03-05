using static GTA5_VH.SigScan;

namespace GTA5_VH
{
    internal static class GetAddress
    {
       
        public static string WorldPTR => MemLib.ReadLong(WorldBaseAddress).ToString("X2");
        public static string CPed => MemLib.ReadLong(WorldPTR + "+8").ToString("X2");
        public static string CPlayerInfo => MemLib.ReadLong(CPed + "+10A8").ToString("X2");     
        public static string CNavigation => MemLib.ReadLong(CPed + "+30").ToString("X2");
        public static string CModelInfo => MemLib.ReadLong(CVehicle + "+20").ToString("X2");   
        public static string CHandlingData => MemLib.ReadLong(CVehicle + "+918").ToString("X2");
        public static string CVehicleDrawHandler => MemLib.ReadLong(CVehicle + "+48").ToString("X2");
        public static string CVehicleVisual => MemLib.ReadLong(CVehicleDrawHandler + "+20").ToString("X2");
        public static string CAIHandlingData => MemLib.ReadLong(CHandlingData + "+150").ToString("X2");
        public static string CVehicle => MemLib.ReadLong(CPed + "+D10").ToString("X2");
        public static string CVehicleStuff => MemLib.ReadLong(CVehicle + "+30").ToString("X2");
     

        

    }
}
