using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private IFile _fileProxy;
        public Form1()
        {
            InitializeComponent();
            _fileProxy = new FileProxy(@"C:\example.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _fileProxy.Read();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _fileProxy.Write(textBox1.Text);
            MessageBox.Show("Запис додано до файлу.", "Успіх");
        }
    }
}
