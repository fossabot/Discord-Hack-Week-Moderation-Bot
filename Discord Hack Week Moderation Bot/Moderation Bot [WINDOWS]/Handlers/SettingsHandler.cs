using System.Configuration;

namespace Moderation_Bot__WINDOWS_.Handlers
{
    public class SettingsHandler
    {
        public string BotToken { get; } = ConfigurationManager.AppSettings["BotToken"];
        public string BotCommandPrefix { get; } = ConfigurationManager.AppSettings["BotCommandPrefix"];
    }
}
