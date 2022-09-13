namespace Assignment1.Tests;

public class RegExprTests
{
    [Fact]
    public void Check_If_Returns_Corret_Strings()
    {
        // Arrange
            IEnumerable<string> myList = new List<string>()
            {"one two", "two", "three", "four five"};

            IEnumerable<string> answer = new List<string>()
            {"one", "two", "two", "three", "four", "five"};

        // Act
            var splitList = RegExpr.SplitLine(myList);

        // Assert
            Assert.Equal(answer, splitList);
    }

    [Fact]
    public void Check_If_Return_Resolution()
    {
         // Arrange
            string resolutions = "1920x1080 1024x768, 800x600, 640x480 320x200, 320x240, 800x600 1280x960";

            var tupleArray = new (int,int)[] {(1920, 1080),(1024, 768),(800, 600),(640, 480),(320, 200),(320, 240),(800, 600),(1280, 960)};

        // Act
            var resolutionList = RegExpr.Resolution(resolutions);
            
        // Assert
            
            Assert.Equal(tupleArray, resolutionList);
           
    }

    [Fact]
    public void Check_if_Return_InnerText_Without_p()
    {
        // Arrange
            var html = @"<div> <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p> </div>";
            var tag = "p";

            IEnumerable<string> answer = new List<string>()
            {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};

        // Act
            var innerTextList = RegExpr.InnerText(html,tag);

        // Assert
            Assert.Equal(answer, innerTextList);
    }

    [Fact]
    public void Check_If_Return_Url_and_Title()
    {
        // Arrange
            var html = @"<div> <p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href=""https://en.wikipedia.org/wiki/Theoretical_computer_science"" title=""Theoretical computer science"">theoretical computer science</a> and <a href=""https://en.wikipedia.org/wiki/Formal_language"" title=""Formal language"">formal language</a> </div>"  ;

            IEnumerable<(Uri,string)> answer = new List<(Uri, string)>()
            {(new Uri("https://en.wikipedia.org/wiki/Theoretical_computer_science"),"Theoretical computer science"), (new Uri("https://en.wikipedia.org/wiki/Formal_language"),"Formal language")};
        
        // Act
            var UrlList = RegExpr.Urls(html);

        // Assert
            Assert.Equal(answer,UrlList);
    }
}