using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DAL_BLL_QL_LoaiMon
    {
        QL_QuanAnDataContext quanAnDataContext = new QL_QuanAnDataContext();
        public DAL_BLL_QL_LoaiMon()
        {

        }
        public List<LOAISP> GetDataLoaisp()
        {
            var lsanphams = from d in quanAnDataContext.LOAISPs select d;
            List<LOAISP> list_lsanpham = lsanphams.ToList<LOAISP>();
            return list_lsanpham;
            //return quanAnDataContext.LOAISPs.Select(k => k).ToList<LOAISP>();
        }

        public void ThemLoaisp(string ma, string ten)
        {
            //tao san pham
            LOAISP sp = new LOAISP();

            sp.MALOAI = ma;
            sp.TENLOAI = ten;

            //add diem
            quanAnDataContext.LOAISPs.InsertOnSubmit(sp);
            quanAnDataContext.SubmitChanges();
        }

        public bool deleteLoaiSp(string DD)
        {
            try
            {
                LOAISP lsp = quanAnDataContext.LOAISPs.Where(t => t.MALOAI == DD).FirstOrDefault();
                quanAnDataContext.LOAISPs.DeleteOnSubmit(lsp);
                quanAnDataContext.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool SuaLoaiSanPham(LOAISP DD)
        {
            try
            {
                LOAISP sp = quanAnDataContext.LOAISPs.Where(t => t == DD).FirstOrDefault();
                if (sp != null)
                {

                    sp.TENLOAI = DD.TENLOAI;
                    quanAnDataContext.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
