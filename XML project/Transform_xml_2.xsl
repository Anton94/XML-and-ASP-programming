<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="xml" encoding="UTF-8" indent='yes'/>
    <xsl:template match="/">
        <Environments>            
            <xsl:for-each select="/RoboSimulation/Environments/Environment">
                <id><xsl:value-of select="@id"/></id>
                <name><xsl:value-of select="@name"/></name>
                <TravelCostEnter><xsl:value-of select="TravelCostEnter"/></TravelCostEnter>
                <TravelCostIn><xsl:value-of select="TravelCostIn"/></TravelCostIn>
                <TravelCostExit><xsl:value-of select="TravelCostExit"/></TravelCostExit>
                <Damage><xsl:value-of select="Damage"/></Damage>                
                <xsl:variable name="enviroment_id" select="@id"/>   
                <Robots>            
                    <xsl:for-each select="/RoboSimulation/Robots/Robot">                        
                        <xsl:variable name="robot_environments" select="@environments"/>   
                        <xsl:if test="contains($robot_environments, $enviroment_id)">
                            <Robot>
                                <id><xsl:value-of select="@id"/></id>
                                <enviroments><xsl:value-of select="@environments"/></enviroments>
                                <name><xsl:value-of select="@name"/></name>
                                <RobotMeshGrid><xsl:value-of select="RobotMeshGrid"/></RobotMeshGrid>
                                <Speed><xsl:value-of select="Speed"/></Speed>
                                <TurningSpeed><xsl:value-of select="TurningSpeed"/></TurningSpeed>
                                <Wheels>
                                    <xsl:for-each select="Wheels/Wheel">    
                                        <Wheel>
                                            <diriving><xsl:value-of select="@driving"/></diriving>
                                            <WheelDiameter><xsl:value-of select="WheelDiameter"/></WheelDiameter>
                                        </Wheel>
                                    </xsl:for-each>   
                                </Wheels>
                                <Sensors>
                                    <xsl:for-each select="Sensors/Sensor">    
                                        <Sensor>
                                            <name><xsl:value-of select="@name"/></name>                            
                                            <SensorMeshGrid><xsl:value-of select="SensorMeshGrid"/></SensorMeshGrid>
                                            <Value><xsl:value-of select="Value"/></Value>
                                        </Sensor>
                                    </xsl:for-each>   
                                </Sensors>
                                <Fins>
                                    <xsl:for-each select="Fins/Fin">    
                                        <Fin>                     
                                            <FinMeshGrid><xsl:value-of select="FinMeshGrid"/></FinMeshGrid>
                                            <FinLiftingPower><xsl:value-of select="FinLiftingPower"/></FinLiftingPower>
                                        </Fin>
                                    </xsl:for-each>   
                                </Fins>
                            </Robot>    
                        </xsl:if>
                    </xsl:for-each>
                </Robots>                    
            </xsl:for-each>
        </Environments>
    </xsl:template>
</xsl:stylesheet>