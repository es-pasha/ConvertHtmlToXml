<xsl:stylesheet version="1.0"
 xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" omit-xml-declaration="yes" indent="yes"/>
  <!--<xsl:strip-space elements="*"/>-->

  <!--<xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>-->

  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="*/div[@id='id1']|@*|node()"/>
    </xsl:copy>
    <!--<xsl:copy-of select="*/div[@id='id1']|@*|node()"/>-->
  </xsl:template>


  <!--<xsl:template match="p[@*]">
    <xsl:apply-templates />
  </xsl:template>-->

  <xsl:template match="body" />
  <xsl:template match="/div[@id='id2']/div[@class='classDiv3']" />

  <!--<xsl:template match="div[@id='id1']">
    <a href="#ReadmoreWrapper">READMORE</a>
    <div class="wrapper" id="#ReadmoreWrapper">
      <xsl:apply-templates select="following-sibling::node()" mode="copy"/>
    </div>
  </xsl:template>-->

  <!--<xsl:template match="node()[ancestor::p[descendant::text()[. = '[READMORE]']] or preceding::p[descendant::text()[. = '[READMORE]']]]"/>-->

  <!--<xsl:template match="node()|@*" mode="copy">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*" mode="copy"/>
    </xsl:copy>
  </xsl:template>-->
</xsl:stylesheet>