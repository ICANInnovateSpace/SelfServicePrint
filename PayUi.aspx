<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayUi.aspx.cs" Inherits="PayUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>云打印</title>
<script type="text/javascript" src="js/jquery-3.1.1.js" ></script>
<script type="text/javascript" src="js/jquery-3.1.1.min.js" ></script>
</head>
<body>

    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Text="请扫描以下二维码："></asp:Label>
    
    </div>
        <asp:Image ID="Image1" runat="server" Height="166px" Width="184px" />
        <br />
    </form>
    <script type="text/javascript">
    var iCount = setInterval(check, 2000);  //每隔2秒执行一次check函数。

    function check() {
      var aj=  $.ajax({
            contentType: "application/xml",
            url: "queryOrder.aspx",
            type: "POST",
            dataType: "xml",
            success: function (xml) {
               
               // bulkpdfPrint("d:/a.pdf");
                window.location.href = "Printui.aspx?path=<%=path%>" ;
            },
            error: function (xml) {
  
               
            }
      }
        );
    }

       







</script>
</body>
</html>
