using System;
using System.IO;
using System.Threading.Tasks;

using Moderation_Bot__LINUX_.Tools;

using Discord;
using Discord.Commands;

namespace Moderation_Bot__LINUX_.Handlers
{
    public class MuteStateHandler
    {
        public async Task Mute(IGuildUser UserName, SocketCommandContext Context)
        {
            string AccountDatas = File.ReadAllText("./Accounts/" + UserName.Id);
            bool MuteState = bool.Parse(new ParserTool().Parse(AccountDatas, "<MuteState>", "</>"));
            if (!MuteState)
            {
                string NewAccountDatas = AccountDatas.Replace("false", "true");
                File.WriteAllText("./Accounts/" + UserName.Id, NewAccountDatas);

                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.WithTitle("User " + UserName.ToString() + " succesfully muted !")
                    .WithDescription("By " + Context.User.Mention)
                    .WithColor(Color.DarkRed);

                await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
            }
            else
            {
                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.WithTitle("User " + UserName.ToString() + " is already muted !")
                    .WithColor(Color.DarkRed);

                await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
            }
        }

        public async Task Unmute(IGuildUser UserName, SocketCommandContext Context)
        {
            string AccountDatas = File.ReadAllText("./Accounts/" + UserName.Id);
            bool MuteState = bool.Parse(new ParserTool().Parse(AccountDatas, "<MuteState>", "</>"));
            if (MuteState)
            {
                string NewAccountDatas = AccountDatas.Replace("true", "false");
                File.WriteAllText("./Accounts/" + UserName.Id, NewAccountDatas);

                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.WithTitle("User " + UserName.ToString() + " succesfully unmuted !")
                    .WithDescription("By " + Context.User.Mention)
                    .WithColor(Color.DarkRed);

                await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
            }
            else
            {
                EmbedBuilder embedBuilder = new EmbedBuilder();

                embedBuilder.WithTitle("User " + UserName.ToString() + " is already unmuted !")
                    .WithColor(Color.DarkRed);

                await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
            }
        }
    }
}