using System.Threading.Tasks;

using Moderation_Bot__WINDOWS_.Handlers;

using Discord;
using Discord.Commands;

namespace Moderation_Bot__WINDOWS_.Commands.Administrators
{
    public class MuteCommand : ModuleBase<SocketCommandContext>
    {
        [Command("mute")]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        public async Task Mute(IGuildUser UserName)
        {
            await new MuteStateHandler().Mute(UserName, Context);
        }
    }
}
