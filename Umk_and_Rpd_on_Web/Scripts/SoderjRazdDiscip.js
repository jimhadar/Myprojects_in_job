; (function () {
    //SoderjRazdDiscip - основная функция для библиотеки
    function SoderjRazdDiscip(){

    }
    //указывает, нужно ли отправлять запрос на сервер на обновление данных в текущей строке
    //(обновлять не нужно, если строка не добавлялась)
    var UpdateRow = true;
    //ТАблица SoderjRazdDiscip
    var Table_for_soderjDiscip = document.getElementById("Table_for_soderjDiscip");
    //Номер текущей выбранной строки
    var CurrentRow_InRazdelLesson = (Table_for_soderjDiscip.rows.length > 1 ? 1 : 0);
    if (CurrentRow_InRazdelLesson > 0) {
        Table_for_soderjDiscip.rows[0].focus();
        allocationCurrentRow(Table_for_soderjDiscip, CurrentRow_InRazdelLesson);
    }
    //представляет собой список семестров, в которых изучается дисциплина, как объект <select>
    var NewTDSemestr;
    //представляет собой список оценочных средств, как объект <select>
    var NewTDOcenSredstv;

    var HourLec = 0;
    var HourLab = 0;
    var HourSam = 0;

    function podshet_hours_in_RazdelLesson() {
        var temp = 0;
        for (var i = 1; i < Table_for_soderjDiscip.rows.length; i++) {
            var j;
            var Razdel_or_Theme_hours_Cell = Table_for_soderjDiscip.rows[i].cells[0].childNodes[0].value.toString().trim();
            if(Razdel_or_Theme_hours_Cell == "Раздел" || Razdel_or_Theme_hours_Cell == "Тема"){
                j = i + 1;
                while (j <= Table_for_soderjDiscip.rows.length - 1 && Table_for_soderjDiscip.rows[j].cells[0].childNodes[0].value.toString().trim() != Razdel_or_Theme_hours_Cell) {
                    if(Table_for_soderjDiscip.rows[j].cells[0].childNodes[0].value.toString().trim() == "Лекция" ||
                        Table_for_soderjDiscip.rows[j].cells[0].childNodes[0].value.toString().trim() == "Семинар" ||
                        Table_for_soderjDiscip.rows[j].cells[0].childNodes[0].value.toString().trim() == "Сам. работа") {
                        temp += Number(Table_for_soderjDiscip.rows[j].cells[3].childNodes[0].value);
                    }
                    j++;
                }
                Table_for_soderjDiscip.rows[i].cells[3].innerText = temp.toString();
                temp = 0;
            }
        }
    }
    /* 
        Возвращает номер строки, которой расположена ячейка cll
        Cell - текущая ячейка
    */
    function GetNumRow(Table, Cell) {
        var NumCol = Cell.cellIndex;
        for (var i = 0; i < Table.rows.length; i++) {
            Row = Table.rows[i];
            if (Row.cells[NumCol] == Cell) return i;
        }
    }
    //Выделение текущей выбранной ячейки
    function allocationCurrentRow(Table, CurRow) {
        for (var i = 1; i < Table.rows.length; i++) {
            for (var j = 0; j < Table.rows[i].cells.length; j++) {
                Table.rows[i].cells[j].style.backgroundColor = "";
            }
        }
        for (var j = 0; j < Table.rows[CurRow].cells.length; j++){
            Table.rows[CurRow].cells[j].style.backgroundColor = "rgb(200, 200, 80)";
        }
    }
    //удаление строки из таблицы
    function del_str(event) {
        event.stopPropagation();
        var tr = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson];
        //раздел/тема/лекция/практика/самост. работа
        var Name_razdel = tr.cells[0].childNodes[0].value.toString().trim();
        if (Name_razdel == "Раздел" || Name_razdel == "Тема") {
            if (CurrentRow_InRazdelLesson != Table_for_soderjDiscip.rows.length - 1 &&
                Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson + 1].cells[0].childNodes[0].value.toString().trim() != Name_razdel &&
                Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson + 1].cells[0].childNodes[0].value.toString().trim() != "Раздел") {
                alert( (Name_razdel == "Раздел" ? "Данный " : "Данная ") + Name_razdel.toString().toLowerCase() + " не является " + (Name_razdel == "Раздел" ? "пустым!" : "пустой! ") + "Сначала удалите содержимое " + (Name_razdel == "Раздел" ? "раздела" : "темы") + '.');
                return;
            }
        }
        
        Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].remove();
        document.getElementById('RowCountSoderjDiscip').value = Table_for_soderjDiscip.rows.length - 1;
        //изменение текущей выделенной ячейки
        if (Table_for_soderjDiscip.rows.length == 1) {
            CurrentRow_InRazdelLesson = 0;
        }
        else if (CurrentRow_InRazdelLesson == Table_for_soderjDiscip.rows.length) {
            CurrentRow_InRazdelLesson--;
        }

        if (CurrentRow_InRazdelLesson > 0) {
            allocationCurrentRow(Table_for_soderjDiscip, CurrentRow_InRazdelLesson);
        }
        Update_NameAttr_in_InputElem_in_SoderjDiscipTable();
    }
    //событие, происходящее при клике на любом месте таблицы "Table_for_SoderjDiscip"
    function ClickOnCell_InRazdelLesson(event) {
        var target = event.target;
        if ((target.tagName == 'TD') || (target.parentNode.tagName == 'TD')) {
            CurrentRow_InRazdelLesson = (target.tagName == 'TD') ? GetNumRow(document.getElementById("Table_for_soderjDiscip"), target) : GetNumRow(document.getElementById("Table_for_soderjDiscip"), target.parentNode);
            allocationCurrentRow(Table_for_soderjDiscip, CurrentRow_InRazdelLesson);
        }
        else {
            return;
        }
    }
    //добавление раздела
    function AddRazdelRow() {
        UpdateRow = true;
        if(Table_for_soderjDiscip.rows.length > 1){
            if (CurrentRow_InRazdelLesson != Table_for_soderjDiscip.rows.length - 1) {
                for (var i = CurrentRow_InRazdelLesson + 1; i < Table_for_soderjDiscip.rows.length; i++) {
                    if(Table_for_soderjDiscip.rows[i].cells[0].childNodes[0].value.toString().trim() == "Раздел"){
                        CurrentRow_InRazdelLesson = i;
                        break;
                    }
                    else {
                        CurrentRow_InRazdelLesson = Table_for_soderjDiscip.rows.length;
                    }
                }
            }
            else {
                CurrentRow_InRazdelLesson++;
            }
        }
        else {
            CurrentRow_InRazdelLesson++;
        }
        var Row = Table_for_soderjDiscip.insertRow(CurrentRow_InRazdelLesson);

        for (var i = 0; i < 6; i++) {
            var td = document.createElement("td");
            td.className = "GridViewCss";
            Row.appendChild(td);
        }

        var td = Row.cells[0];
        td.className = "GridViewCss VidColumn Razdel";
        var textbox = document.createElement("input");
        textbox.type = "text";
        textbox.readOnly = true;
        textbox.value = "Раздел";
        textbox.name = "Vid" + CurrentRow_InRazdelLesson.toString();
        textbox.className = "VidColumn Razdel";
        td.appendChild(textbox);

        var td = Row.cells[1];
        NewTDSemestr = td;

        var td = Row.cells[2];
        td.className = "GridViewCss";
        var textarea = document.createElement("textarea");
        textarea.name = "About" + CurrentRow_InRazdelLesson;
        textarea.className = "TextBoxStyle SoderjLesson";
        /*td.innerHTML = "<textarea class=\"TextBoxStyle SoderjLesson\"></textarea>";*/
        td.appendChild(textarea);

        var td = Row.cells[3];
        td.innerHTML = "";
        td.innerText = "0";

        var td = Row.cells[4];
        NewTDOcenSredstv = td;
        
        var td = Row.cells[5];
        var button = document.createElement("INPUT");
        td.innerHTML = "<input type=\"button\" class=\"bttn\" onclick=\"SoderjRazdDiscip.ClickOnCell_InRazdelLesson(event);SoderjRazdDiscip.del_str(event);\" value=\"Удалить\"/>";
               

        allocationCurrentRow(Table_for_soderjDiscip, CurrentRow_InRazdelLesson);
    }
    //добавление темы
    function AddThemeRow() {
        if (CurrentRow_InRazdelLesson != 0) {
            UpdateRow = true;
            if (Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[0].childNodes[0].value.toString().trim() != "Раздел") {
                while (CurrentRow_InRazdelLesson != Table_for_soderjDiscip.rows.length &&
                      Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[0].childNodes[0].value.toString().trim() != "Раздел") {
                    CurrentRow_InRazdelLesson++;
                    if (CurrentRow_InRazdelLesson != Table_for_soderjDiscip.rows.length && Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[0].childNodes[0].value.toString().trim() == "Тема") {
                        break;
                    }
                }
            }
            else {
                CurrentRow_InRazdelLesson++;
            }
            var Row = Table_for_soderjDiscip.insertRow(CurrentRow_InRazdelLesson);

            for (var i = 0; i < 6; i++) {
                var td = document.createElement("td");
                td.className = "GridViewCss";
                Row.appendChild(td);
            }

            var td = Row.cells[0];
            td.className = "GridViewCss VidColumn Razdel";
            var textbox = document.createElement("input");
            textbox.type = "text";
            textbox.readOnly = true;
            textbox.value = "Тема";
            textbox.name = "Vid" + CurrentRow_InRazdelLesson.toString();
            textbox.className = "VidColumn Theme";
            td.appendChild(textbox);

            var td = Row.cells[1];
            if (Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson - 1].cells[1].childNodes[0].tagName != undefined) {
                td.innerText = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson - 1].cells[1].childNodes[0].options[Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson - 1].cells[1].childNodes[0].options.selectedIndex].text;
            }
            else{
                td.innerText = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson - 1].cells[1].innerText;
            }

            var td = Row.cells[2];
            var textarea = document.createElement("textarea");
            textarea.name = "About" + CurrentRow_InRazdelLesson;
            textarea.className = "TextBoxStyle SoderjLesson";
            /*td.innerHTML = "<textarea class=\"TextBoxStyle SoderjLesson\"></textarea>";*/
            td.appendChild(textarea);

            var td = Row.cells[3];
            td.innerHTML = "";
            td.innerText = "0";

            var td = Row.cells[4];
            NewTDOcenSredstv = td;

            var td = Row.cells[5];
            td.innerHTML = "<input type=\"button\" class=\"bttn\" onclick=\"SoderjRazdDiscip.ClickOnCell_InRazdelLesson(event);SoderjRazdDiscip.del_str(event);\" value=\"Удалить\"/>";
            document.getElementById('RowCountSoderjDiscip').value = Table_for_soderjDiscip.rows.length - 1;
            allocationCurrentRow(Table_for_soderjDiscip, CurrentRow_InRazdelLesson);
        }
        else {
            alert("Перед добавлением тем занятий необходимо выбрать или создать раздел! Для этого добавьте новый раздел.");
            UpdateRow = false;
        }
    }
    //добавление лекции/практического занятия/самостоятельной работы в зависимости от значения параметра Lec_or_Prakt_or_SamJob
    function Add_Lec_or_Prakt_or_SamJob(Lec_or_Prakt_or_SamJob) {
        "use strict"
        if(Table_for_soderjDiscip.rows.length > 1){
            for (var i = CurrentRow_InRazdelLesson; i > 0; i--) {
                if (Table_for_soderjDiscip.rows[i].cells[0].childNodes[0].value.toString().trim() == "Тема") {
                    break;
                }
                else {
                    if (Table_for_soderjDiscip.rows[i].cells[0].childNodes[0].value.toString().trim() == "Раздел") {
                        let messsage = (Lec_or_Prakt_or_SamJob == "Лекция") ? "Добавление лекции невозможно, так как сначала нужно добавить в текущий раздел тему!" :
                                             ((Lec_or_Prakt_or_SamJob == "Семинар") ? "Добавление семинара невозможно, так как сначала нужно добавить в текущий раздел тему!" :
                                             "Добавление самостоятельной работы невозможно, так как сначала нужно добавить в текущий раздел тему!");
                        alert(messsage);
                        UpdateRow = false;
                        return;
                    }
                }
            }
            UpdateRow = true;
            var Row = Table_for_soderjDiscip.insertRow(++CurrentRow_InRazdelLesson);
            for (var i = 0; i < 6; i++) {
                var td = document.createElement("td");
                td.className = "GridViewCss";
                Row.appendChild(td);
            }

            var td = Row.cells[0];
            td.className = "GridViewCss VidColumn all";
            var textbox = document.createElement("input");
            textbox.type = "text";
            textbox.readOnly = true;
            textbox.value = Lec_or_Prakt_or_SamJob.toString();
            textbox.name = "Vid" + CurrentRow_InRazdelLesson.toString();
            textbox.className = "VidColumn all";
            td.appendChild(textbox);

            var td = Row.cells[1];
            td.innerText = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson - 1].cells[1].innerText;

            var td = Row.cells[2];
            var textarea = document.createElement("textarea");
            textarea.name = "About" + CurrentRow_InRazdelLesson;
            textarea.className = "TextBoxStyle SoderjLesson";
            /*td.innerHTML = "<textarea class=\"TextBoxStyle SoderjLesson\"></textarea>";*/
            td.appendChild(textarea);

            var td = Row.cells[3];
            td.innerHTML = "<input type=\"number\" name=\"Volume" + CurrentRow_InRazdelLesson.toString() + "\"" + " oninput=\"SoderjRazdDiscip.Update_value_of_hours_in_razdel_and_row();\" step=\"0.5\" min=\"0\" max=\"100\" value='2'/>";

            var td = Row.cells[5];
            td.innerHTML = "<input type=\"button\" class=\"bttn\" onclick=\"SoderjRazdDiscip.ClickOnCell_InRazdelLesson(event);SoderjRazdDiscip.del_str(event);\" value=\"Удалить\"/>";
            Row.appendChild(td);

            document.getElementById('RowCountSoderjDiscip').value = Table_for_soderjDiscip.rows.length - 1;

            allocationCurrentRow(Table_for_soderjDiscip, CurrentRow_InRazdelLesson);
            Update_NameAttr_in_InputElem_in_SoderjDiscipTable();

            Update_value_of_hours_in_razdel_and_row();
        }
        else {
            alert("Перед добавлением занятий необходимо выбрать или создать тему! Для этого добавьте тему.");
            UpdateRow = false;
        }
    }
    
    //клиентская функция, обрабатывающая информацию с сервера после обратного вызова. Функция срабатывает при добавлении раздела или темы
    function Get_Inf_for_Razdel_ClientCallBack(result, context) {
        "use strict"
        if (result.indexOf("}{") != -1) {
            var items = result.split("}{");
            var semestres = items[0].split("|");
            //заполнение списка оценочных средств
            GetList_of_OcenSredtsv(items[1].split("||"));
            var combobox = document.createElement("select");
            combobox.innerHTML = "";
            for (let i = 0; i < semestres.length - 1; i++) {
                var option = document.createElement("option");
                option.innerHTML = semestres[i].toString().trim();
                combobox.appendChild(option);
            }
            combobox.name = "Semestr" + CurrentRow_InRazdelLesson.toString();
            NewTDSemestr.innerHTML = "";
            combobox.onchange = function () { SoderjRazdDiscip.Update_Semestr_in_thme_or_lec(); }
            NewTDSemestr.appendChild(combobox);
            //если переданные с сервера данные содержат также количество часов лекций, практических и самостоятельных занятий
        }
        else {
            GetList_of_OcenSredtsv(result.split("||"));
        }
        Update_NameAttr_in_InputElem_in_SoderjDiscipTable();
    }
    //добавление в поле для ввода оценочных средств элемента, выбарнного текущим в списке "Оценочные средства"
    function Add_OcenSredstv_to_TextBox() {
        //ячейка с списком оценочных средств, включающая 3 других эемента: textbox, select, button
        var ParentTD = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[4];
        var select = ParentTD.childNodes[1];
        var textbox = ParentTD.childNodes[0];
        //добавляемый текст
        var AddText = select.options[select.options.selectedIndex].text;
        AddText = AddText.substring(0, AddText.indexOf('-')).trim();
        if (textbox.value != '') {
            textbox.value += ', ' + AddText;
        }
        else {
            textbox.value = AddText;
        }
    }

    //заполнение списка оценочных средств
    function GetList_of_OcenSredtsv(OcenSredstv) {
        var inputText = document.createElement('INPUT');
        inputText.type = "text";
        inputText.name = "FormCurControl" + CurrentRow_InRazdelLesson.toString();
        inputText.className = "TextBoxOcenSredstv";
        
        NewTDOcenSredstv.innerHTML = "";
        var ListOcenSredstv = document.createElement("select");
        ListOcenSredstv.innerHTML = "";
        for (var i = 0; i < OcenSredstv.length - 1; i++){
            var str = OcenSredstv[i].split("|");
            var option = document.createElement("option");
            option.value = str[0];
            option.innerText = str[1];
            ListOcenSredstv.appendChild(option);
        }
        ListOcenSredstv.className = "SelectStyle";
        var inputButton = document.createElement("INPUT");
        inputButton.type = "button";
        inputButton.value = "Добавить";
        inputButton.className = "bttn_AddOcenSredstv";
        inputButton.onclick = SoderjRazdDiscip.Add_OcenSredstv_to_TextBox;
        NewTDOcenSredstv.className = "GridViewCss formCurControlColumn";
        NewTDOcenSredstv.appendChild(inputText);
        NewTDOcenSredstv.appendChild(ListOcenSredstv);
        NewTDOcenSredstv.appendChild(inputButton);
    }

    function Update_Semestr_in_thme_or_lec() {
        //Текущая строка
        var CurRow = CurrentRow_InRazdelLesson;
        //текущий семестр
        var CurSemestr = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[1].childNodes[0].options[Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[1].childNodes[0].options.selectedIndex].text;
        //изменение семестра во всех темах/лекциях/практиках/практ. занятиях текущего раздела
        while ((CurrentRow_InRazdelLesson < Table_for_soderjDiscip.rows.length - 1) && (Table_for_soderjDiscip.rows[++CurrentRow_InRazdelLesson].cells[0].childNodes[0].value != "Раздел")) {
            Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[1].innerText = CurSemestr;
        }
        CurrentRow_InRazdelLesson = CurRow;
    }
    
    function Update_value_of_hours_in_razdel_and_row() {
        function sum_lec_or_praktik_or_samjob(Lec_or_Praktik_or_SamJob) {
            var temp = 0;
            for (var i = 1; i < Table_for_soderjDiscip.rows.length; i++) {
                if (Table_for_soderjDiscip.rows[i].cells[0].childNodes[0].value.toString().trim() == Lec_or_Praktik_or_SamJob.toString().trim()) {
                    temp += Number(Table_for_soderjDiscip.rows[i].cells[3].childNodes[0].value.toString().trim());
                }
            }
            return temp;
        }
        var Sum_Lec = sum_lec_or_praktik_or_samjob("Лекция");
        var Sum_Praktik = sum_lec_or_praktik_or_samjob("Семинар");
        var Sum_Samost_Job = sum_lec_or_praktik_or_samjob("Сам. работа");
        var Label_for_hours = document.getElementById("Label_for_hours");
        Label_for_hours.innerText = "Оставшийся объем часов:" + '\n' + "Лекции: " + (Number(HourLec) - Number(Sum_Lec)).toString() + '\n' + "Семинары: " + (Number(HourLab) - Number(Sum_Praktik)).toString() + '\n' + "Самостоятельные: " + (Number(HourSam) - Number(Sum_Samost_Job)).toString();
        var Label_for_hours1 = document.getElementById("Label_for_hours1");
        if (Table_for_soderjDiscip.rows.length >= 4) {
            Label_for_hours1.innerText = Label_for_hours.innerText;
        }
        var CurrentCell = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[3].childNodes[0].value.toString().trim();
        var Name_task = Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[0].childNodes[0].value.toString().trim();
        switch (Name_task) {
            case "Лекция":
                if (Number(Sum_Lec) > Number(HourLec)) {
                    alert("Объем часов, предназначенных для лекционных занятий - " + Sum_Lec.toString() + " уже соотвествует объему, содержащемуся в учебном плане! Введите другой объем часов!");
                    Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[3].childNodes[0].value = Number(HourLec) - Number(Sum_Lec) + Number(CurrentCell);
                }
                break;
            case "Семинар":
                if (Number(Sum_Praktik) > Number(HourLab)) {
                    alert("Объем часов, предназначенных для практических занятий - " + Sum_Praktik.toString() + " уже соотвествует объему, содержащемуся в учебном плане! Введите другой объем часов!");
                    Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[3].childNodes[0].value = Number(HourLab) - Number(Sum_Praktik) + Number(CurrentCell);
                }
                break;
            case "Сам. работа":
                if (Number(Sum_Samost_Job) > Number(HourSam)) {
                    alert("Объем часов, предназначенных для самоcтоятельной работы - " + Sum_Samost_Job.toString() + " уже соотвествует объему, содержащемуся в учебном плане! Введите другой объем часов!");
                    Table_for_soderjDiscip.rows[CurrentRow_InRazdelLesson].cells[3].childNodes[0].value = Number(HourSam) - Number(Sum_Samost_Job) + Number(CurrentCell);
                }
                break;
        }
        podshet_hours_in_RazdelLesson();        
        Sum_Lec = sum_lec_or_praktik_or_samjob("Лекция");
        Sum_Praktik = sum_lec_or_praktik_or_samjob("Семинар");
        Sum_Samost_Job = sum_lec_or_praktik_or_samjob("Сам. работа");
        Label_for_hours.innerText = "Оставшийся объем часов:" + '\n' + "Лекции: " + (Number(HourLec) - Number(Sum_Lec)).toString() + '\n' + "Семинары: " + (Number(HourLab) - Number(Sum_Praktik)).toString() + '\n' +  "Самостоятельные: " + (Number(HourSam) - Number(Sum_Samost_Job)).toString();
        if (Table_for_soderjDiscip.rows.length >= 4) {
            Label_for_hours1.innerText = Label_for_hours.innerText;
        }
    }
    //обновление атрибута "name" для всех элементов типа input в таблице Table_for_soderjDiscip
    function Update_NameAttr_in_InputElem_in_SoderjDiscipTable() {
        for (var i = 1; i < Table_for_soderjDiscip.rows.length; i++){
            var Row = Table_for_soderjDiscip.rows[i];
            Row.cells[0].childNodes[0].name = "Vid" + (i - 1).toString();
            if (Row.cells[0].childNodes[0].value == "Раздел") {
                Row.cells[1].childNodes[0].name = "Semestr" + (i - 1).toString();
            }
            Row.cells[2].childNodes[0].name = "AboutTheme" + (i - 1).toString();
            if (Row.cells[0].childNodes[0].value == "Раздел" || Row.cells[0].childNodes[0].value == "Тема") {
                Row.cells[4].childNodes[0].name = "FormCurControl" + (i - 1).toString();
            }
            else {
                Row.cells[3].childNodes[0].name = "Volume" + (i - 1).toString();
            }
        }
        document.getElementById('RowCountSoderjDiscip').value = Table_for_soderjDiscip.rows.length - 1;
    }
    
    function onloadForm() {
        HourLec = Number(document.getElementById('HourLec').innerText);
        HourLab = Number(document.getElementById('HourLab').innerText);
        HourSam = Number(document.getElementById('HourSam').innerText);
        Update_value_of_hours_in_razdel_and_row();
    }

    

    Update_NameAttr_in_InputElem_in_SoderjDiscipTable(); 

    SoderjRazdDiscip.ClickOnCell_InRazdelLesson = ClickOnCell_InRazdelLesson;
    SoderjRazdDiscip.AddRazdelRow = AddRazdelRow;
    SoderjRazdDiscip.AddThemeRow = AddThemeRow;
    SoderjRazdDiscip.Add_Lec_or_Prakt_or_SamJob = Add_Lec_or_Prakt_or_SamJob;
    SoderjRazdDiscip.Get_Inf_for_Razdel_ClientCallBack = Get_Inf_for_Razdel_ClientCallBack;
    SoderjRazdDiscip.Update_Semestr_in_thme_or_lec = Update_Semestr_in_thme_or_lec;
    SoderjRazdDiscip.Update_value_of_hours_in_razdel_and_row = Update_value_of_hours_in_razdel_and_row;
    SoderjRazdDiscip.Update_NameAttr_in_InputElem_in_SoderjDiscipTable = Update_NameAttr_in_InputElem_in_SoderjDiscipTable;
    SoderjRazdDiscip.del_str = del_str;
    SoderjRazdDiscip.onloadForm = onloadForm;

    SoderjRazdDiscip.Add_OcenSredstv_to_TextBox = Add_OcenSredstv_to_TextBox;

    // "экспортировать" SoderjRazdDiscip наружу из модуля
    window.SoderjRazdDiscip = SoderjRazdDiscip;
}());