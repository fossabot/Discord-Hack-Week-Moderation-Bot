using System.Threading.Tasks;

using Moderation_Bot__WINDOWS_.Handlers;

using Discord;
using Discord.Commands;

namespace Moderation_Bot__WINDOWS_.Commands.Administrators
{
    public class UnmuteCommand : ModuleBase<SocketCommandContext>
    {
        [Command("unmute")]
        [RequireBotPermission(GuildPermission.MuteMembers)]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        public async Task Unmute(IGuildUser UserName)
        {
            await new MuteStateHandler().Unmute(UserName, Context);
        }
    }
}
