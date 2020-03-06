using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockManageWebservice
{
    /// <summary>
    /// 一个操作数据库的类，所有对SQLServer的操作都写在这个类中，使用的时候实例化一个然后直接调用就可以
    /// </summary>
    public class DBOperation : IDisposable
    {
        public static SqlConnection sqlCon;  //用于连接数据库

        //将下面的引号之间的内容换成上面记录下的属性中的连接字符串
        private String ConServerStr = @"Data Source=DESKTOP-FCQ5U4P;Initial Catalog=sdUser;Persist Security Info=True;User ID=sa;Password=123";

        //默认构造函数
        public DBOperation()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection();
                sqlCon.ConnectionString = ConServerStr;
                sqlCon.Open();
            }
        }

        //关闭/销毁函数，相当于Close()
        public void Dispose()
        {
            if (sqlCon != null)
            {
                sqlCon.Close();
                sqlCon = null;
            }
        }

        /// <summary>
        /// 获取所有用户的信息
        /// </summary>
        /// <returns>所有用户信息</returns>
        public List<string> selectAllUserInfo()
        {
            List<string> list = new List<string>();

            try
            {
                string sql = "select * from userInfo";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// 增加一条用户信息
        /// </summary>
        /// <param name="Uname">用户名称</param>
        /// <param name="Upwd">用户密码</param>
        public bool insertUserInfo(string Uname, string Upwd)
        {
            try
            {
                //string sql = "insert into C (Cname,Cnum) values ('" + Cname + "'," + Cnum + ")";
                string sql = "insert into userInfo (sdname, sdpwd) values ('" + Uname + "','" + Upwd + "') ";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 2.0 注册页面增加 用户注册信息
        /// </summary>
        /// <param name="registerPhone">用户手机号码，作为登录名</param>
        /// <param name="registerPassword">密码</param>
        /// <param name="registerName">用户注册姓名</param>
        /// <param name="registerId">用户身份证</param>
        /// <param name="registerClinicName">用户诊所名称</param>
        /// <param name="registerClinicAddress">用户诊所地址</param>
        /// <param name="registerHostId">用户主机编号</param>
        /// <param name="registerSex">用户性别</param>
        /// <returns></returns>
        public bool registerNewUser(string registerPhone, string registerPassword, string registerName, string registerId, string registerClinicName,
            string registerClinicAddress, string registerHostId, string registerSex)
        {
            try
            {
                string sql = "insert into userInfo (sdname, sdpwd, RegisterName, RegisterId, RegisterClinicName, RegisterClinicAddress, RegisterHostId, " +
                    "RegisterSex) values ('" + registerPhone + "','" + registerPassword + "','" + registerName + "','" + registerId + "','" + registerClinicName + "','"
                    + registerClinicAddress + "','" + registerHostId + "','" + registerSex + "')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch(Exception)
            {
                return false;
            }

        }

        ///<summary>
        ///增加用户诊断结果的信息
        ///</summary>
        ///<param name="Uname"></param>
        public bool insertDiagnoseInfo(string Name, string Sex, string Age, string Date, 
            string Color1, string Color2, string Color3, string Color4, string Color5, string Color6, string Color7, 
            string Color1_1, string Color2_1, string Color3_1, string Color4_1, string Color5_1, string Color6_1, string Color7_1, 
            string OtherParts, string Analyze, string Result, string Treat, string Cases, string Opinion, string Image, string Phone)
        {
            try
            {
                string sql = "insert into CansInfo (Name, Sex, Age, Date, Color1, Color2, Color3, Color4, Color5, Color6, Color7, "+
                    "Color1_1, Color2_1, Color3_1, Color4_1, Color5_1, Color6_1, Color7_1," +
                    "OtherParts, Analyze, Result, Treat, Cases, Opinion, Image, Phone) values ('" + Name + "','" + Sex + "','" + Age + "','" + Date + "','" + 
                    Color1 + "','" + Color2 + "','" + Color3 + "','" + Color4 + "','" + Color5 + "','" + Color6 + "','" + Color7 + "','" +
                    Color1_1 + "','" + Color2_1 + "','" + Color3_1 + "','" + Color4_1 + "','" + Color5_1 + "','" + Color6_1 + "','" + Color7_1 + "','" +
                    OtherParts + "','" + Analyze + "','" + Result + "','" + Treat + "','" + Cases + "','" + Opinion + "','" + Image + "','" + Phone + "')";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 查询最近一次的用户诊断信息
        /// </summary>
        /// <returns>返回最近一次用户的诊断信息</returns>
        public List<string> selectRecentUserInfo()
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select top 1 * from CansInfo order by Uid desc";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果信息添加到返回向量中
                    //第 0 是Uid
                    for (int i = 0; i < reader.FieldCount; i++)
                        list.Add(reader[i].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return list;
        }

        /// <summary>
        /// 搜索一位病人的诊断信息
        /// </summary>
        /// <param name="Name">搜索病人的姓名</param>
        /// <returns>返回搜索病人的诊断信息</returns>
        public List<string> selectOneUserInfo(string Name)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from CansInfo where Name = '" + Name + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果信息添加到返回向量中
                    //第 0 是Uid
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                    list.Add(reader[4].ToString());
                    list.Add(reader[5].ToString());
                    list.Add(reader[6].ToString());
                    list.Add(reader[7].ToString());
                    list.Add(reader[8].ToString());
                    list.Add(reader[9].ToString());
                    list.Add(reader[10].ToString());
                    list.Add(reader[11].ToString());
                    list.Add(reader[12].ToString());
                    list.Add(reader[13].ToString());
                    list.Add(reader[14].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// 根据Uid搜索病人诊断信息
        /// </summary>
        /// <param name="Uid"></param>
        /// <returns>返回病人诊断信息</returns>
        public List<string> selectUidUserInfo(string Uid)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from CansInfo where Uid = '" + Uid + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果信息添加到返回向量中
                    //第 0 是Uid
                    for(int i = 0; i < reader.FieldCount; i ++)
                        list.Add(reader[i].ToString());                    
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// 搜索一位病人的Uid、名字、电话、诊断日期信息
        /// </summary>
        /// <param name="Name">搜索病人的姓名</param>
        /// <returns>返回搜索病人的Uid、名字、电话、诊断日期信息</returns>
        public List<string> selectUserNamePhoneDate(string Name)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Uid, Name, Phone, Date from CansInfo where Name = '" + Name + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果信息添加到返回向量中
                    //第 0 是Uid
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());                   
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        /// <summary>
        /// 根据电话搜索病人的id，名字，电话，日期信息
        /// </summary>
        /// <param name="Phone">病人的电话</param>
        /// <returns>返回搜索病人的id，名字，电话，日期信息</returns>
        public List<string> selectPhoneInfo(string Phone)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select Uid, Name, Phone, Date from CansInfo where Phone = '" + Phone + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果信息添加到返回向量中
                    //第 0 是Uid
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                    list.Add(reader[3].ToString());
                }
                reader.Close();
                cmd.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }


        /// <summary>
        /// 判断用户信息进行登录
        /// </summary>
        /// <param name="Uname">用户名称</param>
        /// <param name="Upwd">用户密码</param>
        public bool loginUserInfo(string Uname, string Upwd)
        {
            List<string> list = new List<string>();
            try
            {              
                string sql = "select * from userInfo where sdname = '" + Uname + "'and sdpwd = '" + Upwd + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    //将结果信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();
                if (list.Count > 1)
                    return true;                
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// 判断输入的用户名是否存在
        /// </summary>
        /// <param name="Uname">输入的用户名</param>
        /// <returns></returns>
        public bool userNameIsExist(string Uname)
        {
            List<string> list = new List<string>();
            try
            {
                string sql = "select * from userInfo where sdname = '" + Uname + "'";
                SqlCommand cmd = new SqlCommand(sql, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //将结果信息添加到返回向量中
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                reader.Close();
                cmd.Dispose();              

                if (list.Count > 1)
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        

    }
}