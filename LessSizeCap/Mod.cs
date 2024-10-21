using GDWeave;
using Serilog;
using System.Security.Cryptography.X509Certificates;

namespace LessSizeCap;

public class Mod : IMod {
    public Config Config;

    public ILogger Logger;

    public Mod(IModInterface modInterface) {

        Logger = modInterface.Logger;
        Logger.Information("Loaded LessSizeCap");
        modInterface.RegisterScriptMod(new PlayerPatch(this));

    }

    public void Dispose() {
        // Cleanup anything you do here
    }
}
