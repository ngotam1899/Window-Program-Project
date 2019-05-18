using QLSV.BD_layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.BS_layer
{
    class BLAccount
    {
        DataProvider db = null;
        public BLAccount()
        {
            db = new DataProvider();
        }
        public bool Login(string userName, string passWord)
        {
            string query = "Select * From Login where userName='" + userName + "' and passWord='" + passWord + "' and Quyen='Admin'"; 
            DataTable result = db.MyExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        //public bool ChangePassAccount(string username, string newpass, string type)
        //{
        //    string query = string.Format("UPDATE Login SET passWord = N'{0}', Type =N'{1}' WHERE UserName = N'{2}'", newpass, type,username);
        //    int result = db.MyExecuteNonQuery(query);
        //    return result > 0;
        //}
        public DataTable GetAccount()
        {
            return db.MyExecuteQuery("select * from Login");
        }
        public bool DeleteAccount(string user)
        {
            string sqlString =string.Format("Delete From Login Where userName=N'{0}'",user);
            int result= db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool InsertAccount(string user,string pass,string Hoten,string GT,string phone,string email)
        {
            string sqlString =
           string.Format("Insert Login (userName ,passWord,hoTen,gioiTinh,Phone,Email,Quyen)" +
           "VALUES(N'{0}',N'{1}',N'{2}',N'{3}',N'{4}',N'{5}',N'{6}')",user,pass,Hoten,GT,phone,email,"Member");
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
        public bool UpdateAccount(string user, string pass, string Hoten, string GT, string phone, string email)
        {
            string sqlString =
            string.Format("Update Login SET passWord=N'{1}',hoTen=N'{2}',gioiTinh=N'{3}',Phone=N'{4}',Email=N'{5}' where userName=N'{0}'",user,pass,Hoten,GT,phone,email);
            int result = db.MyExecuteNonQuery(sqlString);
            return result > 0;
        }
    }
}
