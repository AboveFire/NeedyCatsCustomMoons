using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Linq;
using static NeedyCats.NeedyCatsBase;

namespace NeedyCatsCustomMoons
{
    internal class NeedyCatPatch
    {
        [HarmonyPatch(typeof(RoundManager), "Start")]
        [HarmonyPrefix]
        [HarmonyPriority(Priority.Last)]
        private static void AddNeedyCatsToAllLevels_Prefix()
        {
            Plugin.mls.LogMessage("AddNeedyCatsToAllLevels_Prefix");

            Item item = Assets.MainAssetBundle.LoadAsset<Item>("CatItem");
            SpawnableItemWithRarity val = new SpawnableItemWithRarity();
            val.rarity = NeedyCatsCustomMoonsConfig.spawnRate.Value;
            val.spawnableItem = item;
            SelectableLevel[] levels = StartOfRound.Instance.levels;
            String addedLevels = "";
            String alreadyInLevels = "";
            foreach (SelectableLevel val2 in levels)
            {
                if (!val2.spawnableScrap.Any((SpawnableItemWithRarity x) => (Object)(object)x.spawnableItem == (Object)(object)item))
                {
                    addedLevels += val2.PlanetName + ",";
                    val2.spawnableScrap.Add(val);
                }
                else
                {
                    alreadyInLevels += val2.PlanetName + ",";
                }
            }
            Plugin.mls.LogMessage("Added Needy Cats to all levels and custom moons. (added to: " + addedLevels + ") (already in: " + alreadyInLevels + ")");
        }
    }
}
