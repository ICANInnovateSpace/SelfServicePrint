using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

/// <summary>
/// Down_load 的摘要说明
/// </summary>
public class Download
{
    public Download()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    private void DownloadFile(string physicalFilePath)
    {
        FileStream stream = null;
        try
        {
            stream = new FileStream(physicalFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            int bufSize = (int)stream.Length;
            byte[] buf = new byte[bufSize];

            int bytesRead = stream.Read(buf, 0, bufSize);
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            //attachment是以附件的形式下载，也可以改为online在线找开． 
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(System.IO.Path.GetFileName(physicalFilePath), System.Text.Encoding.UTF8));
            HttpContext.Current.Response.OutputStream.Write(buf, 0, bytesRead);
            HttpContext.Current.Response.End();
        }
        finally
        {
            stream.Close();
        }
    }
}