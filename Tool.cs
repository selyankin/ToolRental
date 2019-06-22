namespace ToolsRental
{
    public sealed class Tool
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        public string Note { get; private set; }
        public string PathToPicture { get; private set; }

        public Tool() : this("", 0, 0)
        {

        }

        public Tool(string name, int price, int id, string note = null, string pathToPicture = null)
        {
            Name = name;
            Price = price;
            Id = id;
            Note = note;
            PathToPicture = pathToPicture;
        }
    }
}
