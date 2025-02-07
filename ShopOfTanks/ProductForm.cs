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
    public partial class ProductForm : Form
    {
        public ProductForm(Product product)
        {
            InitializeComponent();
            
            Text = product.name;
            ProductLabel.Text = product.name;
            ProductPictureBox.Image = product.picture.Image;
            CountryLabel.Text = "Страна производства: " + product.country;
            MassaLabel.Text = "Масса танка: " + product.massa;
            PriceLabel.Text = "Цена танка: " + product.price;
            CategoryLabel.Text = "Тип танка: " + product.type;

        }
    }
}
