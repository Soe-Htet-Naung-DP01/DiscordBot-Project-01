using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Newtonsoft.Json;

namespace DiscordBot_Project_01.Commands
{
    public class MainCommands : BaseCommandModule
    {
        [Command("greet")]
        [Description("Says the classic programming nerd line")]
        public async Task Greet(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Hello World!").ConfigureAwait(false);
        }

        [Command("ping")]
        [Description("says 'Pong' back to you")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }
        [Command("stupid")]
        [Description("You know what I'm about to say back, right?...Right?..")]
        public async Task Ching(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("No, You are.").ConfigureAwait(false);
        }
        [Command("Hello")]
        [Description("Greets back to you")]
        public async Task Hello(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Hello there, Human. Nice to meet  you! beep bop").ConfigureAwait(false);
        }
        //[Command("add")]
        //[Description("sum up two numbers")]
        //[RequireRoles(RoleCheckMode.Any, "The Big Boss Bento", "Manager Bento")]
        //public async Task Add(CommandContext ctx, [Description("first number")] int numOne, [Description("second number")] int numTwo)
        //{
        //    await ctx.Channel.SendMessageAsync((numOne + numTwo).ToString()).ConfigureAwait(false);
        //}

        [Command("slap")]
        [Description("slap anyone you want, go wild")]
        public async Task Slap(CommandContext ctx, string memberName)
        {
            await ctx.Channel.SendMessageAsync("You  Slapped " + memberName + " so hard that their teeth came off").ConfigureAwait(false);
        }

        //[Command("prefix")]
        //[Description("Change Prefix to desired one")]
        //public async Task ChangePrefix(CommandContext ctx, string newPrefix)
        //{
        //    //assign it later
        //   // await ctx.Channel.SendMessageAsync("Hello World!").ConfigureAwait(false);
        //}
    }
}
