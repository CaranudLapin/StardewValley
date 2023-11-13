using System;
using BirbCore;
using BirbCore.Annotations;
using Microsoft.Xna.Framework;
using StardewValley;

namespace PanningUpgrades;

[SCommand("pan_upgrades")]
public class Command
{
    [SCommand.Command("give_pan", "Add a pan to the player inventory")]
    public static void GivePan(int level = 0)
    {
        Game1.player.addItemToInventory(level switch
        {
            0 => ItemRegistry.Create("(T)drbirbdev.PanningUpgrades_NormalPan"),
            1 => ItemRegistry.Create("(T)Pan"),
            2 => ItemRegistry.Create("(T)drbirbdev.PanningUpgrades_SteelPan"),
            3 => ItemRegistry.Create("(T)drbirbdev.PanningUpgrades_GoldPan"),
            _ => ItemRegistry.Create("(T)drbirbdev.PanningUpgrades_IridiumPan")
        });
    }

    [SCommand.Command("remove_pan", "Remove a pan from the player inventory")]
    public static void RemovePan()
    {
        Item pan = Game1.player.getToolFromName("Pan");
        if (pan is not null)
        {
            Log.Info("Found pan to remove");
            Game1.player.removeItemFromInventory(pan);
        }
        else
        {
            Log.Info("Found no pan to remove");
        }
    }

    [SCommand.Command("spawn_pan_spot", "Spawn panning spot on the current map if possible")]
    public static void SpawnPanSpot()
    {
        Game1.MasterPlayer.mailReceived.Add("ccFishTank");
        Game1.currentLocation.orePanPoint.Value = Point.Zero;
        for (int i = 0; i < 100; i++)
        {
            Game1.currentLocation.performOrePanTenMinuteUpdate(new Random());
            if (Game1.currentLocation.orePanPoint.Value != Point.Zero)
            {
                break;
            }
        }
    }
}