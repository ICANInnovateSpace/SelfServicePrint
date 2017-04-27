using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;

public partial class queryOrder : System.Web.UI.Page
{
    /**
     * 为ajax提供的订单查询完整业务流程逻辑
     * @param result 用来存放WxPayData对象（提取下单后的WxPayData信息）
     * @author zcy
    */
    protected void Page_Load(object sender, EventArgs e)
    {
        //把WxPayData对象result存放到内置对象Session中，方面后面对其进行调用
        WxPayData result = (WxPayData)Session["result"];

        if (result == null)
        {
          //  System.Diagnostics.Debug.Write("result对象为空");
            Response.Write("ERROR");
        }
        else
        {
            //判断商品号是否为空
            if(result.GetValue("out_trade_no") == null || result.GetValue("out_trade_no").Equals(""))
                //是，则打印out_trade_no为空
                System.Diagnostics.Debug.Write("out_trade_no为空");
            else
            {
                //调用OrderQuery静态类的 Run(string transaction_id, string out_trade_no)方法，进行订单查询完整业务流程逻辑
                WxPayData response = OrderQuery.Run(null, result.GetValue("out_trade_no").ToString());
                //通过查询订单状态trade_state是否是SUCCESS来判断是否支付成功
                  if ("SUCCESS".Equals(response.GetValue("trade_state")))
                  {
                          //SUCCESS，则打印支付成功
                         System.Diagnostics.Debug.Write("22222222222222222222222222222222222支付成功");
                   }
                   else
                   {
                         //支付失败
                         Response.Write("ERROR");
                   }
            }
        }        
    }
}