using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WF_DGV
{
    public partial class MainForm : Form
    {

        public SqlConnection conn;
        public SqlTransaction transaction;

        string strconn = "data source=user-PC;Persist Security Info=false;database=MyDatabase;user id=sa;password=yourpassword;Connection Timeout=0";
        bool error = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer1.Visible = false;
            dGV_filter.DataSource = filter_bindingSource;
            string qry = "Select Names from tblSearch";
            BindGrid(qry);           
        }
      
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            #region ENTER KEY

            if (keyData == Keys.Enter || keyData == Keys.Tab)
            {
                      if (splitContainer1.Visible == true)  
                      {                        
                        try
                        {
                            if ((String.IsNullOrEmpty(dGV_search.Rows[dGV_search.CurrentCell.RowIndex].Cells[0].EditedFormattedValue.ToString()))  ) //Checks entered value is whether an integer or not..
                            {
                                dGV_search.Rows[dGV_search.CurrentCell.RowIndex].Cells[dGV_search.CurrentCell.ColumnIndex].Value = dGV_filter.CurrentCell.Value;
                                splitContainer1.Visible = false;
                                return true;
                            }
                            //IF FILTER_DGV CURRENTCELL VALUE IS NOT NULL OR EMPTY...                        

                            if (!String.IsNullOrEmpty(dGV_filter.CurrentCell.ToString()))                            
                            {
                                error = false;
                                dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, dGV_search.CurrentCell.RowIndex+1];
                                splitContainer1.Visible = false;                                
                                return true;
                            }
                        }
                        catch (Exception)
                        {
                            error = true;
                            MessageBox.Show("Name not found..");       //Show Error msg..                            
                            dGV_search.RefreshEdit();                          //Clears Current Cell Value..
                            dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, dGV_search.CurrentCell.RowIndex]; //Focus remains on the same cell..
                            splitContainer1.Visible = false;
                            return true;
                        }
                    }
             }

            #endregion

            #region DOWN ARROW KEY
            if (keyData == Keys.Down)
            {
                try
                {                    
                    if (dGV_search.ContainsFocus == true)
                    {
                        if (dGV_search.CurrentCell.ColumnIndex == 0)
                        {
                            if(splitContainer1.Visible == true)
                            {
                                if (dGV_filter.CurrentCell.RowIndex == dGV_filter.Rows.Count - 1)
                                {
                                    dGV_filter.CurrentCell = dGV_filter[dGV_filter.CurrentCell.ColumnIndex, 0];
                                }
                                else
                                {
                                    dGV_filter.CurrentCell = dGV_filter[dGV_filter.CurrentCell.ColumnIndex, dGV_filter.CurrentCell.RowIndex + 1];
                                }
                            }
                            if(splitContainer1.Visible == false)
                            {
                                if(dGV_search.CurrentCell.RowIndex == dGV_search.Rows.Count - 1)
                                {
                                    dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, 0];
                                }
                                else
                                {
                                    dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, dGV_search.CurrentCell.RowIndex + 1];
                                }
                            }
                        }
                    }
                    return true;
                }
                catch(Exception)
                {
                    MessageBox.Show("Error");
                    dGV_search.RefreshEdit();
                    dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, dGV_search.CurrentCell.RowIndex];
                }
            }
            #endregion
            
            #region UP Arrow Key

            /*UP ARROW KEY */
            if (keyData == Keys.Up)
            {
                try
                {                    
                    if (dGV_search.ContainsFocus == true)
                    {
                        if (dGV_search.CurrentCell.ColumnIndex == 0)
                        {
                            if(splitContainer1.Visible == true)
                            {
                                if (dGV_filter.CurrentCell.RowIndex == 0)
                                {
                                    dGV_filter.CurrentCell = dGV_filter[dGV_filter.CurrentCell.ColumnIndex, dGV_filter.Rows.Count - 1];
                                }
                                else
                                {
                                    dGV_filter.CurrentCell = dGV_filter[dGV_filter.CurrentCell.ColumnIndex, dGV_filter.CurrentCell.RowIndex - 1];
                                }
                            }
                            if(splitContainer1.Visible == false)
                            {
                                if(dGV_search.CurrentCell.RowIndex == 0)
                                {
                                    dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, dGV_search.Rows.Count - 1];
                                }
                                else
                                {
                                    dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, dGV_search.CurrentCell.RowIndex - 1];
                                }
                            }
                        }
                    }
                    return true;
                }
                catch(Exception)
                {
                    MessageBox.Show("Error");
                    dGV_search.RefreshEdit();
                    dGV_search.CurrentCell = dGV_search[dGV_search.CurrentCell.ColumnIndex, dGV_search.CurrentCell.RowIndex];
                }
            }
            #endregion


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void dGV_search_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox tb = e.Control as TextBox;
            e.CellStyle.BackColor = Color.Gold;
            e.CellStyle.ForeColor = Color.White;
            tb.TextChanged += tb_TextChanged;
        }

        void tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dGV_search.Rows[dGV_search.CurrentCell.RowIndex].Cells[0].EditedFormattedValue.ToString() != "")
                {
                    string qry = "Select Names from tblSearch where Names like '" + dGV_search.Rows[dGV_search.CurrentCell.RowIndex].Cells[0].EditedFormattedValue + "%'";
                    BindGrid(qry);
                    splitContainer1.Visible = true;
                }
                else
                {
                    splitContainer1.Visible = false;
                }
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        
        private void BindGrid(string qry)
        {
            try
            {
                conn = new SqlConnection(strconn);
                SqlCommand cmd = new SqlCommand(qry, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tblSearch");
                filter_bindingSource.DataSource = ds;
                filter_bindingSource.DataMember = "tblSearch";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dGV_search_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if(error == false && splitContainer1.Visible==true)
            {
                dGV_search.Rows[dGV_search.CurrentCell.RowIndex].Cells[dGV_search.CurrentCell.ColumnIndex].Value = dGV_filter.CurrentCell.Value;
                splitContainer1.Visible = false;           
            }
        }

    }
}
