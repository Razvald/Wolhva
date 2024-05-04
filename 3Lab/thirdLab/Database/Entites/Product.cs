namespace thirdLab.Database.Entites
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; } = 0;

        public int MaterialId { get; set; } = 1;
        public virtual Material Material { get; set; } = null!;
    }
}
