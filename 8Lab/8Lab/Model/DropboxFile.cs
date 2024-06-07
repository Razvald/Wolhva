// Models/DropboxFile.cs
namespace _8Lab.Model
{
    // Класс, представляющий файл или папку в Dropbox
    public class DropboxFile
    {
        // Имя файла или папки
        public string Name { get; set; }
        // Путь к файлу или папке
        public string Path { get; set; }
        // Является ли элемент папкой
        public bool IsDirectory { get; set; }
    }
}
