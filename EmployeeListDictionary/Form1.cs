using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeListDictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //create new dictionary to hold Employee ID and Employee Name
        private Dictionary<int, string> dEmployee = new Dictionary<int, string>();

        //Function to load employees from the dictionary to a listbox
        private void AddEmployeesFromDictionary()
        {
            // Adding key value pair to the dictionary
            dEmployee.Add(100, "Don");
            dEmployee.Add(101, "Mary");
            dEmployee.Add(102, "Sam");
            dEmployee.Add(103, "Tom");
            dEmployee.Add(104, "Samatha");

            //binding to the ListBox
            lstNames.DisplayMember = "Value";
            lstNames.ValueMember = "Key";
            lstNames.DataSource = new BindingSource(dEmployee, null);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddEmployeesFromDictionary();
            btnSave.Enabled = false;
        }

        private void lstNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEmpName.Text = lstNames.Text;
            txtEmpID.Text = lstNames.SelectedValue.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Enable the Save button and clear out the current contents of the text boxes
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            txtEmpID.Text = "";
            txtEmpName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Verify the input information is not empty
            if(txtEmpID.Text != "" && txtEmpName.Text != "")
            {
                //Disable the Save button and Enable the Add button
                btnSave.Enabled = false;
                btnAdd.Enabled = true;

                //Add the new employee to the dictionary
                dEmployee.Add(int.Parse(txtEmpID.Text), txtEmpName.Text);

                //Update the list box with the new employees information
                lstNames.DataSource = new BindingSource(dEmployee, null);

            }
            else
            {
                MessageBox.Show("You must enter both an Employee ID and Employee Name");
            }
        }
    }
}
