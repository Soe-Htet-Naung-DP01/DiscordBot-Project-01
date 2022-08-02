using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity.Extensions;

namespace DiscordBot_Project_01.Commands
{
    public class GameCommands : BaseCommandModule
    {
        [Command("register")]
        [Description("Register you at the adventurer guild of Bento Town")]
        public async Task Register(CommandContext ctx)
        {
            string[] classArray = { "swordman", "wizard", "healer", "thief", "explorer", "lancer", "archer" };

            await ctx.RespondAsync("Welcome to Adventurer Guild! Please Choose Your Class." +
                "\n SwordMan \n Wizard \n Healer \n Thief \n Explorer \n Lancer \n Archer ");
            
            var interactivity = ctx.Client.GetInteractivity();
            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel && x.Author == ctx.User).ConfigureAwait(false);


            if (classArray.Contains(message.Result.Content.ToLower()))
            {
                //TO DO actually assign the role/class in DB
                await ctx.Channel.SendMessageAsync("Your class is now successfully registered as " + message.Result.Content.ToLower() + "\n Thank you for registering.");
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Registeration Failed. Please Choose From Given Classes.");
            }
            

        }

        [Command("work")]
        [Description("Work a random job to earn money")]
        public async Task Work(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Hello World!").ConfigureAwait(false);
        }
    }
}
