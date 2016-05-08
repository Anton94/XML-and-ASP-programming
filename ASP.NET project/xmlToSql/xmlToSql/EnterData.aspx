<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterData.aspx.cs" Inherits="xmlToSql.EnterData" MaintainScrollPositionOnPostback="true" %>
<%@ Register TagPrefix="en" TagName="WebUserControlEnvironments" Src="~/WebUserControlEnvironments.ascx" runat="server" %>
<%@ Register TagPrefix="r" TagName="WebUserControlRobots" Src="~/WebUserControlRobots.ascx" runat="server" %>
<%@ Register TagPrefix="m" TagName="WebUserControlMaps" Src="~/WebUserControlMaps.ascx" runat="server" %>
<%@ Register TagPrefix="al" TagName="WebUserControlAlgorithms" Src="~/WebUserControlAlgorithms.ascx" runat="server" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 487px;
            margin-left: 43px;
            margin-right: 111px;
        }
        .auto-style2 {
            width: 185px;
        }
        .auto-style3 {
            width: 211px;
        }
        .auto-style4 {
            width: 211px;
            height: 26px;
        }
        .auto-style5 {
            width: 185px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
        </style>
</head>
<body style="margin-right: 158px">
    <form id="form1" runat="server" dir="ltr" style="font-weight: normal; width: 700px;">
        <asp:HyperLink ID="HyperLinkBackFromXMLFiles" runat="server" ForeColor="#0099FF" NavigateUrl="~/Default.aspx">Върни се обратно на началната страница</asp:HyperLink>
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Font-Size="Large" ForeColor="#0099FF" Text="Въвеждане на данни чрез форма!"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#0066CC" Text="Робо симулация"></asp:Label>
        <br />
        <hr />
        <table style="width: 100%; height: 85px;">
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="LabelSimulationName" runat="server" AssociatedControlID="TextBoxSimulationName" Text="Име на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxSimulationName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="LabelSimulationNameError" runat="server" AssociatedControlID="TextBoxSimulationName" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label1SimulationOwner" runat="server" AssociatedControlID="TextBoxSimulationOwner" Text="Собственик на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxSimulationOwner" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="LabelSimulationOwnerError" runat="server" AssociatedControlID="TextBoxSimulationOwner" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1SimulationOwnerEmail" runat="server" AssociatedControlID="TextBoxSimulationOwnerEmail" Text="Имейл на собственика: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSimulationOwnerEmail" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelSimulationOwnerEmailError" runat="server" AssociatedControlID="TextBoxSimulationOwnerEmail" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1SimulationDescription" runat="server" AssociatedControlID="TextBoxSimulationDescription" Text="Описание на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSimulationDescription" runat="server" Height="29px" TextMode="MultiLine" Width="177px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelSimulationDescriptionError" runat="server" AssociatedControlID="TextBoxSimulationDescription" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1SimulationDescription0" runat="server" AssociatedControlID="TextBoxSimulationRating" Text="Рейтинг на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSimulationRating" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelSimulationRatimgError" runat="server" AssociatedControlID="TextBoxSimulationRating" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
        <asp:Button ID="ButtonClearRoboSimulationData" runat="server" OnClick="ButtonClearRoboSimulationData_Click" Text="Изчисти данните за симулацията" />
        <hr />
        <br />
        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Околна среда"></asp:Label>
        <br />
        <asp:PlaceHolder ID="PlaceHolderEnvironments" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Button ID="ButtonAddEnvironment" runat="server" OnClick="ButtonAddEnvironment_Click" Text="Добави околна среда" />
        <br />
        <hr />
        <br />
        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Робот"></asp:Label>
        <br />
        <asp:PlaceHolder ID="PlaceHolderRobots" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Button ID="ButtonAddRobot" runat="server" OnClick="ButtonAddRobot_Click" Text="Добави робот" />
        <hr style="height: -12px" />
        <br />
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Карта"></asp:Label>
        <br />
        <asp:PlaceHolder ID="PlaceHolderMaps" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Button ID="ButtonAddMap" runat="server" OnClick="ButtonAddMap_Click" Text="Добави карта" />
        <br />
        <hr />
        <br />
        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Алгоритъм"></asp:Label>
        <br />
        <asp:PlaceHolder ID="PlaceHolderAlgorithms" runat="server"></asp:PlaceHolder>
        <br />
        <asp:Button ID="ButtonAddAlgorithm" runat="server" Text="Добави алгоритъма" OnClick="ButtonAddAlgorithm_Click" />
        <br />
        <hr />
        <br />
        <br />
        <hr />
        <asp:Button ID="ButtonSaveToDB" runat="server" OnClick="ButtonSaveToDBAndXML_Click" Text="Записване" />
        <hr />
        <br />
        <br />
        <asp:Label ID="LabelValidationStatus" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <br />
        <br />
        <hr />
        <asp:Label ID="Label18" runat="server" Font-Size="Medium" ForeColor="Red" Text="** Изчистването на данните само маха въведените стойности в полетата!"></asp:Label>
    </form>
</body>
</html>
