using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StockManageWebservice
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        DBOperation dbOperation = new DBOperation();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "获取所有用户信息")]
        public string[] selectAllUserInfo()
        {
            return dbOperation.selectAllUserInfo().ToArray();
        }

        [WebMethod(Description = "增加一条用户信息")]
        public bool insertUserInfo(string Uname, string Upwd)
        {
            return dbOperation.insertUserInfo(Uname, Upwd);
        }

        [WebMethod(Description = "注册页面增加用户注册信息")]
        public bool registerNewUser(string registerPhone, string registerPassword, string registerName, string registerId, string registerClinicName,
            string registerClinicAddress, string registerHostId, string registerSex)
        {
            return dbOperation.registerNewUser(registerPhone, registerPassword, registerName, registerId, registerClinicName,
            registerClinicAddress, registerHostId, registerSex);
        }

        [WebMethod(Description  = "增加用户诊断结果的信息")]
        public bool insertDiagnoseInfo(string Name, string Sex, string Age, string Date,
            string Color1, string Color2, string Color3, string Color4, string Color5, string Color6, string Color7,
            string Color1_1, string Color2_1, string Color3_1, string Color4_1, string Color5_1, string Color6_1, string Color7_1,
            string OtherParts, string Analyze, string Result, string Treat, string Cases, string Opinion, string Image, string Phone)
        {
            return dbOperation.insertDiagnoseInfo(Name, Sex, Age, Date, Color1, Color2,  Color3, Color4, Color5, Color6, Color7,
                Color1_1, Color2_1, Color3_1, Color4_1, Color5_1, Color6_1, Color7_1, OtherParts,  Analyze,  Result, Treat, Cases, Opinion, Image, Phone);
        }

        [WebMethod(Description = "查询最近一次用户诊断信息")]
        public string[] selectRecentUserInfo()
        {
            return dbOperation.selectRecentUserInfo().ToArray();
        }

        [WebMethod(Description = "搜索一位病人的诊断信息")]
        public string[] selectOneUserInfo(string Name)
        {
            return dbOperation.selectOneUserInfo(Name).ToArray();
        }

        [WebMethod(Description = "根据Uid搜索病人诊断信息")]
        public string[] selectUidUserInfo(string Uid)
        {
            return dbOperation.selectUidUserInfo(Uid).ToArray();
        }

        [WebMethod(Description = "根据姓名搜索病人的Uid、名字、电话、诊断日期信息")]
        public string[] selectUserNamePhoneDate(string Name)
        {
            return dbOperation.selectUserNamePhoneDate(Name).ToArray();
        }

        [WebMethod(Description = "根据电话搜索病人的Uid、名字、电话、诊断日期信息")]
        public string[] selectPhoneInfo(string Phone)
        {
            return dbOperation.selectPhoneInfo(Phone).ToArray();
        }

        [WebMethod(Description = "判断用户信息进行登录")]
        public bool loginUserInfo(string Uname, string Upwd)
        {
            return dbOperation.loginUserInfo(Uname, Upwd);
        }

        [WebMethod(Description = "判断输入用户是否存在")]
        public bool userNameIsExist(string Uname)
        {
            return dbOperation.userNameIsExist(Uname);
        }


    }
}
