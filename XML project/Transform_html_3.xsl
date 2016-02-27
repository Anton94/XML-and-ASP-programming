<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="html" version="1.0" encoding="UTF-8"/>
    <xsl:template name="robots">
        <xsl:for-each select="/RoboSimulation/Robots/Robot">
            <h3>
                <xsl:value-of select="@name"/>
            </h3>
            <xsl:variable name="enviroments_list" select="@environments"/>
            <p> Околните среди, които може да преминава са: 
            <xsl:for-each
                select="/RoboSimulation/Environments/Environment">
                <xsl:variable name="enviroment_id" select="@id"/> <xsl:if
                    test="contains($enviroments_list, $enviroment_id)">
                    <li><xsl:value-of select="@name"/></li>
                </xsl:if>
            </xsl:for-each>
            </p>
            <br/>
        </xsl:for-each>
    </xsl:template>

    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml" lang="bg">
            <head>
                <title>Роботи и околни среди</title>
                <meta http-equiv="content-type" content="application/html; charset=utf-8"/>
            </head>
            <body>
                <div style="text-align: center;">
                    <div id="header">
                        <h1>XML програмиране</h1>
                        <h1>Роботи и околните среди, които могат да преминават</h1>
                    </div>
                    <div id="content">
                        <div style="text-align: center;">
                            <xsl:call-template name="robots"/>
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
