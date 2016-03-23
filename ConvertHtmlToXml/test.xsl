<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/ | @* | node()">
    <root>
      <xsl:copy-of select="//div"/>
    </root>
  </xsl:template>
</xsl:stylesheet>