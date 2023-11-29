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
using DevExpress.XtraGrid.Views.Grid;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAn
{
    public partial class frm_QL_LoaiMon : DevExpress.XtraEditors.XtraForm
    {
        DAL_BLL_QL_LoaiMon db = new DAL_BLL_QL_LoaiMon();
        public frm_QL_LoaiMon()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;
            gridControl1.Click += GridControl1_Click;
        }

        private void GridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                object maloaiValue = gridView1.GetFocusedRowCellValue("MALOAI");
                string maloaiString = maloaiValue != null ? maloaiValue.ToString() : null;
                if (!string.IsNullOrEmpty(maloaiString))
                {
                    textEdit1.Text = gridView1.GetFocusedRowCellValue("MALOAI").ToString();
                    textEdit2.Text = gridView1.GetFocusedRowCellValue("TENLOAI").ToString();
                }    
            } 
            catch (Exception ex)
            {

            }
        }

        

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult n = MessageBox.Show("Bạn có chắc muốn thêm: " + textEdit2.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (n == DialogResult.Yes) {
                try
                {
                    int so = 0;
                    string[] soma = new string[2];
                    if (gridView1 != null && gridView1.RowCount > 0)
                    {

                        // Lấy giá trị của cột đầu tiên từ dòng cuối cùng
                        object value = gridView1.GetRowCellValue(gridView1.RowCount - 1, "MALOAI");

                        // Kiểm tra giá trị có null không (tránh trường hợp không có dữ liệu)
                        if (value != null)
                        {
                            soma = value.ToString().Split(new char[] { '.' });
                            so = Convert.ToInt32(soma[1]) + 1;
                        }
                    }
                    db.ThemLoaisp(soma[0] + "." + so.ToString(), textEdit2.Text);
                    gridControl1.DataSource = db.GetDataLoaisp();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frm_QL_LoaiMon_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.GetDataLoaisp();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(!string.IsNullOrEmpty(textEdit1.Text)) { 
                LOAISP sp = new LOAISP();
                sp.MALOAI = textEdit1.Text;
                sp.TENLOAI = textEdit2.Text;
                db.SuaLoaiSanPham(sp);
                gridControl1.DataSource = db.GetDataLoaisp();
            } else
            {
                MessageBox.Show("Vui lòng chọn một loại món", "Thông báo");
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textEdit1.Text))
            {
                DialogResult n = MessageBox.Show("Bạn có chắc muốn xóa: " + textEdit2.Text, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (n == DialogResult.Yes)
                {
                    db.deleteLoaiSp(textEdit1.Text);
                    gridControl1.DataSource = db.GetDataLoaisp();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một loại món", "Thông báo");
            }
        }
    }
}