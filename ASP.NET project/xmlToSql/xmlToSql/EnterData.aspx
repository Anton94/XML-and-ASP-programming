<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterData.aspx.cs" Inherits="xmlToSql.EnterData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            width: 487px;
            margin-left: 69px;
            margin-right: 74px;
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
        .auto-style7 {
            width: 216px;
        }
        .auto-style8 {
            width: 216px;
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                <td class="auto-style3">
                    <asp:Label ID="LabelSimulationName" runat="server" AssociatedControlID="TextBoxSimulationName" Text="Име на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSimulationName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="Label1SimulationOwner" runat="server" AssociatedControlID="TextBoxSimulationOwner" Text="Собственик на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxSimulationOwner" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1SimulationOwnerEmail" runat="server" AssociatedControlID="TextBoxSimulationOwnerEmail" Text="Имейл на собственика: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSimulationOwnerEmail" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1SimulationDescription" runat="server" AssociatedControlID="TextBoxSimulationDescription" Text="Описание на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSimulationDescription" runat="server" Height="29px" TextMode="MultiLine" Width="177px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label1SimulationDescription0" runat="server" AssociatedControlID="TextBoxSimulationRating" Text="Рейтинг на симулацията: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSimulationRating" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="ButtonClearRoboSimulationData" runat="server" OnClick="ButtonClearRoboSimulationData_Click" Text="Изчисти данните за симулацията" />
        <hr />
        <br />
        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Околна среда"></asp:Label>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentName" runat="server" AssociatedControlID="TextBoxEnvironmentName" Text="Име на околната среда: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentCostEnter" runat="server" AssociatedControlID="TextBoxEnvironmentCostEnter" Text="Цена за влизане: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentCostEnter" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelEnvironmentCostIn" runat="server" AssociatedControlID="TextBoxEnvironmentCostIn" Text="Цена за преминаваме: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxEnvironmentCostIn" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentCostExit" runat="server" AssociatedControlID="TextBoxEnvironmentExit" Text="Цена за излизане: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentExit" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelEnvironmentDamage" runat="server" AssociatedControlID="TextBoxEnvironmentDamage" Text="Поети щети: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxEnvironmentDamage" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddEnvironment" runat="server" OnClick="ButtonAddEnvironment_Click" Text="Добави околната среда" />
        <asp:Button ID="ButtonClearEnvironmentData" runat="server" OnClick="ButtonClearEnvironmentData_Click" Text="Изчисти данните за околната среда" Width="258px" />
        <br />
        <hr />
        <br />
        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Робот"></asp:Label>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelRobotName" runat="server" AssociatedControlID="TextBoxRobotName" Text="Име на робота: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxRobotName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelRobotOwner" runat="server" AssociatedControlID="TextBoxRobotOwner" Text="Собственик на робота: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxRobotOwner" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelRobotMesh" runat="server" AssociatedControlID="TextBoxRobotMesh" Text="Геометрия на робота: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxRobotMesh" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelRobotSpeed" runat="server" AssociatedControlID="TextBoxRobotSpeed" Text="Скорост: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxRobotSpeed" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelRobotSpeedBack" runat="server" AssociatedControlID="TextBoxRobotSpeedBack" Text="Скорост назад: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxRobotSpeedBack" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelRobotTurningSpeed" runat="server" AssociatedControlID="TextBoxRobotTurningSpeed" Text="Скорост на завиване: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxRobotTurningSpeed" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelRobotTurningSpeedBack" runat="server" AssociatedControlID="TextBoxRobotTurningSpeedBack" Text="Скорост на завиване назад: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxRobotTurningSpeedBack" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Колело"></asp:Label>
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelWheelDiriving" runat="server" AssociatedControlID="DropDownListWheelDiriving" Text="Задвижващо: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListWheelDiriving" runat="server">
                        <asp:ListItem>ДА</asp:ListItem>
                        <asp:ListItem>НЕ</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelWheelMesh" runat="server" AssociatedControlID="TextBoxWheelMesh" Text="Геометрия на гумата: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxWheelMesh" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelWheelDiameter" runat="server" AssociatedControlID="TextBoxWheelDiameter" Text="Диаметър: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxWheelDiameter" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelWheelWidth" runat="server" AssociatedControlID="TextBoxWheelWidth" Text="Ширина: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxWheelWidth" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddWheel" runat="server" OnClick="ButtonAddWheel_Click" Text="Добави колелото" />
        <asp:Button ID="ButtonClearWheelData" runat="server" OnClick="ButtonClearWheelData_Click" Text="Изчисти данните за колелото" />
        <br />
        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Сензор"></asp:Label>
        <table style="width:100%;">
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelSensorName" runat="server" AssociatedControlID="TextBoxSensorName" Text="Име на сензора: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxSensorName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelSensorValueType" runat="server" AssociatedControlID="TextBoxSensorValueType" Text="Тип отчетена стойност: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSensorValueType" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelSensorMesh" runat="server" AssociatedControlID="TextBoxSensorMesh" Text="Геометрия на сензора: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxSensorMesh" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelSensorValuesPerSecond" runat="server" AssociatedControlID="TextBoxSensorValuesPerSecond" Text="Отчетени стойности(сек): *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxSensorValuesPerSecond" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddSensor" runat="server" OnClick="ButtonAddSensor_Click" Text="Добави сензора" />
        <asp:Button ID="ButtonClearSensorData" runat="server" OnClick="ButtonClearSensorData_Click" Text="Изчисти данните за сензора" />
        <br />
        <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Витло"></asp:Label>
        <table style="width:100%;">
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelRotorMesh" runat="server" AssociatedControlID="TextBoxRotorMesh" Text="Геометрия на витлото: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxRotorMesh" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelRotorLiftingPower" runat="server" AssociatedControlID="TextBoxRotorLiftingPower" Text="Повдигаща мощ: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxRotorLiftingPower" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddRotor" runat="server" OnClick="ButtonAddRotor_Click" Text="Добави витлото" />
        <asp:Button ID="ButtonClearRotorData" runat="server" OnClick="ButtonClearRotorData_Click" Text="Изчисти данните за витлото" />
        <hr style="height: -12px" />
        <br />
        <asp:Button ID="ButtonAddRobot" runat="server" OnClick="ButtonAddRobot_Click" Text="Добави робота" />
        <asp:Button ID="ButtonClearRobotData" runat="server" OnClick="ButtonClearRobotData_Click" Text="Изчисти данните за робота" />
        <hr style="height: -12px" />
        <br />
        <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Карта"></asp:Label>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelMapName" runat="server" AssociatedControlID="TextBoxMapName" Text="Име на картата: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxMapName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelMapMapData" runat="server" AssociatedControlID="TextBoxMapMapData" Text="Файл: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxMapMapData" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelMapDenivelation" runat="server" AssociatedControlID="TextBoxMapDenivelation" Text="Денивелация: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxMapDenivelation" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddMap" runat="server" OnClick="ButtonAddMap_Click" Text="Добави картата" />
        <asp:Button ID="ButtonClearMapData" runat="server" OnClick="ButtonClearMapData_Click" Text="Изчисти данните за картата" />
        <br />
        <hr />
        <br />
        <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#0066CC" Text="Алгоритъм"></asp:Label>
        <hr />
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelAlgorithmName" runat="server" AssociatedControlID="TextBoxAlgorithmName" Text="Име на алгоритъма: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxAlgorithmName" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelAlgorithmDiffEnvironments" runat="server" AssociatedControlID="DropDownListAlgorithmDiffEnvironments" Text="Различни околни среди: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListAlgorithmDiffEnvironments" runat="server">
                        <asp:ListItem>ДА</asp:ListItem>
                        <asp:ListItem>НЕ</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelAlgorithmMultipleDestPoints" runat="server" AssociatedControlID="DropDownListAlgorighmMultipleDestPoints" Text="Множество целеви точки: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:DropDownList ID="DropDownListAlgorighmMultipleDestPoints" runat="server">
                        <asp:ListItem>ДА</asp:ListItem>
                        <asp:ListItem>НЕ</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="LabelAlgorithmComplexity" runat="server" AssociatedControlID="TextBoxAlgorithmComplexity" Text="Сложност: *"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="TextBoxAlgorithmComplexity" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style7">
                    <asp:Label ID="LabelAlgorithmDepth" runat="server" AssociatedControlID="TextBoxAlgorithmDepth" Text="Максимална дълбочина: *"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="TextBoxAlgorithmDepth" runat="server" Width="178px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="ButtonAddAlgorithm" runat="server" Text="Добави алгоритъма" OnClick="ButtonAddAlgorithm_Click" />
        <asp:Button ID="ButtonClearAlgorithmData" runat="server" OnClick="ButtonClearAlgorithmData_Click" Text="Изчисти данните за алгоритъма" />
        <br />
        <br />
        <br />
        <hr />
        <hr />
        <hr />
        <asp:Button ID="ButtonSaveToXMLFile" runat="server" Text="Записване в XML файл" />
        <asp:Button ID="ButtonSaveToDB" runat="server" OnClick="ButtonSaveToDB_Click" Text="Записване в базата от данни" />
        <hr />
        <hr />
        <hr />
        <br />
        <br />
        <asp:Label ID="Label18" runat="server" Font-Size="Small" ForeColor="Red" Text="** Изчистването на данните само маха въведените стойности в полетата!"></asp:Label>
    </form>
</body>
</html>
