<?xml version="1.0" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0" xmlns:media="http://search.yahoo.com/mrss/" xmlns:content="http://purl.org/rss/1.0/modules/content/">
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="div[@class='article news']|@*|node()" />
    </xsl:copy>
  </xsl:template>

  <xsl:template match="html">
    <rss version="2.0">
      <channel>
        <item>
          <author>
            <xsl:value-of select="//span[last() and text()[contains(., 'By: ')]]//text()" />
          </author>
          <content:encoded>
            <xsl:text disable-output-escaping="yes">&lt;![CDATA[</xsl:text>
            <xsl:apply-templates select="//div[@class='article news']|@*|node()" />
            <xsl:text disable-output-escaping="yes">]]&gt;</xsl:text>
          </content:encoded>
          <media:content>
            <xsl:variable name="src" select="//div[@class='article_images']//img//@src"/>
            <xsl:if test="not(starts-with($src, '/'))">
              <xsl:attribute name="url">
                <xsl:value-of select="$src"/>
              </xsl:attribute>
            </xsl:if>
            <xsl:if test="starts-with($src, '/')">
              <xsl:attribute name="url">
                <xsl:value-of select="concat('http://www.dirtbikerider.com/', $src)"/>
              </xsl:attribute>
            </xsl:if>

          </media:content>
        </item>
      </channel>
    </rss>
  </xsl:template>

  <xsl:template match="head | body" />
  <xsl:template match="div[@class='article news']/h2" />
  <xsl:template match="div[@class='article news']/div[@id='addthisbox-new']" />
  <xsl:template match="div[@class='article news']/div[@class='article_images']" />
  <xsl:template match="div[@class='article news']/p/span[contains(text(), 'Published Date:')]" />
  <xsl:template match="div[@class='article news']/div[@class='like_link']" />
  <xsl:template match="div[@class='article news']/p[@class='btt']" />
  <xsl:template match="div[@class='article news']/p/span[last() and text()[contains(., 'By: ')]]" />
  <xsl:template match="div[@class='article news']/p/span[last() and text()[contains(., 'Section: ')]]" />
</xsl:stylesheet>