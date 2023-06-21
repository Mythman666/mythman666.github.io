//Xinhua Zhou
//xzhou1
//Due time:12/01/2022
//Final lab exam
//national dog bed order application

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogBedFinalExam
{
    public partial class frmDogBedOrders : Form
    {
        public frmDogBedOrders()
        {
            InitializeComponent();
        }

        List<DogBedOrders> dogBedOrdersList = new List<DogBedOrders>();
        List<DogBedProduct> dogBedProducts = new List<DogBedProduct>();

        private void frmDogBedOrders_Load(object sender, EventArgs e)
        {
            string[] customer_order = this.Tag.ToString().Split('|');
            btnAdd.Enabled = false;
            if (this.Tag.ToString().EndsWith("add"))
            {
                this.Text = "Add Dog Bed Orders";
                txtName.Text = customer_order[0];
                txtEmail.Text = customer_order[1];
                txtPhone.Text = customer_order[2];
            }
            else 
            {
                this.Text = "Update Dog Bed Orders";
                btnAdd.Text = "Update Order";
                txtName.Text = customer_order[0];
                txtEmail.Text = customer_order[1];
                txtPhone.Text = customer_order[2];
                dogBedOrdersList = DogBedDB.GetDogBedOrders();
                
                cmboDogBeds.Text = customer_order[3];
                cmboQuantity.Text = customer_order[4];
                txtPrice.Text = customer_order[5];
                txtSubtotal.Text = customer_order[6];
                txtSalesTax.Text = customer_order[7];
                txtOrderTotal.Text = customer_order[8];

                dogBedProducts = DogBedDB.GetDogBedProducts();

                foreach(DogBedProduct dogBedProduct in dogBedProducts)
                {
                    if(cmboDogBeds.Text == dogBedProduct.DogBedName)
                    {
                        for(int i=0; i<dogBedProduct.QuantityOnHand; i++)
                        {
                            cmboQuantity.Items.Add(i + 1);
                        }
                    }
                }
            }
            dogBedProducts = DogBedDB.GetDogBedProducts();

            foreach(DogBedProduct dogBedProduct in dogBedProducts)
            {
                cmboDogBeds.Items.Add(dogBedProduct.DogBedName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DogBedOrders dogBedOrder = new DogBedOrders();
            dogBedOrdersList = DogBedDB.GetDogBedOrders();
            dogBedOrder.OrderName = txtName.Text.ToString();
            dogBedOrder.OrderEmail = txtEmail.Text.ToString();
            dogBedOrder.OrderPhone = txtPhone.Text.ToString();
            dogBedOrder.OrderDogBedProduct = cmboDogBeds.Text.ToString();
            dogBedOrder.QuantityBought = Convert.ToInt16(cmboQuantity.Text);
            dogBedOrder.OrderPrice = Convert.ToDecimal(txtPrice.Text);
            dogBedOrder.Subtotal = Convert.ToDecimal(txtSubtotal.Text);
            dogBedOrder.SalesTax = Convert.ToDecimal(txtSalesTax.Text);
            dogBedOrder.OrderTotal = Convert.ToDecimal(txtOrderTotal.Text);
            dogBedOrdersList.Add(dogBedOrder);
            for(int i=0; i < dogBedOrdersList.Count; i++)
            {
                if (btnAdd.Text == "Update Order" && dogBedOrdersList[i].GetDisplayText() == this.Tag.ToString())
                {
                    dogBedOrdersList.RemoveAt(i);
                }
            }
            DogBedDB.SaveDogBedOrders(dogBedOrdersList);
            

            this.Close();
        }

        private void cmboDogBeds_SelectedIndexChanged(object sender, EventArgs e)
        {
            dogBedProducts = DogBedDB.GetDogBedProducts();
            cmboQuantity.Items.Clear();
            cmboQuantity.Text = "";
            txtSubtotal.Text = "";
            txtSalesTax.Text = "";
            txtOrderTotal.Text = "";
            for (int i = 0; i < dogBedProducts[cmboDogBeds.SelectedIndex].QuantityOnHand; i++)
            {
                cmboQuantity.Items.Add(i + 1);
            }
            txtPrice.Text = dogBedProducts[cmboDogBeds.SelectedIndex].Price.ToString();
        }

        private void cmboQuantity_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSubtotal.Text = (Convert.ToDecimal(txtPrice.Text) * Convert.ToInt16(cmboQuantity.Text)).ToString();
            txtSalesTax.Text = (Convert.ToDecimal(txtSubtotal.Text) / 10).ToString();
            txtOrderTotal.Text = (Convert.ToDecimal(txtSubtotal.Text) + Convert.ToDecimal(txtSalesTax.Text)).ToString();
            if(cmboDogBeds.Text != "" && cmboQuantity.Text != "")
            {
                btnAdd.Enabled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmboQuantity.Items.Clear();
            cmboDogBeds.Text = "";
            cmboQuantity.Text = "";
            txtPrice.Text = "";
            txtSubtotal.Text = "";
            txtSalesTax.Text = "";
            txtOrderTotal.Text = "";
            btnAdd.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
