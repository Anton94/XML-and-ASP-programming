<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"  version="1.0">    
    <xsl:output method="html" version="1.0" encoding="UTF-8"/>    
    <xsl:template name="environments">
        <xsl:for-each select="/RoboSimulation/Environments/Environment">
            <xsl:sort select="Damage" order="descending"/>
                <h2><xsl:value-of select="@name"/></h2>
                <p>Цена за влизане (за единица площ): <xsl:value-of select='format-number(TravelCostEnter, "#.00")'/></p>
                <p>Цена за преминаване (за единица площ): <xsl:value-of select='format-number(TravelCostIn, "#.00")'/></p>
                <p>Цена за излизане (за единица площ): <xsl:value-of select='format-number(TravelCostExit, "#.00")'/></p>            
                <p>Поети щети (за единица време): <xsl:value-of select='format-number(Damage, "#.00")'/></p> 
                <br/>
                <br/>            
        </xsl:for-each>
    </xsl:template>
    
    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml" lang="bg">
            <head>
                <title>Околни среди</title>
                <meta http-equiv="content-type" content="application/html; charset=utf-8" />
            </head>
            <body>
                <div style="text-align: center;">
                    <div id="header">			
                        <h1>XML програмиране</h1>	
                        <h1>Околни среди</h1>	
                        <h4>(сортирани в поетите щети)</h4>	
                    </div>
                    <div id="content">
                        <div style="text-align: center;">
                            <xsl:call-template name="environments"></xsl:call-template>
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