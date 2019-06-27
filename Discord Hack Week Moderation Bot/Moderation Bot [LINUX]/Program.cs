using System.Reflection;
using System.Threading.Tasks;

using Moderation_Bot__LINUX_.Handlers;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Moderation_Bot__LINUX_
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

            await _Service.AddModulesAsync(assembly: Assembly.GetEntryAssembly(), services: null);

            _Client.Log += _Client_Log;
            _Client.LatencyUpdated += _Client_LatencyUpdated;
            _Client.MessageReceived += _Client_MessageReceived;

            await Task.Delay(-1);
        }

        private async Task _Client_Log(LogMessage arg)
        {
            await new LogsHandler().Logs(arg);
        }

        private async Task _Client_LatencyUpdated(int arg1, int arg2)
        {
            await new BotStateHandler().BotState(_Client, arg2, _Settings.BotCommandPrefix);
        }

        private async Task _Client_MessageReceived(SocketMessage arg)
        {
            await new MessagesHandler().Messages(arg, _Client, _Service, _Settings.BotCommandPrefix);
        }
    }
}
