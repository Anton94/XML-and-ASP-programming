<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">    
    <xsl:output method="text" indent="no" />    
    <xsl:variable name="newline">
        <xsl:text>&#10;</xsl:text>
    </xsl:variable>    
    <xsl:template match="/">
                    Роботи
______________________________________________________________          
        <xsl:for-each select="/RoboSimulation/Robots/Robot">  
Име                 : <xsl:value-of select="@name"/>          
Скорост             : <xsl:value-of select="Speed"/>
Скорост на завиване : <xsl:value-of select="TurningSpeed"/>
Геометрия           : <xsl:value-of select="RobotMeshGrid"/>
Колела:              
<xsl:for-each select="Wheels/Wheel">        Задвижващо - <xsl:value-of select="@driving"/>, с диаметър <xsl:value-of select="WheelDiameter"/>  <xsl:value-of select="$newline"/> </xsl:for-each>
Перки:              
<xsl:for-each select="Fins/Fin">        Перка с подемна мощност <xsl:value-of select="FinLiftingPower"/>  <xsl:value-of select="$newline"/> </xsl:for-each>

______________________________________________________________  
        </xsl:for-each>
        
            Антон Дудов, 71488
    </xsl:template>
    
</xsl:stylesheet>