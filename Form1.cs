using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace crud1
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getdata();
            //using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-N4PPTFRMS\SQLSERVER01;Initial Catalog=db1;Integrated Security=True")) ;
        }
        private void getdata()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-N4PPTFR\MSSQLSERVER01;Initial Catalog=db1;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {

            }

            SqlCommand cmd;
            cmd = new SqlCommand("select * from student3", cnn);
            DataTable dt = new DataTable();

            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            cnn.Close();

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            if (Isvalid())
            {
                // SqlConnection conn = new SqlConnection();
                // conn.ConnectionString = "Server = localhost;User id=root;database=stud;Password=1234"string connetionString;
                try
                {

                    SqlConnection cnn;
                    string connetionString;
                    connetionString = @"Data Source=DESKTOP-N4PPTFR\MSSQLSERVER01;Initial Catalog=db1;Integrated Security=True";
                    cnn = new SqlConnection(connetionString);

                    SqlCommand cmd = new SqlCommand(" INSERT INTO student3 VALUES(@rid,@Student_Name, @Father_Name, @Mother_Name, @Address, @Age, @registration_Date)", cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@rid", textbox.Text);
                    cmd.Parameters.AddWithValue("@Student_Name", studname.Text);
                    cmd.Parameters.AddWithValue("@Father_Name", fname.Text);
                    cmd.Parameters.AddWithValue("@Mother_Name", mname.Text);
                    cmd.Parameters.AddWithValue("@Address", txtadress.Text);
                    cmd.Parameters.AddWithValue("@Age", age.Text);
                    cmd.Parameters.AddWithValue("@registration_Date", reg.Text);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("new student sucessfully saved database", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                }


                getdata();
                clear1();
            }

        }
        private bool Isvalid()
        {
            if (fname.Text == string.Empty)
            {
                MessageBox.Show("Student name is required", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textbox.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            studname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            fname.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            mname.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtadress.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            age.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            reg.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void update_Click(object sender, EventArgs e)
        {
            
                try
                {
                    SqlConnection cnn;
                    string connetionString;
                    connetionString = @"Data Source=DESKTOP-N4PPTFR\MSSQLSERVER01;Initial Catalog=db1;Integrated Security=True";
                    cnn = new SqlConnection(connetionString);
                    //SqlConnection conn = new SqlConnection();
                    // conn.ConnectionString = "Server = localhost;User id=root;database=stud;Password=1234";
                    SqlCommand cmd = new SqlCommand(@"UPDATE student3 SET Student_Name=@Student_Name, Father_Name=@Father_Name, Mother_Name=@Mother_Name,
                                                       Address=@Address, Age=@Age, registration_Date=@registration_Date WHERE rid=@rid", cnn);
                    cmd.CommandType = CommandType.Text;  
                    cmd.Parameters.AddWithValue("@rid", textbox.Text);
                    cmd.Parameters.AddWithValue("@Student_Name", studname.Text);
                    cmd.Parameters.AddWithValue("@Father_Name", fname.Text);
                    cmd.Parameters.AddWithValue("@Mother_Name", mname.Text);
                    cmd.Parameters.AddWithValue("@Age", age.Text);
                    cmd.Parameters.AddWithValue("@Address", txtadress.Text);
                    cmd.Parameters.AddWithValue("@registration_Date", reg.Text);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("Update sucessfully saved database", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {

                }
                getdata();
                clear1();


            

        }

        private void Delete_Click(object sender, EventArgs e)
        {
          
            

                try
                {


                    SqlConnection cnn;
                    string connetionString;
                    connetionString = @"Data Source=DESKTOP-N4PPTFR\MSSQLSERVER01;Initial Catalog=db1;Integrated Security=True";
                    cnn = new SqlConnection(connetionString);

                    //SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = "Server = localhost;User id=root;database=stud;Password=1234";
                    SqlCommand cmd = new SqlCommand(" DELETE FROM student3 WHERE rid=@rid", cnn);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@rid", textbox.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                    MessageBox.Show("delete sucessfully saved database", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {

                }
                getdata();
                clear1();

            

        }

        private void clear_Click(object sender, EventArgs e)
        {
            clear1();


        }
        private void clear1()
        {
            textbox.Clear();
            studname.Clear();
            fname.Clear();
            mname.Clear();
            age.Clear();
            reg.Clear();
            txtadress.Clear();
        }

        private void sname_TextChanged(object sender, EventArgs e)
        {

        }

        private void fs_TextChanged(object sender, EventArgs e)
        {

        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

