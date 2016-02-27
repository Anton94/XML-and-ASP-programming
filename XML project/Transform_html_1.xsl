<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  version="1.0">    
    <xsl:output method="html" version="1.0" encoding="UTF-8"/>    
    <xsl:template name="robots">
        <xsl:for-each select="/RoboSimulation/Robots/Robot">
            <h2><xsl:value-of select="@name"/></h2>
            <p>Скорост <xsl:value-of select='format-number(Speed, "#.00")'/></p>
            <p>Скорост на завиване <xsl:value-of select='format-number(TurningSpeed, "#.00")'/></p>
            <p>Файл с информацията за робота <xsl:value-of select="RobotMeshGrid"/></p>            
            <p>Имащ следните сензори:                
                <xsl:for-each select="Sensors/Sensor">
                    <xsl:value-of select="Value"/>; 
                </xsl:for-each>
            </p>
            <br/>
            <br/>            
        </xsl:for-each>
    </xsl:template>
    
    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml" lang="bg">
            <head>
                <title>Роботи</title>
                <meta http-equiv="content-type" content="application/html; charset=utf-8" />
            </head>
            <body>
                <div style="text-align: center;">
                    <div id="header">			
                        <h1>XML програмиране</h1>	
                        <h1>РОБОТИ</h1>	
                    </div>
                    <div id="content">
                        <div style="text-align: left;">
                            <xsl:call-template name="robots"></xsl:call-template>
                        </div>
                    </div>
                    <div id="footer">
                        <p style="text-align: center;">
                             Антон Василев Дудов, 71488
                        </p>			
                    </div>
                </div>
            </body>
        </html>
    </xsl:template>
    
</xsl:stylesheet>