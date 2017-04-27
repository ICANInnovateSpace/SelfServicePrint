using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;

public partial class ResultNotifyPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ResultNotify resultNotify = new ResultNotify(this);
        WxPayData res = resultNotify.ProcessNotify2();
        if (res.GetValue("return_code").ToString() == "SUCCESS")
        {
            //查询微信订单信息
            string paySignKey = ConfigurationManager.AppSettings["paySignKey"].ToString();
            string mch_id = ConfigurationManager.AppSettings["mch_id"].ToString();
            string appId = ConfigurationManager.AppSettings["AppId"].ToString();
            Response.Write(res.ToXml());
            Response.End();
            Server.Transfer("Printui.aspx");
        }


        Response.Write(res.ToXml());
        Response.End();
    }

  
}