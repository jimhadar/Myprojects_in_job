; (function () {
    function umk() {

    }

    //ТАблица CurrentControlTable
    var Table = document.getElementById("CurrentControlHtmlTable");
    //Номер текущей выбранной строки
    var CurrentRow = (Table.rows.length > 1 ? 1 : 0);
    if (CurrentRow > 0) {
        Table.rows[0].focus();
        allocationCurrentRow(CurrentRow);
    }
    /* 
        Возвращает номер строки, которой расположена ячейка cll
        Cell - текущая ячейка
    */
    function GetNumRow(Cell) {
        var NumCol = Cell.cellIndex;
        for (var i = 0; i < Table.rows.length; i++) {
            Row = Table.rows[i];
            if (Row.cells[NumCol] == Cell) return i;
        }
    }
    //Выделение текущей выбранной ячейки
    function allocationCurrentRow(CurRow) {
        for (var i = 1; i < Table.rows.length; i++) {
            for (var j = 0; j < Table.rows[i].cells.length; j++) {
                Table.rows[i].cells[j].style.backgroundColor = "";
            }
        }
        for (var j = 0; j < Table.rows[CurRow].cells.length; j++) {
            Table.rows[CurRow].cells[j].style.backgroundColor = "rgb(200, 200, 80)";
        }
    }
    //удаление строки из таблицы
    function del_str(event) {
        event.stopPropagation();
        Table.rows[CurrentRow].remove();
        //изменение текущей выделенной ячейки
        if (Table.rows.length == 1) {
            CurrentRow = 0;
        }
        else if (CurrentRow == Table.rows.length) {
            CurrentRow--;
        }
        else {
            CurrentRow++;
        }
        if (CurrentRow > 0) {
            allocationCurrentRow(CurrentRow);
        }
    }
    //событие, происходящее при клике на любом месте таблицы
    function ClickOnCell(event) {
        var target = event.target;
        if ((target.tagName == 'TD') || (target.parentNode.tagName == 'TD')) {
            CurrentRow = (target.tagName == 'TD') ? GetNumRow(target) : GetNumRow(target.parentNode);
            allocationCurrentRow(CurrentRow);
        }
        else {
            return;
        }
    }
    /*
        Добавление строки к конец таблицы
    */
    function AddRowInEnd() {
        if (CurrentRow == Table.rows.length - 1) {
            var tr = document.createElement("TR");

            for (var i = 0; i < 4; i++) {
                var td = document.createElement("TD");
                tr.appendChild(td);
                tr.className = "GridViewCss";
            }

            var select;

            var td = tr.cells[0];
            td.className = "GridViewCss formCurControlColumn";
            td.onchange = umk.AddRowInEnd;
            select = Table.rows[(CurrentRow != 1 ? CurrentRow - 1 : CurrentRow)].cells[0].childNodes[0];
            var OcenSredstv = document.createElement("SELECT");
            for (var i = 0; i < select.options.length; i++) {
                var option = document.createElement("OPTION");
                option.value = select.options[i].value;
                option.text = select.options[i].text;
                OcenSredstv.appendChild(option);
            }
            OcenSredstv.onchange = Table.rows[1].cells[0].childNodes[0].onchange;
            td.appendChild(OcenSredstv);

            var td = tr.cells[1];
            td.innerHTML = "<textarea class='TextBoxStyle'></textarea>";
            td.className = "GridViewCss";
            td.oninput = Table.rows[1].cells[1].childNodes[0].oninput;
            td.onchange = Table.rows[1].cells[1].childNodes[0].onchange;

            var td = tr.cells[2];
            var RazdelDiscip = document.createElement("SELECT");
            select = Table.rows[(CurrentRow != 1 ? CurrentRow - 1 : CurrentRow)].cells[2].childNodes[0];
            for (var i = 0; i < select.options.length; i++) {
                var option = document.createElement("OPTION");
                option.value = select.options[i].value;
                option.innerHTML = select.options[i].innerHTML;
                RazdelDiscip.appendChild(option);
            }
            td.appendChild(RazdelDiscip);
            td.onchange = Table.rows[1].cells[2].childNodes[0].onchange;

            var td = tr.cells[3];
            td.className = "GridViewCss";
            td.innerHTML = "<input type=\"button\" class=\"bttn\" onclick=\"umk.ClickOnCell(event);umk.CallBack_on_server_with_del_str();umk.del_str(event);\" value=\"Удалить\"/>";
            
            Table.appendChild(tr);

            CallBack_on_server_with_EditStr("false");
        }
    }

    /*
        Осуществление отправки информации серверу при добавлении новой строк в таблицу/каких-либо произведенных изменениях в строках таблицы
        type_post = true, если произошло изменение существующей строки
                  = fasle, если произошла вставка новой строки
    */
    function CallBack_on_server_with_EditStr(type_post) {
        var formData = new FormData();
        formData.append("EditStr", type_post);
        formData.append("CurrentRow", CurrentRow);
        var select = Table.rows[CurrentRow].cells[0].childNodes[0];
        formData.append("FormCurControl", select.options[select.selectedIndex].value);
        formData.append("Number_ball", Table.rows[CurrentRow].cells[1].childNodes[0].value);
        var select = Table.rows[CurrentRow].cells[2].childNodes[0];
        formData.append("ThemeDiscip", (select.selectedIndex != -1 ? select.options[select.selectedIndex].innerText : ""));

        var xhr = new XMLHttpRequest();
        xhr.open('POST', "", true);
        xhr.send(formData);
    }
    /*
        отправка на сервер номера строки, которая удаляется
    */
    function CallBack_on_server_with_del_str() {
        var formData = new FormData();
        formData.append("DelStr", true);
        formData.append("CurrentRow", CurrentRow);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', "", true);
        xhr.send(formData);
    }

    umk.AddRowInEnd = AddRowInEnd;
    umk.ClickOnCell = ClickOnCell;
    umk.del_str = del_str;
    umk.CallBack_on_server_with_del_str = CallBack_on_server_with_del_str;
    umk.CallBack_on_server_with_EditStr = CallBack_on_server_with_EditStr;

    window.umk = umk;

}());