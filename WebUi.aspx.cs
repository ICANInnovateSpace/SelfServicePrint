using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUi : System.Web.UI.Page
{
    /**
     * 文件浏览和上传文件到服务器
     * @param pages 全局变量pages为浏览文件的页数
     * 
     */
    int pages = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /**
     * 上传和跳转页面的点击事件
     * @param pagecount 统计页数
     * @param file System.IO.FileInfo文件对象
     */
    protected void Button1_Click(object sender, EventArgs e)
    {
        //判断是否有浏览文件
        if (FileUpload1.HasFile)
        {
            //将浏览的文件保持到服务器的当前位置
            FileUpload1.SaveAs(Server.MapPath("~/") + FileUpload1.FileName);
            //通过文件的路径来获取一个文件对象
            System.IO.FileInfo file = new System.IO.FileInfo(FileUpload1.PostedFile.FileName);

            //判断是否是.doc或者.docx格式的文件

           if (file.Extension == ".doc" || file.Extension == ".docx")
            {
                //是，则对该文件进行统计页数
                PageCount pagecount = new PageCount();
                pages=  pagecount.GetWordPageCount(Server.MapPath("~/") + FileUpload1.FileName);

            }
           //判断是否是.pdf格式的文件
            else if(file.Extension == ".pdf")
            {
                //是，则对该文件进行计算
                PageCount pagecount = new PageCount();
                pages = pagecount.GetPDFPageCountByDll(Server.MapPath("~/") + FileUpload1.FileName);
            }
             //通过label来显示页数
             Label1.Text = "上传成功！"+pages;
            string WebUi_url;

            //跳转的url以及对象需要传递的参数
            WebUi_url = "PayUi.aspx?pages=" +pages+"&path=" + FileUpload1.FileName;

            //传递参数
            Response.Redirect(WebUi_url);
            //Session["path"]= Server.MapPath("~/") + FileUpload1.FileName;
            //页面跳转到PayUi.aspx
            Server.Transfer("PayUi.aspx");
        }
    }
}