using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            LisaTabelBtn.Click += Lisa_btn_Click;
            KustutaKat.Click += Kustuta_Kategooria;
            piltbtn1.Click += otsi_fail_btn_click;
        }

        int Id;

        public void Lisakatbtn_Click(object sender, EventArgs e)
        {
            bool on = false;
            foreach (var item in KategooriaBox.Items)
            {
                if (item.ToString() == KategooriaBox.Text)
                {
                    on = true;
                }
            }
            if (on == false)
            {
                command = new SqlCommand("INSERT INTO KategooriaTabel (kategooria_nimetus) VALUES (@kat)", connect);
                connect.Open();
                command.Parameters.AddWithValue("@kat", KategooriaBox.Text);
                command.ExecuteNonQuery();
                connect.Close();
                KategooriaBox.Items.Clear();
                NaitaKategooria();
            }
            else
            {
                MessageBox.Show("Selline kategooriast on juba olemas");
            }
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
        private void Kustuta_Kategooria(object sender, EventArgs e)
        {
            if(KategooriaBox.SelectedItem != null)
            {
                string val_kat = KategooriaBox.SelectedItem.ToString();

                connect.Open();
                command = new SqlCommand("DELETE FROM KategooriaTabel WHERE kategooria_nimetus = @kat", connect);
                command.Parameters.AddWithValue("@kat", val_kat);
                command.ExecuteNonQuery();
                connect.Close();
                KategooriaBox.Items.Clear();
                NaitaKategooria();
            }
        }
        string kat;
        SaveFileDialog save;
        OpenFileDialog open;
        string extension=null;
        private void otsi_fail_btn_click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            open.InitialDirectory = @"C:\Users\opilane\Pictures";
            open.Multiselect = true;
            open.Filter = "Images Files(*.jpeg;*.png;*.jpg)|*.jpeg;*.png;*jpg";

            FileInfo open_info = new FileInfo(@"C:\Users\opilane\Pictures\"+open.FileName);
            if (open.ShowDialog()==DialogResult.OK && ToodeBox.Text!=null)
            {
                save = new SaveFileDialog();
                save.InitialDirectory = Path.GetFullPath(@"..\..\Pildid");
                extension = Path.GetExtension(open.FileName);
                save.FileName = ToodeBox.Text + Path.GetExtension(open.FileName);
                save.Filter = "Image" + Path.GetExtension(open.FileName)+"|"+Path.GetExtension(open.FileName);
                if (save.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(open.FileName, save.FileName);
                    toodepictbox.Image = Image.FromFile(save.FileName);
                }
            }
            else
            {
                MessageBox.Show("Puudub toode nimetus või");
            }
            open.ShowDialog();
        }
        private void dataGridView1_rowheader_click(object sender, DataGridViewCellMouseEventArgs e)
        {
            Id = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            ToodeBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            KogusBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            HindBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            try
            {
                toodepictbox.Image = Image.FromFile(@"..\..\Images" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());//?
            }
            catch(Exception)
            {
                MessageBox.Show("Pilt puudub");
            }
            KategooriaBox.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[5].Value;//?
        }
        
        private void Lisa_btn_Click(object sender, EventArgs e)
        {
            if (ToodeBox.Text.Trim()!=string.Empty && KogusBox.Text.Trim()!=string.Empty && HindBox.Text.Trim()!=string.Empty && KategooriaBox.SelectedItem != null)
            {
                try
                {
                    connect.Open();
                    command = new SqlCommand("SELECT Id FROM KategooriaTabel WHERE kategooria_nimetus=@kat", connect);
                    command.Parameters.AddWithValue("@kat", KategooriaBox.Text);
                    command.ExecuteNonQuery();
                    int Id = Convert.ToInt32(command.ExecuteScalar());

                    command= new SqlCommand("INSERT INTO Table (Toodenimetus,kogus,hind,pilt,KATEGOORIAD) VALUES (@tod,@kog,@hin,@pil,@kat");
                    command.Parameters.AddWithValue("@tod", ToodeBox.Text);
                    command.Parameters.AddWithValue("@kog", KogusBox.Text);
                    command.Parameters.AddWithValue("@hin", HindBox.Text);
                    command.Parameters.AddWithValue("@pil", ToodeBox.Text+".jpg");
                    command.Parameters.AddWithValue("@kat", Id);//id
                
                    command.ExecuteNonQuery();
                    
                    connect.Close();
                    NaitaAndmed();
            }
                catch (Exception)
            {
                MessageBox.Show("Andmebaasiga viga!");
            }
        }
            else
            {
                MessageBox.Show("Sisesta Andmed");
            }
        }
        
        public void NaitaAndmed()
        {
            connect.Open();

            DataTable dt_toode= new DataTable();

            adapter_table = new SqlDataAdapter("SELECT [Table].Id, [Table].Toodenimetus, [Table].kogus, [Table].hind, [Table].pilt, KategooriaTabel.kategooria_nimetus FROM [Table] INNER JOIN KategooriaTabel on [Table].KATEGOORIAD=KategooriaTabel.Id", connect);
          
            adapter_table.Fill(dt_toode);
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt_toode;
            DataGridViewComboBoxColumn combo_kat = new DataGridViewComboBoxColumn();
            combo_kat.HeaderText= "Kategooria";
            combo_kat.Name = "KategooriaColumn";
            combo_kat.DataPropertyName= "Kategooria";
            HashSet<string> uniqueCategories= new HashSet<string>();
            foreach (DataRow item in dt_toode.Rows)
            {
                string category = item["kategooria_nimetus"].ToString();
                if (!uniqueCategories.Contains(category))
                {
                    uniqueCategories.Add(category);
                    combo_kat.Items.Add(category);
                }
            }
            dataGridView1.Columns.Add(combo_kat);
            dataGridView1.Columns["kategooria_nimetus"].Visible= false;

            connect.Close();
        }

        public void NaitaKategooria()
        {
            KategooriaBox.Items.Clear();
            KategooriaBox.Text = "";
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Id, kategooria_nimetus FROM KategooriaTabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach (DataRow item in dt_kat.Rows)
            {
                if (!KategooriaBox.Items.Contains(item["kategooria_nimetus"]))
                    KategooriaBox.Items.Add(item["kategooria_nimetus"]);
                else
                {
                    command = new SqlCommand("DELETE FROM KategooriaTabel WHERE Id=@id", connect);
                    command.Parameters.AddWithValue("@Id", item["Id"]);
                    command.ExecuteNonQuery();
                }
            }
            connect.Close();
        }

        private void Kustuta(object sender, EventArgs e)
        {
            if (DGW.SelectedRows.Count > 0)
            {
                
            }
        }
    }
}
