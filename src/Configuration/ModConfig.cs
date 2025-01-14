using System.Collections.Generic;
using Vintagestory.API.Common;

namespace VanillaVariants.Configuration
{
  static class ModConfig
  {
    private const string jsonConfig = "VanillaVariantsConfig.json";
    private static VanillaVariantsConfig config;

    public static void ReadConfig(ICoreAPI api)
    {
      try
      {
        config = LoadConfig(api);

        if (config == null)
        {
          GenerateConfig(api);
          config = LoadConfig(api);
        }
        else
        {
          GenerateConfig(api, config);
        }
      }
      catch
      {
        GenerateConfig(api);
        config = LoadConfig(api);
      }

      api.World.Config.SetBool("VVMoreRecipesFeatureEnabled", config.MoreRecipesFeature);
      api.World.Config.SetBool("VVSlidingDoorCompatibilityEnabled", config.SlidingDoorCompatibility);
      api.World.Config.SetBool("VVTradersSellVariantsEnabled", config.TradersSellVariants);
      api.World.Config.SetBool("VVBedEnabled", config.Bed);
      api.World.Config.SetBool("VVCageEnabled", config.Cage);
      api.World.Config.SetBool("VVChairEnabled", config.Chair);
      api.World.Config.SetBool("VVDisplayCaseEnabled", config.DisplayCase);
      api.World.Config.SetBool("VVDoorEnabled", config.Door);
      api.World.Config.SetBool("VVForgeEnabled", config.Forge);
      api.World.Config.SetBool("VVHenboxEnabled", config.Henbox);
      api.World.Config.SetBool("VVLadderEnabled", config.Ladder);
      api.World.Config.SetBool("VVMoldrackEnabled", config.Moldrack);
      api.World.Config.SetBool("VVShelfEnabled", config.Shelf);
      api.World.Config.SetBool("VVSignEnabled", config.Sign);
      api.World.Config.SetBool("VVSignpostEnabled", config.Signpost);
      api.World.Config.SetBool("VVTableEnabled", config.Table);
      api.World.Config.SetBool("VVToolrackEnabled", config.Toolrack);
      api.World.Config.SetBool("VVTrapdoorEnabled", config.Trapdoor);
      api.World.Config.SetBool("VVTroughLargeEnabled", config.TroughLarge);
      api.World.Config.SetBool("VVTroughSmallEnabled", config.TroughSmall);
      api.World.Config.SetBool("VVWagonWheelsEnabled", config.WagonWheels);
      api.World.Config.SetBool("VVWoodBucketEnabled", config.WoodBucket);
      api.World.Config.SetBool("VVWoodenClubEnabled", config.WoodenClub);
      api.World.Config.SetBool("VVWoodenPanEnabled", config.WoodenPan);
      api.World.Config.SetBool("VVWoodenRailsEnabled", config.WoodenRails);
    }

    private static VanillaVariantsConfig LoadConfig(ICoreAPI api) =>
      api.LoadModConfig<VanillaVariantsConfig>(jsonConfig);

    private static void GenerateConfig(ICoreAPI api) =>
      api.StoreModConfig(new VanillaVariantsConfig(), jsonConfig);

    private static void GenerateConfig(ICoreAPI api, VanillaVariantsConfig previousConfig) =>
      api.StoreModConfig(new VanillaVariantsConfig(previousConfig), jsonConfig);
  }
}