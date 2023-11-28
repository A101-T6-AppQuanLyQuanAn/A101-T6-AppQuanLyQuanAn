using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class DAL_BLL_NHANVIEN
    {
        QL_QuanAnDataContext ql = new QL_QuanAnDataContext();
        public DAL_BLL_NHANVIEN()
        {

        }
        public List<NHANVIEN> getData()
        {
            return ql.NHANVIENs.Select(k => k).ToList<NHANVIEN>();
        }


        public void themNV(string manv, string tennv, string gioitinh, string sdt, string diachi)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = manv;
            nv.TENNV = tennv;
            nv.GIOITINH = gioitinh;
            nv.SDT = sdt;
            nv.DIACHI = diachi;
            ql.NHANVIENs.InsertOnSubmit(nv);
            ql.SubmitChanges();
        }
    }
}
