using Verse;

namespace MorrowRim_Bonewalkers
{
    class ModSettingsUtility
    {
        public static bool MorrowRim_BonewalkerSetting_GraveRevenantEnabled()
        {
            return LoadedModManager.GetMod<MorrowRim_Bonewalkers_Mod>().GetSettings<MorrowRim_Bonewalkers_ModSettings>().MorrowRim_BonewalkerSetting_GraveRevenantEnabled;
        }

        public static bool MorrowRim_BonewalkerSetting_GraveRevenantVersion()
        {
            return LoadedModManager.GetMod<MorrowRim_Bonewalkers_Mod>().GetSettings<MorrowRim_Bonewalkers_ModSettings>().MorrowRim_BonewalkerSetting_GraveRevenantVersion;
        }

        public static float MorrowRim_BonewalkerSetting_GraveRevenantPrecentage()
        {
            return LoadedModManager.GetMod<MorrowRim_Bonewalkers_Mod>().GetSettings<MorrowRim_Bonewalkers_ModSettings>().MorrowRim_BonewalkerSetting_GraveRevenantPrecentage;
        }
    }
}
