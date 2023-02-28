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
        options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "System.Memory.dll"));
        options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "System.Net.Http.dll"));
        // options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "ReusableTasks.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.BEncoding.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.Client.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.Connections.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.Dht.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.Factories.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.Messages.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.PiecePicking.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.PieceWriter.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.PortForwarding.dll"));
        //options.ScriptingAPI.FileReferences.Add(Path.Combine(FolderPath, "..", "..", "Source","dll", "MonoTorrent.Trackers.dll"));
        // Here you can modify the build options for your game module
        // To reference another module use: options.PublicDependencies.Add("Audio");
        // To add C++ define use: options.PublicDefinitions.Add("COMPILE_WITH_FLAX");
        // To learn more see scripting documentation.
    }
}
