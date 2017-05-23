<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    	<link rel="stylesheet" href="css/bootstrap.min.css" />
		<link rel="stylesheet" href="css/page.css" />s
    <title>云打印</title>
    <style type="text/css">
			#p1{
				color: white;
				font-size: 27px;
				text-align: center;
				margin-top: 100px;
				margin-left: -300px;
			}
			#p2{
				font-family: pmzd;
				color: white;
				font-size: 56px;
				margin-top: -20px;
				text-align: center;
				margin-bottom: -15px;
			}
			#line{
				
				text-align: center;
			}
			#line1{
				display: inline-block;
				border: 3px solid white;
				width: 800px;
			}
			#printer{
				text-align: center;
				margin-top: 12px;
			}
			#printer img{
				width: 200px;
			}
			#word{
				margin-top: 20px;
				font-family: pmzd;
				font-size: 40px;
				color: white;
				text-align: center;
			}
			#word1{
				font-family: pmzd;
				font-size: 20px;
				color: white;
				float: left;
				position: fixed;
				margin-left: 283px;
			}
			#btn{
				text-align: center;
			}
			#btn button{
				width: 200px;
				height: 40px;
				font-family: pmzd;
				font-size: 25px;
				line-height: 0px;
			}
		</style>
    
   
</head>
<body>
    <form id="form1" runat="server">
  	<div id="bg">
			<img src="img/bg.jpg" />
		</div>
		<p id="p1">欢迎使用</p>
		<p id="p2">微信自助打印系统</p>
		<div id="line">
			<span id="line1"></span>
		</div>
		<div id="word1">
			<div>支持黑白、彩印</div>
			<div>支持单、双面打印</div>
		</div>
		<div id="printer"><img src="img/打印机.png" /></div>
		<p id="word">方便·快捷·实惠</p>
		<div id="btn">
            <asp:Button ID="Button1" runat="server" Text="打印入口" BackColor="#D9534F" BorderColor="#D43F3A" BorderStyle="Solid" Font-Names="庞门正道标题体" Font-Size="Larger" ForeColor="White" Height="47px" Width="212px" OnClick="Button1_Click" />
			
		</div>
    </form>
</body>
</html>
