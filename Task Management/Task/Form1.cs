using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Todo_List
{
    public partial class Form1: Form
    {
        DataTable todoList = new DataTable();
        bool isEditing = false;
       


        public Form1()
        {
            InitializeComponent();

            dataGridView1.DataSource = todoList;
            
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create colums
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");
            todoList.Columns.Add("Date");



            // points data grid view to our source
            dataGridView1.DataSource = todoList;
          
            
            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void newbtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            isEditing = false;
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            isEditing = true;
            textBox1.Text = todoList.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[0].ToString();
            textBox2.Text = todoList.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[1].ToString();
            dateTimePicker1.Text = todoList.Rows[dataGridView1.CurrentCell.RowIndex].ItemArray[2].ToString();


        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[dataGridView1.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex)
            {
                Console.WriteLine("error: " + ex);
            }
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text)  && string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Please fill in the field", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if(isEditing)
            {
                todoList.Rows[dataGridView1.CurrentCell.RowIndex]["Title"] = textBox1.Text;
                todoList.Rows[dataGridView1.CurrentCell.RowIndex]["Description"] = textBox2.Text;
                todoList.Rows[dataGridView1.CurrentCell.RowIndex]["Date"] = textBox2.Text;
            }
            else
            {
                todoList.Rows.Add(textBox1.Text, textBox2.Text, dateTimePicker1.Text);
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Text = "";
                
            }
        }
    }
}
