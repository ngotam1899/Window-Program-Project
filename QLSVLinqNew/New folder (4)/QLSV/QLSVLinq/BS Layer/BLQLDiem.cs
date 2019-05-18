using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QLSVLinq.BS_Layer
{
    class BLQLDiem
    {
        public System.Data.Linq.Table<KetQua> LayDiem()
        {
            DataSet ds = new DataSet();
            QLSVDataContext qlSV = new QLSVDataContext();
            return qlSV.KetQuas;
        }

        public bool ThemDiem(string maSV, string maMon, double dgk, double dck, double dtb, bool kq, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            KetQua kh = new KetQua();
            kh.maSV = maSV;
            kh.maMon = maMon;
            kh.diemGiuaKi = dgk;
            kh.diemCuoiKi = dck;
            kh.diemTB = dtb;
            kh.ketQ = kq;
            qlSV.KetQuas.InsertOnSubmit(kh);
            qlSV.KetQuas.Context.SubmitChanges();
            return true;
        }
        public bool XoaDiem(ref string err, string MaSV, string MaMon)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = from tp in qlSV.KetQuas
                          where tp.maSV == MaSV && tp.maMon == MaMon
                          select tp;
            qlSV.KetQuas.DeleteAllOnSubmit(tpQuery);
            qlSV.SubmitChanges();
            return true;
        }
        public bool CapNhatDiem(string maSV, string maMon, double dgk, double dck, double dtb, bool kq, ref string err)
        {
            QLSVDataContext qlSV = new QLSVDataContext();
            var tpQuery = (from tp in qlSV.KetQuas
                           where tp.maMon == maMon && tp.maSV == maSV
                           select tp).SingleOrDefault();
            if (tpQuery != null)
            {
                tpQuery.diemGiuaKi = dgk;
                tpQuery.diemCuoiKi = dck;
                tpQuery.diemTB = dtb;
                tpQuery.ketQ = kq;
                qlSV.SubmitChanges();
            }
            return true;
        }
        //public List<KetQua> TimMaKetQua(string MaKetQua)
        //{

        //    QLSVDataContext qlSV = new QLSVDataContext();
        //    var tpQuery = (from tp in qlSV.KetQuas
        //                   where tp.maKetQua.Contains(MaKetQua)
        //                   select tp).ToList();
        //    return tpQuery;
        //}
        //public List<KetQua> TimTenKetQua(string TenKetQua)
        //{
        //    QLSVDataContext qlSV = new QLSVDataContext();
        //    var tpQuery = (from tp in qlSV.KetQuas
        //                   where tp.tenKetQua.Contains(TenKetQua)
        //                   select tp).ToList();
        //    return tpQuery;
        //}

        
    }
}
