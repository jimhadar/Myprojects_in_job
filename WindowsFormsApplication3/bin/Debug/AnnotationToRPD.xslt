﻿<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/RPD">
    <w:document mc:Ignorable="w14 w15 wp14"
                xmlns:wpc="http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:o="urn:schemas-microsoft-com:office:office"
                xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
                xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math"
                xmlns:v="urn:schemas-microsoft-com:vml"
                xmlns:wp14="http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing"
                xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing"
                xmlns:w10="urn:schemas-microsoft-com:office:word"
                xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
                xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml"
                xmlns:w15="http://schemas.microsoft.com/office/word/2012/wordml"
                xmlns:wpg="http://schemas.microsoft.com/office/word/2010/wordprocessingGroup"
                xmlns:wpi="http://schemas.microsoft.com/office/word/2010/wordprocessingInk"
                xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml"
                xmlns:wps="http://schemas.microsoft.com/office/word/2010/wordprocessingShape"
        >
      <w:body>
        <w:p w:rsidR="00D603CB" w:rsidRPr="00D603CB" w:rsidRDefault="00D603CB" w:rsidP="00D603CB">
          <w:pPr>
            <w:jc w:val="center"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve">Аннотация рабочей программы дисциплины </w:t>
          </w:r>          
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve"><xsl:value-of select="Title/@Shift_discip"/></w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve"><xsl:value-of select="Title/@Name_discip"/>.</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="00186733" w:rsidRDefault="00186733" w:rsidP="00D603CB">
          <w:pPr>
            <w:jc w:val="center"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="9351" w:type="dxa"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
            </w:tblBorders>
            <w:tblLook w:val="04A0" w:firstRow="1" w:lastRow="0" w:firstColumn="1" w:lastColumn="0" w:noHBand="0" w:noVBand="1"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="2830"/>
            <w:gridCol w:w="6521"/>
          </w:tblGrid>
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Цели освоения дисциплины</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <xsl:for-each select="RPD_1_2_3/Data/GoalsDisciplin/Abzac">
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                  <w:pPr>
                    <w:jc w:val="both"/>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t><xsl:value-of select="@Value"/></w:t>
                  </w:r>
                </w:p>
              </xsl:for-each>
            </w:tc>
          </w:tr>
          
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Место дисциплины в учебном плане и трудоемкость в зачетных единицах</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <!--Вывод первого предложения в этом разделе-->
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                <w:pPr>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:sz w:val="24"/>
                    <w:szCs w:val="24"/>
                  </w:rPr>
                  <w:t>
                    <xsl:value-of select="RPD_1_2_3/Data/PlaceOOP/AboutPlaceOOP/@Value"/>
                  </w:t>
                </w:r>
              </w:p>
              <!--Вывод текста раздела "Место дисциплины в структуре ООП бакалавриата"-->
              <xsl:for-each select="RPD_1_2_3/Data/PlaceOOP/Abzac">                
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                  <w:pPr>
                    <w:jc w:val="both"/>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Value"/>
                    </w:t>
                  </w:r>
                </w:p>
              </xsl:for-each>              
              <w:p w:rsidR="00D21397" w:rsidRPr="00D21397" w:rsidRDefault="00D21397" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t>
                    Общая трудоемкость дисциплины составляет <xsl:value-of select="RPD_1_2_3/Struct_Discip/@ZET"/> зачетные единицы <xsl:value-of select="RPD_1_2_3/Struct_Discip/@All_hours"/> часов.
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Формируемые компетенции</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRDefault="00D603CB" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve"><xsl:for-each select="RPD_1_2_3/Data/Competetion/Row"><xsl:value-of select="@CodCompetencii"/>, </xsl:for-each>.</w:t>                  
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Знания, умения и навыки, формируемые в результате освоения дисциплины</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRDefault="004639CB" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>В результате освоения дисциплины обучающийся должен</w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="004639CB" w:rsidRDefault="004639CB" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>знать:</w:t>
                </w:r>
              </w:p>

              <xsl:for-each select="RPD_1_2_3/Data/Student_must_znat/Abzac">
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                  <w:pPr>
                    <w:ind w:firstLine="709"/>
                    <w:jc w:val="both"/>
                    <w:tabs>
                      <w:tab w:val="clear" w:pos="360"/>
                      <w:tab w:val="both" w:pos="720"/>
                    </w:tabs>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Value"/>
                    </w:t>
                  </w:r>
                </w:p>
              </xsl:for-each>              
              
              <w:p w:rsidR="004639CB" w:rsidRDefault="004639CB" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>уметь:</w:t>
                </w:r>
              </w:p>
              
              <xsl:for-each select="RPD_1_2_3/Data/Student_must_umet/Abzac">
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                  <w:pPr>
                    <w:ind w:firstLine="709"/>
                    <w:jc w:val="both"/>
                    <w:tabs>
                      <w:tab w:val="clear" w:pos="360"/>
                      <w:tab w:val="both" w:pos="720"/>
                    </w:tabs>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Value"/>
                    </w:t>
                  </w:r>
                </w:p>
              </xsl:for-each>
              
              <w:p w:rsidR="004639CB" w:rsidRDefault="004639CB" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>владеть:</w:t>
                </w:r>
              </w:p>
              
              <xsl:for-each select="RPD_1_2_3/Data/Student_must_vladet/Abzac">
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                  <w:pPr>
                    <w:ind w:firstLine="709"/>
                    <w:jc w:val="both"/>
                    <w:tabs>
                      <w:tab w:val="clear" w:pos="360"/>
                      <w:tab w:val="both" w:pos="720"/>
                    </w:tabs>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Value"/>
                    </w:t>
                  </w:r>
                </w:p>
              </xsl:for-each>
              
            </w:tc>
          </w:tr>
          
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Содержание дисциплины</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/Razdel">
                <w:p w:rsidR="00D603CB" w:rsidRDefault="00D603CB" w:rsidP="004639CB">
                  <w:pPr>
                    <w:ind w:firstLine="0"/>                    
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t xml:space="preserve"><xsl:value-of select="@Id"/>. <xsl:value-of select="@About_razdel"/></w:t>
                  </w:r>
                </w:p>
                <xsl:for-each select="Theme">
                  <w:p w:rsidR="00D603CB" w:rsidRDefault="00D603CB" w:rsidP="004639CB">
                    <w:pPr>
                      <w:ind w:left="680" w:firstLine="0"/>
                    </w:pPr>
                    <w:r>                      
                      <w:t xml:space="preserve"><xsl:value-of select="@Id"/>. <xsl:value-of select="@About_theme"/></w:t>
                    </w:r>
                  </w:p>
                </xsl:for-each>  
              </xsl:for-each>
              <w:p w:rsidR="00D603CB" w:rsidRDefault="00D603CB" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>
            </w:tc>
          </w:tr>
          
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Виды учебной работы</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRDefault="006F7CC3" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t>Лекции, консультации, лабораторные занятия, самостоятельная работа.</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          
          <w:tr w:rsidR="00D603CB" w:rsidRPr="007977D7" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Характеристика образовательных технологий, информационных, программных и иных средств обучения, с указанием доли аудиторных занятий, проводимых в интерактивных формах</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <xsl:for-each select="RPD_4_5/Obraz_technology/Abzac">
                <w:p w:rsidR="00D603CB" w:rsidRPr="000B014E" w:rsidRDefault="000B014E" w:rsidP="004639CB">
                  <w:pPr>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@Value"/>
                    </w:t>
                  </w:r>
                </w:p>
              </xsl:for-each>
              
              <w:p w:rsidR="000B014E" w:rsidRPr="000B014E" w:rsidRDefault="000B014E" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve">Доля занятий с использованием активных и интерактивных методов составляет  <xsl:value-of select="RPD_4_5/Obraz_technology/Part_zanyatii/@Value"/>.</w:t>
                </w:r>
              </w:p>
              
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Формы текущего контроля успеваемости студентов</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="00FA67D8" w:rsidRDefault="000437CA" w:rsidP="004639CB">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t>В течение учебного года текущий контроль успеваемости студентов проверяется в ходе практических занятий,</w:t>
                  <w:t>при выполнении и оценке самостоятельных заданий, индивидуальных домашних работ, по результатам тестирования и тематических контрольных работ.</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="00D603CB" w:rsidTr="008F5E23">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2830" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="00D603CB" w:rsidRPr="008F5E23" w:rsidRDefault="008F5E23" w:rsidP="008F5E23">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="left"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Виды и формы промежуточной аттестации</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="6521" w:type="dxa"/>
              </w:tcPr>

              <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/Type_and_Form_promej_control/Abzac">
                <w:p w:rsidR="00D603CB" w:rsidRPr="005066AB" w:rsidRDefault="00FA67D8" w:rsidP="004639CB">
                  <w:pPr>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@Value"/>
                    </w:t>
                  </w:r>
                </w:p>
              </xsl:for-each>

            </w:tc>
          </w:tr>
        </w:tbl>
        <w:p w:rsidR="008563B6" w:rsidRPr="00D603CB" w:rsidRDefault="008563B6" w:rsidP="00D603CB">
          <w:bookmarkStart w:id="0" w:name="_GoBack"/>
          <w:bookmarkEnd w:id="0"/>
        </w:p>
        <w:sectPr w:rsidR="008563B6" w:rsidRPr="00D603CB">
          <w:pgSz w:w="11906" w:h="16838"/>
          <w:pgMar w:top="1134" w:right="850" w:bottom="1134" w:left="1701" w:header="708" w:footer="708" w:gutter="0"/>
          <w:cols w:space="708"/>
          <w:docGrid w:linePitch="360"/>
        </w:sectPr>
      </w:body>
    </w:document>
  </xsl:template>
</xsl:stylesheet>