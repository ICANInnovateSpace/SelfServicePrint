<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebUi.aspx.cs" Inherits="WebUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>云打印</title>
</head>
<body>
   <form id="form1" runat="server">  
    <asp:FileUpload ID="FileUpload1" runat="server" />  
    <asp:Button ID="Button1" runat="server" Text="确认" OnClick="Button1_Click" style="height: 27px" />  
    <asp:Label ID="Label1" runat="server" Text="" Style="color: Red"></asp:Label>  
    </form>  
   

</body>
</html>
