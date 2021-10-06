using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Newtonsoft.Json;
using DiscordBot_Project_01.Commands;


namespace DiscordBot_Project_01
{
    public class Bot
    {
        public DiscordClient Client { get; private set; } //Getting the access to bot discord account
        public CommandsNextExtension Commands { get; private set; } //
        public async Task RunAsync() //To have results as the code runs in the background
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
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug
                
                };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true,
                DmHelp = false,
                
            };

            Commands = Client.UseCommandsNext(commandsConfig); //Command Handler

            Commands.RegisterCommands<MainCommands>();

            await Client.ConnectAsync(); //Sync

            await Task.Delay(-1); // 1sec Delay
        }

        private Task OnClientReady(DiscordClient c, ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
