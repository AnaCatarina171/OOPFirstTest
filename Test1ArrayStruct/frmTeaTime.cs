using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Ana Silva
 * ITPA 2021-10-04
 */

namespace Test1ArrayClass
{
    public partial class frmTeaTime : Form
    {

        public frmTeaTime()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTeaCategories();

        }

        public void LoadTeaCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("White");
            cmbCategory.Items.Add("Green");
            cmbCategory.Items.Add("Oolong");
            cmbCategory.Items.Add("Black");
            cmbCategory.Items.Add("Pu-Erh");
            cmbCategory.Items.Add("Herbal");

            txtItemsLeft.Text = itemsLeftCounter.ToString();
        }

        private int GetSelectedTeaIndex()
        {
            return lstTeaSales.SelectedIndex;
        }

        private Tea[] teas = new Tea[5];
        private int itemsLeftCounter = 5;
        private int teasCounter = 0;

        private void btnMakeSale_Click(object sender, EventArgs e)
        {
            int errorCounter = 0;

            Tea currentTea = new Tea();

            if (currentTea.IsValidName(txtName.Text))
            {
                currentTea.Name = txtName.Text;
                errorProvider1.SetError(txtName, null);
            }
            else
            {
                errorProvider1.SetError(txtName, "The name must be defined.");
                errorCounter++;
            }

            try
            {
                if (cmbCategory.SelectedIndex == -1)
                {
                    currentTea.Category = "";
                    errorProvider1.SetError(cmbCategory, "The category must be defined.");
                    errorCounter++;
                }
                else
                {
                    currentTea.Category = cmbCategory.SelectedItem.ToString();
                    errorProvider1.SetError(cmbCategory, null);
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(cmbCategory, ex.Message);
            }

            if (decimal.TryParse(txtWeight.Text, out decimal weight))
            {
                if (currentTea.IsValidWeight(weight))
                {
                    currentTea.Weight = weight;
                    errorProvider1.SetError(txtWeight, null);
                }
                else
                {
                    errorProvider1.SetError(txtWeight, "The weight must be a number greater than 0.");
                    errorCounter++;
                }
            }
            else
            {
                errorProvider1.SetError(txtWeight, "The weight must be a number greater than 0.");
                errorCounter++;
            }

            if (decimal.TryParse(txtCost.Text, out decimal cost))
            {
                if (currentTea.IsValidCost(cost))
                {
                    currentTea.Cost = cost;
                    errorProvider1.SetError(txtCost, null);
                }
                else
                {
                    errorProvider1.SetError(txtCost, "The cost must be a number greater than 0.");
                    errorCounter++;
                }
            }
            else
            {
                errorProvider1.SetError(txtCost, "The cost must be a number greater than 0.");
                errorCounter++;
            }

            if (errorCounter > 0)
            {
                MessageBox.Show("Invalid Order", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (currentTea.IsValid())
            {
                lstTeaSales.Items.Add(currentTea.Name);
                teas[teasCounter] = currentTea;
                teasCounter++;
                itemsLeftCounter--;
                txtItemsLeft.Text = itemsLeftCounter.ToString();
            }

            if (itemsLeftCounter == 0)
            {
                btnMakeSale.Enabled = false;
            }

            ClearForm();

        }

        public void ClearForm()
        {
            txtCost.Text = string.Empty;
            txtName.Text = string.Empty;
            txtWeight.Text = string.Empty;
            cmbCategory.SelectedIndex = -1;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            try
            {
                int currentIndex = lstTeaSales.SelectedIndex;
                string displayItem = $"{teas[currentIndex].Name}, " +
                    $"{teas[currentIndex].Category}, Cost {(teas[currentIndex].Cost):c}," +
                    $" Weight {teas[currentIndex].Weight}";
                MessageBox.Show(displayItem, "Tea", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
        }

        private void btnDisplayOrder_Click(object sender, EventArgs e)
        {
            string displayEverything = string.Empty;
            
            for (int i = 0; i < lstTeaSales.Items.Count; i++)
            {
                displayEverything += $"{teas[i].Name}, {teas[i].Category}, Cost {(teas[i].Cost):c}," +
                $" Weight {teas[i].Weight}{Environment.NewLine}";
            }

            MessageBox.Show(displayEverything, "Order Details",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
