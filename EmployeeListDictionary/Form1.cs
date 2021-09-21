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
    }
}
