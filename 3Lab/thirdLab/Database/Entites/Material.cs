namespace thirdLab.Database.Entites
{
    internal class Material
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
