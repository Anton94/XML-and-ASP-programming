<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="xmlToSql.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <add name=“ASP.NET v4.0“ autoStart=“true“ managedRuntimeVersion=“v4.0“ managedPipelineMode=“Integrated“>
   
    
        <asp:Button ID="ButtonAddXMLFiles" runat="server" OnClick="ButtonAddXMLFiles_Click" Text="Add the xml files" />
        <asp:Button ID="ButtonDeleteAllData" runat="server" OnClick="ButtonDeleteAllData_Click" Text="Delete all data" />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="RoboSimulationSqlDataSource" ForeColor="#333333" GridLines="None" style="margin-right: 0px; margin-top: 11px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="simulation_name" HeaderText="simulation_name" SortExpression="simulation_name" />
                <asp:BoundField DataField="simulation_owner" HeaderText="simulation_owner" SortExpression="simulation_owner" />
                <asp:BoundField DataField="simulation_owner_email" HeaderText="simulation_owner_email" SortExpression="simulation_owner_email" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="id" DataSourceID="RobotSqlDataSource">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="travel_cost_enter" HeaderText="travel_cost_enter" SortExpression="travel_cost_enter" />
                <asp:BoundField DataField="travel_cost_in" HeaderText="travel_cost_in" SortExpression="travel_cost_in" />
                <asp:BoundField DataField="travel_cost_exit" HeaderText="travel_cost_exit" SortExpression="travel_cost_exit" />
                <asp:BoundField DataField="damage" HeaderText="damage" SortExpression="damage" />
                <asp:BoundField DataField="СимулацияИме" HeaderText="СимулацияИме" SortExpression="СимулацияИме" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
        <asp:SqlDataSource ID="RobotSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT E.id, E.name, E.travel_cost_enter, E.travel_cost_in, E.travel_cost_exit, E.damage, RS.simulation_name AS СимулацияИме FROM Environments AS E INNER JOIN RoboSimulationsToEnvironments AS RTE ON E.id = RTE.environment_id INNER JOIN RoboSimulations AS RS ON RS.id = RTE.robo_simulation_id"></asp:SqlDataSource>
        <asp:SqlDataSource ID="RoboSimulationSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT * FROM [RoboSimulations]">
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
