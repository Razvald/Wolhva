namespace _8Lab.Model
{
    public class DropboxFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsDirectory { get; set; }
        public long Size { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
