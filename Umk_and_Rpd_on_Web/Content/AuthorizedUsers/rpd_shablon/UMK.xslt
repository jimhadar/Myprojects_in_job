<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  
  <xsl:template match="/">
      <w:document
          xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main"
          xmlns:wpc="http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas"
          xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
          xmlns:o="urn:schemas-microsoft-com:office:office"
          xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"
          xmlns:m="http://schemas.openxmlformats.org/officeDocument/2006/math"
          xmlns:v="urn:schemas-microsoft-com:vml"
          xmlns:wp14="http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing"
          xmlns:wp="http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing"
          xmlns:w10="urn:schemas-microsoft-com:office:word"          
          xmlns:w14="http://schemas.microsoft.com/office/word/2010/wordml"
          xmlns:w15="http://schemas.microsoft.com/office/word/2012/wordml"
          xmlns:wpg="http://schemas.microsoft.com/office/word/2010/wordprocessingGroup"
          xmlns:wpi="http://schemas.microsoft.com/office/word/2010/wordprocessingInk"
          xmlns:wne="http://schemas.microsoft.com/office/word/2006/wordml"
          xmlns:wps="http://schemas.microsoft.com/office/word/2010/wordprocessingShape"
          mc:Ignorable="w14 w15 wp14"          
      >        
      <w:body>
        <w:docPr>
          <w:updateFields w:val="true"/>
        </w:docPr>
          <!-- Вывод  "Министерство образования и науки Российской Федерации"-->
          <w:p w:rsidR="006B3973" w:rsidRPr="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:bookmarkStart w:id="0" w:name="_GoBack"/>
            <w:bookmarkEnd w:id="0"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Министерство образования и науки Российской Федерации</w:t>
            </w:r>
          </w:p>
          <!-- Вывод "Байкальский государственный университет" -->
          <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Байкальский государственный университет</w:t>
            </w:r>
          </w:p>
          <!--Вывод "Читинский институт"-->
          <w:p w:rsidR="006B3973" w:rsidRDefault="006B3973" w:rsidP="006B3973">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Читинский институт</w:t>
            </w:r>
          </w:p>
          <!-- Вывод "Кафедра "-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve">Кафедра </w:t>
            </w:r>
            <w:r>
              <w:t>
                <xsl:value-of select="umk/Title/@Kaf_for_prep"/>
              </w:t>
            </w:r>
          </w:p>
          <!--Вывод символов ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">

          </w:p>
          <!--Здесь указываем название дисциплины (ссылку)-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="00AD67F7" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r w:rsidRPr="00AD67F7">
              <w:rPr>
                <w:b/>
                <w:caps/>
                <w:sz w:val="32"/>
                <w:szCs w:val="32"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="umk/Title/@Name_discip"/></w:t>
            </w:r>
          </w:p>
          <!--Далее указываем ссылку на шифр дисциплины-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="006866AF" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r w:rsidRPr="006866AF">
              <w:rPr>
                <w:b/>
                <w:sz w:val="32"/>
                <w:szCs w:val="32"/>
              </w:rPr>
              <w:softHyphen/>
              <w:t>
                <xsl:value-of select="umk/Title/@Shift_discip"/></w:t>
            </w:r>
          </w:p>
          <!--Учебно-методический комплекс (программа и методические указания по изучению курса) - это выводится без изменений-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="00C525A0" w:rsidRDefault="003D2F68" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Учебно-методический комплекс</w:t>
            </w:r>
          </w:p>
          
          <w:p w:rsidR="002F48BD" w:rsidRPr="00C525A0" w:rsidRDefault="003D2F68" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r w:rsidR="002F48BD" w:rsidRPr="00C525A0">
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>(программа и методические указания по изучению курса)</w:t>
            </w:r>
          </w:p>
          <!--Указываются ниже направление и профиль подготовки-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="003A404B" w:rsidRDefault="002F48BD" w:rsidP="004F2DFE">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r w:rsidRPr="003A404B">
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve">для студентов бакалавриата направления </w:t>
            </w:r>
          </w:p>

          <w:p w:rsidR="002F48BD" w:rsidRPr="003A404B" w:rsidRDefault="002F48BD" w:rsidP="004F2DFE">
            <w:pPr>
              <w:i/>
              <w:jc w:val="center"/>              
            </w:pPr>
            <w:r w:rsidRPr="003A404B">
              <w:rPr>
                <w:i/>
                <w:u w:val="single"/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve"><xsl:value-of select="umk/Title/@Cod_Speciality"/> <xsl:value-of select="umk/Title/@Name_speciality"/></w:t>
            </w:r>
          </w:p>
          
          <w:p w:rsidR="002F48BD" w:rsidRPr="003A404B" w:rsidRDefault="00BC58B2" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve">профиля </w:t>
            </w:r>
         </w:p>
          
         <w:p w:rsidR="002F48BD" w:rsidRPr="003A404B" w:rsidRDefault="00BC58B2" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:i/>
                <w:u w:val="single"/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                «<xsl:value-of select="umk/Title/@Specialization"/>»
              </w:t>
            </w:r>
         </w:p> 
          
          <!--Вывод символов ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="00DC7FBB" w:rsidRDefault="00DC7FBB" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="00DC7FBB" w:rsidRDefault="00DC7FBB" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="00DC7FBB" w:rsidRDefault="00DC7FBB" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="00DC7FBB" w:rsidRDefault="00DC7FBB" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="00DC7FBB" w:rsidRDefault="00DC7FBB" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="00DC7FBB" w:rsidRDefault="00DC7FBB" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
          </w:p>
          <!--Вывод "Чита"-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="008A558E" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Чита</w:t>
            </w:r>
          </w:p>
          <!--Вывод "Издательство ЧИ БГУЭП"-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve">Издательство ЧИ БГУЭП</w:t>
            </w:r>
          </w:p>
          <!--Здесь должна быть ссылка на текущий год-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
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
              <w:t>
                <xsl:value-of select="umk/Title/@Year"/></w:t>
            </w:r>
          </w:p>
          <!--Установка разрыва страницы-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:br w:type="page"/>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:lastRenderedPageBreak/>
              <w:t>УДК</w:t>
            </w:r>
          </w:p>
          <!--Здесь указывается ББК (фз что это пока что)-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>ББК</w:t>
            </w:r>
          </w:p>
          <!--Указывается авторский знак (фз что это) точнее ссылка на него-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>Авторский знак</w:t>
            </w:r>
          </w:p>
          <!--Вывод абзаца-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="008A558E">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">Печатается по решению УМК Читинского института (филиала) ФГБОУ ВО «Байкальский государственный университет»</w:t>
            </w:r>
          </w:p>
          <!--Вывод от какого числа составлен протокол, надо узнать, нужно ли дату проставлять автоматически-->>
          <w:p w:rsidR="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>(протокол № ___ от ___ ________ </w:t>
              <w:t>
                <xsl:value-of select="umk/Title/@Year"/> г.)
              </w:t>
            </w:r>
          </w:p>
          <!---->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E"/>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>Учебно-методический комплекс обсужден и утвержден на заседании кафедры</w:t>
              <!--Далее указать ссылку на кафедру-->
              <w:t xml:space="preserve"> <xsl:value-of select="umk/Two_str/@Kaf_for_prep"/> </w:t>
            </w:r>
            <!--от какого числа протокол-->>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>(протокол № ___ от ___ ________ </w:t>
              <w:t>
                <xsl:value-of select="umk/Title/@Year"/> г.)
              </w:t>
            </w:r>
          </w:p>
          <!--Простой вывод символов ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод составителя УМК-->>
          <w:p w:rsidR="005E2612" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>Составитель</w:t>
            </w:r>
            <w:r w:rsidR="005E2612" w:rsidRPr="008A558E">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <!--Здесь указать ссылку на степень, должность и И.О. Фамилия преподавателя, составившего УМК-->>
              <w:t xml:space="preserve"> <xsl:value-of select="umk/Two_str/@Full_inf_about_Sostavitel"/></w:t>
            </w:r>
          </w:p>
          <!--Символы ввода-->
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод рецензента Составляемой УМК-->
          <w:p w:rsidR="005E2612" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">Рецензент </w:t>
            </w:r>
            <w:r w:rsidR="005E2612" w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>___________________________</w:t>
            </w:r>
          </w:p>
          <!--подсказка, что выводить в данных о рецензенте : степень, должность, 
          И.О. Фамилия. (возможно не должно присутствовать в конечном документе)-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="005E2612" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">                  степень, должность И.О. Фамилия</w:t>
            </w:r>
          </w:p>
          <!--символ ввода-->
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод "СОГЛАСОВАНО"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>СОГЛАСОВАНО</w:t>
            </w:r>
          </w:p>
          <!--Вывод: Зав. кафедрой + ссылка на зав. кафедрой с указанием 
        кафедры, степени, должности, И.О. Фамилия преподавателя-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E">
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>Зав. кафедрой</w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:rFonts w:eastAsia="Calibri"/>
                <w:i/>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve"> <xsl:value-of select="umk/Two_str/@NameKaf"/> <xsl:value-of select="umk/Two_str/@ZavKafForKafPlan"/></w:t>
            </w:r>
          </w:p>
        
          <!--Дата-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E">
            <w:pPr>
              <w:pStyle w:val="13"/>
              <w:ind w:firstLine="0"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>___  ______________ </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t><xsl:value-of select="umk/Title/@Year"/> г.</w:t>
            </w:r>
          </w:p>
          <!--Символ ввода-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод декана факультета-->
          <w:p w:rsidR="005E2612" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:rFonts w:eastAsia="Calibri"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">Декан <xsl:value-of select="umk/Two_str/@NameFac"/> факультета </w:t>
            </w:r>
            <w:r w:rsidR="005E2612" w:rsidRPr="008A558E">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="umk/Two_str/@Dean"/>
              </w:t>
            </w:r>
          </w:p>
          <!--Дата-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E">
            <w:pPr>
              <w:pStyle w:val="13"/>
              <w:ind w:firstLine="0"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>___  ______________ </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t><xsl:value-of select="umk/Title/@Year"/> г.</w:t>
            </w:r>
          </w:p>
          <!--Символ ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="13"/>
              <w:ind w:firstLine="0"/>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод "Начальник УМО" с указанием начальника УМО-->
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">Начальник УМО </w:t>
            </w:r>
            <!--Здесь указывается Начальник УМО (пока что не знаю - возможно будет статическим или сделать потом ссылкой)-->
            <w:r w:rsidR="008A558E" w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
                <w:i/>
              </w:rPr>
              <w:t xml:space="preserve">О.К. Куклина</w:t>
            </w:r>
          </w:p>
          <!--Дата-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E">
            <w:pPr>
              <w:pStyle w:val="13"/>
              <w:ind w:firstLine="0"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>___  ______________ </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t><xsl:value-of select="umk/Title/@Year"/> г.</w:t>
            </w:r>
          </w:p>
          <!--Символ ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="13"/>
              <w:ind w:firstLine="0"/>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод зама директора по учебной работе-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E">
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">Зам. директора по учебной работе </w:t>
            </w:r>
            <!--Здесь ссылка на зам. директора по учебной работе-->
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>Л.А. Болтовская</w:t>
            </w:r>
          </w:p>
          <!--Дата-->>
          <w:p w:rsidR="008A558E" w:rsidRPr="008A558E" w:rsidRDefault="008A558E" w:rsidP="008A558E">
            <w:pPr>
              <w:pStyle w:val="13"/>
              <w:ind w:firstLine="0"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>___  ______________ </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t><xsl:value-of select="umk/Title/@Year"/> г.</w:t>
            </w:r>
          </w:p>
          <!--Вывод символа ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="13"/>
              <w:ind w:firstLine="0"/>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Абзац, начинающийся с указания авторского знака и названия дисциплины-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <!--Здесь ссылки на авторский знак-->
              <w:t xml:space="preserve">Авторский знак </w:t>
              <w:t><xsl:value-of select="umk/Title/@Name_discip"/>:</w:t>
            </w:r>
            <!--В этом блоке указать ссылки на код и название направления подготовки-->
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve"> учебно-методический комплекс (программа и методические указания по изучению курса) для студентов бакалавриата направления </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve"><xsl:value-of select="umk/Title/@Cod_Speciality"/> <xsl:value-of select="umk/Title/@Name_speciality"/></w:t>
            </w:r>
            <!--В этом блоке ссылка на профиль подготовки-->
            <w:r w:rsidR="00BC58B2" w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve"> профиля </w:t>
            </w:r>
            <!--Вместо этого кода указать ссылку на название профиля подготовки-->
            <w:r w:rsidR="003D2F68" w:rsidRPr="003A404B">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>
                «<xsl:value-of select="umk/Title/@Specialization"/>»
              </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">) / сост. </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve"><xsl:value-of select="umk/Two_str/@Sostavitel"/></w:t>
            </w:r>
            <!--Вывод: " - Чита Изд-во ЧИ БГУЭП, "-->
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve"> – Чита: Изд-во ЧИ БГУЭП, </w:t>
            </w:r>
            <!--Вывод текущего года-->
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <!--Вместо этого кода - ссылка на текущий год-->
              <w:t>
                <xsl:value-of select="umk/Title/@Year"/></w:t>
            </w:r>
            <!--Вывод количества страниц в УМК-->
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">. – ___ с.</w:t>
            </w:r>
          </w:p>
          <!--Символ ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Абзац, начинающийся с "Учебно-методический комплекс"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:ind w:firstLine="454"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">Учебно-методический комплекс по дисциплине составлен на основании федерального </w:t>
              <w:t xml:space="preserve">государственного образовательного стандарта высшего профессионального образования направления бакалавриата </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:i/>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve"><xsl:value-of select="umk/Title/@Cod_Speciality"/> <xsl:value-of select="umk/Title/@Name_speciality"/></w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="-6"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">, утвержденного __ ______ </w:t>
              <w:t xml:space="preserve"><xsl:value-of select="umk/Title/@Year"/> г. </w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>Содержит программу и методические указания по изучению курса.</w:t>
            </w:r>
          </w:p>
          <!--Вывод абзаца: Педназначен для студентов очной и заочной (или очной формы) обучения-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="22"/>
              <w:spacing w:after="0" w:line="240" w:lineRule="auto"/>
              <w:ind w:firstLine="426"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>Предназначен для студентов </w:t>
              <!--Вместо следующей строки указать ссылку на форму обучения-->
              <w:t xml:space="preserve"> очной и заочной форм (или очной формы)</w:t>
              <w:t xml:space="preserve"> формы обучения.</w:t>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t> </w:t>
            </w:r>
          </w:p>
          <!--Вывод символа ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:jc w:val="right"/>
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод ББК-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a5"/>
              <w:jc w:val="right"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t>ББК</w:t>
            </w:r>
          </w:p>
          <!--Вывод Издательство-->>
          <w:p w:rsidR="00FC2453" w:rsidRDefault="002F48BD" w:rsidP="00942773">
            <w:pPr>
              <w:pStyle w:val="22"/>
              <w:spacing w:after="0" w:line="240" w:lineRule="auto"/>
              <w:ind w:firstLine="454"/>
              <w:jc w:val="right"/>
            </w:pPr>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:t xml:space="preserve">© Издательство ЧИ БГУЭП, </w:t>
              <!--в строке ниже должна быть ссылка на текущий год-->
              <w:t>
                <xsl:value-of select="umk/Title/@Year"/></w:t>
            </w:r>
          </w:p>
          <!--Установка разрыва страницы-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008A558E" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:br w:type="page"/>
            </w:r>
            <w:r w:rsidRPr="008A558E">
              <w:rPr>
                <w:spacing w:val="2"/>
                <w:sz w:val="26"/>
                <w:szCs w:val="26"/>
              </w:rPr>
              <w:lastRenderedPageBreak/>
            </w:r>
          </w:p>
          <!--_________________________Вывод СОДЕРЖАНИЯ_____________________________________________-->>
          <w:p w:rsidR="008618EE" w:rsidRDefault="008618EE" w:rsidP="008618EE">
            <w:pPr>
              <w:pStyle w:val="ae"/>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:bookmarkStart w:id="0" w:name="_Toc263409649"/>
            <w:bookmarkStart w:id="1" w:name="_Toc351130164"/>
            <w:r>
              <w:rPr>
                <w:caps/>
                <w:color w:val="auto"/>
              </w:rPr>
              <w:t>СОДЕРЖАНИЕ</w:t>
            </w:r>
          </w:p>
          <!---->
          <w:p w:rsidR="008618EE" w:rsidRPr="008618EE" w:rsidRDefault="008618EE" w:rsidP="008618EE">
            <w:pPr>
              <w:rPr>
                <w:lang w:eastAsia="en-US"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <!--Вывод пункта "1. Пояснительная записка"-->
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="008618EE">
            <w:pPr>
              <w:pStyle w:val="11"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:caps w:val="0"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:szCs w:val="22"/>
              </w:rPr>
            </w:pPr>
            <w:r>
              <w:fldChar w:fldCharType="begin"/>
            </w:r>
            <w:r>
              <w:instrText xml:space="preserve"> TOC \o "1-3" \h \z \u </w:instrText>
            </w:r>
            <w:r>
              <w:fldChar w:fldCharType="separate"/>
            </w:r>
            <w:hyperlink w:anchor="_Toc351563450" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>1. Пояснительная записка</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563450 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>4</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563451" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>1.1. Цели  освоения дисциплины</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563451 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>4</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563452" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>1.2. Место дисциплины  в структуре ООП бакалавриата</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563452 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>4</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563453" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>1.3. Компетенции обучающегося, формируемые в результате освоения дисциплины</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563453 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>4</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="11"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:caps w:val="0"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:szCs w:val="22"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563454" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>2. Структура дисциплины</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563454 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>6</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563455" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>2.1. Трудоемкость дисциплины и ее общая структура</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563455 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>6</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563456" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>2.2. Содержание разделов дисциплины, структурированное по видам учебной работы и формам обучения</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563456 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>6</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="11"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:caps w:val="0"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:szCs w:val="22"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563457" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>3. Методические указания по организации изучения дисциплины и выполнению самостоятельной работы</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563457 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>9</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563458" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>3.1. Содержание разделов и тем и методические указания по их изучению</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563458 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563459" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>3.2. Список рекомендуемой литературы</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563459 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>9</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="31"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563460" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                  <w:w w:val="101"/>
                </w:rPr>
                <w:t>3.2.1. Основная литература</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563460 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>9</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="31"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563461" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                  <w:w w:val="101"/>
                </w:rPr>
                <w:t>3.2.2. Дополнительная литература</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563461 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!-- <w:t>10</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="31"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563462" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                  <w:w w:val="101"/>
                </w:rPr>
                <w:t>3.2.3. Электронные ресурсы</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563462 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>10</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="11"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:caps w:val="0"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:szCs w:val="22"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563463" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>4. Организация текущего контроля успеваемости и промежуточной аттестации по итогам освоения дисциплины</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563463 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!-- <w:t>10</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563464" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>4.1. Организация текущего контроля</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563464 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>10</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563465" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>4.2.Форма и правила проведения промежуточной аттестации (зачета, экзамена)</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563465 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>10</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563466" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>4.3. Перечень вопросов к зачету, экзамену</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563466 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!--<w:t>10</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>

          <!---->>
          <w:p w:rsidR="00CC78D9" w:rsidRDefault="0033268F">
            <w:pPr>
              <w:pStyle w:val="23"/>
              <w:tabs>
                <w:tab w:val="right" w:leader="dot" w:pos="9628"/>
              </w:tabs>
              <w:rPr>
                <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
                <w:noProof/>
                <w:sz w:val="22"/>
                <w:lang w:eastAsia="ru-RU"/>
              </w:rPr>
            </w:pPr>
            <w:hyperlink w:anchor="_Toc351563467" w:history="1">
              <w:r w:rsidR="00CC78D9" w:rsidRPr="00A7011C">
                <w:rPr>
                  <w:rStyle w:val="af1"/>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:noProof/>
                </w:rPr>
                <w:t>4.4. Образцы экзаменационных тестов, заданий</w:t>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:tab/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="begin"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:instrText xml:space="preserve"> PAGEREF _Toc351563467 \h </w:instrText>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="separate"/>
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <!-- <w:t>10</w:t>-->
              </w:r>
              <w:r w:rsidR="00CC78D9">
                <w:rPr>
                  <w:noProof/>
                  <w:webHidden/>
                </w:rPr>
                <w:fldChar w:fldCharType="end"/>
              </w:r>
            </w:hyperlink>
          </w:p>
          <!---->>
          <w:p w:rsidR="008618EE" w:rsidRDefault="008618EE" w:rsidP="008618EE">
            <w:pPr>
              <w:pStyle w:val="1"/>
              <w:sectPr w:rsidR="008618EE" w:rsidSect="00362E1E">
                <w:footerReference w:type="default" r:id="rId8"/>
                <w:pgSz w:w="11906" w:h="16838"/>
                <w:pgMar w:top="1134" w:right="1134" w:bottom="1134" w:left="1134" w:header="709" w:footer="709" w:gutter="0"/>
                <w:cols w:space="708"/>
                <w:docGrid w:linePitch="360"/>
              </w:sectPr>
            </w:pPr>
            <w:r>
              <w:fldChar w:fldCharType="end"/>
            </w:r>
          </w:p>
          <!--Вывод "Пояснительная записка"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="00B93906" w:rsidRDefault="002F48BD" w:rsidP="008618EE">
            <w:pPr>
              <w:pStyle w:val="1"/>
              <w:rPr>
                <w:lang w:val="en-US"/>
              </w:rPr>
            </w:pPr>
            <w:bookmarkStart w:id="3" w:name="_Toc351563450"/>
            <w:r w:rsidRPr="00EA5ADA">
              <w:lastRenderedPageBreak/>
              <w:t>1. Пояснительная записка</w:t>
            </w:r>
            <w:bookmarkEnd w:id="1"/>
            <w:bookmarkEnd w:id="2"/>
            <w:bookmarkEnd w:id="3"/>
            <w:r w:rsidR="00297B6F" w:rsidRPr="00EA5ADA">
              <w:t xml:space="preserve"> </w:t>
            </w:r>
          </w:p>

          <!--Вывод текста в разделе "1. Пояснительная записка"-->
          <w:p w:rsidR="006D40F1" w:rsidRDefault="006D40F1" w:rsidP="006D40F1">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve">УМК составлен в соответствии с требованиями ФГОС ВО, с учетом рекомендаций ПрОПОП ВО по направлению подготовки</w:t>
            </w:r>
            <w:r>
              <w:rPr>
                <w:i/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve"> <xsl:value-of select="umk/Title/@Cod_Speciality"/> <xsl:value-of select="umk/Title/@Name_speciality"/> </w:t>
            </w:r>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve">и в соответствии с учебным планом профиля </w:t>
            </w:r>
            <w:r w:rsidR="00D13C0D">
              <w:rPr>
                <w:i/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space="preserve">«<xsl:value-of select="umk/Title/@Specialization"/>»</w:t>
            </w:r>
            <w:r w:rsidR="004D29B4">
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>, утвержденного ученым советом института.</w:t>
            </w:r>
          </w:p>
          
          <!--Вывод "Цели освоения дисциплины"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="00B93906" w:rsidRDefault="002F48BD" w:rsidP="00B93906">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="4" w:name="_Toc351130165"/>
            <w:bookmarkStart w:id="5" w:name="_Toc351563451"/>
            <w:r w:rsidRPr="00B93906">
              <w:t>1.1. Цели  освоения дисциплины</w:t>
            </w:r>
            <w:bookmarkEnd w:id="4"/>
            <w:bookmarkEnd w:id="5"/>
          </w:p>
          <!--Вывод текста раздела "Цели освоения дисциплины"-->
        <xsl:for-each select="umk/UMK_razdel_1/Data/GoalsDisciplin/Abzac">
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Место дисциплины в системе ООП бакалавриата"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="004D29B4" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="6" w:name="_Toc351130166"/>
            <w:bookmarkStart w:id="7" w:name="_Toc351563452"/>
            <w:r>
              <w:t xml:space="preserve">1.2. Место дисциплины в структуре ООП бакалавриата</w:t>
            </w:r>
            <w:bookmarkEnd w:id="6"/>
            <w:bookmarkEnd w:id="7"/>
          </w:p>
        <!--Вывод первого предложения в этом разделе-->
        <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:ind w:firstLine="709"/>
            <w:jc w:val="both"/>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
            <w:t>
              <xsl:value-of select="umk/UMK_razdel_1/Data/PlaceOOP/AboutPlaceOOP/@Value"/>
            </w:t>
          </w:r>
        </w:p>
        <xsl:for-each select="umk/UMK_razdel_1/Data/PlaceOOP/Abzac">
          <!--Вывод текста раздела "Место дисциплины в структуре ООП бакалавриата"-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Компетенции обучающегося, формируемые в результате освоения дисциплины"-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="8" w:name="_Toc351130167"/>
            <w:bookmarkStart w:id="9" w:name="_Toc351563453"/>
            <w:r>
              <w:t>1.3. Компетенции обучающегося, формируемые в результате освоения дисциплины</w:t>
            </w:r>
            <w:bookmarkEnd w:id="8"/>
            <w:bookmarkEnd w:id="9"/>
          </w:p>
          <!--Вывод содержимого раздела "Компетенции обучающегося, формируемые в результате освоения дисциплины"-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Процесс изучения дисциплины направлен на формирование следующих компетенций.</w:t>
            </w:r>
          </w:p>
          <!--Вывод "Компетентностная карта дисциплины"-->
          <w:p w:rsidR="002F48BD" w:rsidRPr="0054372B" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a7"/>
              <w:spacing w:after="0" w:line="360" w:lineRule="auto"/>
              <w:ind w:left="0" w:firstLine="454"/>
              <w:jc w:val="center"/>
            </w:pPr>
            <w:r w:rsidRPr="0054372B">
              <w:rPr>
                <w:rFonts w:ascii="Times New Roman" w:hAnsi="Times New Roman"/>
                <w:b/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Компетентностная карта дисциплины</w:t>
            </w:r>
          </w:p>
          <!--Далее здесь надо сформировать таблицы с компетенциями и их описанием!!!-->
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
          <xsl:for-each select="umk/UMK_razdel_1/Data/Competetion/Row">
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
        
          <!--Здесь выводится список ключевых компетенций!-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Ключевыми компетенциями, формируемыми в процессе изучения дисциплины являются <xsl:value-of select="umk/UMK_razdel_1/Data/All_key_compet/@Value"/></w:t>
              <!--Далее ссылки на названия ключевых компетенций-->
            </w:r>
          </w:p>
        
          <!--Далее описание каждой ключевой дисциплины-->
        <xsl:for-each select="umk/UMK_razdel_1/Data/Key_compet/Competetion">
          <!--Вывод символов ввода-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:jc w:val="center"/>
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
                <w:t>Уровневое описание признаков компетенции <xsl:value-of select="@Name"/>:</w:t>
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
                        <w:widowControl w:val="0"/>
                        <w:jc w:val="left"/>
                        <w:rPr>
                          <w:rFonts w:eastAsia="Calibri"/>
                        </w:rPr>
                      </w:pPr>
                      <w:r>
                        <w:t>
                          <xsl:value-of select="@ur_osv"/></w:t>
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
                        <w:jc w:val="both"/>
                        <w:rPr>
                          <w:rFonts w:eastAsia="Calibri"/>
                        </w:rPr>
                      </w:pPr>
                      <w:r>
                        <w:t><xsl:value-of select="@priznak_osv"/></w:t>
                      </w:r>
                    </w:p>
                  </w:tc>
                </w:tr>                
                </xsl:for-each>
              </w:tbl>            
        </xsl:for-each>
          <!--Вывод "В результате освоения дисциплины обучающийся должен:"-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD"/><w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:b/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>В результате освоения дисциплины обучающийся должен:</w:t>
            </w:r>
          </w:p>
          <!--Вывод "Знать"-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a8"/>
              <w:tabs>
                <w:tab w:val="clear" w:pos="360"/>
                <w:tab w:val="left" w:pos="708"/>
              </w:tabs>
              <w:ind w:left="709"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:b/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Знать:</w:t>
            </w:r>
          </w:p>
        <xsl:for-each select="umk/UMK_razdel_1/Data/Student_must_znat/Abzac">
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a8"/>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:tabs>
                <w:tab w:val="clear" w:pos="360"/>
                <w:tab w:val="left" w:pos="720"/>
              </w:tabs>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Уметь:"-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a8"/>
              <w:tabs>
                <w:tab w:val="clear" w:pos="360"/>
                <w:tab w:val="left" w:pos="708"/>
              </w:tabs>
              <w:ind w:left="709"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:b/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Уметь:</w:t>
            </w:r>
          </w:p>
        <xsl:for-each select="umk/UMK_razdel_1/Data/Student_must_umet/Abzac">
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a8"/>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:tabs>
                <w:tab w:val="clear" w:pos="360"/>
                <w:tab w:val="left" w:pos="720"/>
              </w:tabs>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Владеть"-->
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a8"/>              
              <w:tabs>
                <w:tab w:val="clear" w:pos="360"/>
                <w:tab w:val="left" w:pos="708"/>
              </w:tabs>
              <w:ind w:left="709"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:b/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>Владеть:</w:t>
            </w:r>
          </w:p>
        <xsl:for-each select="umk/UMK_razdel_1/Data/Student_must_vladet/Abzac">
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:pStyle w:val="a8"/>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
              <w:tabs>
                <w:tab w:val="clear" w:pos="360"/>
                <w:tab w:val="left" w:pos="720"/>
              </w:tabs>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Структура дисциплины"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="008F606C" w:rsidRDefault="002F48BD" w:rsidP="00EA5ADA">
            <w:pPr>
              <w:pStyle w:val="1"/>
            </w:pPr>
            <w:bookmarkStart w:id="10" w:name="_Toc274825242"/>
            <w:r w:rsidRPr="00F07149">
              <w:br w:type="page"/>
            </w:r>
            <w:bookmarkStart w:id="11" w:name="_Toc351130168"/>
            <w:bookmarkStart w:id="12" w:name="_Toc351563454"/>
            <w:r w:rsidRPr="008F606C">
              <w:lastRenderedPageBreak/>
              <w:t xml:space="preserve">2. Структура дисциплины</w:t>
            </w:r>
            <w:bookmarkEnd w:id="11"/>
            <w:bookmarkEnd w:id="12"/>
            <w:bookmarkEnd w:id="10"/>
          </w:p>
          <!--Вывод "Трудоемкость дисциплины и ее общая структура"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="003D7FB2" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="13" w:name="_Toc351130169"/>
            <w:bookmarkStart w:id="14" w:name="_Toc351563455"/>
            <w:r w:rsidRPr="003D7FB2">
              <w:t>2.1. Трудоемкость дисциплины и ее общая структура</w:t>
            </w:r>
            <w:bookmarkEnd w:id="13"/>
            <w:bookmarkEnd w:id="14"/>
          </w:p>
        <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F" w:rsidP="003F7F2F">
          <w:pPr>
            <w:jc w:val="both"/>
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
            <w:t>Общая трудоемкость дисциплины составляет <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@ZET"/> зачетные единицы, <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@All_hours"/> часов.</w:t>
          </w:r>
        </w:p>
        <!--Формирование таблицы--><w:tbl>
        <w:tblPr>
          <w:tblW w:w="9357" w:type="dxa"/>
          <w:tblInd w:w="-72" w:type="dxa"/>
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
          <w:gridCol w:w="3960"/>
          <w:gridCol w:w="1303"/>
          <w:gridCol w:w="1397"/>
          <w:gridCol w:w="1348"/>
          <w:gridCol w:w="1349"/>
        </w:tblGrid>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:vMerge w:val="restart"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:vMerge w:val="restart"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t><xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@FormaOb"/></w:t></w:r>
            </w:p>
          </w:tc>          
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t xml:space="preserve">Курс </w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t><xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@Course"/></w:t>              
              </w:r>
            </w:p>
          </w:tc>
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t xml:space="preserve">Семестр </w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@Semestr"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>          
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>Лекции</w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@HourLec"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>          
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>Практические (сем., лаб.) занятия</w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@HourPraktik"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>Самостоятельная работа</w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@HourSam"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>          
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>Всего часов</w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@All_hours"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>          
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>Курсовая работа</w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@Kursov_job"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>Зачет (семестр)</w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@Zachet"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>         
        </w:tr>
        <w:tr w:rsidR="003F7F2F" w:rsidTr="003F7F2F">
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="3960" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:hideMark/>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="45"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>Экзамен (семестр)</w:t>
              </w:r>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="1303" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="003F7F2F" w:rsidRDefault="003F7F2F">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:firstLine="72"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@Ekzamen"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>
        </w:tr>
      </w:tbl>           
          <!--Вывод "Содержание разделов дисциплины, структуриованное по видам учебной работы и формам обучения"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="003D7FB2" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="15" w:name="_Toc351563456"/>
            <w:r w:rsidRPr="003D7FB2">
              <w:t>2.2. Содержание разделов дисциплины, структурированное по видам учебной работы и формам обучения</w:t>
            </w:r>
            <w:bookmarkEnd w:id="15"/>
          </w:p>
        <!--Вывод формы обучения-->
        <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:jc w:val="center"/>
            <w:rPr>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
          </w:pPr>
          <w:r>
            <w:rPr>
              <w:b/>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
            <w:t>Форма обучения <xsl:value-of select="umk/Razdel_2/Soderjanie_razd_discip/@FormaOb"/></w:t>
          </w:r>
        </w:p>
        <!--Вывод таблицы раздела "Содержание разделов дисциплины, структуриованное по видам учебной работы и формам обучения"--><w:tbl>
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
          <w:gridCol w:w="675"/>
          <w:gridCol w:w="4111"/>
          <w:gridCol w:w="851"/>
          <w:gridCol w:w="992"/>
          <w:gridCol w:w="1417"/>
          <w:gridCol w:w="1242"/>
        </w:tblGrid>
        <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
          <w:trPr>
            <w:cantSplit/>
            <w:trHeight w:val="1312"/>
          </w:trPr>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="675" w:type="dxa"/>
              <w:vMerge w:val="restart"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
            </w:p>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:rPr>
                  <w:b/>
                </w:rPr>
              </w:pPr>
            </w:p>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
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
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
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
              <w:tcW w:w="4111" w:type="dxa"/>
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
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
            </w:p>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
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
                <w:t>Раздел и тема</w:t>
              </w:r>
            </w:p>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
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
              <w:tcW w:w="851" w:type="dxa"/>
              <w:vMerge w:val="restart"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:textDirection w:val="btLr"/>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:left="113" w:right="113"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
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
              <w:tcW w:w="3651" w:type="dxa"/>
              <w:gridSpan w:val="3"/>
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
        </w:tr>
        <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
          <w:trPr>
            <w:cantSplit/>
            <w:trHeight w:val="1416"/>
          </w:trPr>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="675" w:type="dxa"/>
              <w:vMerge/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:vAlign w:val="center"/>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="4111" w:type="dxa"/>
              <w:vMerge/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:vAlign w:val="center"/>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
            </w:p>
          </w:tc>
          <w:tc>
            <w:tcPr>
              <w:tcW w:w="851" w:type="dxa"/>
              <w:vMerge/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:vAlign w:val="center"/>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
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
              <w:textDirection w:val="btLr"/>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:left="113" w:right="113"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
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
              <w:tcW w:w="1417" w:type="dxa"/>
              <w:tcBorders>
                <w:top w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:left w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:bottom w:val="single" w:sz="4" w:space="0" w:color="auto"/>
                <w:right w:val="single" w:sz="4" w:space="0" w:color="auto"/>
              </w:tcBorders>
              <w:textDirection w:val="btLr"/>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:ind w:left="113" w:right="113"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:rPr>
                  <w:b/>
                </w:rPr>
                <w:t>Семинар</w:t>
              </w:r>
            </w:p>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:left="113" w:right="113"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:rPr>
                  <w:b/>
                </w:rPr>
                <w:t>Лаборат. Практич.</w:t>
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
              <w:textDirection w:val="btLr"/>
            </w:tcPr>
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:ind w:left="113" w:right="113"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:rPr>
                  <w:b/>
                </w:rPr>
                <w:t>Самост. раб.</w:t>
              </w:r>
            </w:p>
          </w:tc>
        </w:tr>
          <xsl:for-each select="umk/Razdel_2/Soderjanie_razd_discip/Razdel">
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
                    <w:widowControl w:val="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:rFonts w:eastAsia="Calibri"/>
                      <w:b/>
                      <w:iCs/>
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
                    <w:widowControl w:val="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:rFonts w:eastAsia="Calibri"/>
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
                    <w:widowControl w:val="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:rFonts w:eastAsia="Calibri"/>
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
                    <w:widowControl w:val="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:rFonts w:eastAsia="Calibri"/>
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
                    <w:widowControl w:val="0"/>
                    <w:jc w:val="both"/>
                    <w:rPr>
                      <w:rFonts w:eastAsia="Calibri"/>
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
                      <w:widowControl w:val="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
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
                      <w:widowControl w:val="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
                        <w:b/>
                        <w:iCs/>
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
                      <w:widowControl w:val="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
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
                      <w:widowControl w:val="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
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
                      <w:widowControl w:val="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
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
                      <w:widowControl w:val="0"/>
                      <w:jc w:val="both"/>
                      <w:rPr>
                        <w:rFonts w:eastAsia="Calibri"/>
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
              <w:pPr>
                <w:widowControl w:val="0"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                  <w:bCs/>
                  <w:iCs/>
                </w:rPr>
              </w:pPr>
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
                <w:widowControl w:val="0"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:rPr>
                  <w:b/>
                </w:rPr>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@HourLec"/>
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
                <w:widowControl w:val="0"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:rPr>
                  <w:b/>
                </w:rPr>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@HourPraktik"/>
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
                <w:widowControl w:val="0"/>
                <w:jc w:val="both"/>
                <w:rPr>
                  <w:rFonts w:eastAsia="Calibri"/>
                  <w:b/>
                </w:rPr>
              </w:pPr>
              <w:r>
                <w:rPr>
                  <w:b/>
                </w:rPr>
                <w:t>
                  <xsl:value-of select="umk/Razdel_2/Struct_discip/Main_inform/@HourSam"/>
                </w:t>
              </w:r>
            </w:p>
          </w:tc>
        </w:tr>
      </w:tbl>
        
          <!--Вывод "Методические указания по организации изучения дисциплины и выполнения самостоятельной работы"-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="003F7F2F" w:rsidP="00B03A7C">
            <w:pPr>
              <w:pStyle w:val="1"/>
            </w:pPr>
            <w:r>
              <w:br w:type="page"/>
            </w:r>
            <w:bookmarkStart w:id="16" w:name="_Toc351130170"/>
            <w:bookmarkStart w:id="17" w:name="_Toc351563457"/>
            <w:r w:rsidR="002F48BD">
              <w:lastRenderedPageBreak/>
              <w:t>3. Методические указания по организации изучения дисциплины и выполнению самостоятельной работы</w:t>
            </w:r>
            <w:bookmarkEnd w:id="16"/>
            <w:bookmarkEnd w:id="17"/>
          </w:p>
        <!--Вывод "Содержание разделов и тем и методические указания по их изучению"-->>
        <w:p w:rsidR="002F48BD" w:rsidRPr="003D7FB2" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
          <w:pPr>
            <w:pStyle w:val="2"/>
          </w:pPr>
          <w:bookmarkStart w:id="18" w:name="_Toc351130171"/>
          <w:bookmarkStart w:id="19" w:name="_Toc351563458"/>
          <w:r w:rsidRPr="003D7FB2">
            <w:t>3.1. Содержание разделов и тем и методические указания по их изучению</w:t>
          </w:r>
          <w:bookmarkEnd w:id="18"/>
          <w:bookmarkEnd w:id="19"/>
        </w:p>
        
        <xsl:for-each select="umk/Razdel_2/Soderjanie_razd_discip/Razdel">
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:shd w:val="clear" w:color="auto" w:fill="FFFFFF"/>
              <w:jc w:val="center"/>
              <w:rPr>
                <w:w w:val="101"/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
            </w:pPr>
            <w:r w:rsidRPr="00DB5A3A">
              <w:rPr>
                <w:b/>
                <w:w w:val="101"/>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t xml:space ="preserve"><xsl:value-of select="@Name"/> <xsl:value-of select="@About_razdel"/></w:t>
            </w:r>
          </w:p>
          <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
            <w:pPr>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
            </w:pPr>
          </w:p>
          <xsl:for-each select="Theme">
            <!--Вывод "Содержание лекционных занятий"-->
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
              <w:pPr>
                <w:shd w:val="clear" w:color="auto" w:fill="FFFFFF"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
              </w:pPr>
              <w:r w:rsidRPr="00DB5A3A">
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
                <w:t xml:space ="preserve"><xsl:value-of select="@Name"/> <xsl:value-of select="@About_theme"/></w:t>
              </w:r>
            </w:p>
            <!--Вывод символа ввода-->
            <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
              <w:pPr>
                <w:rPr>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
              </w:pPr>
            </w:p>
            
            <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
              <w:pPr>
                <w:shd w:val="clear" w:color="auto" w:fill="FFFFFF"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
              </w:pPr>
              <w:r w:rsidRPr="00FF1DAA">
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
                <w:t>Содержание лекционных занятий по теме</w:t>
              </w:r>
            </w:p>
            <!--Таблица с содержанием лекционных занятий-->
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
                <w:gridCol w:w="3528"/>
                <w:gridCol w:w="5940"/>
              </w:tblGrid>
              <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="3528" w:type="dxa"/>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRPr="00920F57" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:jc w:val="center"/>
                    </w:pPr>
                    <w:r>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                      <w:t xml:space="preserve">№ лекционного занятия</w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="5940" w:type="dxa"/>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:jc w:val="center"/>
                    </w:pPr>
                    <w:r>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                      <w:t>Содержание</w:t>
                    </w:r>
                  </w:p>
                </w:tc>
              </w:tr>
              <xsl:for-each select="Lecsii/Lec">
                <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
                  <w:tc>
                    <w:tcPr>
                      <w:tcW w:w="3528" w:type="dxa"/>
                    </w:tcPr>
                    <w:p w:rsidR="002F48BD" w:rsidRPr="005D615E" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                      <w:r>
                        <w:t>
                          <xsl:value-of select="@Name"/>
                        </w:t>
                      </w:r>
                    </w:p>
                  </w:tc>
                  <w:tc>
                    <w:tcPr>
                      <w:tcW w:w="5940" w:type="dxa"/>
                    </w:tcPr>                 
                    <w:p w:rsidR="002F48BD" w:rsidRPr="005D615E" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
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
            <!--Вывод символа ввода-->
            <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
              <w:pPr>
                <w:rPr>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
              </w:pPr>
            </w:p>
            <!--Вывод "Содержание семинарских (практических, лабораторных) занятий"-->
            <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
              <w:pPr>
                <w:shd w:val="clear" w:color="auto" w:fill="FFFFFF"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
              </w:pPr>
              <w:r w:rsidRPr="00FF1DAA">
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
                <w:t>Содержание семинарских (практических, лабораторных) занятий</w:t>
              </w:r>
            </w:p>
            <!--таблица с содержанием семинарских занятий-->
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
                <w:gridCol w:w="3528"/>
                <w:gridCol w:w="5940"/>
              </w:tblGrid>
              <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="3528" w:type="dxa"/>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRPr="00920F57" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:jc w:val="center"/>
                    </w:pPr>
                    <w:r>
                      <w:rPr>
                        <w:b/>
                      </w:rPr>
                      <w:t xml:space="preserve">№ занятия</w:t>
                    </w:r>
                  </w:p>
                </w:tc>
                <w:tc>
                  <w:tcPr>
                    <w:tcW w:w="5940" w:type="dxa"/>
                  </w:tcPr>
                  <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                    <w:pPr>
                      <w:jc w:val="center"/>
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
              <xsl:for-each select="Praktiki/Praktika">
                <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
                  <w:tc>
                    <w:tcPr>
                      <w:tcW w:w="3528" w:type="dxa"/>
                    </w:tcPr>
                    <w:p w:rsidR="002F48BD" w:rsidRPr="005D615E" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
                      <w:r>
                        <w:t>
                          <xsl:value-of select="@Name"/>
                        </w:t>
                      </w:r>
                    </w:p>
                  </w:tc>
                  <w:tc>
                    <w:tcPr>
                      <w:tcW w:w="5940" w:type="dxa"/>
                    </w:tcPr>
                    <w:p w:rsidR="002F48BD" w:rsidRPr="002C6CD0" w:rsidRDefault="002F48BD" w:rsidP="003D2F68">
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
            <!--Вывод символа ввода-->
            <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
              <w:pPr>
                <w:rPr>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
              </w:pPr>
            </w:p>
            <!--Вывод "Методические указания по изучению темы и организации самостоятельной работы"-->
            <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
              <w:pPr>
                <w:shd w:val="clear" w:color="auto" w:fill="FFFFFF"/>
                <w:jc w:val="center"/>
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
              </w:pPr>
              <w:r w:rsidRPr="00FF1DAA">
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
                <w:t xml:space="preserve">Методические указания по </w:t>
              </w:r>
              <w:r>
                <w:rPr>
                  <w:b/>
                  <w:w w:val="101"/>
                  <w:sz w:val="28"/>
                  <w:szCs w:val="28"/>
                </w:rPr>
                <w:t>изучению темы и организации самостоятельной работы</w:t>
              </w:r>
            </w:p>            
            <xsl:for-each select="Sam_Job/SamJob">
              <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                <w:pPr>
                  <w:shd w:val="clear" w:color="auto" w:fill="FFFFFF"/>
                  <w:jc w:val="both"/>
                  <w:rPr>
                    <w:sz w:val="28"/>
                    <w:szCs w:val="28"/>
                  </w:rPr>
                </w:pPr>
                <w:r>
                  <w:rPr>
                    <w:b/>
                    <w:sz w:val="28"/>
                    <w:szCs w:val="28"/>
                  </w:rPr>
                  <w:t xml:space="preserve"><xsl:value-of select="@Name"/> </w:t>
                </w:r>
                <w:r>
                  <w:rPr>
                    <w:sz w:val="28"/>
                    <w:szCs w:val="28"/>
                  </w:rPr>
                  <w:t><xsl:value-of select="@About_samJob"/></w:t>
                </w:r>
              </w:p>
              <!--Вывод символа ввода-->              
            </xsl:for-each>
            <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
                <w:pPr>
                  <w:rPr>
                    <w:sz w:val="28"/>
                    <w:szCs w:val="28"/>
                  </w:rPr>
                </w:pPr>
              </w:p>
         </xsl:for-each> 
        </xsl:for-each>
        <!--Вывод символа ввода-->
        <w:p w:rsidR="002F48BD" w:rsidRPr="00FF1DAA" w:rsidRDefault="002F48BD" w:rsidP="002F48BD">
          <w:pPr>
            <w:rPr>
              <w:sz w:val="28"/>
              <w:szCs w:val="28"/>
            </w:rPr>
          </w:pPr>
        </w:p>
          <!--Вывод "Список рекомендуемой литературы"-->
          <w:p w:rsidR="002F48BD" w:rsidRPr="003D7FB2" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="20" w:name="_Toc351130172"/>
            <w:bookmarkStart w:id="21" w:name="_Toc351563459"/>
            <w:r w:rsidRPr="003D7FB2">
              <w:t>3.2. Список рекомендуемой литературы</w:t>
            </w:r>
            <w:bookmarkEnd w:id="20"/>
            <w:bookmarkEnd w:id="21"/>
          </w:p>
          <!--Вывод "Основная литература"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="3"/>
              <w:rPr>
                <w:w w:val="101"/>
              </w:rPr>
            </w:pPr>
            <w:bookmarkStart w:id="22" w:name="_Toc351130173"/>
            <w:bookmarkStart w:id="23" w:name="_Toc351563460"/>
            <w:r w:rsidRPr="001B11BA">
              <w:rPr>
                <w:w w:val="101"/>
              </w:rPr>
              <w:t>3.2.1. Основная литература</w:t>
            </w:r>
            <w:bookmarkEnd w:id="22"/>
            <w:bookmarkEnd w:id="23"/>
          </w:p>
        <!--Вывод списка основной литературы-->
        <xsl:for-each select="umk/Recommand_literature/Main_Liter">
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="a3"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="2"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Author"/></w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Дополнительная литература"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="3"/>
              <w:rPr>
                <w:w w:val="101"/>
              </w:rPr>
            </w:pPr>
            <w:bookmarkStart w:id="24" w:name="_Toc351130174"/>
            <w:bookmarkStart w:id="25" w:name="_Toc351563461"/>
            <w:r w:rsidRPr="001B11BA">
              <w:rPr>
                <w:w w:val="101"/>
              </w:rPr>
              <w:t>3.2.2. Дополнительная литература</w:t>
            </w:r>
            <w:bookmarkEnd w:id="24"/>
            <w:bookmarkEnd w:id="25"/>
          </w:p>
        <!--Вывод списка дополнительной литературы-->
        <xsl:for-each select="umk/Recommand_literature/Dop_Liter">
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="a3"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="3"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Author"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Электронные ресурсы"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="3"/>
              <w:rPr>
                <w:w w:val="101"/>
              </w:rPr>
            </w:pPr>
            <w:bookmarkStart w:id="26" w:name="_Toc351130175"/>
            <w:bookmarkStart w:id="27" w:name="_Toc351563462"/>
            <w:r>
              <w:rPr>
                <w:w w:val="101"/>
              </w:rPr>
              <w:t xml:space="preserve">3.2.3. Электронные ресурсы</w:t>
            </w:r>
            <w:bookmarkEnd w:id="26"/>
            <w:bookmarkEnd w:id="27"/>
          </w:p>
        <!--Вывод списка электронных ресурсов-->
        <xsl:for-each select="umk/Recommand_literature/Elektr_Resourse">
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="a3"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="4"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Author"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Организация текущего контроля успеваемости..."-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="00EA5ADA">
            <w:pPr>
              <w:pStyle w:val="1"/>
            </w:pPr>
            <w:bookmarkStart w:id="28" w:name="_Toc351130176"/>
            <w:bookmarkStart w:id="29" w:name="_Toc351563463"/>
            <w:r>
              <w:t>4. Организация текущего контроля успеваемости и промежуточной аттестации по итогам освоения дисциплины</w:t>
            </w:r>
            <w:bookmarkEnd w:id="28"/>
            <w:bookmarkEnd w:id="29"/>
          </w:p>
          <!--Вывод "Организация текущего контроля"-->>
          <w:p w:rsidR="002F48BD" w:rsidRPr="003D7FB2" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="30" w:name="_Toc351130177"/>
            <w:bookmarkStart w:id="31" w:name="_Toc351563464"/>
            <w:r>
              <w:t>4.1. Организация текущего контроля</w:t>
            </w:r>
            <w:bookmarkEnd w:id="30"/>
            <w:bookmarkEnd w:id="31"/>
          </w:p>
        <!--Вывод абзаца "Текущий контроль осуществляется в соответствии с Положением о рейтинговой оценке БГУЭП..."-->
        <w:p w:rsidR="00F87D78" w:rsidRDefault="00F87D78" w:rsidP="00F87D78">
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
            <w:gridCol w:w="5352"/>
            <w:gridCol w:w="1474"/>
            <w:gridCol w:w="2519"/>
          </w:tblGrid>
          <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
            <w:trPr>
              <w:trHeight w:val="821"/>
              <w:jc w:val="center"/>
            </w:trPr>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="5352" w:type="dxa"/>
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
                <w:tcW w:w="1474" w:type="dxa"/>
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
                  <w:t xml:space="preserve">Количество </w:t>
                </w:r>
              </w:p>
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
                  <w:t>баллов</w:t>
                </w:r>
              </w:p>
            </w:tc>
            <w:tc>
              <w:tcPr>
                <w:tcW w:w="2519" w:type="dxa"/>
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
          <xsl:for-each select="umk/CurrentControl/CurControl/Row">
            <w:tr w:rsidR="002F48BD" w:rsidTr="003D2F68">
              <w:trPr>
                <w:trHeight w:val="461"/>
                <w:jc w:val="center"/>
              </w:trPr>
              <w:tc>
                <w:tcPr>
                  <w:tcW w:w="5352" w:type="dxa"/>
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
                  <w:tcW w:w="1474" w:type="dxa"/>
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
                  <w:tcW w:w="2519" w:type="dxa"/>
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
        <!--Вывод "Форма и правила проведения промежуточной аттестации..."-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="00CC78D9">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="33" w:name="_Toc351130178"/>
            <w:bookmarkStart w:id="34" w:name="_Toc351563465"/>
            <w:r>
              <w:t xml:space="preserve">4.2.Форма и правила проведения промежуточной </w:t>
            </w:r>
            <w:bookmarkEnd w:id="32"/>
            <w:r>
              <w:t>аттестации</w:t>
            </w:r>
            <w:bookmarkEnd w:id="33"/>
            <w:r>
              <w:t xml:space="preserve"> </w:t>
            </w:r>
            <w:bookmarkStart w:id="35" w:name="_Toc351130179"/>
            <w:r>
              <w:t>(зачета, экзамена)</w:t>
            </w:r>
            <w:bookmarkEnd w:id="34"/>
            <w:bookmarkEnd w:id="35"/>
          </w:p>
        <xsl:for-each select="umk/CurrentControl/Form_and_rules_attestat/Abzac">
          <w:p w:rsidR="006D40F1" w:rsidRDefault="006D40F1" w:rsidP="006D40F1">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Перечень вопросов к зачету (экзамену)"-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="36" w:name="_Toc351130180"/>
            <w:bookmarkStart w:id="37" w:name="_Toc351563466"/>
            <w:r>
              <w:t>4.3. Перечень вопросов к зачету, экзамену</w:t>
            </w:r>
            <w:bookmarkEnd w:id="36"/>
            <w:bookmarkEnd w:id="37"/>
          </w:p>
        <!--Вывод перечня вопросов к зачтеу/экзамену-->
        <xsl:for-each select="umk/CurrentControl/Voprosy_k_ekz/Abzac">
          <w:p w:rsidR="002F48BD" w:rsidRPr="001B11BA" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="a3"/>
              <w:jc w:val="both"/>
              <w:numPr>
                <w:ilvl w:val="0"/>
                <w:numId w:val="5"/>
              </w:numPr>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
            </w:pPr>
            <w:proofErr w:type="spellStart"/>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
              <w:t>
                <xsl:value-of select="@Value"/>
              </w:t>
            </w:r>
            <w:proofErr w:type="spellEnd"/>
          </w:p>
        </xsl:for-each>
          <!--Вывод "Образцы экзаменационных тестов, заданий"-->>
          <w:p w:rsidR="002F48BD" w:rsidRDefault="002F48BD" w:rsidP="003D7FB2">
            <w:pPr>
              <w:pStyle w:val="2"/>
            </w:pPr>
            <w:bookmarkStart w:id="38" w:name="_Toc351130181"/>
            <w:bookmarkStart w:id="39" w:name="_Toc351563467"/>
            <w:r>
              <w:t>4.4. Образцы экзаменационных тестов, заданий</w:t>
            </w:r>
            <w:bookmarkEnd w:id="38"/>
            <w:bookmarkEnd w:id="39"/>
          </w:p>
        <!--Вывод образцов экзаменационных тестов, заданий-->
        <xsl:for-each select="umk/CurrentControl/Example_ekz_Unit/Abzac">
          <w:p w:rsidR="006D40F1" w:rsidRDefault="006D40F1" w:rsidP="006D40F1">
            <w:pPr>
              <w:ind w:firstLine="709"/>
              <w:jc w:val="both"/>
            </w:pPr>
            <w:r>
              <w:rPr>
                <w:sz w:val="28"/>
                <w:szCs w:val="28"/>
              </w:rPr>
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