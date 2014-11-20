<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

  <!--http://www.moet.gov.vn/?page=1.3&view=4977-->
  <!--//div[@id='center']/div[@class='info']-->
  <xsl:template match="/">
    <xsl:apply-templates select="/div/table/tr/td/table/tr[1]">
    </xsl:apply-templates>
    <dl>
      <xsl:apply-templates select="/div/table/tr/td/table/tr[3]/td[1]">
      </xsl:apply-templates>
    </dl>
  </xsl:template>

  <xsl:template match="tr[@class='txtNhodi']">
    <xsl:if test="position()=1">
      <small>
        <xsl:apply-templates />
      </small>
    </xsl:if>
    <xsl:if test="position()=2">
      <xsl:text disable-output-escaping="yes"><![CDATA[ <dl class="dl=horizontal">]]></xsl:text>
      <dt>
        <xsl:apply-templates  select="td[1]" />
      </dt>
      <dd>
        <xsl:apply-templates  select="td[2]" />
      </dd>
    </xsl:if>
    <xsl:if test="position()=3">
      <dt>  
        <xsl:apply-templates  select="td[1]" />       
      </dt>
      <dd>
        <xsl:apply-templates  select="td[2]" />
      </dd>

      <xsl:text disable-output-escaping="yes"><![CDATA[</dl>]]></xsl:text>
    </xsl:if>

  </xsl:template>
  <xsl:template match="p[@class='arialTitle']">
    <p class="lead">
      <xsl:apply-templates />
    </p>
  </xsl:template>
  <xsl:template match="strong">
    <dt>
      <xsl:apply-templates />
    </dt>
  </xsl:template>
  <xsl:template match="p[@style='text-align: justify;']">
    <dd>
      <xsl:apply-templates />
    </dd>
  </xsl:template>
</xsl:stylesheet>
