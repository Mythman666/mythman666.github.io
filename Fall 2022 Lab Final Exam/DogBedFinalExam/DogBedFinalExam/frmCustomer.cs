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
    public partial class frmCustomer : Form
    {

        List<Customers> customersList;
        List<DogBedOrders> dogBedOrdersList;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmboCustomerName.SelectedIndex >= 0)
            {
                Form dogBedOrders = new frmDogBedOrders();
                dogBedOrders.Tag = null;
                dogBedOrders.Tag = cmboCustomerName.Text + "|" + txtEmail.Text + "|" + txtPhone.Text + "|" + "add";
                dogBedOrders.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error!");
            }
            dogBedOrdersList = DogBedDB.GetDogBedOrders();
            lstCustomerOrders.Items.Clear();
            foreach (DogBedOrders dogBedOrder in dogBedOrdersList)
            {
                if (cmboCustomerName.Text == dogBedOrder.OrderName)
                {
                    lstCustomerOrders.Items.Add(dogBedOrder.GetDisplayText());
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmboCustomerName.SelectedIndex >= 0)
            {
                Form dogBedOrders = new frmDogBedOrders();
                dogBedOrders.Tag = null;
                dogBedOrders.Tag = lstCustomerOrders.SelectedItem;
                dogBedOrders.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error!");
            }
            dogBedOrdersList = DogBedDB.GetDogBedOrders();
            lstCustomerOrders.Items.Clear();
            foreach (DogBedOrders dogBedOrder in dogBedOrdersList)
            {
                if (cmboCustomerName.Text == dogBedOrder.OrderName)
                {
                    lstCustomerOrders.Items.Add(dogBedOrder.GetDisplayText());
                }
            }
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dogBedOrdersList = DogBedDB.GetDogBedOrders();
            for (int i = 0; i < dogBedOrdersList.Count; i++)
            {
                if (dogBedOrdersList[i].GetDisplayText() == lstCustomerOrders.SelectedItem.ToString())
                {
                    dogBedOrdersList.RemoveAt(i);
                }
            }
            lstCustomerOrders.Items.RemoveAt(lstCustomerOrders.SelectedIndex);
            if (lstCustomerOrders.Items.Count <= 0)
            {
                btnDelete.Enabled = false;
            }
            DogBedDB.SaveDogBedOrders(dogBedOrdersList);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            cmboCustomerName.Items.Clear();
            customersList = DogBedDB.GetCustomers();
            foreach (Customers customer in customersList)
            {
                cmboCustomerName.Items.Add(customer.Name);
            }
            
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void cmboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmail.Text = customersList[cmboCustomerName.SelectedIndex].Email;
            txtPhone.Text = customersList[cmboCustomerName.SelectedIndex].Phone;
            dogBedOrdersList = DogBedDB.GetDogBedOrders();
            lstCustomerOrders.Items.Clear();
            for (int i=0; i<dogBedOrdersList.Count;i++)
            { 
                if (cmboCustomerName.SelectedItem.ToString() == dogBedOrdersList[i].OrderName)
                {
                    lstCustomerOrders.Items.Add(dogBedOrdersList[i].GetDisplayText());
                }
            }
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void lstCustomerOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstCustomerOrders.SelectedIndex >= 0)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }
    }
}
