<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html" version="1.0" encoding="UTF-8"/>
    <xsl:template name="maps">
        <xsl:for-each select="/RoboSimulation/Maps/Map">
            
            <h3>Карта <xsl:value-of select="MapData"/></h3>            
            <xsl:variable name="enviroments_list_map" select="@environments"/>
             Околните среди, които се срещат на картата са: 
            <xsl:for-each select="/RoboSimulation/Environments/Environment">
                <xsl:variable name="enviroment_id" select="@id"/> 
                <xsl:if test="contains($enviroments_list_map, $enviroment_id)">
                     <xsl:value-of select="@name"/> ;
                </xsl:if>
            </xsl:for-each>
            
            <p> Роботите, които могат да ползват картата са: 
            <xsl:for-each select="/RoboSimulation/Robots/Robot">
                <xsl:variable name="enviroments_list_robot" select="@environments"/>   
                <xsl:variable name="robot_name" select="@name"/>     
                <xsl:if test="contains($enviroments_list_robot, $enviroments_list_map)">
                    <li><xsl:value-of select="$robot_name"/></li>
                </xsl:if>
            </xsl:for-each>
            </p>
            <br/>
        </xsl:for-each>
    </xsl:template>
    
    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml" lang="bg">
            <head>
                <title>Карти и роботи</title>
                <meta http-equiv="content-type" content="application/html; charset=utf-8"/>
            </head>
            <body>
                <div style="text-align: center;">
                    <div id="header">
                        <h1>XML програмиране</h1>
                        <h1>Картите и кои роботи могат да бъдат пускани на тях</h1>
                    </div>
                    <div id="content">
                        <div style="text-align: left;">
                            <xsl:call-template name="maps"/>
                        </div>
                    </div>
                    <div id="footer">
                        <p style="text-align: center;"> Антон Василев Дудов, 71488 </p>
                    </div>
                </div>
            </body>
        </html>
    </xsl:template>
    
</xsl:stylesheet>
