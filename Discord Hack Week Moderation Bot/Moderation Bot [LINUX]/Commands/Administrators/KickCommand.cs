using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Moderation_Bot__LINUX_.Commands.Administrators
{
    public class KickCommand : ModuleBase<SocketCommandContext>
    {
        [Command("kick")]
        [RequireBotPermission(GuildPermission.KickMembers)]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task Kick(IGuildUser UserName, string Reason)
        {
            await UserName.KickAsync(Reason);
            EmbedBuilder embedBuilder = new EmbedBuilder();

            embedBuilder.WithTitle("User : " + UserName.ToString() + " has been kicked for :\n" + Reason)
                .WithDescription("By " + Context.User.Mention)
                .WithColor(Color.DarkRed);

            await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
        }
    }
}
