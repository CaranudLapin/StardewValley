using BirbCore;
using BirbCore.Annotations;
using StardewModdingAPI;

namespace GameboyArcade;

[SEvent]
internal class Events
{
    /// <summary>
    /// Allow remote players to load ROM saves which are marked as shared.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    [SEvent.ModMessageReceived]
    private void LoadRequest(object sender, StardewModdingAPI.Events.ModMessageReceivedEventArgs e)
    {
        if (e.FromModID == ModEntry.Instance.ModManifest.UniqueID && e.Type == "LoadRequest")
        {
            string minigameId = e.ReadAs<string>();
            SaveState loaded = ModEntry.Instance.Helper.Data.ReadJsonFile<SaveState>($"data/{minigameId}/{Constants.SaveFolderName}/file.json");
            ModEntry.Instance.Helper.Multiplayer.SendMessage<SaveState>(loaded, "LoadReceive", new string[] { ModEntry.Instance.ModManifest.UniqueID }, new long[] { e.FromPlayerID });
        }
    }

    /// <summary>
    /// Allow remote players to save ROM saves which are marked as shared.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    [SEvent.ModMessageReceived]
    private void SaveRequest(object sender, StardewModdingAPI.Events.ModMessageReceivedEventArgs e)
    {
        if (e.FromModID == ModEntry.Instance.ModManifest.UniqueID && e.Type.StartsWith("SaveRequest "))
        {
            string minigameId = e.Type.Substring(12);
            if (!ModEntry.Content.ContainsKey(minigameId))
            {
                Log.Error($"{e.FromPlayerID} sent save request for {minigameId}, but no such minigame exists for host computer!");
                return;
            }
            SaveState save = e.ReadAs<SaveState>();
            ModEntry.Instance.Helper.Data.WriteJsonFile<SaveState>($"data/{minigameId}/{Constants.SaveFolderName}/file.json", save);
        }
    }
}