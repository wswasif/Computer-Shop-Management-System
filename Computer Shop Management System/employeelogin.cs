﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Computer_Shop_Management_System
{
    public partial class employeelogin : Form
    {
        public employeelogin()
        {
            InitializeComponent();
        }

        private void signup_Click(object sender, EventArgs e)
        {
            employeesignup es = new employeesignup();
            es.ShowDialog();
        }

        private void signin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-F0FMCLK\\SQLEXPRESS;database = computershop;integrated security = SSPI";
            //SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-F0FMCLK\\SQLEXPRESS;AttachDbFilename=computershop;Integrated Security=True;Connect Timeout=30;User Instance=True");
            string query = "Select * from employeesingnup Where UserID = '" + userid.Text.Trim() + "' and Password = '" + password.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            // if (dtbl.Rows.Count == 1)
            if (dtbl.Rows.Count > 0)
            {
                productdetails ed = new productdetails();
                this.Hide();
                ed.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
    }
}
