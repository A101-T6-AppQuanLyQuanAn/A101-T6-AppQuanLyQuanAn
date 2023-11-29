using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DAL_BLL_QL_Mon
    {
        QL_QuanAnDataContext quanAnDataContext = new QL_QuanAnDataContext();
        public DAL_BLL_QL_Mon()
        {

        }
        public List<SANPHAM> GetDataSanPham()
        {
            var sanphams = from d in quanAnDataContext.SANPHAMs select d;
            List<SANPHAM> list_sanpham = sanphams.ToList<SANPHAM>();
            return list_sanpham;
        }

        //public bool ThemSanPham(SANPHAM DD)
        //{
        //    try
        //    {
        //        //tao san pham
        //        SANPHAM sp = new SANPHAM();

        //        sp.MASP = DD.MASP;
        //        sp.TENSP = DD.TENSP;
        //        sp.MOTA = DD.MOTA;
        //        sp.MALOAI = DD.MALOAI;
        //        sp.MANCC = DD.MANCC;
        //        sp.SOLUONG = DD.SOLUONG;
        //        sp.DONVITINH = DD.DONVITINH;
        //        sp.DONGIA = DD.DONGIA;
        //        //add
        //        quanAnDataContext.SANPHAMs.InsertOnSubmit(sp);
        //        quanAnDataContext.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //}

        //public bool XoaSanPham(string masp)
        //{
        //    try
        //    {
        //        SANPHAM sp = quanAnDataContext.SANPHAMs.Where(t => t.MASP == masp).FirstOrDefault();
        //        quanAnDataContext.SANPHAMs.DeleteOnSubmit(sp);
        //        quanAnDataContext.SubmitChanges();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }


        //}

        //public bool SuaSanPham(SANPHAM DD)
        //{
        //    try
        //    {
        //        SANPHAM sp = quanAnDataContext.SANPHAMs.Where(t => t.MASP == DD.MASP).FirstOrDefault();
        //        if (sp != null)
        //        {

        //            sp.TENSP = DD.TENSP;
        //            sp.MOTA = DD.MOTA;
        //            sp.MALOAI = DD.MALOAI;
        //            sp.MANCC = DD.MANCC;
        //            sp.SOLUONG = DD.SOLUONG;
        //            sp.DONVITINH = DD.DONVITINH;
        //            sp.DONGIA = DD.DONGIA;
        //            quanAnDataContext.SubmitChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public List<SANPHAM> TimSanPham(string keyword)
        //{
        //    List<SANPHAM> sanPhamList = new List<SANPHAM>();
        //    var sanphams = from d in quanAnDataContext.SANPHAMs
        //                   where d.TENSP.Contains(keyword) || d.MASP.Contains(keyword) || d.MOTA.Contains(keyword)
        //                   select d;
        //    sanPhamList = sanphams.ToList<SANPHAM>();
        //    return sanPhamList;
        //}

        //public List<SANPHAM> TimSanPham_Loai(string maloai)
        //{
        //    List<SANPHAM> sanPhamList = new List<SANPHAM>();
        //    var sanphams = from d in quanAnDataContext.SANPHAMs
        //                   where d.MALOAI == maloai
        //                   select d;
        //    sanPhamList = sanphams.ToList<SANPHAM>();
        //    return sanPhamList;
        //}

        //public List<SANPHAM> TimSanPham_NCC(string keyword)
        //{
        //    List<SANPHAM> sanPhamList = new List<SANPHAM>();
        //    var sanphams = from d in quanAnDataContext.SANPHAMs
        //                   where d.MANCC.Contains(keyword)
        //                   select d;
        //    sanPhamList = sanphams.ToList<SANPHAM>();
        //    return sanPhamList;
        //}
    }
}
