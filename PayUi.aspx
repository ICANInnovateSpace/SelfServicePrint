<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayUi.aspx.cs" Inherits="PayUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    	<link rel="stylesheet" href="css/bootstrap.min.css" />
			<link rel="stylesheet" href="css/page.css" />
    <title>云打印</title>
    <style type="text/css">
			#t{
				font-family: pmzd;
				font-size: 40px;
				color: white;
				text-align: center;
			}
			#code{
				text-align: center;
			}
			#code img{
				width: 200px;
			}
			#price{
				margin-top: 15px;
				text-align: center;
				font-family: pmzd;
				font-size: 25px;
				color: white;
			}
		</style>
<script type="text/javascript" src="js/jquery-3.1.1.js" ></script>
<script type="text/javascript" src="js/jquery-3.1.1.min.js" ></script>
</head>
<body>

    <form id="form1" runat="server">
 <div id="bg">
			<img src="img/bg.jpg" />
		</div>
		<h1 id="title">微信自助打印</h1>
		<h2 id="t">请扫码支付</h2>
		<div id="code">
        <asp:Image ID="Image1" runat="server" Height="166px" Width="184px" />
        &nbsp;</div>
		<div id="price">
			<p>共<asp:Label ID="lb_page" runat="server" Text="Label"></asp:Label>
                页</p>
			<p>需支付<asp:Label ID="lb_Money" runat="server" Text="Label"></asp:Label>
                元</p>
		</div>
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
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
                window.location.href = "Printui.aspx?path=<%=path%>" + "&PrintType=<%=PrintType%>" +"&PrintColor=<%=PrintColor%>" ;
            },
            error: function (xml) {
  
               
            }
      }
        );
    }

       







</script>
</body>
</html>
