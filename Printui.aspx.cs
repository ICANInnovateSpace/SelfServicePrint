using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
  
    protected void Page_Load(object sender, EventArgs e)
    {
        string path1 = Request.QueryString["path"];

        //测试path

        //打印路径为F:\SelfServicePrint\+文件名，的文件
        if (path1 != null)
        {
            printfirst(@"F:\selPrint\" + path1);
        }

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
            ref oMissing);

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


  

}