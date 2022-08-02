using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using Newtonsoft.Json;
using DiscordBot_Project_01.Commands;
using Microsoft.Extensions.Logging;


namespace DiscordBot_Project_01
{
    public class Bot
    {
        public DiscordClient Client { get; private set; } //Getting the access to bot discord account
        public InteractivityExtension Interactivity { get; private set; } 
        
        public CommandsNextExtension Commands { get; private set; }
        public async Task RunAsync() //To have results as the code runs in the background and to respond multiple users
        {

            var json = string.Empty;
            using (var fs = File.OpenRead("config.Json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug
                
                };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            //interactivity config
            Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(2)
            });

            //cmds config
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = false,
                
            };

            Commands = Client.UseCommandsNext(commandsConfig); //Command Handler

            Commands.RegisterCommands<MainCommands>();
            Commands.RegisterCommands<GameCommands>();

            await Client.ConnectAsync(); 

            await Task.Delay(-1); // 1sec Delay
        }

        private Task OnClientReady(DiscordClient c, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
