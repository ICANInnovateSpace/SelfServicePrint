<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebUi.aspx.cs" Inherits="WebUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>云打印</title>
<meta charset="utf-8" />
    
		<link rel="stylesheet" href="css/bootstrap.min.css" />
		<link rel="stylesheet" href="css/page.css" />
	
		<style type="text/css">
			#d {
				border: 10px solid white;
				display: inline-block;
				width: 300px;
				height: 400px;
				margin-top: 20px;
			}

			
			#logo img{
				width: 60%;
				height: 60%;
				margin-top: 10px;
			}
			
			#b {
				margin-top: 60px;
			}
			
			#b span {
				display: inline-block;
				width: 215px;
				height: 27px;
				font-size: 20px;
				background-color: #ADADAD;
			}
		    .auto-style1 {
                width: 223px;
                height: 30px;
                margin-left: 0;
            }
		    </style>

    <script type="text/javascript">
    function test(){
        //document.getElementById("FileUpload1").style.display="none";
        document.getElementById("FileUpload1").click();
        
        }
        function flash() {
            document.getElementById("Label2").innerHTMLs = document.getElementById("FileUpload1").value;
        }
    </script>
	</head>

	<body style="text-align: center;">
      
      
		<div id="bg">
			<img src="img/bg.jpg" />
		</div>
		<h1 id="title">微信自助打印</h1>
		<div id="a">
			<span id="d"> <form id="form1" runat="server">  
				<div id="logo">
					<img src="img/logo.png" />
				</div>
				<div id="b">  
                   
					<!--<span class="label label-default" id="span">-->
                     <input id="Text1" type="text"  readonly="readonly" class="auto-style1"/><br />
                    <br />
				</span></div>
				<div id="c">
                   
    
					<input class="btn btn-danger btn-lg"  id="Button1"  type="button"  value="浏览文件" onclick="FileUpload1.click()" style="font-family: 庞门正道标题体; font-size: 22px; color: #FFFFFF; font-weight: normal" height="50px" />
					<asp:Button class="btn btn-primary btn-lg" ID="Button2" runat="server" Text="上传文件" OnClick="Button1_Click" BorderStyle="Solid" Height="51px" Font-Bold="True" Font-Names="庞门正道标题体" Font-Size="22px"/>
				  
                        

 

                  </div>
			</span>
		</div>  
    <asp:Label ID="Label1" runat="server" Text="" Style="color: Red"></asp:Label>   
        <asp:FileUpload ID="FileUpload1" runat="server" onchange="Text1.value=this.value" />
      </form>
	</body>
   
</html>