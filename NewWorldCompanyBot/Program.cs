using System;
using System.Linq;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using NewWorldCompanyBot;

namespace NewWorldCompanBot
{
    class Program
    {
        static DiscordClient discord;
        static CommandsNextExtension commands;
        static InteractivityExtension interactivity;


        static void Main(string[] args)
        {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        static async Task MainAsync(string[] args)
        {
            string token = Environment.GetEnvironmentVariable("BOTTOKEN");
            discord = new DiscordClient(new DiscordConfiguration
            {
                Token = token,
                TokenType = TokenType.Bot
            });

            interactivity = discord.UseInteractivity(new InteractivityConfiguration());

            commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { "!" },
                CaseSensitive = false
            });

            commands.RegisterCommands<Commands>();

            var command = new Commands();

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

    }
}
