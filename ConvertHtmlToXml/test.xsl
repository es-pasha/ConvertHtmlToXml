<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" omit-xml-declaration="yes" indent="yes"/>
  <!--<xsl:strip-space elements="*"/>-->

  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="*/div[@id='id1']|@*|node()" />
    </xsl:copy>
  </xsl:template>

  <xsl:template match="html">
    <div>
      <xsl:apply-templates select="*/div[@id='id1']|@*|node()" />
    </div>
  </xsl:template>

  <xsl:template match="body" />
  <xsl:template match="div[@id='id2']/div[@class='classDiv3'] | div[@id='id2']/*/div[@class='classDiv3']" />
</xsl:stylesheet>