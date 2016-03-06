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
   
    
        <asp:Button ID="ButtonAddXMLFiles" runat="server" OnClick="ButtonAddXMLFiles_Click" Text="Добави XML файловете" />
        <asp:Button ID="ButtonDeleteAllData" runat="server" OnClick="ButtonDeleteAllData_Click" Text="Изтрий информацията" Width="174px" />
        <br />
        <asp:Button ID="ButtonChangeTablesPaging" runat="server" OnClick="ButtonChangeTablesPaging_Click" Text="Смени формата на таблиците(всички на една или на повече)" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Симулации"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="RoboSimulationSqlDataSource" ForeColor="#333333" GridLines="None" style="margin-right: 0px; margin-top: 11px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="simulation_name" HeaderText="simulation_name" SortExpression="simulation_name" />
                <asp:BoundField DataField="simulation_owner" HeaderText="simulation_owner" SortExpression="simulation_owner" />
                <asp:BoundField DataField="simulation_owner_email" HeaderText="simulation_owner_email" SortExpression="simulation_owner_email" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="RoboSimulationSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT * FROM [RoboSimulations] ORDER BY [id]">
        </asp:SqlDataSource>
    
        <br />
        <asp:Label ID="Label1" runat="server" Text="Околни среди"></asp:Label>
        <asp:GridView ID="GridView2" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="EnvironmentSqlDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="СимID" HeaderText="СимID" InsertVisible="False" ReadOnly="True" SortExpression="СимID" />
                <asp:BoundField DataField="Симулация" HeaderText="Симулация" SortExpression="Симулация" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="travel_cost_enter" HeaderText="travel_cost_enter" SortExpression="travel_cost_enter" />
                <asp:BoundField DataField="travel_cost_in" HeaderText="travel_cost_in" SortExpression="travel_cost_in" />
                <asp:BoundField DataField="travel_cost_exit" HeaderText="travel_cost_exit" SortExpression="travel_cost_exit" />
                <asp:BoundField DataField="damage" HeaderText="damage" SortExpression="damage" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <asp:SqlDataSource ID="EnvironmentSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT RS.id AS СимID, RS.simulation_name AS Симулация , E.id, E.name, E.travel_cost_enter, E.travel_cost_in, E.travel_cost_exit, E.damage FROM Environments AS E INNER JOIN RoboSimulationsToEnvironments AS RTE ON E.id = RTE.environment_id INNER JOIN RoboSimulations AS RS ON RS.id = RTE.robo_simulation_id ORDER BY Симулация"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Роботи"></asp:Label>
        <asp:GridView ID="GridView3" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="RobotSqlDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="СимID" HeaderText="СимID" InsertVisible="False" ReadOnly="True" SortExpression="СимID" />
                <asp:BoundField DataField="Симулация" HeaderText="Симулация" SortExpression="Симулация" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="owner" HeaderText="owner" SortExpression="owner" />
                <asp:BoundField DataField="robot_mesh_grid" HeaderText="robot_mesh_grid" SortExpression="robot_mesh_grid" />
                <asp:BoundField DataField="speed" HeaderText="speed" SortExpression="speed" />
                <asp:BoundField DataField="speed_back" HeaderText="speed_back" SortExpression="speed_back" />
                <asp:BoundField DataField="turning_speed" HeaderText="turning_speed" SortExpression="turning_speed" />
                <asp:BoundField DataField="turning_speed_back" HeaderText="turning_speed_back" SortExpression="turning_speed_back" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="RobotSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT RS.id AS СимID, RS.simulation_name AS Симулация , R.id, R.name, R.owner, R.robot_mesh_grid, R.speed, R.speed_back, R.turning_speed, R.turning_speed_back FROM RoboSimulations AS RS INNER JOIN RoboSimulationsToRobots AS RSTR ON RS.id = RSTR.robo_simulation_id INNER JOIN Robots AS R ON RSTR.robot_id = R.id
ORDER BY RS.id"></asp:SqlDataSource>
        <br />
        Колела<br />
        <asp:GridView ID="GridView4" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="СимID,РобоID,id" DataSourceID="WheelSqlDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="СимID" HeaderText="СимID" InsertVisible="False" ReadOnly="True" SortExpression="СимID" />
                <asp:BoundField DataField="Симулация" HeaderText="Симулация" SortExpression="Симулация" />
                <asp:BoundField DataField="РобоID" HeaderText="РобоID" InsertVisible="False" ReadOnly="True" SortExpression="РобоID" />
                <asp:BoundField DataField="Робот" HeaderText="Робот" SortExpression="Робот" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="driving" HeaderText="driving" SortExpression="driving" />
                <asp:BoundField DataField="wheel_mesh_grid" HeaderText="wheel_mesh_grid" SortExpression="wheel_mesh_grid" />
                <asp:BoundField DataField="wheel_diameter" HeaderText="wheel_diameter" SortExpression="wheel_diameter" />
                <asp:BoundField DataField="wheel_width" HeaderText="wheel_width" SortExpression="wheel_width" />
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
        <asp:SqlDataSource ID="WheelSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT RoboSimulations.id AS СимID, RoboSimulations.simulation_name AS Симулация, Robots.id AS РобоID, Robots.name AS Робот, Wheels.id, Wheels.driving, Wheels.wheel_mesh_grid, Wheels.wheel_diameter, Wheels.wheel_width FROM RoboSimulations INNER JOIN RoboSimulationsToRobots ON RoboSimulations.id = RoboSimulationsToRobots.robo_simulation_id INNER JOIN Robots ON Robots.id = RoboSimulationsToRobots.robot_id INNER JOIN RobotsToWheels ON Robots.id = RobotsToWheels.robot_id INNER JOIN Wheels ON Wheels.id = RobotsToWheels.wheel_id ORDER BY СимID, РобоID"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Сензори"></asp:Label>
        <asp:GridView ID="GridView5" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SensorsSqlDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="СимID" HeaderText="СимID" InsertVisible="False" ReadOnly="True" SortExpression="СимID" />
                <asp:BoundField DataField="Симулация" HeaderText="Симулация" SortExpression="Симулация" />
                <asp:BoundField DataField="РобоID" HeaderText="РобоID" InsertVisible="False" ReadOnly="True" SortExpression="РобоID" />
                <asp:BoundField DataField="Робот" HeaderText="Робот" SortExpression="Робот" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="value_type" HeaderText="value_type" SortExpression="value_type" />
                <asp:BoundField DataField="sensor_mesh_grid" HeaderText="sensor_mesh_grid" SortExpression="sensor_mesh_grid" />
                <asp:BoundField DataField="number_of_values_per_second" HeaderText="number_of_values_per_second" SortExpression="number_of_values_per_second" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SensorsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT RoboSimulations.id AS СимID, RoboSimulations.simulation_name AS Симулация, Robots.id AS РобоID, Robots.name AS Робот, Sensors.id, Sensors.name, Sensors.value_type, Sensors.sensor_mesh_grid, Sensors.number_of_values_per_second FROM RoboSimulations INNER JOIN RoboSimulationsToRobots ON RoboSimulations.id = RoboSimulationsToRobots.robo_simulation_id INNER JOIN Robots ON Robots.id = RoboSimulationsToRobots.robot_id INNER JOIN RobotsToSensors ON Robots.id = RobotsToSensors.robot_id INNER JOIN Sensors ON Sensors.id = RobotsToSensors.sensor_id ORDER BY СимID, РобоID"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Ротори"></asp:Label>
        <br />
        <asp:GridView ID="GridView6" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="RotorsSqlDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="СимID" HeaderText="СимID" InsertVisible="False" ReadOnly="True" SortExpression="СимID" />
                <asp:BoundField DataField="Симулация" HeaderText="Симулация" SortExpression="Симулация" />
                <asp:BoundField DataField="РобоID" HeaderText="РобоID" InsertVisible="False" ReadOnly="True" SortExpression="РобоID" />
                <asp:BoundField DataField="Робот" HeaderText="Робот" SortExpression="Робот" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="rotor_mesh_grid" HeaderText="rotor_mesh_grid" SortExpression="rotor_mesh_grid" />
                <asp:BoundField DataField="rotor_lifting_power" HeaderText="rotor_lifting_power" SortExpression="rotor_lifting_power" />
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
        <asp:SqlDataSource ID="RotorsSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT RoboSimulations.id AS СимID, RoboSimulations.simulation_name AS Симулация, Robots.id AS РобоID, Robots.name AS Робот, Rotors.id, Rotors.rotor_mesh_grid, Rotors.rotor_lifting_power FROM RoboSimulations INNER JOIN RoboSimulationsToRobots ON RoboSimulations.id = RoboSimulationsToRobots.robo_simulation_id INNER JOIN Robots ON Robots.id = RoboSimulationsToRobots.robot_id INNER JOIN RobotsToRotors ON Robots.id = RobotsToRotors.robot_id INNER JOIN Rotors ON Rotors.id = RobotsToRotors.rotor_id ORDER BY СимID, РобоID"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Карти"></asp:Label>
        <br />
        <asp:GridView ID="GridView7" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="MapSqlDataSource" ForeColor="#333333" GridLines="None" style="margin-right: 1px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="СимID" HeaderText="СимID" InsertVisible="False" ReadOnly="True" SortExpression="СимID" />
                <asp:BoundField DataField="Симулация" HeaderText="Симулация" SortExpression="Симулация" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="map_data" HeaderText="map_data" SortExpression="map_data" />
                <asp:BoundField DataField="denivelation" HeaderText="denivelation" SortExpression="denivelation" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="MapSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT RS.id AS СимID, RS.simulation_name AS Симулация, М.id, М.map_data, М.denivelation FROM Maps AS М INNER JOIN RoboSimulationsToMaps AS RTE ON М.id = RTE.map_id INNER JOIN RoboSimulations AS RS ON RS.id = RTE.robo_simulation_id ORDER BY СимID"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Алгоритми"></asp:Label>
        <br />
        <asp:GridView ID="GridView8" runat="server" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="AlgorithmSqlDataSource" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="СимID" HeaderText="СимID" InsertVisible="False" ReadOnly="True" SortExpression="СимID" />
                <asp:BoundField DataField="Симулация" HeaderText="Симулация" SortExpression="Симулация" />
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="diffEnvironments" HeaderText="diffEnvironments" SortExpression="diffEnvironments" />
                <asp:BoundField DataField="multipleDestPoints" HeaderText="multipleDestPoints" SortExpression="multipleDestPoints" />
                <asp:BoundField DataField="complexity" HeaderText="complexity" SortExpression="complexity" />
                <asp:BoundField DataField="depth" HeaderText="depth" SortExpression="depth" />
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
        <asp:SqlDataSource ID="AlgorithmSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ASP programmingConnectionString %>" SelectCommand="SELECT RS.id AS СимID, RS.simulation_name AS Симулация, A.id, A.name, A.diffEnvironments, A.multipleDestPoints, A.complexity, A.depth FROM Algorithms AS A INNER JOIN RoboSimulationsToAlgorithms AS RTA ON A.id = RTA.algorithm_id INNER JOIN RoboSimulations AS RS ON RS.id = RTA.robo_simulation_id ORDER BY СимID"></asp:SqlDataSource>
    
    </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
