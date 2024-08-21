using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot.commands
{
    public class TestCommands : BaseCommandModule
    {
        [Command("test")]
        public async Task CommandOne(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hello {ctx.User.Username}");
        }

        [Command("add")]
        public async Task Addition(CommandContext ctx, int num1, int num2)
        {
            int result = num1 + num2;
            await ctx.Channel.SendMessageAsync(result.ToString());
        }

        [Command("embed")]
        public async Task EmbedMessage(CommandContext ctx)
        {

            var message = new DiscordEmbedBuilder
            {
                Title = "This is a Discord Embed",
                Description = $"This command was executed by {ctx.User.Username}"
                //Color = DiscordColor.Blue
            };
            await ctx.Channel.SendMessageAsync(embed: message);
        }
    }
}
