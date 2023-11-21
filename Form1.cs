using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abak
{
    public partial class Form1 : Form
    {
        SqlConnection connect=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\source\repos\abak\abFolder\tooded_db.mdf;Integrated Security=True");
        SqlDataAdapter adapter_table, adapter_kategooria;
        SqlCommand command, command2;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
            NaitaKategooria();
            lisakatbtn.Click += Lisakatbtn_Click;
            LisaTabelBtn.Click += andmed_Click;
        }

        

        public void Lisakatbtn_Click(object sender, EventArgs e)
        {
            command= new SqlCommand("INSERT INTO KategooriaTabel (kategooria_nimetus) VALUES (@kat)",connect);
            connect.Open();
            command.Parameters.AddWithValue("@kat", KategooriaBox.Text);
            command.ExecuteNonQuery();
            connect.Close();
            KategooriaBox.Items.Clear();
            NaitaKategooria();
        }
        public void andmed_Click(object sender, EventArgs e)
        {
            command2 = new SqlCommand("INSERT INTO [Table] (Toodenimetus, kogus, hind) VALUES (@tod, @kog, @hin)", connect);
            connect.Open();
            command2.Parameters.AddWithValue("@tod", ToodeBox.Text);
            command2.Parameters.AddWithValue("@kog", KogusBox.Text);
            command2.Parameters.AddWithValue("@hin", HindBox.Text);
            command2.ExecuteNonQuery();
            connect.Close();
            
            NaitaAndmed();
        }
        
        public void NaitaKategooria()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT kategooria_nimetus FROM KategooriaTabel", connect);
            DataTable dt_kat= new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                KategooriaBox.Items.Add(item["kategooria_nimetus"]);
            }
            connect.Close();
        }
        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode= new DataTable();
            adapter_table = new SqlDataAdapter("SELECT * FROM [Table]", connect);
            adapter_table.Fill(dt_toode);
            dataGridView1.DataSource = dt_toode;

            connect.Close();
        }
    }
}
