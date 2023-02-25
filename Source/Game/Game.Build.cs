using System.IO;
using Flax.Build;
using Flax.Build.NativeCpp;

public class Game : GameModule
{
    /// <inheritdoc />
    public override void Init()
    {
        base.Init();

        // C#-only scripting
        BuildNativeCode = true;
    }

    /// <inheritdoc />
    public override void Setup(BuildOptions options)
    {
        base.Setup(options);

        options.ScriptingAPI.IgnoreMissingDocumentationWarnings = true;
        options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "Interop.IWshRuntimeLibrary.dll"));
        options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "System.Deployment.dll"));
        options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "System.Drawing.dll"));
        options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "System.Windows.Forms.dll"));
        // Here you can modify the build options for your game module
        // To reference another module use: options.PublicDependencies.Add("Audio");
        // To add C++ define use: options.PublicDefinitions.Add("COMPILE_WITH_FLAX");
        // To learn more see scripting documentation.
    }
}
