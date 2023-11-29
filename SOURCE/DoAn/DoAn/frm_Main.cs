using DevExpress.XtraBars;
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
    public partial class frm_Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frm_Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {

        }
        void openFormChildren(Type typeForm)
        {
            foreach(Form frm in MdiChildren)
            {
                if(frm.GetType() == typeForm)
                {
                    frm.Activate();
                    return;
                } 
            }
            Form f = (Form)Activator.CreateInstance(typeForm);
            f.MdiParent = this;
            f.Show();
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFormChildren(typeof(frm_DatMonMangDi));
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFormChildren(typeof(frm_DatMonMangDi));
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFormChildren(typeof(frm_DatMonTaiBan)); 
        }

<<<<<<< Updated upstream
        private void barButtonItem2_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            openFormChildren(typeof(frm_QL_Ban));
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFormChildren(typeof(frm_QL_NV));
=======
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFormChildren(typeof(frm_QL_LoaiMon));
        }

        private void an_ItemClick(object sender, ItemClickEventArgs e)
        {
            openFormChildren(typeof(frm_QL_Mon));
>>>>>>> Stashed changes
        }
    }
}