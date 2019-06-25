using System.Threading.Tasks;

using Discord;
using Discord.Commands;

namespace Moderation_Bot__WINDOWS_.Commands.Administrators
{
    public class BanCommand : ModuleBase<SocketCommandContext>
    {
        [Command("ban")]
        [RequireBotPermission(GuildPermission.BanMembers)]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task Ban(IGuildUser UserName, int SupprDay, string Reason)
        {
            await UserName.BanAsync(SupprDay, Reason);
            EmbedBuilder embedBuilder = new EmbedBuilder();

            embedBuilder.WithTitle("User : " + UserName.ToString() + " has been banned for :\n" + Reason)
                .WithDescription("By " + Context.User.Mention)
                .WithColor(Color.DarkRed);

            await Context.Channel.SendMessageAsync("", false, embedBuilder.Build());
        }
    }
}
