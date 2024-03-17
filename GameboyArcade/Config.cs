using BirbCore.Attributes;
using StardewModdingAPI;

namespace GameboyArcade;

[SConfig]
class Config
{

    [SConfig.Option]
    public SButton Up { get; set; } = SButton.W;

    [SConfig.Option]
    public SButton Down { get; set; } = SButton.S;

    [SConfig.Option]
    public SButton Left { get; set; } = SButton.A;

    [SConfig.Option]
    public SButton Right { get; set; } = SButton.D;

    [SConfig.Option]
    public SButton A { get; set; } = SButton.MouseLeft;

    [SConfig.Option]
    public SButton B { get; set; } = SButton.MouseRight;

    [SConfig.Option]
    public SButton Start { get; set; } = SButton.Space;

    [SConfig.Option]
    public SButton Select { get; set; } = SButton.Tab;

    [SConfig.Option]
    public SButton Power { get; set; } = SButton.Escape;

    [SConfig.Option]
    public SButton Turbo { get; set; } = SButton.F1;

    [SConfig.Option(10000, 22050, 1)]
    public int MusicSampleRate { get; set; } = 22050;
}
