namespace Assignment1;

using System.Text.RegularExpressions;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        foreach(var l in lines)
        {
            var matches = Regex.Matches(l,@"[a-zA-Z0-9]+");
             foreach(Match m in matches)
             {
                yield return m.ToString();
             }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(string resolutions)
    {
        var matches = Regex.Matches(resolutions,@"(?<width>[0-9]*)x(?<height>[0-9]*)");
        foreach(Match m in matches)
        {
           yield return (Int32.Parse(m.Groups["width"].Value), Int32.Parse(m.Groups["height"].Value)); 
        }
        
    }

    public static IEnumerable<string> InnerText(string html, string tag) 
    {
        var pattern = "<" + tag + @".*?>(?<text>.*?)<\/" + tag + ">";
        var matches = Regex.Matches(html,pattern);
        foreach(Match m in matches)
        {
            yield return Regex.Replace(m.ToString(),@"[^>](?<=\<)(.*?)(?=\>)[^<]", "");
        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        var pattern = @"(href=""(?<link>.*?)"") (title=""(?<title>.*?)"")";
        if(Regex.IsMatch(html,pattern))
        {
            var matches = Regex.Matches(html, pattern);
            foreach(Match m in matches)
            {
                yield return (new Uri(m.Groups["link"].Value), m.Groups["title"].Value); 
            }
        }
        else
        {
            InnerText(html,"a");
        }

    }
}