<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">    
    <xsl:output method="text" indent="no" />    
    <xsl:variable name="newline">
        <xsl:text>&#10;</xsl:text>
    </xsl:variable>    
    <xsl:variable name="tab">
        <xsl:text>&#9;</xsl:text>
    </xsl:variable>   
    <xsl:template match="/">
        
        АЛГОРИТМИ
______________________________________________________________          
            <xsl:for-each select="/RoboSimulation/Algorithms/Algorithm">  
Име     : <xsl:value-of select="@name"/>          
Сложност: <xsl:value-of select="Complexity"/>
Приложим за различни околни среди - <xsl:value-of select="@diffEnvironments"/>
______________________________________________________________  
</xsl:for-each>
        
        ОКОЛНИ СРЕДИ
______________________________________________________________          
<xsl:for-each select="/RoboSimulation/Environments/Environment">  
Име       : <xsl:value-of select="@name"/>          
Поети щети: <xsl:value-of select="Damage"/>
______________________________________________________________  
</xsl:for-each>
        
        РОБОТИ
______________________________________________________________          
<xsl:for-each select="/RoboSimulation/Robots/Robot">  
Име    : <xsl:value-of select="@name"/>          
Скорост: <xsl:value-of select="Speed"/>
Сензори:              
<xsl:for-each select="Sensors/Sensor"><xsl:value-of select="$tab"/><xsl:value-of select="$tab"/><xsl:value-of select="Value"/><xsl:value-of select="$newline"/> 
</xsl:for-each>
______________________________________________________________  
</xsl:for-each>
            Антон Дудов, 71488
    </xsl:template>
    
</xsl:stylesheet>