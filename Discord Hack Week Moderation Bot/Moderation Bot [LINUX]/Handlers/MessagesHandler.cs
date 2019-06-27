using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using Moderation_Bot__LINUX_.Tools;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Moderation_Bot__LINUX_.Handlers
{
    public class MessagesHandler
    {
        public async Task Messages(SocketMessage arg, DiscordSocketClient _Client, CommandService _Service, string BotCommandPrefix)
        {
            SocketUserMessage Msg = arg as SocketUserMessage;

            int ArgPos = 0;
            try
            {
                if (Msg.Content == "" || Msg.Author.IsBot)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("[" + Msg.Timestamp.ToLocalTime().ToString().Substring(11, 8) + "] - [" + Msg.Channel + "] - [" + Msg.Author + "] - " + Msg.Content);
                }
            }
            catch (Exception)
            {
                return;
            }

            if (Msg.HasStringPrefix(BotCommandPrefix, ref ArgPos))
            {
                var Context = new SocketCommandContext(_Client, Msg);

                var result = await _Service.ExecuteAsync(Context, ArgPos, null);

                if (!result.IsSuccess)
                {
                    EmbedBuilder embedBuilder = new EmbedBuilder()
                        .WithTitle(result.ErrorReason)
                        .WithColor(Color.DarkRed);

                    await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
                }
            }
            else
            {
                if (!Directory.Exists("./Accounts"))
                {
                    Directory.CreateDirectory("./Accounts");
                }
                if (!Directory.Exists("./Logs"))
                {
                    Directory.CreateDirectory("./Logs");
                }
                if (!File.Exists("./Accounts/" + arg.Author.Id))
                {
                    File.WriteAllText("./Accounts/" + arg.Author.Id,
                        "<Username>" + arg.Author + "</>\n" +
                        "<MuteState>" + "false" + "</>\n");
                }
                string Date = DateTime.UtcNow.ToLocalTime().ToString().Substring(0, 10).Replace("/", "-");
                if (!File.Exists("./Logs/MsgLogs " + Date))
                {
                    var MsgLogs = File.Create("./Logs/MsgLogs " + Date);
                    MsgLogs.Close();
                }

                string ActualContent = File.ReadAllText("./Logs/MsgLogs " + Date);

                string NewContent = ActualContent + "\n[" + arg.Timestamp + "][" + arg.Author.Id + "][" + arg.Author + "][" + arg.Channel + "]" + arg.Content + "[]";
                byte[] Encode = UnicodeEncoding.Unicode.GetBytes(NewContent);
                NewContent = UnicodeEncoding.Unicode.GetString(Encode);

                File.WriteAllText("./Logs/MsgLogs " + Date, NewContent);

                string AccountDatas = File.ReadAllText("./Accounts/" + arg.Author.Id);
                bool MuteState = bool.Parse(new ParserTool().Parse(AccountDatas, "<MuteState>", "</>"));
                if (MuteState)
                {
                    await arg.DeleteAsync();
                }
            }
        }
    }
}
