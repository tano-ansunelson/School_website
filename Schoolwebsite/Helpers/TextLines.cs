using System.Runtime.CompilerServices;

namespace Schoolwebsite.Helpers
{
    public static class TextLines
    {

        public static IEnumerable<string> ToLines(this string? text) 
        {
            if(string.IsNullOrEmpty(text))
            {
              return Enumerable.Empty<string>();
            }

            return text
                .Split('\n', StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Trim())
                .Where(line => line.Length > 0);




        }

    }
}
