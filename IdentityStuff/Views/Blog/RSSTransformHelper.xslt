<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
                xmlns:atom="http://www.w3.org/2005/Atom"
                xmlns:openSearch="http://a9.com/-/spec/opensearch/1.1/" 
                xmlns:georss="http://www.georss.org/georss" 
                xmlns:gd="http://schemas.google.com/g/2005" 
                xmlns:geo="http://www.w3.org/2003/01/geo/wgs84_pos#" 
                xmlns:feedburner="http://rssnamespace.org/feedburner/ext/1.0"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt" 
                exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes" />
    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>
    <xsl:template match="//item[position() > 4]" />
    <xsl:template match="description" />
</xsl:stylesheet>
    <!--    
    <xsl:template match="//item/content[@type='html']"></xsl:template>
    
<xsl:template match="//item/content[@type='html']">
      <description>
        <xsl:apply-templates select="child::text()"/>
      </description>
    </xsl:template>-->  <!--<xsl:template match="/feed/generator" />
    <xsl:template match="feed" />
  -->