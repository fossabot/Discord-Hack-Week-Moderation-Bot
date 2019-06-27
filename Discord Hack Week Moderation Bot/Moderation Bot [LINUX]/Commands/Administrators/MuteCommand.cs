using System.Threading.Tasks;

using Moderation_Bot__LINUX_.Handlers;

using Discord;
using Discord.Commands;

namespace Moderation_Bot__LINUX_.Commands.Administrators
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
