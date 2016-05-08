<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="xmlToSql.Default"  MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="ImageProfile" runat="server" Height="217px" ImageUrl="~/resources/profile_pic.jpg" Width="274px" />
        <br />
        <asp:Label ID="LabelName" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#3333CC" Text="Антон Василев Дудов"></asp:Label>
        <br />
        <asp:Label ID="LabelFnCourse" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#3333CC" Text="№71488, курс 3"></asp:Label>
        <br />
        <asp:Label ID="LabelFnCourse0" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#3333CC" Text="спец. Информационни системи"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelFnCourse1" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="#3333CC" Text="курс ASP Програмиране"></asp:Label>
        <br />
        <asp:Label ID="LabelFnCourse2" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="#3333CC" Text="тема Симулация на роботи"></asp:Label>
        <br />
        <br />
    
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddXMLFiles.aspx" Font-Bold="True" Font-Size="Large" ForeColor="#009933">Въвеждане на данни чрез XML документи</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/EnterData.aspx" Font-Bold="True" Font-Size="Large" ForeColor="#0099FF">Въвеждане на данни чрез форма</asp:HyperLink>
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="LabelFnCourse3" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium" ForeColor="#3333CC" Text="София, 2016"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
