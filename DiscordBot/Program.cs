using DiscordBot.commands;
using DiscordBot.config;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System.Threading.Tasks;

namespace DiscordBot
{
    internal class Program
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands {  get; set; }
         

        static async Task Main(string[] args)
        {
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            //Discord Configuration
            var discordConfig = new DiscordConfiguration()
            {
                //pre-defined WebSocket events that determine which events the bot recieves
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                //Automatically reconnect if bot goes offline
                AutoReconnect = true
            };

            Client = new DiscordClient(discordConfig);

            Client.Ready += Client_Ready;


            
            // COMMANDS 
            var commandConfig = new CommandsNextConfiguration()
            {
                // add out prefix to the bot
                StringPrefixes = new string[] { jsonReader.prefix },
                // enable the prefix to mention the bot
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = true
            };

            Commands = Client.UseCommandsNext(commandConfig);

            //Register custom commands <Class Name>
            Commands.RegisterCommands<TestCommands>();






            await Client.ConnectAsync();
            //Makes program run infinitely or until stopped
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
