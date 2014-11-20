<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
      xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

  <xsl:template match="/">
    <xsl:apply-templates select="/div/table/tr/td/table/tr[1]">
    </xsl:apply-templates>
    <xsl:apply-templates select="/div/table/tr/td/table/tr[3]/td[1]">
    </xsl:apply-templates>
  </xsl:template>

  <xsl:template match="tr[@class='txtNhodi']/td[1]">
    <small>
      <xsl:apply-templates />
    </small>
  </xsl:template>
  <xsl:template match="p[@class='arialTitle']">
    <h3>
      <xsl:apply-templates />
    </h3>
  </xsl:template>
  <xsl:template match="p">
    <p>
      <xsl:apply-templates />
    </p>
  </xsl:template>
</xsl:stylesheet>
