using System;
using System.Threading.Tasks;

using Discord;
using Discord.WebSocket;

namespace Moderation_Bot__WINDOWS_.Handlers
{
    public class BotStateHandler
    {
        public async Task BotState(DiscordSocketClient _Client, int arg2, string BotCommandPrefix)
        {
            await _Client.SetGameAsync(BotCommandPrefix + "help | " + arg2 + "ms ~ " + DateTime.Now.ToString().Substring(0, DateTime.Now.ToString().Length - 3));
            if (arg2 < 150)
                await _Client.SetStatusAsync(UserStatus.Online);
            else
                await _Client.SetStatusAsync(UserStatus.Idle);
        }
    }
}
