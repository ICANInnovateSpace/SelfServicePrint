using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WxPayAPI;
using ThoughtWorks.QRCode.Codec;
using System.Threading;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;

public partial class PayUi : System.Web.UI.Page
{
    /**
     * 生成二维码
     * @param result 存放下单后的WxPayData
     * @param path 获取上一个页面传递过来的路径信息
     * @param pages 获取WebUi.aspx传过来的页数
     * @param url2 微信二维码的url
     * @author zcy
     */
 
    WxPayData result;
    public string path;
    private string out_trade_no1 = null;//用来接收商品号
    protected void Page_Load(object sender, EventArgs e)
    {
        //接收从WebUi.aspx传过来的pages参数
        int pages=int.Parse(Request.QueryString["pages"]);
        //本地文件的路径
        path = Request.QueryString["path"];
        NativePay nativePay = new NativePay();
        //生成扫码支付模式二url
        //page * 15 为了测试改成1
        WxPayData wx = nativePay.GetPayUrl(1, "123456789", "商品名称", "商品标记", "商品描述");
        WxPayData result = new WxPayData();
        result.SetValue("appid",wx.GetValue("appid"));
        result.SetValue("mch_id", wx.GetValue("mch_id"));
        result.SetValue("nonce_str", WxPayApi.GenerateNonceStr());
        result.SetValue("out_trade_no", wx.GetValue("out_trade_no"));
        result.SetValue("sign", wx.MakeSign());
        //为了测试，把下单后的信息输出到控制台
        System.Diagnostics.Debug.Write(result.ToXml());

        //把下单后WxPayData的对象result存到Session
        Session["result"] = result;

        //获得统一下单接口返回的二维码链接
        string url2 = wx.GetValue("code_url").ToString();
    
        //生成二维码
        CreateQRImg(url2); 
    }

    
    /**
     * 生成二维码的方法
     *@param enCodeString 存储传过来的微信支付url
     *@param Image1 显示图片的控件 
     * @param bt Bitmap的对象，存放图片信息
     * 
     */
    private void CreateQRImg(string str)
    {
        Bitmap bt;
        string enCodeString = str;
        //生成设置编码实例
        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        //设置二维码的规模，默认4
        qrCodeEncoder.QRCodeScale = 4;
        //设置二维码的版本，默认7
        qrCodeEncoder.QRCodeVersion = 7;
        //设置错误校验级别，默认中等
        qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
        //生成二维码图片
        bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);
        //二维码图片的名称
        string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
        //保存二维码图片在photos路径下
        bt.Save(Server.MapPath("~/photos/") + filename + ".jpg");
        //图片控件要显示的二维码图片路径
        this.Image1.ImageUrl = "~/photos/" + filename + ".jpg";

    }




 
}