namespace Moderation_Bot__LINUX_.Tools
{
    public class ParserTool
    {
        public string Parse(string text, string start, string end)
        {
            int i = 0;
            int space = 0;

            for (; text.Substring(i, start.Length) != start; i++) ;
            for (int count = 0; count != start.Length + 1; count++) ;
            for (i += start.Length; text.Substring(i, end.Length) != end; i++)
                space++;
            string Result = text.Substring(i - space, space);

            return (Result);
        }
    }
}
