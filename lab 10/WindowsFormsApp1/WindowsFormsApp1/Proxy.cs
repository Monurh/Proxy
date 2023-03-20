using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    interface IFile
    {
        void Read();
        void Write(string text);
    }

    class File : IFile
    {
        private readonly string _filePath;

        public File(string filePath)
        {
            _filePath = filePath;
        }

        public void Read()
        {
            using (var reader = new StreamReader(_filePath))
            {
                MessageBox.Show(reader.ReadToEnd(), "Вміст файлу");
            }
        }

        public void Write(string text)
        {
            using (var writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(text);
            }
        }
    }

    class FileProxy : IFile
    {
        private readonly string _filePath;
        private File _file;

        public FileProxy(string filePath)
        {
            _filePath = filePath;
        }

        public void Read()
        {
            if (_file == null)
            {
                _file = new File(_filePath);
            }

            _file.Read();
        }

        public void Write(string text)
        {
            if (_file == null)
            {
                _file = new File(_filePath);
            }

            _file.Write(text);
        }
    }
}