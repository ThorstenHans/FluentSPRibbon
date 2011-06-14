namespace DotNetRocks.FluentSPRibbon
{
    public class CustomPath
    {
        public string Path { get; set; }
        public static CustomPath Build(string customPath)
        {
            return new CustomPath(){ Path = customPath};
        }
    }
}