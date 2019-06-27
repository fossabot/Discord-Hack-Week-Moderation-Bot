using System;
using System.Threading.Tasks;

using Discord;

namespace Moderation_Bot__LINUX_.Handlers
{
    public class LogsHandler
    {
        public async Task Logs(LogMessage arg)
        {
            Console.WriteLine(arg);
        }
    }
}
