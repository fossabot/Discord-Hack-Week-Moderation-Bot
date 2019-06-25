using System;
using System.Threading.Tasks;

using Discord;

namespace Moderation_Bot__WINDOWS_.Handlers
{
    public class LogsHandler
    {
        public async Task Logs(LogMessage arg)
        {
            Console.WriteLine(arg);
        }
    }
}
