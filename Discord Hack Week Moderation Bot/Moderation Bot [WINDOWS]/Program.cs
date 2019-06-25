using System.Reflection;
using System.Threading.Tasks;

using Moderation_Bot__WINDOWS_.Handlers;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Moderation_Bot__WINDOWS_
{
    class Program
    {
        static void Main(string[] Args) => new Program().StartAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _Client;
        private CommandService _Service;
        private SettingsHandler _Settings;

        public async Task StartAsync()
        {
            _Client = new DiscordSocketClient();
            _Service = new CommandService();
            _Settings = new SettingsHandler();

            await _Client.LoginAsync(TokenType.Bot, _Settings.BotToken);
            await _Client.StartAsync();

            await _Service.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null); ;

            _Client.Log += _Client_Log;

            await Task.Delay(-1);
        }

        private async Task _Client_Log(LogMessage arg)
        {
            await new LogsHandler().Logs(arg);
        }
    }
}
