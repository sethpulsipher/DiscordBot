using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.config
{
    internal class JSONReader
    {
        // variables accessable in program.cs
        public string token {  get; set; }
        public string prefix { get; set; }
        
        // Reads the JSON file in the bin/debug folder
        public async Task ReadJSON()
        {
            using (StreamReader sr = new StreamReader("config.json"))
            {
                var json = await sr.ReadToEndAsync();
                JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);

                this.token = data.token;
                this.prefix = data.prefix;
            }
        }
    }

    internal sealed class JSONStructure
    {
        public string token { get; set; }
        public string prefix { get; set; }
    }
}
