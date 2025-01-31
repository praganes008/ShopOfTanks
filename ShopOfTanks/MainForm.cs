using ShopOfTanks.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopOfTanks
{

    public struct Product
    {
        public string name;
        public string country;
        public int massa;
        public string type;
        public int price;
        public PictureBox picture;
        public Label label;

        public Product(string _name, string _country, int _massa, string _type, int _price)
        {
            name = _name;
            country = _country;
            massa = _massa;
            type = _type;
            price = _price;
            picture = new PictureBox();
            try
            {
                picture.Load("../../Pictures/" + name + ".jpeg");
            }
            catch (Exception) { }

            picture.Tag = name;

            label = new Label();
            label.Text = name;
        }

    }


    public partial class MainForm : Form
    {
        Product[] products = new Product[8];

        public MainForm()
        {



            InitializeComponent();

            NameLabel.Visible = false;
            FiltrPanel.Height = HideButton.Height;
            HideButton.Text = "развернуть";

            products[0] = new Product("Т-34", "СССР", 32, "средний танк", 25150000);
            products[1] = new Product("Т34(1776)", "Америка", 65, "тяжёлый танк", 32200000);
            products[2] = new Product("AMX 50 120", "Франция", 19, "тяжёлый танк", 18430000);
            products[3] = new Product("FV4005", "Великобритания", 19, "ПТ-САУ", 28250000);
            products[4] = new Product("Grille15", "Германия", 22, "ПТ-САУ", 78450000);
            products[5] = new Product("СТ-1", "СССР", 34, "тяжёлый танк", 56000000);
            products[6] = new Product("Jg. Pz. E100", "Германия", 98, "ПТ-САУ", 1000000000);
            products[7] = new Product("Progetto 65", "Италия", 23, "средний танк", 28450000);

        }

        private void PicProduct_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            for(int i = 0; i<5; i++)
            {
                if(pb.Tag.ToString() == products[i].name)
                {
                       ProductForm frm = new ProductForm(products[i]);
                       frm.Show();
                }
            }
            
        }

        private void lblProduct_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            for (int i = 0; i < 8; i++)
            {
                if (lbl.Text == products[i].name)
                {
                   ProductForm frm = new ProductForm(products[i]);
                    frm.Show(); 
                }
            }
            
        }

        private void HideButton_Click(object sender, EventArgs e)
        {
            if (FiltrPanel.Height == HideButton.Height)
            {
                FiltrPanel.Height = 128;
                HideButton.Text = "свернуть";
            }
            else
            {
                FiltrPanel.Height = HideButton.Height;
                HideButton.Text = "развернуть";
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            RegForm frm = new RegForm();
            frm.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int x = 30;
            int y = 25;
            for(int i=0; i < 8; i++)   
            {
                products[i].picture.Location = new Point(x, y);
                products[i].picture.Size = new Size(171, 166);
                products[i].picture.SizeMode = PictureBoxSizeMode.Zoom;
                products[i].picture.Click += new EventHandler(PicProduct_Click);
                MainPanel.Controls.Add(products[i].picture);

                products[i].label.Location = new Point(x+35, y+185);
                products[i].label.Size = new Size(103, 25);
                products[i].label.Click += new EventHandler(lblProduct_Click);
                MainPanel.Controls.Add(products[i].label);
                x += 200;
                if(x+171 > MainPanel.Width)
                {
                    x = 30;
                    y = 225;
                }
            }
        }
    }
}
