; (function () {
    function CurrentControl() {

    }
    //ТАблица CurrentControlTable
    var Table = document.getElementById("CurrentControlHtmlTable");

    var CurrentRow = (Table.rows.length > 1 ? 1 : 0);
    if (CurrentRow > 0) {
        Table.rows[CurrentRow].focus();
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
        if(Table.rows.length > 2){
            event.stopPropagation();
            Table.rows[CurrentRow].remove();
            //изменение текущей выделенной ячейки
            if (Table.rows.length == 1) {
                CurrentRow = 0;
            }        
            else if (CurrentRow == Table.rows.length) {
                CurrentRow--;
            }
            if (CurrentRow > 0) {
                allocationCurrentRow(CurrentRow);
            }
        }
        UpdateNameElementsInCurControlTable();
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
    //обновление атрибута "name" длях всех элементов типа input в таблице CurrentControlHtmlTable
    function UpdateNameElementsInCurControlTable() {
        for (var i = 1; i < Table.rows.length; i++) {
            var Row = Table.rows[i];
            Row.cells[0].childNodes[0].name = 'FormCurControl' + (i - 1).toString();
            Row.cells[1].childNodes[0].name = 'NumberBalls' + (i - 1).toString();
            Row.cells[2].childNodes[0].name = 'Themes' + (i - 1).toString();
        }
        document.getElementById('CurrentControlTableRowCount').value = Table.rows.length - 1;
    }
    
    function AddRowInEnd() {
        if (CurrentRow == Table.rows.length - 1) {
            var tr = document.createElement("TR");

            for (var i = 0; i < 4; i++) {
                var td = document.createElement("TD");
                tr.appendChild(td);
                tr.className = "GridViewCss";
            }

            var td = tr.cells[0];            
            
            var select = Table.rows[(CurrentRow != 1 ? CurrentRow - 1 : CurrentRow)].cells[0].childNodes[1];
            var OcenSredstv = document.createElement("SELECT");
            for (var i = 0; i < select.length; i++) {
                var option = document.createElement("OPTION");
                option.value = select.options[i].value;
                option.text = select.options[i].text;
                OcenSredstv.appendChild(option);
            }
            OcenSredstv.onchange = Table.rows[1].cells[0].childNodes[0].onchange;
            OcenSredstv.className = select.className;
            AddElementsToCell(td, OcenSredstv);
            td.className = "GridViewCss formCurControlColumn";

            var td = tr.cells[1];
            td.innerHTML = "<textarea class='TextBoxStyle' oninput='CurrentControl.AddRowInEnd();'></textarea>";
            td.oninput = Table.rows[1].cells[1].childNodes[0].oninput;
            td.onchange = Table.rows[1].cells[1].childNodes[0].onchange;
            td.className = "GridViewCss NumberBallColumn";

            var td = tr.cells[2];
            var RazdelDiscip = document.createElement("SELECT");
            select = Table.rows[(CurrentRow != 1 ? CurrentRow - 1 : CurrentRow)].cells[2].childNodes[1];
            for (var i = 0; i < select.length; i++) {
                var option = document.createElement("OPTION");
                option.value = select.options[i].value;
                option.innerHTML = select.options[i].innerHTML;
                RazdelDiscip.appendChild(option);
            }
            

            AddElementsToCell(td, RazdelDiscip);
            td.onchange = Table.rows[1].cells[2].childNodes[0].onchange;
            td.className = "GridViewCss";

            var td = tr.cells[3];            
            td.innerHTML = "<input type=\"button\" class=\"bttn\" onclick=\"CurrentControl.ClickOnCell(event);CurrentControl.del_str(event);\" value=\"Удалить\"/>";
            td.className = "GridViewCss for_del_str";

            Table.appendChild(tr);

            UpdateNameElementsInCurControlTable();
        }
    }
    /*добавление в ячейкутрех элементов: текстовое поле, select, и кнопка
        в select - список форм текущего контроля успеваемости/список тем дисциплины, 
        в зависимости от того, в каком столбце находится ячейка
        td - ячейка, в которую добавляются элементы,
        select - список форм текущего контроля успеваемости/список тем дисциплины
    */
    function AddElementsToCell(td, select) {
        var inputText = document.createElement('INPUT');
        inputText.type = "text";
        inputText.name = "FormCurControl" + CurrentRow.toString();
        inputText.className = "TextBoxOcenSredstv";

        td.innerHTML = "";
        select.className = "SelectStyle";
        var inputButton = document.createElement("INPUT");
        inputButton.type = "button";
        inputButton.value = "Добавить";
        inputButton.className = "bttn_AddOcenSredstv";
        inputButton.onclick = CurrentControl.AddTheme_or_ForCurControlToTextBox;
        td.className = "GridViewCss formCurControlColumn";

        td.appendChild(inputText);
        td.appendChild(select);
        td.appendChild(inputButton);
    }

    function AddTheme_or_ForCurControlToTextBox(event) {
        var target = event.target;
        if (target.type == 'button') {
            event.stopPropagation();
            var td = target.parentNode;
            var select = td.childNodes[1];
            var textbox = td.childNodes[0];
            var AddText = select.options[select.options.selectedIndex].value;
            if (textbox.value != '') {
                textbox.value += ', ' + AddText;
            }
            else {
                textbox.value = AddText;
            }
        }       
    }

    UpdateNameElementsInCurControlTable();

    CurrentControl.AddRowInEnd = AddRowInEnd;
    CurrentControl.ClickOnCell = ClickOnCell;
    CurrentControl.del_str = del_str;
    CurrentControl.AddTheme_or_ForCurControlToTextBox = AddTheme_or_ForCurControlToTextBox;

    window.CurrentControl = CurrentControl;
}());