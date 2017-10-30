namespace PlcFactoryApp.Core.Config
{
    public interface IConfigProvider
    {
        string Path { get; set; }
        bool Exists { get; }

        void Save(ConfigModel config);
        ConfigModel Load();
    }
}