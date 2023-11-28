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

namespace DoAn
{
    public partial class frm_QL_Ban : DevExpress.XtraEditors.XtraForm
    {
        QL_QuanAnDataContext ql = new QL_QuanAnDataContext();
        DAL_BLL_QLBAN qlban = new DAL_BLL_QLBAN();
        public frm_QL_Ban()
        {

            InitializeComponent();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            qlban.themban();
            loadData();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gridView = gird_Ban.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gridView != null)
            {
                if (gridView.RowCount == 0)
                {
                    MessageBox.Show("Không có bàn nào được chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int selectedRowHandle = gridView.FocusedRowHandle;
                    string maban = gridView.GetRowCellValue(selectedRowHandle, "MABAN").ToString();
                    qlban.xoaBan(maban);
                    loadData();
                }
            }
        }
        public void loadData()
        {
            gird_Ban.DataSource = qlban.getData();
        }
        private void frm_QL_Ban_Load(object sender, EventArgs e)
        {
            loadData();
            gridView1.OptionsBehavior.Editable = false;
        }

        private void gird_Ban_Click(object sender, EventArgs e)
        {

        }
    }
}
