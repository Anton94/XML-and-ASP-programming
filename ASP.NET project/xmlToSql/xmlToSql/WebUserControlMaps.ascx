<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlMaps.ascx.cs" Inherits="xmlToSql.WebUserControlMaps" %>
<style type="text/css">

        .auto-style8 {
            width: 216px;
            height: 26px;
        }
        .auto-style5 {
            width: 185px;
            height: 26px;
        }
        .auto-style6 {
            height: 26px;
        }
        .auto-style7 {
            width: 216px;
        }
        .auto-style2 {
            width: 185px;
        }
        </style>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelMapName" runat="server" AssociatedControlID="TextBoxMapName" Text="Име на картата: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxMapName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="LabelMapNameError" runat="server" AssociatedControlID="TextBoxMapName" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelMapMapData" runat="server" AssociatedControlID="TextBoxMapMapData" Text="Файл: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxMapMapData" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelMapMapDataError" runat="server" AssociatedControlID="TextBoxMapMapData" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelMapDenivelation" runat="server" AssociatedControlID="TextBoxMapDenivelation" Text="Денивелация: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxMapDenivelation" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="LabelMapDenivelationError" runat="server" AssociatedControlID="TextBoxMapDenivelation" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonRemove" runat="server" OnClick="ButtonRemove_Click" Text="Премахни" />
        <asp:Button ID="ButtonClearData" runat="server" OnClick="ButtonClearData_Click" Text="Изчисти полетата" />
        <hr />
        
