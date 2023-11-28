using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class BLL_DAL_NhomNguoiDung
    {
        QL_QuanAnDataContext qlch = new QL_QuanAnDataContext();

        public BLL_DAL_NhomNguoiDung()
        {

        }
        public List<QL_NhomNguoiDung> GetNhomNguoiDung()
        {
            return qlch.QL_NhomNguoiDungs.Select(k => k).ToList<QL_NhomNguoiDung>();
        }

        public List<string> ListMaNhom()
        {
            return qlch.QL_NhomNguoiDungs.Select(k => k.MaNhom).ToList();
        }
    }
}
