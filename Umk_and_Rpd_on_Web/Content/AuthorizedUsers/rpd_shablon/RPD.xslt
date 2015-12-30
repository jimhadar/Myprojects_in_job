<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
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
        <!--<w:p w:rsidR="00957CE7" w:rsidRDefault="00957CE7" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
          </w:pPr>
        </w:p>-->
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
          </w:pPr>
          <w:r>
            <w:t>МИНИСТЕРСТВО  ОБРАЗОВАНИЯ  И  НАУКИ  РОССИЙСКОЙ  ФЕДЕРАЦИИ</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <w:p w:rsidR="00E32D9D" w:rsidRDefault="00E32D9D" w:rsidP="00E32D9D">
          <w:pPr>
            <w:jc w:val="center"/>
          </w:pPr>
          <w:r>
            <w:t>ЧИТИНСКИЙ ИНСТИТУТ (ФИЛИАЛ)</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
          </w:pPr>
          <w:r>
            <w:t>ФГБОУ ВПО «БАЙКАЛЬСКИЙ ГОСУДАРСТВЕННЫЙ УНИВЕРСИТЕТ»</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="right"/>
          </w:pPr>
          <w:r>
            <w:t>УТВЕРЖДАЮ</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="00E32D9D" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="right"/>
          </w:pPr>
          <w:r>
            <w:t>Зам. директора по учебной работе</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="00E32D9D" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="right"/>
          </w:pPr>
          <w:r>
            <w:t>
              <xsl:value-of select="Title/@ZamDir_po_uchJob"/>
            </w:t>
          </w:r>
          <w:proofErr w:type="spellEnd"/>
        </w:p>
        <!--Символ ввода-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="right"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="right"/>
          </w:pPr>
          <w:r>
            <w:t>_______________________</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="right"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="right"/>
          </w:pPr>
          <w:r>
            <w:t>"_____"__________________</w:t>
            <!--Здесь указать ссылку на текущий год-->
            <w:t xml:space="preserve"> <xsl:value-of select="Title/@Year"/> г.</w:t>
          </w:r>
        </w:p>
        <!--Без понятия зачем это-->>
        <w:p w:rsidR="00503FE6" w:rsidRPr="0040113E" w:rsidRDefault="00503FE6" w:rsidP="00503FE6">
          <w:pPr>
            <w:tabs>
              <w:tab w:val="both" w:pos="5670"/>
            </w:tabs>
            <w:ind w:left="5670" w:hanging="567"/>
            <w:rPr>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
            <w:t xml:space="preserve">        М.П.</w:t>
          </w:r>
        </w:p>
        <!--Символ ввода-->>
        <w:p w:rsidR="00957CE7" w:rsidRDefault="00957CE7" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
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
            <w:t>Рабочая программа дисциплины</w:t>
          </w:r>
        </w:p>
        <!--Название дисциплины-->
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
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
            <w:t xml:space="preserve"><xsl:value-of select="Title/@Name_discip"/></w:t>
          </w:r>
        </w:p>
        <!--Код дисциплины-->
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
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
            <w:t xml:space="preserve"><xsl:value-of select="Title/@Shift_discip"/></w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r>
            <w:t xml:space="preserve">Направление подготовки: </w:t>
          </w:r>
          <!--Ссылку на направление подготовки-->>
          <w:r>
            <w:rPr>
              <w:i/>
            </w:rPr>
            <w:t xml:space="preserve"><xsl:value-of select="Title/@Cod_Speciality"/> <xsl:value-of select="Title/@Name_speciality"/></w:t>
          </w:r>
        </w:p>
        <!--<w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
          </w:pPr>
        </w:p>-->
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r>
            <w:t xml:space="preserve">Профиль подготовки: </w:t>
          </w:r>
          <w:r w:rsidR="008E5645">
            <w:rPr>
              <w:i/>
            </w:rPr>
            <w:t>
              <xsl:value-of select="Title/@Specialization"/>
            </w:t>
          </w:r>
        </w:p>
        <!--<w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="both"/>
          </w:pPr>
        </w:p>-->
        <w:p w:rsidR="006B3973" w:rsidRDefault="008E5645" w:rsidP="008E5645">
          <w:r w:rsidR="006B3973">
            <w:t xml:space="preserve">Квалификация (степень) выпускника: </w:t>
          </w:r>
          <w:r w:rsidR="006B3973" w:rsidRPr="008E5645">
            <w:rPr>
              <w:i/>
            </w:rPr>
            <w:t>Бакалавр</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
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
            <w:t xml:space="preserve">Форма обучения </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>
              <xsl:value-of select="Title/@FormaOb"/>
            </w:t>
          </w:r>
        </w:p>
        <!--Символ ввода-->>
        <!--<w:p w:rsidR="00997CD5" w:rsidRDefault="00997CD5" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
            <w:rPr>
              <w:i/>
            </w:rPr>
          </w:pPr>
        </w:p>-->
        <!--Таблица с структурой дисциплины-->
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
            <w:gridCol w:w="6096"/>
            <w:gridCol w:w="4200"/>
          </w:tblGrid>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:jc w:val="center"/>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRPr="005929EA" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <!--Ссылка на форму обучения-->>
                <w:r>
                  <w:t>
                    <xsl:value-of select="RPD_1_2_3/Struct_Discip/@FormaOb"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t xml:space="preserve">Курс </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:jc w:val="center"/>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <!--Ссылка на курс обучения-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@Course"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t xml:space="preserve">Триместр </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:jc w:val="center"/>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <!--Ссылка на триместры обучения-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@Semestr"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t>Лекции</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <!--Ссылка на сумму часов лекций-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@HourLec"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t>Практические (семинарские, лабораторные) занятия</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <!--Ссылка на сумму часов практических занятий-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@HourPraktik"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t>Самостоятельная работа</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:pPr>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="center"/>
                  </w:pPr>
                </w:pPr>
                <!--Ссылка на сумму часов самостоятельных работ-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@HourSam"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645" w:rsidRPr="007977D7">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t>Всего часов</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRPr="007977D7" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:pPr>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="center"/>
                  </w:pPr>
                </w:pPr>
                <!--Ссылка на общий объем часов-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@All_hours"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t>Курсовая работа</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <!--Ссылка на семестр курсовой работы, если есть-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@Kursov_job"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t>Зачет (триместр)</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <!--Ссылка на триместр, в котором будет зачет-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@Zachet"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="008E5645">
            <w:tc>
              <w:tcPr>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:r>
                  <w:t>Экзамен (триместр)</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="008E5645" w:rsidRDefault="008E5645" w:rsidP="008E5645">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <!--Ссылка на триместр экзамена, если есть-->
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="RPD_1_2_3/Struct_Discip/@Ekzamen"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
        </w:tbl>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:r>
            <w:t>Рабочая программа обсуждена и утверждена на заседании кафедры <!--<xsl:value-of select="Two_str/@Kaf_for_prep"/>--></w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <!--Указать ссылку на год-->>
          <w:r>
            <w:t>
              «_____»_____________ <xsl:value-of select="Title/@Year"/> г. протокол №_____
            </w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>

        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="9000" w:type="dxa"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="6296"/>
            <w:gridCol w:w="4000"/>
          </w:tblGrid>
          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve">Зав. кафедрой <xsl:value-of select="Two_str/@Kaf_for_prep"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="right"/>
                </w:pPr>
                <w:r>
                  <w:t></w:t>
                </w:r>
              </w:p>
            </w:tc>            
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:i/>
                  </w:rPr>
                  <w:t>
                    <xsl:value-of select="Title/@ZavKaf_forKaf_for_prep"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r>
                  <w:t>_________________</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:i/>
                  </w:rPr>
                  <w:t>
                    «_____»_____________ <xsl:value-of select="Title/@Year"/> г.
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r>
                  <w:t>(подпись)</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>           
          
          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                
              </w:p>
            </w:tc>
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:t>Рабочая программа согласована:</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="right"/>
                </w:pPr>
                <w:r>
                  <w:t></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve">Зав. кафедрой <xsl:value-of select="Two_str/@NameKaf"/></w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="Two_str/@ZavKafForKafPlan"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                
              </w:p>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r>
                  <w:t>_________________</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="left"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:i/>
                  </w:rPr>
                  <w:t>«_____»_____________ <xsl:value-of select="Title/@Year"/> г.</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r>
                  <w:t>(подпись)</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="left"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve">Декан <xsl:value-of select="Two_str/@NameFac"/> факультета</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                
              </w:p>
            </w:tc>
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:i/>
                  </w:rPr>
                  <w:t>
                    <xsl:value-of select="Two_str/@Dean"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r>
                  <w:t>_________________</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>

          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
                <w:pPr>
                  <w:ind w:firstLine="300"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:i/>
                  </w:rPr>
                  <w:t>
                    «_____»_____________ <xsl:value-of select="Title/@Year"/> г.
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r>
                  <w:t>(подпись)</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          
        </w:tbl>
        
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:ind w:left="708" w:firstLine="1"/>
            <w:jc w:val="center"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
          </w:pPr>
          <w:r>
            <w:br w:type="page"/>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="center"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:jc w:val="both"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:t xml:space="preserve">Программа составлена в соответствии с требованиями ФГОС ВПО с учетом рекомендаций и ПрОПОП ВПО по направлению подготовки</w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:i/>
            </w:rPr>
            <!--Ссылка на направление подготовки-->
            <w:t xml:space="preserve"> <xsl:value-of select="Title/@Cod_Speciality"/> <xsl:value-of select="Title/@Name_speciality"/> </w:t>
          </w:r>
          <w:r>
            <w:t>профиля</w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:i/>
            </w:rPr>
            <w:t xml:space="preserve"> «<xsl:value-of select="Title/@Specialization"/>».</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <!--в этой таблице в соотвестсвующих ячейках - ссылки на должность, звание препода (автора) и его ФИО-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="9288" w:type="dxa"/>
            <w:tblLook w:val="01E0" w:firstRow="1" w:lastRow="1" w:firstColumn="1" w:lastColumn="1" w:noHBand="0" w:noVBand="0"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="10296"/>
            <w:gridCol w:w="2000"/>
            <w:gridCol w:w="4000"/>
            <w:gridCol w:w="1416"/>
            <w:gridCol w:w="2880"/>
          </w:tblGrid>
          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1728" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve">Автор (ы) </w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2880" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="both"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="Two_str/@Full_inf_about_Sostavitel"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1800" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2880" w:type="dxa"/>
              </w:tcPr>
              <!--<w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>-->
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve"><xsl:value-of select="Two_str/@Sostavitel"/></w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1728" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:t xml:space="preserve">Рецензент (ы) </w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2880" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1800" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2880" w:type="dxa"/>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
              </w:p>
            </w:tc>
          </w:tr>
        </w:tbl>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="006B3973">
          <w:pPr>
            <w:spacing w:line="360" w:lineRule="auto"/>
            <w:ind w:firstLine="454"/>
            <w:jc w:val="both"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:sectPr w:rsidR="00503FE6">
              <w:pgSz w:w="11906" w:h="16838"/>
              <w:pgMar w:top="1134" w:right="850" w:bottom="1134" w:left="1701" w:header="708" w:footer="708" w:gutter="0"/>
              <w:cols w:space="708"/>
              <w:docGrid w:linePitch="360"/>
            </w:sectPr>
          </w:pPr>
        </w:p>
        <!--"1. Цели освоения дисциплины"-->
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:spacing w:line="360" w:lineRule="auto"/>
            <w:ind w:firstLine="454"/>
            <w:jc w:val="both"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:lastRenderedPageBreak/>
            <w:t xml:space="preserve">1. Цели  освоения дисциплины </w:t>
          </w:r>
        </w:p>
        <!--Вывод текста раздела "Цели освоения дисциплины"-->
        <xsl:for-each select="RPD_1_2_3/Data/GoalsDisciplin/Abzac">
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:ind w:firstLine="709"/>
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
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:ind w:left="426" w:firstLine="0"/>
          </w:pPr>
        </w:p>
        <!--2.Место дисциплины  в структуре ООП-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:spacing w:line="360" w:lineRule="auto"/>
            <w:ind w:firstLine="454"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve">2.Место дисциплины в структуре ООП бакалавриата</w:t>
          </w:r>
        </w:p>
        <!--Вывод первого предложения в этом разделе-->
        <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:ind w:firstLine="709"/>
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
        <xsl:for-each select="RPD_1_2_3/Data/PlaceOOP/Abzac">
          <!--Вывод текста раздела "Место дисциплины в структуре ООП бакалавриата"-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:ind w:firstLine="709"/>
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
        <!--Символ ввода-->
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:ind w:firstLine="454"/>
            <w:rPr>
              <w:i/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <!--"3. Компетенции обучающегося, формируемые в результате освоения дисциплины"-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:spacing w:line="360" w:lineRule="auto"/>
            <w:ind w:firstLine="454"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>3. Компетенции обучающегося, формируемые в результате освоения дисциплины</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRPr="00997CD5" w:rsidRDefault="006B3973" w:rsidP="00997CD5">
          <w:pPr>
            <w:pStyle w:val="a5"/>
            <w:numPr>
              <w:ilvl w:val="0"/>
              <w:numId w:val="0"/>
            </w:numPr>
            <w:spacing w:line="240" w:lineRule="auto"/>
            <w:ind w:firstLine="709"/>
            <w:rPr>
              <w:i/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:t>Процесс изучения дисциплины направлен на формирование следующих компетенций</w:t>
          </w:r>
          <w:r w:rsidR="00997CD5">
            <w:t xml:space="preserve"> </w:t>
          </w:r>
          <w:r w:rsidR="00997CD5">
            <w:rPr>
              <w:i/>
            </w:rPr>
            <w:t>(пометкой «частично» отмечается, если компетенция в рамках данной дисциплины формируется не в полном объеме).</w:t>
          </w:r>
        </w:p>
        <!--Вывод "Компетентностная карта дисциплины"-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:pStyle w:val="a4"/>
            <w:spacing w:after="0" w:line="360" w:lineRule="auto"/>
            <w:ind w:left="0" w:firstLine="454"/>
            <w:jc w:val="center"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:proofErr w:type="spellStart"/>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>Компетентностная карта дисциплины</w:t>
          </w:r>
        </w:p>
        <!--Таблица с компетенциями и их уровневым описанием-->>
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="0" w:type="auto"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
            </w:tblBorders>
            <w:tblLook w:val="01E0" w:firstRow="1" w:lastRow="1" w:firstColumn="1" w:lastColumn="1" w:noHBand="0" w:noVBand="0"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="10296"/>
          </w:tblGrid>
          <w:tr w:rsidR="002F48BD" w:rsidRPr="0054372B" w:rsidTr="003D2F68">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="20" w:type="pct"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRPr="005929EA" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:pStyle w:val="a4"/>
                  <w:spacing w:after="0"/>
                  <w:ind w:left="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                    <w:b/>
                    <w:i/>
                    <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                  </w:rPr>
                </w:pPr>
                <w:r w:rsidRPr="005929EA">
                  <w:rPr>
                    <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                    <w:b/>
                    <w:i/>
                    <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                  </w:rPr>
                  <w:t>Код компетенции</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="80" w:type="pct"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRPr="005929EA" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:pStyle w:val="a4"/>
                  <w:spacing w:after="0"/>
                  <w:ind w:left="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                    <w:b/>
                    <w:i/>
                    <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                  </w:rPr>
                </w:pPr>
                <w:r w:rsidRPr="005929EA">
                  <w:rPr>
                    <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                    <w:b/>
                    <w:i/>
                    <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                  </w:rPr>
                  <w:t>Компетенция</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          
          <xsl:for-each select="RPD_1_2_3/Data/Competetion/Row">
            <w:tr>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="20" w:type="pct"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRPr="005929EA" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:pStyle w:val="a4"/>
                    <w:spacing w:after="0"/>
                    <w:ind w:left="0" w:firstline="0"/>
                    <w:jc w:val="center"/>
                    <w:rPr>
                      <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                      <w:b/>
                      <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                    </w:rPr>
                  </w:pPr>
                  <w:r w:rsidRPr="005929EA">
                    <w:rPr>
                      <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                      <w:b/>
                      <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@CodCompetencii"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="80" w:type="pct"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRPr="005929EA" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:pStyle w:val="a4"/>
                    <w:spacing w:after="0"/>
                    <w:ind w:left="0" w:firstline="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                      <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                    </w:rPr>
                  </w:pPr>
                  <w:r w:rsidRPr="005929EA">
                    <w:rPr>
                      <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                      <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Competencia"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
          </xsl:for-each>
        </w:tbl>
        <!--Вывод списка ключевых компетенций-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:pStyle w:val="a4"/>
            <w:spacing w:after="0" w:line="360" w:lineRule="auto"/>
            <w:ind w:left="0" w:firstLine="709"/>
            <w:jc w:val="center"/>
            <w:rPr>
              <w:b/>
              <w:i/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="00503FE6" w:rsidP="006B3973">
          <w:rPr>
            <w:ind w:left="0" w:firstLine="709"/>
          </w:rPr>
          <w:r>
            <w:t>
              Ключевыми компетенциями, формируемыми в процессе изучения дисциплины являются <xsl:value-of select="RPD_1_2_3/Data/All_key_compet/@Value"/>
            </w:t>
          </w:r>
        </w:p>        
        <!--Уровневое описание каждой ключевой компетенции-->
        <xsl:for-each select="RPD_1_2_3/Data/Key_compet/Competetion">
          <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="006B3973">
            <w:pPr>
              <w:rPr>
                <w:b/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:b/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:lastRenderedPageBreak/>
              <w:t>
                Уровневое описание признаков компетенции <xsl:value-of select="@Name"/>:
              </w:t>
            </w:r>
          </w:p>
          <w:tbl>
            <w:tblPr>
              <w:tblW w:w="0" w:type="auto"/>
              <w:tblBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tblBorders>
              <w:tblLook w:val="01E0" w:firstRow="1" w:lastRow="1" w:firstColumn="1" w:lastColumn="1" w:noHBand="0" w:noVBand="0"/>
            </w:tblPr>
            <w:tblGrid>
              <w:gridCol w:w="3348"/>
              <w:gridCol w:w="6223"/>
            </w:tblGrid>
            <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3348" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl w:val="0"/>
                    <w:jc w:val="center"/>
                    <w:rPr>
                      <w:rFonts w:eastAsia="Calibri"/>
                      <w:b/>
                      <w:i/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                      <w:i/>
                    </w:rPr>
                    <w:t>Уровень освоения</w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="6223" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl w:val="0"/>
                    <w:jc w:val="center"/>
                    <w:rPr>
                      <w:rFonts w:eastAsia="Calibri"/>
                      <w:b/>
                      <w:i/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                      <w:i/>
                    </w:rPr>
                    <w:t>Признаки проявления</w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
            <xsl:for-each select="Yr_compet">
              <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="3348" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:ind w:left="0" w:firstLine="0"/>
                      <w:jc w:val="left"/>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@ur_osv"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="6223" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:pStyle w:val="a4"/>
                      <w:spacing w:after="0"/>
                      <w:ind w:left="0" w:firstline="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                        <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                      </w:rPr>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@priznak_osv"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
              </w:tr>
            </xsl:for-each>
          </w:tbl>
        </xsl:for-each>
        <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
              <w:sz w:val="24"/>
              <w:szCs w:val="24"/>
            </w:rPr>
            <w:lastRenderedPageBreak/>
            <w:t>В результате освоения дисциплины обучающийся должен:</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
              <w:sz w:val="24"/>
              <w:szCs w:val="24"/>
            </w:rPr>
            <w:lastRenderedPageBreak/>
            <w:t>Знать:</w:t>
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
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:pStyle w:val="a5"/>
            <w:numPr>
              <w:ilvl w:val="0"/>
              <w:numId w:val="0"/>
            </w:numPr>
            <w:tabs>
              <w:tab w:val="both" w:pos="708"/>
            </w:tabs>
            <w:ind w:firstLine="454"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
              <w:sz w:val="24"/>
              <w:szCs w:val="24"/>
            </w:rPr>
            <w:lastRenderedPageBreak/>
            <w:t>Уметь:</w:t>
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
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:pStyle w:val="a5"/>
            <w:numPr>
              <w:ilvl w:val="0"/>
              <w:numId w:val="0"/>
            </w:numPr>
            <w:tabs>
              <w:tab w:val="both" w:pos="708"/>
            </w:tabs>
            <w:ind w:firstLine="454"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
              <w:sz w:val="24"/>
              <w:szCs w:val="24"/>
            </w:rPr>
            <w:lastRenderedPageBreak/>
            <w:t>Владеть:</w:t>
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
        <!---->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:pStyle w:val="a5"/>
            <w:numPr>
              <w:ilvl w:val="0"/>
              <w:numId w:val="0"/>
            </w:numPr>
            <w:tabs>
              <w:tab w:val="both" w:pos="708"/>
            </w:tabs>
            <w:ind w:left="709"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve">4. Структура и содержание дисциплины </w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:rPr>
            <w:ind w:firstLine="709"/>
            <w:jc w:val="both"/>
          </w:rPr>
          <w:r>            
            <w:t>
              Общая трудоемкость дисциплины составляет <xsl:value-of select="RPD_1_2_3/Struct_Discip/@ZET"/> зачетные единицы <xsl:value-of select="RPD_1_2_3/Struct_Discip/@All_hours"/> часов.
            </w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>4.1. Содержание разделов дисциплины</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973"/>
        <!--Таблица для структуры дисциплины-->>
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="9468" w:type="dxa"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
            </w:tblBorders>
            <w:tblLayout w:type="fixed"/>
            <w:tblLook w:val="01E0" w:firstRow="1" w:lastRow="1" w:firstColumn="1" w:lastColumn="1" w:noHBand="0" w:noVBand="0"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="563"/>
            <w:gridCol w:w="2605"/>
            <w:gridCol w:w="720"/>
            <w:gridCol w:w="900"/>
            <w:gridCol w:w="1260"/>
            <w:gridCol w:w="900"/>
            <w:gridCol w:w="2520"/>
          </w:tblGrid>
          <w:tr w:rsidR="00503FE6">
            <w:trPr>
              <w:cantSplit/>
              <w:trHeight w:val="1312"/>
            </w:trPr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="563" w:type="dxa"/>
                <w:vMerge w:val="restart"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
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
                  <w:t>№</w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
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
                  <w:t>п/п</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2605" w:type="dxa"/>
                <w:vMerge w:val="restart"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:tcMar>
                  <w:top w:w="28" w:type="dxa"/>
                  <w:left w:w="17" w:type="dxa"/>
                  <w:bottom w:w="0" w:type="dxa"/>
                  <w:right w:w="17" w:type="dxa"/>
                </w:tcMar>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="00503FE6">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Раздел и тема</w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="00503FE6">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>дисциплины</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="720" w:type="dxa"/>
                <w:vMerge w:val="restart"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:textDirection w:val="btLr"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:left="113" w:right="113" w:firstLine="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Семестр</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3060" w:type="dxa"/>
                <w:gridSpan w:val="3"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Виды учебной работы, включая самостоятельную работу студентов и трудоемкость (в часах)</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2520" w:type="dxa"/>
                <w:vMerge w:val="restart"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:b/>
                    <w:i/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Формы текущего контроля  *</w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:b/>
                    <w:i/>
                  </w:rPr>
                </w:pPr>
              </w:p>
            </w:tc>
          </w:tr>
          <w:tr w:rsidR="00503FE6">
            <w:trPr>
              <w:cantSplit/>
              <w:trHeight w:val="1416"/>
            </w:trPr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="563" w:type="dxa"/>
                <w:vMerge/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:vAlign w:val="center"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:widowControl/>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2605" w:type="dxa"/>
                <w:vMerge/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:vAlign w:val="center"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:widowControl/>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="720" w:type="dxa"/>
                <w:vMerge/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:vAlign w:val="center"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:widowControl/>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="900" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:textDirection w:val="btLr"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:left="113" w:right="113" w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Лекции</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1260" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:textDirection w:val="btLr"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:left="113" w:right="113" w:firstLine="0"/>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Семинар</w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:left="113" w:right="113" w:firstLine="0"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:proofErr w:type="spellStart"/>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Лаборат.</w:t>
                </w:r>
                <w:proofErr w:type="spellEnd"/>
                <w:proofErr w:type="spellStart"/>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Практич.</w:t>
                </w:r>
                <w:proofErr w:type="spellEnd"/>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="900" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:textDirection w:val="btLr"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:left="113" w:right="113" w:firstLine="0"/>
                </w:pPr>
                <w:proofErr w:type="spellStart"/>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Самост. раб.</w:t>
                </w:r>
                <w:proofErr w:type="spellEnd"/>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2520" w:type="dxa"/>
                <w:vMerge/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
                <w:vAlign w:val="center"/>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:widowControl/>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:b/>
                    <w:i/>
                  </w:rPr>
                </w:pPr>
              </w:p>
            </w:tc>
          </w:tr>
          <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/Razdel">
            <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="675" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Id"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="4111" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@About_razdel"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="851" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Semestr"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="992" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@SumLec"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="1417" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@SumPraktik"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="1242" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@SumSamJob"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="1242" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@FormCurControl"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
            <xsl:for-each select="Theme">
              <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="675" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:widowControl/>
                      <w:ind w:firstLine="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@Id"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="4111" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:widowControl/>
                      <w:ind w:firstLine="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@About_theme"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="851" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:widowControl/>
                      <w:ind w:firstLine="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@Semestr"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="992" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:widowControl/>
                      <w:ind w:firstLine="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@SumLec"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="1417" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:widowControl/>
                      <w:ind w:firstLine="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@SumPraktik"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="1242" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:widowControl/>
                      <w:ind w:firstLine="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@SumSamJob"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="1242" w:type="dxa"/>
                    <w:tcBorders>
                      <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                      <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    </w:tcBorders>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:widowControl/>
                      <w:ind w:firstLine="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                    </w:pPr>
                    <w:r>
                      <w:t>
                        <xsl:value-of select="@FormCurControl"/>
                      </w:t>
                    </w:r>
                  </w:p>
                </w:tc>
              </w:tr>
            </xsl:for-each>
          </xsl:for-each>

          <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="675" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:widowControl w:val="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:rFonts w:eastAsia="Calibri"/>
                  </w:rPr>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="4111" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pStyle w:val="a4"/>
                <w:spacing w:after="0"/>
                <w:ind w:left="0" w:firstline="0"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                  <w:b/>
                  <w:lang w:val="ru-RU" w:eastAsia="ru-RU"/>
                </w:rPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                    <w:bCs/>
                    <w:iCs/>
                  </w:rPr>
                  <w:t>ИТОГО</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="851" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:widowControl w:val="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:rFonts w:eastAsia="Calibri"/>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1100" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p>
                <w:pPr>
                  <w:widowControl/>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>
                    <xsl:value-of select="RPD_1_2_3/Struct_Discip/@HourLec"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1417" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                    <w:widowControl/>
                    <w:ind w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>
                    <xsl:value-of select="RPD_1_2_3/Struct_Discip/@HourPraktik"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1242" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:widowControl/>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>
                    <xsl:value-of select="RPD_1_2_3/Struct_Discip/@HourSam"/>
                  </w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1242" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p>
              </w:p>
            </w:tc>
          </w:tr>
        </w:tbl>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973"/>
        <!--Вывод "Формы текущего контроля успеваемости (оценочные средства):"-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>*Формы текущего контроля успеваемости (оценочные средства):</w:t>
          </w:r>
        </w:p>
        <!--Вывод списка оценочных средств-->
        <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/SpisokOcenSredstv/OcenSredstv">
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t><xsl:value-of select="@AbbrSredstv"/> - </w:t>
          </w:r>
          <w:r>
            <w:t><xsl:value-of select="@NameSredstv"/></w:t>
          </w:r>
        </w:p>
          </xsl:for-each>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973"/>
        <!--Вывод "Лекционные занятия"-->>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>4.2. Лекционные занятия, их содержание</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <!--Таблица с описанием лекцонных занятий-->>
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="0" w:type="auto"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
            </w:tblBorders>
            <w:tblLayout w:type="fixed"/>
            <w:tblLook w:val="01E0" w:firstRow="1" w:lastRow="1" w:firstColumn="1" w:lastColumn="1" w:noHBand="0" w:noVBand="0"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="560"/>
            <w:gridCol w:w="3328"/>
            <w:gridCol w:w="5580"/>
          </w:tblGrid>
          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="560" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>№</w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>п/п</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3328" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Наименование разделов и тем</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="5580" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Содержание</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/Razdel/Theme/Lecsii/Lec">
            <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="560" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                  <w:pPr>
                    <w:pPr>
                      <w:pStyle w:val="aa"/>
                      <w:ind w:left="0" w:firstLine="0"/>
                      <w:numPr>
                        <w:ilvl w:val="0"/>
                        <w:numId w:val="1"/>
                      </w:numPr>                      
                    </w:pPr>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:proofErr w:type="spellStart"/>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t xml:space="preserve"> </w:t>
                  </w:r>
                  <w:proofErr w:type="spellEnd"/>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3328" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidRDefault="006B3973" w:rsidP="00086368">
                  <w:pPr>
                    <w:ind w:firstLine="34"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:iCs/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@Name_Theme"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="5580" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                  <w:pPr>
                    <w:ind w:firstLine="454"/>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@About_Lec"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
          </xsl:for-each>
        </w:tbl>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973"/>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>4.3. Семинарские, практические, лабораторные занятия, их содержание</w:t>
          </w:r>
        </w:p>
        
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          
        </w:p>
        
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="0" w:type="auto"/>
            <w:tblInd w:w="70" w:type="dxa"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
            </w:tblBorders>
            <w:tblLayout w:type="fixed"/>
            <w:tblCellMar>
              <w:left w:w="70" w:type="dxa"/>
              <w:right w:w="70" w:type="dxa"/>
            </w:tblCellMar>
            <w:tblLook w:val="0000" w:firstRow="0" w:lastRow="0" w:firstColumn="0" w:lastColumn="0" w:noHBand="0" w:noVBand="0"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="1368"/>
            <w:gridCol w:w="7992"/>
          </w:tblGrid>
          <w:tr w:rsidR="00503FE6">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="1368" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                <w:pPr>
                  <w:ind w:firstLine="84"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>№ раздела и темы</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="7992" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
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
                  <w:t>Содержание и формы проведения</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/Razdel/Theme/Praktiki/Praktika">
            <w:tr w:rsidR="00503FE6">
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="1368" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                  <w:pPr>
                    <w:ind w:firstLine="0"/>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@NumRazdel"/>. <xsl:value-of select="@NumTheme"/>.
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="7992" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6">
                  <w:pPr>
                    <w:rPr>
                      <w:bCs/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@About_praktik"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
          </xsl:for-each>
        </w:tbl>
        
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:rPr>
              <w:i/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:i/>
            </w:rPr>
            <w:t xml:space="preserve">К  видам учебной работы отнесены: </w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:pStyle w:val="a7"/>
            <w:tabs>
              <w:tab w:val="clear" w:pos="360"/>
              <w:tab w:val="both" w:pos="708"/>
            </w:tabs>
            <w:spacing w:before="0" w:beforeAutospacing="0" w:after="0" w:afterAutospacing="0"/>
            <w:jc w:val="both"/>
            <w:textAlignment w:val="top"/>
            <w:rPr>
              <w:i/>
              <w:color w:val="333333"/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:i/>
              <w:color w:val="333333"/>
            </w:rPr>
            <w:t xml:space="preserve">лекции, консультации, семинары, практические занятия, лабораторные работы, контрольные работы, коллоквиумы, самостоятельные работы, научно-исследовательская работа, практики, курсовая работа. </w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="00503FE6">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:spacing w:line="360" w:lineRule="auto"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="00503FE6">
          <w:pPr>
            <w:spacing w:line="360" w:lineRule="auto"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>4.4 Вид и форма промежуточной аттестации</w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/Type_and_Form_promej_control/Abzac">
          <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="00503FE6">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:tabs>
                <w:tab w:val="clear" w:pos="360"/>
                <w:tab w:val="both" w:pos="720"/>
              </w:tabs>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve">5. Используемые образовательные технологии </w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_4_5/Obraz_technology/Abzac">
          <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="00503FE6" w:rsidRDefault="00503FE6" w:rsidP="008563B6">
          <w:pPr>
            <w:spacing w:line="360" w:lineRule="auto"/>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
              <w:i/>
            </w:rPr>
            <w:t>Доля занятий с использованием активных и интерактивных методов составляет <xsl:value-of select="RPD_4_5/Obraz_technology/Part_zanyatii/@Value"/>
            </w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973"/>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>6. Оценочные средства для текущего контроля успеваемости, промежуточной аттестации по итогам освоения дисциплины и учебно-методическое обеспечение самостоятельной работы студентов</w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>6.1. Текущий контроль</w:t>
          </w:r>
        </w:p>
        <!--Вывод абзаца "Текущий контроль осуществляется в соответствии с Положением о рейтинговой оценке БГУЭП..."-->
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:firstLine="403"/>
            <w:jc w:val="both"/>
            <w:rPr>
              <w:i/>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
            <w:t xml:space="preserve">Текущий контроль осуществляется в соответствии с Положением о рейтинговой оценке БГУЭП: </w:t>
          </w:r>
          <w:r>
            <w:rPr>
              <w:i/>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
            <w:t>(в соответствии с перечнем заданий и работ, указанных в Разделе 3)</w:t>
          </w:r>
        </w:p>
        <!---Вывод символа ввода-->
        <w:p w:rsidR="002F48BD" w:rsidRPr="002E0B5D" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:ind w:firstLine="403"/>
            <w:rPr>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
          </w:pPr>
        </w:p>

        <!--Таблица раздела "организация текущего контроля"-->
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="0" w:type="auto"/>
            <w:jc w:val="center"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
            </w:tblBorders>
            <w:tblLayout w:type="fixed"/>
            <w:tblLook w:val="00A0" w:firstRow="1" w:lastRow="0" w:firstColumn="1" w:lastColumn="0" w:noHBand="0" w:noVBand="0"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="4500"/>
            <w:gridCol w:w="2000"/>
            <w:gridCol w:w="2845"/>
          </w:tblGrid>
          <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
            <w:trPr>
              <w:trHeight w:val="821"/>
              <w:jc w:val="center"/>
            </w:trPr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="4500" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:pStyle w:val="a5"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:sz w:val="24"/>
                    <w:szCs w:val="24"/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:sz w:val="24"/>
                    <w:szCs w:val="24"/>
                  </w:rPr>
                  <w:t>Контрольные мероприятия по дисциплине</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2000" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:pStyle w:val="a5"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:sz w:val="24"/>
                    <w:szCs w:val="24"/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:sz w:val="24"/>
                    <w:szCs w:val="24"/>
                  </w:rPr>
                  <w:t xml:space="preserve">Количество баллов</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2845" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                <w:pPr>
                  <w:pStyle w:val="a5"/>
                  <w:jc w:val="center"/>
                  <w:rPr>
                    <w:sz w:val="24"/>
                    <w:szCs w:val="24"/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:sz w:val="24"/>
                    <w:szCs w:val="24"/>
                  </w:rPr>
                  <w:t>Разделы и темы дисциплины</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <xsl:for-each select="RPD_6/CurrentControl/Row">
            <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
              <w:trPr>
                <w:trHeight w:val="461"/>
                <w:jc w:val="center"/>
              </w:trPr>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="4500" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:pStyle w:val="a5"/>
                    <w:jc w:val="center"/>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Name_meropriyatie"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="2000" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:pStyle w:val="a5"/>
                    <w:jc w:val="center"/>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t>
                      <xsl:value-of select="@Ball"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="2845" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                  <w:pPr>
                    <w:pStyle w:val="a5"/>
                    <w:jc w:val="center"/>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:r>
                      <w:rPr>
                        <w:sz w:val="24"/>
                        <w:szCs w:val="24"/>
                      </w:rPr>
                      <w:t xml:space="preserve"><xsl:value-of select="@Num_theme"/></w:t>
                    </w:r>
                  </w:pPr>
                </w:p>
              </w:tc>
            </w:tr>
          </xsl:for-each>
        </w:tbl>
        
        <xsl:for-each select="RPD_6/CurrentControl/Abzac">
          <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
            <w:pPr>
              <w:ind w:firstLine="709"/>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:rPr>
              <w:b/>
              <w:i/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:firstLine="360"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>6.2. Образцы тестовых и контрольных заданий текущего контроля</w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_6/Example_Zad_CurControl/Abzac">
          <w:p w:rsidR="008563B6" w:rsidRPr="001E2A16" w:rsidRDefault="008563B6">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/></w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6"/>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="00EC4C26">
          <w:pPr>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r w:rsidR="00EC4C26">
            <w:rPr>
              <w:b/>
              <w:color w:val="000000"/>
            </w:rPr>
            <w:t xml:space="preserve">6.3. Примерная тематика рефератов, эссе, докладов </w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_6/Theme_Referats/Abzac">
          <w:p>
            <w:pPr>
              <w:pStyle w:val="a3"/>
              <w:ind w:left="0" w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="5"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6"/>
        <w:p w:rsidR="00EC4C26" w:rsidRDefault="00EC4C26" w:rsidP="00EC4C26">
          <w:pPr>
            <w:tabs>
              <w:tab w:val="both" w:pos="2910"/>
            </w:tabs>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>6.4. Примерные темы курсовых работ, критерии оценивания</w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_6/Theme_KursJob/Abzac">
          <w:p w:rsidR="00EC4C26" w:rsidRDefault="00EC4C26" w:rsidP="00EC4C26">
            <w:pPr>
              <w:pStyle w:val="a3"/>
              <w:ind w:left="0" w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="4"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
        
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          
        </w:p>
        <!--"Методические указания по организации самостоятельной работы"-->>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:tabs>
              <w:tab w:val="both" w:pos="2910"/>
            </w:tabs>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>6.5. Методические указания по организации самостоятельной работы</w:t>
          </w:r>
        </w:p>
        <!--Вывод методических указаний по организации самостоятельной работы-->
        <xsl:for-each select="RPD_6/MethodUkaz_SamJob/Abzac">
          <w:p>
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
          
        </w:p>
        <!--Таблица с описанием заданий для самостоятельной работы-->>
        <w:tbl>
          <w:tblPr>
            <w:tblW w:w="0" w:type="auto"/>
            <w:tblBorders>
              <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideH w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              <w:insideV w:val="single" w:sz="4" w:space="0" w:color="auto"/>
            </w:tblBorders>
            <w:tblLayout w:type="fixed"/>
            <w:tblLook w:val="01E0" w:firstRow="1" w:lastRow="1" w:firstColumn="1" w:lastColumn="1" w:noHBand="0" w:noVBand="0"/>
          </w:tblPr>
          <w:tblGrid>
            <w:gridCol w:w="560"/>
            <w:gridCol w:w="3328"/>
            <w:gridCol w:w="5580"/>
          </w:tblGrid>
          <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="560" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>№</w:t>
                </w:r>
              </w:p>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>п/п</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="3328" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Наименование тем</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="5580" w:type="dxa"/>
                <w:tcBorders>
                  <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                </w:tcBorders>
              </w:tcPr>
              <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                <w:pPr>
                  <w:ind w:firstLine="0"/>
                  <w:jc w:val="center"/>
                </w:pPr>
                <w:r w:rsidRPr="00086368">
                  <w:rPr>
                    <w:b/>
                  </w:rPr>
                  <w:t>Содержание</w:t>
                </w:r>
              </w:p>
            </w:tc>
          </w:tr>
          <xsl:for-each select="RPD_4_5/Soderjanie_razd_discip/Razdel/Theme/Sam_Job/SamJob">
            <w:tr w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidTr="00086368">
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="560" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                  <w:pPr>
                    <w:pPr>
                      <w:pStyle w:val="aa"/>
                      <w:numPr>
                        <w:ilvl w:val="0"/>
                        <w:numId w:val="3"/>
                      </w:numPr>
                      <w:ind w:left="0" w:firstLine="0"/>
                    </w:pPr>
                    <w:rPr>
                      <w:b/>
                    </w:rPr>
                  </w:pPr>
                  <w:proofErr w:type="spellStart"/>
                  <w:r>
                    <w:rPr>
                      <w:sz w:val="24"/>
                      <w:szCs w:val="24"/>
                    </w:rPr>
                    <w:t xml:space="preserve"> </w:t>
                  </w:r>
                  <w:proofErr w:type="spellEnd"/>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="3328" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="006B3973" w:rsidRPr="00086368" w:rsidRDefault="006B3973" w:rsidP="00086368">
                  <w:pPr>
                    <w:ind w:left="0" w:firstLine="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:iCs/>
                    </w:rPr>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@Name_Theme"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="5580" w:type="dxa"/>
                  <w:tcBorders>
                    <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                    <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                  </w:tcBorders>
                </w:tcPr>
                <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="00086368">
                  <w:pPr>
                    <w:ind w:firstLine="454"/>
                  </w:pPr>
                  <w:r>
                    <w:t>
                      <xsl:value-of select="@About_samJob"/>
                    </w:t>
                  </w:r>
                </w:p>
              </w:tc>
            </w:tr>
          </xsl:for-each>
        </w:tbl>       
        
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6">
          <w:r>
            <w:t></w:t>
          </w:r>
        </w:p>
        
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:tabs>
              <w:tab w:val="both" w:pos="2910"/>
            </w:tabs>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>6.6. Промежуточный  контроль</w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_6/Promej_Control/About_promej_Control/Abzac">
          <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
            <w:pPr>
              <w:ind w:left="0" w:firstLine="709"/>
              <w:tabs>
                <w:tab w:val="both" w:pos="2910"/>
              </w:tabs>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/></w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:left="0" w:firstLine="709"/>
            <w:tabs>
              <w:tab w:val="both" w:pos="2910"/>
            </w:tabs>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve">Образцы тестов, заданий  </w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_6/Promej_Control/Example_Zad/Abzac">
          <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
            <w:pPr>
              <w:ind w:left="0" w:firstLine="709"/>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:left="0" w:firstLine="709"/>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>Перечень вопросов к зачету (экзамену)</w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="RPD_6/Promej_Control/Vopros_k_Ekz/Abzac">
          <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
            <w:pPr>
              <w:pStyle w:val="a3"/>
              <w:ind w:left="0" w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="6"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve">7. Учебно-методическое и информационное обеспечение дисциплины </w:t>
          </w:r>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>7.1. Основная литература:</w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="Recommand_literature/Main_Liter">
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="aa"/>
              <w:ind w:left="0" w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="7"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Author"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6"/>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>7.2. Дополнительная литература:</w:t>
          </w:r>
        </w:p>
        <!--Вывод списка дополнительной литературы-->
        <xsl:for-each select="Recommand_literature/Dop_Liter">
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="aa"/>
              <w:ind w:left="0" w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="8"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Author"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each> 
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6"/>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t>7.3. Программное обеспечение и Интернет-ресурсы:</w:t>
          </w:r>
        </w:p>
        <!--Вывод списка электронных ресурсов-->
        <xsl:for-each select="Recommand_literature/Elektr_Resourse">
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="aa"/>
              <w:ind w:left="0" w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="9"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="24"/>
                <w:szCs w:val="24"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Author"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
        
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:ind w:left="454" w:firstLine="0"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
        </w:p>
        <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
          <w:pPr>
            <w:spacing w:line="360" w:lineRule="auto"/>
            <w:rPr>
              <w:b/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
            </w:rPr>
            <w:t xml:space="preserve">8. Материально-техническое обеспечение дисциплины </w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="Technical_Obespech/Abzac">
          <w:p w:rsidR="008563B6" w:rsidRDefault="008563B6" w:rsidP="008563B6">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
      </w:body>
    </w:document>
  </xsl:template>
</xsl:stylesheet>