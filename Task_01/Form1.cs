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

namespace Task_01
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MenuItemLoading_Click(object sender, EventArgs e)
        {
           openFileDialog1.FileName = "demo.txt";
           if (openFileDialog1.ShowDialog() == DialogResult.OK)
           {
                string[] fileString = File.ReadAllLines(openFileDialog1.FileName);
                int index = 0;
                ListBox listDerma = (ListBox) TbCon.TabPages[index].Controls[0];
                listDerma.Items.Clear();
                foreach (string item in fileString)
                {
                    if (item == "#")
                    {
                        index++;
                        listDerma = (ListBox) TbCon.TabPages[index].Controls[0];
                        listDerma.Items.Clear();
                    }
                    else 
                    {
                        listDerma.Items.Add(item);
                    }
                }
           }
        }

        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "demo.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                string filePath = saveFileDialog1.FileName;
                File.WriteAllText(filePath, "");
                int index = 0;
                foreach (TabPage item in TbCon.TabPages)
                { 
                    ListBox list = (ListBox) item.Controls[0];
                    string[] clist = list.Items.OfType<string>().ToArray();
                    File.AppendAllLines(filePath, clist);
                    if (index < 11) File.AppendAllText(filePath, "#\r\n");
                    index++;
                }
                MessageBox.Show("Сохранение успешно!");
            }
        }

        private void MenuItemAdd_Click(object sender, EventArgs e)
        {
            ListBox list = (ListBox) TbCon.SelectedTab.Controls[0];
            list.Items.Add(TbxInput.Text);
            TbxInput.Text = "";
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            ListBox list = (ListBox) TbCon.SelectedTab.Controls[0];
            list.Items.RemoveAt(list.SelectedIndex);
        }

        private void MenuItemChange_Click(object sender, EventArgs e)
        {
           
           ListBox list = (ListBox) TbCon.SelectedTab.Controls[0];
           list.Items[list.SelectedIndex] = TbxInput.Text;
           TbxInput.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> Dermo = new List<string> {"Январь","Февраля","Март","Апрель","Май","Июнь","Июль","Август","Сентябрь","Октябрь","Ноябрь","Декабрь"};
            foreach (string item in Dermo)
            {
                TbCon.TabPages.Add(item);
                TbCon.TabPages[TbCon.TabCount - 1].Controls.Add(new ListBox());
                TbCon.TabPages[TbCon.TabCount - 1].Controls[0].Size = new Size(TbCon.Width - 10, TbCon.Height - 10);
            }
        }
    }
}
