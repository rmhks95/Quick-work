using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Start_but_Click(object sender, EventArgs e)
        {

            string path = PathBox.Text;

            int total = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path)).Count();
            string[] upload = new string[total];
            string line;

            StreamReader SR = new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
            for (int i = 0; i < total; i++)
            {
                line = SR.ReadLine();
                if(line != null)
                    upload[i] = line;
                
            }
            SR.Close();

            var open = File.Create(path);
            open.Close();
            using (var sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), true))
            {
                for (int i = total-1; i > -1; i--)
                {
                        sw.WriteLine(upload[i]);

                }
                sw.Close();
            }

        }
    }
}
