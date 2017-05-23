<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Setting.aspx.cs" Inherits="Setting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
		<link rel="stylesheet" href="css/bootstrap.min.css" />
		<link rel="stylesheet" href="css/page.css" />

		<style type="text/css">
      body,button,div{
          margin:0;
          padding:0;
      }
			#a{
				text-align: center;
			}
			#b{
				display: inline-block;
				border: 10px solid white;
				width: 300px;
				height: 400px;
				margin-top: 20px;
			}
			#b p{
				font-family: pmzd;
				color: white;
				font-size: 25px;
			}
			#c button{
				float: left;
				width: 90px;
				height: 90px;
				background-color: #5bc0de;
				margin-left: 33px;
				font-family: pmzd;
				font-size: 30px;
			}
			#d_button{
				float: left;
				width: 90px;
				height: 90px;
				background-color: #5bc0de;
				margin-left: 33px;
				margin-top: 30px;
				font-family: pmzd;
				font-size: 30px;
			}
			#check{
				background-color: red;
			}
			#e{
				position: relative;
				margin-top: 200px;
				font-family: pmzd;
				font-size: 16px;
				color: white;
			}
			#e input{
				margin-top: 20px;
				width: 40px;
				color: black;
				text-align: center;
			}
            #e button{
                width: 212px;
                height:20px;
                margin:20px;
                font-family: pmzd;
				font-size: 30px;
				line-height: 5px;
            }
			#f button{
				width: 212px;
			    height:20px;
            
				font-family: pmzd;
				font-size: 30px;
				line-height: 5px;
			}
		    .auto-style1 {
                left: -2px;
                top: -191px;
            }
              #btn_right {
                  	float: left;
				width: 90px;
				height: 90px;
				background-color: #5bc0de;
				margin-left: 33px;
				font-family: pmzd;
				font-size: 30px;
            }
		    .auto-style2 {
                margin-bottom: 0;
            }
		</style>
	</head>
	<body><form id="form2" runat="server">
		<div id="bg">
			<img src="img/bg.jpg" />
		</div>
		<h1 id="title">微信自助打印</h1> 
		<div id="a">
			<div id="b">
				<p>请选择需要打印的规格</p>
                 
				<div id="c">
					<asp:Button   ID="Single" runat="server" OnClick="Button2_Click" Text="单面" Width="100" Height="100" BackColor="#5BC0DE" BorderColor="#46B8DA" BorderStyle="None" BorderWidth="1px" Font-Bold="True" Font-Size="23pt" ForeColor="White" Font-Names="庞门正道标题体"  />
                    &nbsp&nbsp&nbsp
					<asp:Button  ID="Double" runat="server" OnClick="Double_Click" Text="双面" Width="100" Height="100" BackColor="#5BC0DE" BorderColor="#46B8DA" BorderStyle="None" BorderWidth="1px" Font-Bold="True" Font-Size="23pt" ForeColor="White" Font-Names="庞门正道标题体" />
				</div>
                 <br />
				<div id="d">
					<asp:Button  ID="Black_White" runat="server" OnClick="Black_White_Click" Text="黑白" Width="100" Height="100" BackColor="#5BC0DE" BorderColor="#46B8DA" BorderStyle="None" BorderWidth="1px" Font-Bold="True" Font-Names="庞门正道标题体" Font-Overline="False" Font-Size="23pt" ForeColor="White" />
                    &nbsp&nbsp&nbsp
					<asp:Button  ID="Colours" runat="server" OnClick="Colours_Click" Text="彩色" Width="100" Height="100" BackColor="#5BC0DE" BorderColor="#46B8DA" BorderStyle="None" BorderWidth="1px" Font-Bold="True" Font-Size="23pt" ForeColor="White" Font-Names="庞门正道标题体" />
                   
				</div>
				<div id="e" class="auto-style1">

					打印&nbsp;<input type="text" />&nbsp;份
				
			
               <br />
                
		           
					  <div>
                      <asp:Button  runat="server" OnClick="Button1_Click" Text="确认" Width="110px"  Height="30" BackColor="#5BC0DE" BorderColor="#46B8DA" BorderStyle="None" BorderWidth="1px" Font-Bold="True" Font-Size="Larger" ForeColor="White" Font-Names="庞门正道标题体" CssClass="auto-style2" />
                  </div> 
				</div>  
                
               
             </div>
       </div>

		
         
		
	

    </form>
</body>
</html>
