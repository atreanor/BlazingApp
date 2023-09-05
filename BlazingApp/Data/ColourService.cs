namespace BlazingApp.Data
{
    public class ColourService
    {
        public List<string> Colours { get; set; }

        public ColourService()
        {
            Colours = new List<string>();
            Colours.Add("Red");
            Colours.Add("Green");
            Colours.Add("Yellow");
        }

        public Task<int> GetNumberOfDifferentColoursInStock() { return Task.FromResult(Colours.Distinct().Count()); }
    }
}
