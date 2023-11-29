using DAL_BLL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn
{
    public partial class frm_QL_Mon : DevExpress.XtraEditors.XtraForm
    {
        DAL_BLL_QL_LoaiMon db_loaimon = new DAL_BLL_QL_LoaiMon();
        DAL_BLL_QL_Mon db_mon = new DAL_BLL_QL_Mon();   
        public frm_QL_Mon()
        {
            InitializeComponent();
            
            gridView1.OptionsBehavior.Editable = false;
            txtMa.Enabled = false;
        }

        private void frm_QL_Mon_Load(object sender, EventArgs e)
        {
            loadCbb();
            //gridView1.DataSource = db_mon.GetDataSanPham();
        }
        public void loadCbb()
        {
            var listLoai = db_loaimon.GetDataLoaisp().ToList();
            comboBox1.DataSource = listLoai;
            comboBox1.DisplayMember = "TENLOAI"; 
            comboBox1.ValueMember = "MALOAI";
        }
        private void tablePanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelControl4_Click(object sender, EventArgs e)
        {

        }

        private void labelControl7_Click(object sender, EventArgs e)
        {

        }
    }
}