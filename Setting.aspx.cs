using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setting : System.Web.UI.Page
{
    int PrintColor;//存储彩色/黑白
    int PrintType;//用来存储单面/双面
    int pages;//存储WebUi传递过来的页面总数
    string path;//存储WebUi传递过来的路径
    public void SetPrintColor(int PrintColor)
    {
        this.PrintColor = PrintColor;
    }
    public void SetPrintType(int PrintType)
    {
        this.PrintType = PrintType;
    }
    public int getPrintColor()
    {
        return this.PrintColor;
    }

    public int getPrintType()
    {
        return this.PrintType;
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
     
        
        //接收WebUi传递过来的pages（页面数）
        pages = int.Parse(Request.QueryString["pages"]);
        //接收WebUi传递过来的path（文件路径）
        path = Request.QueryString["path"];
      
    }
    /*
     1.处理点击单选按钮，单/双面，黑白/彩色。
     2.分别把选择的value存储到page、color中，
     3.页面的跳转跳转到PayUi.aspx，传递page，color，path，pages。
        Session["PrintType"]="0" 表示单面 "1"表示彩色
        Session["PrintColor"]="0" 表示黑白 "1"表示彩色
         
         */
    protected void Button1_Click(object sender, EventArgs e)
    {
      
        //黑白+单面
            if (Session["PrinType"] == null && Session["PrintColor"] == null)
            {
           
                    Response.Write("<script>alert('请选择单/双面，彩色/黑白')</script>");
            
            }
            else if (Session["PrintType"].Equals("0") && Session["PrintColor"].Equals("0"))
            {
                upload("0", "0");
            }
            //黑白+双面
            else if (Session["PrintType"].Equals("0") && Session["PrintColor"].Equals("1"))
            {
                upload("0", "1");
            }
            //彩色+单面
            else if (Session["PrintType"].Equals("1") && Session["PrintColor"].Equals("0"))
            {
                upload("1", "0");
            }
            //彩色+双面
            else if (Session["PrintType"].Equals("1") && Session["PrintColor"].Equals("1"))
            {
                upload("1", "1");
            }
        
        

    }
    //实现页面的跳转以及传递参数
    private void upload(string PrintType, string PrintColor)
    {
      
        string WebUi_url;

        //跳转的url以及对象需要传递的参数
        WebUi_url = "PayUi.aspx?pages=" + pages + "&path="+ path + "&PrintType="+ PrintType + "&PrintColor="+ PrintColor;

        //传递参数s
        Response.Redirect(WebUi_url);
        //Session["path"]= Server.MapPath("~/") + FileUpload1.FileName;
        //页面跳转到PayUi.aspx
        Server.Transfer("PayUi.aspx");
    }






    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["PrintType"] = "0";
       
        //单面
        SetPrintType(0);

        //设置按钮点击的背景色
        Single.BackColor=System.Drawing.Color.Gray;
        Double.BackColor = ColorTranslator.FromHtml("#5BC0DE");
      
    }

    protected void Double_Click(object sender, EventArgs e)
    {
        Session["PrintType"] = "1";
        //双面
        SetPrintType(1);
        Double.BackColor = System.Drawing.Color.Gray;
        Single.BackColor = ColorTranslator.FromHtml("#5BC0DE");

    }

    protected void Black_White_Click(object sender, EventArgs e)
    {
        Session["PrintColor"] = "0";
        //黑白
        SetPrintColor(0);
        Black_White.BackColor = System.Drawing.Color.Gray;
        Colours.BackColor = ColorTranslator.FromHtml("#5BC0DE");

    }

    protected void Colours_Click(object sender, EventArgs e)
    {
        Session["PrintColor"] = "1";
        //彩色
        SetPrintColor(1);
        Colours.BackColor = System.Drawing.Color.Gray;
        Black_White.BackColor = ColorTranslator.FromHtml("#5BC0DE");
    }
}