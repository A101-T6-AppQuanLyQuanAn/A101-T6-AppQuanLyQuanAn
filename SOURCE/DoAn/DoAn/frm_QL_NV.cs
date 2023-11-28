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
using DAL_BLL;
namespace DoAn
{
    public partial class frm_QL_NV : DevExpress.XtraEditors.XtraForm
    {

        QL_QuanAnDataContext ql = new QL_QuanAnDataContext();
        DAL_BLL_NHANVIEN qlnv = new DAL_BLL_NHANVIEN();
        public frm_QL_NV()
        {
            InitializeComponent();
        }

        private void frm_QL_NV_Load(object sender, EventArgs e)
        {

        }
        public void loadData()
        {
            gridControl1.DataSource = qlnv.getData();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int so = 0;
            string[] soma = new string[2];
            if (gridView1 != null && gridView1.RowCount > 0)
            {

                // Lấy giá trị của cột đầu tiên từ dòng cuối cùng
                object value = gridView1.GetRowCellValue(gridView1.RowCount - 1, "MANV");

                // Kiểm tra giá trị có null không (tránh trường hợp không có dữ liệu)
                if (value != null)
                {
                    soma = value.ToString().Split(new char[] { '.' });
                    so = Convert.ToInt32(soma[1]) + 1;
                }
            }
            string mamoi = soma[0] + "." + so.ToString();

            txtmanhanvien.Text = mamoi.ToString();
            txtmanhanvien.Enabled = false;

        }
    }
}