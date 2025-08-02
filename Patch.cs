using System;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using DuplicateUpgradesAllowed.Patches;
using UnityEngine;

namespace DuplicateUpgradesAllowed 
{
    [BepInPlugin(ModGuid, ModName, ModVersion)]
    public class Patch : BaseUnityPlugin
    {
        private const string ModGuid = "Poseidon.DuplicateUpgradesAllowed";
        private const string ModName = "Duplicate Upgrades Allowed";
        private const string ModVersion = "1.0.0";
        private readonly Harmony _harmony = new Harmony(ModGuid);
        

        private ManualLogSource _mls;

        private void Awake()
        {
            _mls = BepInEx.Logging.Logger.CreateLogSource(ModGuid);
            Debug.Log($"{ModName}, {ModVersion} Active");
            _mls.LogMessage($"{ModName}, {ModVersion} Active");
            try{_harmony.PatchAll(typeof(StackableUpgradesPatch));}
            catch (Exception e) {Debug.Log(e);}
        }
    }
}