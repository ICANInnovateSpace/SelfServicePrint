using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Printing;
using O2S.Components.PDFRender4NET.Printing;
using O2S.Components.PDFRender4NET;

public partial class Printui : System.Web.UI.Page
{  
    /**
     * 实现打印
     * @param path1 打印路径
     * @author zcy
     */
    private System.ComponentModel.Container components;
    private Font printFont;
    private StreamReader streamToPrint;
    public string PrintType;//单双面
    public string PrintColor;//彩色黑白
    protected void Page_Load(object sender, EventArgs e)
    {
        //传递的路径
        string path1 = Request.QueryString["path"];
        //获取传递过来的单/双
        PrintType = Request.QueryString["PrintType"];
        //获取黑白/彩色
        PrintColor = Request.QueryString["PrintColor"];
        if (path1 != null)
        {
            //通过路径来获取文件对象
            System.IO.FileInfo file = new System.IO.FileInfo(@"F:\selPrint\" + path1);
            //判断文件的类型,调用对象的打印机类
            if (file.Extension == ".doc" || file.Extension == ".docx")
            {
               
                //调用printfirst进行打印
                printfirst(@"F:\selPrint\" + path1);
                //打印完后删除文件
                File.Delete(@"F:\selPrint\" + path1);
            }
            else if(file.Extension ==".pdf")
            {
                // 打印pdf文件
                printPDF(@"F:\selPrint\" + path1);
                //打印完后删除文件
                File.Delete(@"F:\selPrint\" + path1);
            }

            
        }else
        {
            Response.Write("<script>alert('请提交文件~！!')</script>");
        }
        //删除文件
        /*
        if (File.Exists(@"F:\selPrint\" + path1))
        {
           
        }
        */
       Server.Transfer("Welcome.aspx");
    }
    /**
     * 打印excel、word格式
     * @param wordFile 文件路径
     * @param appWord 定义word Application相关
     * @param defaultPrinter 默认打印机
     * @param doc Microsoft.Office.Interop.Word.Document的文件对象
     * 
     */
    public void printfirst(string path)
    {
        // 要打印的文件路径
       
        object wordFile = path;

        object oMissing = Missing.Value;

        //自定义object类型的布尔值
        object oTrue = true;
        object oFalse = false;

        object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;

        //定义WORD Application相关
        Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();

        //WORD程序不可见z
        appWord.Visible = false;
        //不弹出警告框
        appWord.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;

        //先保存默认的打印机
        string defaultPrinter = appWord.ActivePrinter;

        //打印设置属性
        PrinterSettings settings = new PrinterSettings();
        //设置打印的颜色为彩色

        if (PrintColor.Equals("1"))
        {
            settings.DefaultPageSettings.Color = true;
        }
        else
        {
            settings.DefaultPageSettings.Color = false;
        }
        
        //设置打印的单双面
        if (PrintType.Equals("0"))
        {
            settings.Duplex = Duplex.Simplex;
        }
        else
        {   //双面
            settings.Duplex = Duplex.Vertical;
        }
        


        //打开要打印的文件
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

        //设置指定的打印机
        appWord.ActivePrinter = "HP Officejet Pro X551dw Printer PCL 6 (网络)";
        if (doc != null)
        {
            //打印
            doc.PrintOut(
                ref oTrue, //此处为true,表示后台打印
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
                ref oMissing,
                ref oMissing,
                ref oMissing,
                ref oMissing,
                ref oMissing
                );
            
            //打印完关闭WORD文件
            doc.Close(ref doNotSaveChanges, ref oMissing, ref oMissing);

            //还原原来的默认打印机
            appWord.ActivePrinter = defaultPrinter;

            //退出WORD程序
            appWord.Quit(ref oMissing, ref oMissing, ref oMissing);

            doc = null;
            appWord = null;

        }

    }


    /*打印pdf*/
  
    // <param name="url">要打印的PDF路径</param>
    private void printPDF(string url)
    {
        //打开pdf文件
        PDFFile file = PDFFile.Open(url);
        PrinterSettings settings = new PrinterSettings();
        System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument();
        //设置打印机的名称
        settings.PrinterName = "HP Officejet Pro X551dw Printer PCL 6 (网络)";
        settings.PrintToFile = false;
   
        
        //设置打印的颜色为彩色
        if (PrintColor.Equals("1"))
        {
                settings.DefaultPageSettings.Color = true;
        }else
        {
            settings.DefaultPageSettings.Color = false;
        }
        
        
        //设置打印的单双面
        if(PrintType.Equals("0"))
        {
            settings.Duplex = Duplex.Simplex;
        }
        else
        {   //双面
            settings.Duplex = Duplex.Vertical;
        }
        
        //设置纸张大小（可以不设置取，取默认设置）3.90 in,  8.65 in
       // PaperSize ps = new PaperSize("Your Paper Name", config.Width, config.Height);
      //  ps.RawKind = 150; //如果是自定义纸张，就要大于118，（A4值为9，详细纸张类型与值的对照请看http://msdn.microsoft.com/zh-tw/library/system.drawing.printing.papersize.rawkind(v=vs.85).aspx）

        O2S.Components.PDFRender4NET.Printing.PDFPrintSettings pdfPrintSettings = new O2S.Components.PDFRender4NET.Printing.PDFPrintSettings(settings);
        //设置打印纸张的大小
        //pdfPrintSettings.PaperSize = ps;
        pdfPrintSettings.PageScaling = O2S.Components.PDFRender4NET.Printing.PageScaling.FitToPrinterMarginsProportional;
        //设置打印份数
        pdfPrintSettings.PrinterSettings.Copies = 1;

        
        //打印pdf
        file.Print(pdfPrintSettings);
        //关闭文件
        file.Dispose();
    }




}