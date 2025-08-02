using HarmonyLib;

namespace DuplicateUpgradesAllowed.Patches
{
    [HarmonyPatch(typeof(ModuleEquipSlots))]
    public class StackableUpgradesPatch
    {
        private static HexMap tempHex;
        [HarmonyPatch("CancelStackingEquip")]
        [HarmonyPrefix]
        public static void CancelStackingEquipPatchPre(ref HexMap ___hexMap)
        {
            tempHex = ___hexMap;
            ___hexMap = new HexMap();
        }
        [HarmonyPatch("CancelStackingEquip")]
        [HarmonyPostfix]
        public static void CancelStackingEquipPatchPost(ref HexMap ___hexMap)
        {
            ___hexMap = tempHex;
        }
    }
}