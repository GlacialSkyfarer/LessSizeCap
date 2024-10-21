using GDWeave.Godot;
using GDWeave.Godot.Variants;
using GDWeave.Modding;
using Serilog.Core;
using System.Security.Cryptography.X509Certificates;

namespace LessSizeCap;

public class PlayerPatch(Mod mod) : IScriptMod { 
    // load the player.gdc file
    public bool ShouldRun(string path) => path == "res://Scenes/Entities/Player/player.gdc";

    public IEnumerable<Token> Modify(string path, IEnumerable<Token> tokens) {
        mod.Logger.Information("started!");
        int pointSevensFound = 0;
        int onePointThreesFound = 0;
        foreach (var token in tokens) {

            if (pointSevensFound < 7 && token is ConstantToken consToken)
            {

                if (pointSevensFound < 7 && consToken.Value.Equals(new RealVariant(0.7)))
                {

                    if (pointSevensFound >= 5)
                    {

                        yield return new ConstantToken(new RealVariant(0.3));

                    }
                    else
                    {

                        yield return token;

                    }

                    pointSevensFound++;

                } else if (onePointThreesFound < 5 && consToken.Value.Equals(new RealVariant(1.3)))
                {

                    if (onePointThreesFound >= 3)
                    {

                        yield return new ConstantToken(new RealVariant(1.7));

                    }
                    else
                    {

                        yield return token;

                    }

                    onePointThreesFound++;

                } else
                {

                    yield return token;

                }


            }
            else
            {

                yield return token;

            }


        }
    }
}