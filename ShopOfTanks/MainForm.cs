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

            label = new Label();
            label.Text = name;
        }

    }


    public partial class MainForm : Form
    {
        Product[] products = new Product[5];

        public MainForm()
        {



            InitializeComponent();

            NameLabel.Visible = false;
            FiltrPanel.Height = HideButton.Height;
            HideButton.Text = "развернуть";

            products[0] = new Product("Т-34", "СССР", 32, "средний танк", 25150000);
            products[1] = new Product("Т-34(1776)", "Америка", 65, "тяжёлый танк", 32200000);
            products[2] = new Product("AMX 50 120", "Франция", 19, "тяжёлый танк", 18430000);
            products[3] = new Product("FV4005", "Великобритания", 19, "ПТ-САУ", 28250000);
            products[4] = new Product("Grile15", "Германия", 22, "ПТ-САУ", 78450000);
        }

        private void PicProduct_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            ProductForm frm = new ProductForm(pb.Tag.ToString());
            frm.Show();
        }

        private void lblProduct_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            ProductForm frm = new ProductForm(lbl.Text);
            frm.Show();
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
            for(int i=0; i < 5; i++)   
            {
                products[i].picture.Location = new Point(x, 20);
                products[i].picture.Size = new Size(171, 166);
                products[i].picture.SizeMode = PictureBoxSizeMode.Zoom;
                products[i].picture.Click += new EventHandler(PicProduct_Click);
                MainPanel.Controls.Add(products[i].picture);

                products[i].label.Location = new Point(x+35, 190);
                products[i].label.Size = new Size(53, 25);
                MainPanel.Controls.Add(products[i].label);
                x += 200;
            }
        }
    }
}
