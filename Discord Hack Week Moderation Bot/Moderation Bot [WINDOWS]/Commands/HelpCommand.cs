using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Moderation_Bot__WINDOWS_.Commands
{
    public class HelpCommand : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task Help()
        {
            IGuildUser guildUser = Context.User as IGuildUser;

            EmbedBuilder embedBuilder = new EmbedBuilder();

            embedBuilder.WithTitle("A list of commands has been sent to you !")
                .WithDescription(Context.User.Mention)
                .WithColor(Color.DarkRed);

            await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());

            if (guildUser.GuildPermissions.Administrator)
            {
                embedBuilder = new EmbedBuilder();

                embedBuilder.WithTitle("Here is the commands list !")
                .AddField(".ban [UserName] [DeleteMsgDay's] [Reason]", "Ban the user by deleting his messages on the number of days wanted while giving him a reason for the ban !")
                .AddField(".kick [UserName] [Reason]", "kick the user while giving him a reason for the kick !")
                .WithColor(Color.DarkRed);
            }
            else
            {
                embedBuilder = new EmbedBuilder();

                embedBuilder.WithTitle("Here is the commands list !")
                    .AddField("", "")
                    .WithColor(Color.DarkRed);
            }

            await Context.User.SendMessageAsync("", false, embedBuilder.Build());
        }
    }
}
