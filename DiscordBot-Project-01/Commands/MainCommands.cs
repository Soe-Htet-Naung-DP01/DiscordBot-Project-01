using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;


namespace DiscordBot_Project_01.Commands
{
    public class MainCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("says 'Pong' back to you")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }
        [Command("ching")]
        [Description("You know what I'm about to say back, right?...Right?..")]
        public async Task Ching(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Chong").ConfigureAwait(false);
        }
        [Command("ding")]
        [Description("says 'Dong' back to you")]
        public async Task Ding(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Dong").ConfigureAwait(false);
        }
        [Command("add")]
        [Description("sum up two numbers")]
        [RequireRoles(RoleCheckMode.Any, "The Big Boss Bento", "Manager Bento")]
        public async Task Add(CommandContext ctx, [Description("first number")] int numOne, [Description("second number")] int numTwo)
        {
            await ctx.Channel.SendMessageAsync((numOne + numTwo).ToString()).ConfigureAwait(false);
        }

        [Command("slap")]
        [Description("slap anyone you want, go wild")]
        public async Task Slap(CommandContext ctx, string memberName)
        {
            await ctx.Channel.SendMessageAsync("Salp " + memberName).ConfigureAwait(false);
        }

    }
}
