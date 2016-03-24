<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Arved</title>
      </head>
      <body>
        <xsl:for-each select="/arved/arve">
          <div>
            <p>
              <b>
                Arve nr <xsl:value-of select="@number"/>
              </b> Koostatud <xsl:value-of select="@kuupäev"/>
            </p>
            <p>
              Koostaja: <xsl:value-of select="koostaja/@eesnimi"/><xsl:value-of select="koostaja/@perenimi"/>
              <ul>
                <xsl:for-each select="./koostaja/kontaktandmed/kontakt">
                  <li>
                    <xsl:value-of select="@tüüp"/>: <xsl:value-of select="@väärtus"/>
                  </li>
                </xsl:for-each>
              </ul>
            </p>
            <p>
              Tellija: <xsl:value-of select="./tellija/@eesnimi"/> <xsl:value-of select="./tellija/@perenimi"/>
            </p>
            <table border="1" cellpadding="4" cellspacing="0">
              <tr>
                <th>Toote nimetus</th>
                <th>Kogus</th>
                <th>Ühik</th>
                <th>Hind</th>
              </tr>
              <xsl:for-each select="./tellitudTooted/toode">
                <tr align="center">
                  <td>
                    <xsl:value-of select="@nimi"/>
                  </td>
                  <td>
                    <xsl:value-of select="@kogus"/>
                  </td>
                  <td>
                    <xsl:value-of select="@ühik"/>
                  </td>
                  <td>
                    <xsl:value-of select="./tavahind/@väärtus"/>
                    <xsl:value-of select="./tavahind/@valuuta"/>
                  </td>
                </tr>
              </xsl:for-each>
              <tr>
                <td colspan="3" align="right">
                  Summa käibemaksuta:
                </td>
                <td colspan="1" align="center">
                  <xsl:value-of select="./summad/käibemaksuta/@väärtus"/>
                  <xsl:value-of select="./summad/käibemaksuta/@valuuta"/>
                </td>
              </tr>
              <tr>
                <td colspan="3" align="right">
                  Käibemaksumäär:
                </td>
                <td colspan="1" align="center">
                  <xsl:value-of select="./käibemaksumäär/@väärtus"/>
                </td>
              </tr>
              <tr>
                <td colspan="3" align="right">
                  <b>Summa käibemaksuga:</b>
                </td>
                <td colspan="1" align="center">
                  <b>
                    <xsl:value-of select="./summad/käibemaksuga/@väärtus"/>
                    <xsl:value-of select="./summad/käibemaksuga/@valuuta"/>
                  </b>
                </td>
              </tr>
            </table>
            <p>
              <b>Juriidiline info</b>
              <xsl:variable name="info" select="./juriidilineInfo"/>
              <br/>
              Ettevõte: <xsl:value-of select="$info/@ettevõtteNimi"/>
              <br/>
              Aadress: <xsl:value-of select="$info/@aadress"/>
              <br/>
              Registrikood: <xsl:value-of select="$info/@registrikood"/>
              <br/>
              <xsl:for-each select="$info/pangakontod/pangakonto">
                <xsl:value-of select="@pangaNimi"/>: <xsl:value-of select="@kontonr"/>
                <br/>
              </xsl:for-each>
              <xsl:for-each select="$info/kontaktandmed/kontakt">
                <xsl:value-of select="@tüüp"/>: <xsl:value-of select="@väärtus"/>
                <br/>
              </xsl:for-each>
            </p>
            <p>
              Maksetähtaeg: <b>
                <xsl:value-of select="./tähtaeg/@kuupäev"/>
              </b>
              <br/>
              <xsl:value-of select="./lisainfo"/>
            </p>
          </div>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>