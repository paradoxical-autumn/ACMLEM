using MonkeyLoader.Configuration;

namespace JohnResoniteMod;

internal sealed class JohnResoniteConfig : ConfigSection
{
    // define variables
    private readonly DefiningConfigKey<string> _userName = new("Name", "What should people be called? The only correct answer is \"john resonite\".", () => "john resonite");

    // set internal variables
    public override string Description => "Options";
    public override string Id => "JohnResonite.MainSettings";
    public override string Name => "john's settings.";
    public override Version Version { get; } = new Version(1, 0, 0);

    // init variables
    public string UserName
    {
        get => _userName.GetValue()!;
        set => _userName.SetValue(value);
    }
}