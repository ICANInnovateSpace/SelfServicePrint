using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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
      this.FileUpload1.Style.Add("display", "none");
     
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
                string pdfpath = FileUpload1.FileName + ".pdf";
                ConvertWordPDF1(Server.MapPath("~/") + FileUpload1.FileName, Server.MapPath("~/") + pdfpath);
                upload(pdfpath);
            }
           //判断是否是.pdf格式的文件
            else if(file.Extension == ".pdf")
            {
                //是，则对该文件进行计算
                PageCount pagecount = new PageCount();
                pages = pagecount.GetPDFPageCountByDll(Server.MapPath("~/") + FileUpload1.FileName);
                upload(FileUpload1.FileName);
            }
            else
            {
                Response.Write("<script>alert('只允许打印.doc 、.docx、 .pdf文件~！!')</script>");
                File.Delete(@"F:\selPrint\" + FileUpload1.FileName);
            }

        }
        else
        {
            Response.Write("<script>alert('请浏览打印文件~！!')</script>");
        }

    }
    //实现页面的跳转以及传递参数
    private void upload(string pdfpath)
    {
        //通过label来显示页数
        Label1.Text = "上传成功！" + pages;
        string WebUi_url;

        //跳转的url以及对象需要传递的参数
        WebUi_url = "Setting.aspx?pages=" + pages + "&path=" + pdfpath;

        //传递参数
        Response.Redirect(WebUi_url);
        //Session["path"]= Server.MapPath("~/") + FileUpload1.FileName;
        //页面跳转到PayUi.aspx
        Server.Transfer("Setting.aspx");
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        
        //this.FileUpload1.Style.Add("display", "none");
    }


    /**word转成pdf
     * <summary> 
     * 转换word为pdf 
     * </summary> 
     * <param name="filename">doc文件路径</param> 
     * <param name="savefilename">pdf保存路径</param> 
     * 
     */
    void ConvertWordPDF1(object filename, object savefilename)
    {
        object oTrue = true;
        object oFalse = false;
        object wordFile = filename;
        object savefile = savefilename;
        object oMissing = Missing.Value;
        //定义WORD Application相关
        Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
        Object Nothing = System.Reflection.Missing.Value;
        //创建一个名为WordApp的组件对象 
        appWord = new ApplicationClass();
        //创建一个名为WordDoc的文档对象并打开 
        Microsoft.Office.Interop.Word.Document doc = appWord.Documents.Open(
            ref wordFile,
            ref oMissing,
            ref oTrue,
            ref oFalse,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing,
            ref oMissing
            );
        //设置保存的格式 
        object filefarmat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
        //保存为PDF 
        doc.SaveAs(ref savefile, ref filefarmat, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
        //关闭文档对象
        doc.Close(ref Nothing, ref Nothing, ref Nothing);
        //推出组建 
        appWord.Quit(ref Nothing, ref Nothing, ref Nothing);
        doc = null;
        appWord = null;
    }
    /**//// <summary>  
        /// 把Excel文件转换成pdf文件  
        /// </summary>  
        /// <param name="sourcePath">需要转换的文件路径和文件名称</param>  
        /// <param name="targetPath">转换完成后的文件的路径和文件名名称</param>  
        /// <returns></returns>  
        /// 
        /// 
        /// */
     //将excel文档转换成PDF格式
     /*
    private bool Convert(string sourcePath, string targetPath, XlFixedFormatType targetType)
    {
        bool result;
        object missing = Type.Missing;
        Excel.ApplicationClass application = null;
        Workbook workBook = null;
        try
        {
            application = new Excel.ApplicationClass();
            object target = targetPath;
            object type = targetType;
            workBook = application.Workbooks.Open(sourcePath, missing, missing, missing, missing, missing,
                    missing, missing, missing, missing, missing, missing, missing, missing, missing);

            workBook.ExportAsFixedFormat(targetType, target, XlFixedFormatQuality.xlQualityStandard, true, false, missing, missing, missing, missing);
            result = true;
        }
        catch
        {
            result = false;
        }
        finally
        {
            if (workBook != null)
            {
                workBook.Close(true, missing, missing);
                workBook = null;
            }
            if (application != null)
            {
                application.Quit();
                application = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        return result;
    }
    */


}