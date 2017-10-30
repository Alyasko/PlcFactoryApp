using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace PlcFactoryApp.Core.Config
{
    public class ConfigProvider : IConfigProvider
    {
        public string Path { get; set; } = "config.json";

        public ConfigModel Load()
        {
            if (!Exists)
                return null;

            return JsonConvert.DeserializeObject<ConfigModel>(File.ReadAllText(Path));
        }

        public void Save(ConfigModel config)
        {
            var contents = JsonConvert.SerializeObject(config);
            File.WriteAllText(Path, contents);
        }

        public bool Exists => File.Exists(Path);
    }
}
