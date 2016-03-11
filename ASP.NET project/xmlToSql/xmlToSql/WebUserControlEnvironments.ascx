<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlEnvironments.ascx.cs" Inherits="xmlToSql.WebUserControlEnvironments" runat="server" %>
<style type="text/css">

        .auto-style7 {
            width: 216px;
        }
        .auto-style2 {
            width: 185px;
        }
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
        </style>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentName" runat="server" AssociatedControlID="TextBoxEnvironmentName" Text="Име на околната среда: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelEnvironmentNameError" runat="server" AssociatedControlID="TextBoxEnvironmentName" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentCostEnter" runat="server" AssociatedControlID="TextBoxEnvironmentCostEnter" Text="Цена за влизане: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentCostEnter" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelEnvironmentCostEnterError" runat="server" AssociatedControlID="TextBoxEnvironmentCostEnter" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelEnvironmentCostIn" runat="server" AssociatedControlID="TextBoxEnvironmentCostIn" Text="Цена за преминаваме: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxEnvironmentCostIn" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6">
                    <asp:Label ID="LabelEnvironmentCostInError" runat="server" AssociatedControlID="TextBoxEnvironmentCostIn" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentCostExit" runat="server" AssociatedControlID="TextBoxEnvironmentCostExit" Text="Цена за излизане: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentCostExit" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelEnvironmentCostExitError" runat="server" AssociatedControlID="TextBoxEnvironmentCostExit" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentDamage" runat="server" AssociatedControlID="TextBoxEnvironmentDamage" Text="Поети щети: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentDamage" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="LabelEnvironmentDamageError" runat="server" AssociatedControlID="TextBoxEnvironmentDamage" ForeColor="#FF5050"></asp:Label>
                </td>
            </tr>
        </table>
        <asp:Button ID="ButtonRemove" runat="server" OnClick="ButtonRemove_Click" Text="Премахни" />
        <asp:Button ID="ButtonClearData" runat="server" OnClick="ButtonClearData_Click" Text="Изчисти полетата" />
        <hr />
        
