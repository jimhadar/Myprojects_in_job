; (function () {
    //Literature - основная функция для библиотеки
    function Literature() {

    }
    //указывает, нужно ли отправлять запрос на сервер на обновление данных в текущей строке
    //(обновлять не нужно, если строка не добавлялась)
    var UpdateRow = true;
    //Таблица Table_for_literature
    var Table_for_literature = document.getElementById("Table_for_Literature");
    //Номер текущей выбранной строки
    var CurrentRow_InTableForLiterature = (Table_for_literature.rows.length > 1 ? 1 : 0);
    if (CurrentRow_InTableForLiterature > 0) {
        allocationCurrentRow(Table_for_literature, CurrentRow_InTableForLiterature);
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
        for (var j = 0; j < Table.rows[CurRow].cells.length; j++) {
            Table.rows[CurRow].cells[j].style.backgroundColor = "rgb(200, 200, 80)";
        }
    }
     
    /*  
        Различные методы для работы с таблицей "Table_for_literature", содержащей список рекомендуемой литературы
    */
    /*
        событие, происходящее при клике на любом месте таблицы "Table_for_literature"
    */
    function ClickOnCell_intbl_liter(event) {
        var target = event.target;
        if ((target.tagName == 'TD') || (target.parentNode.tagName == 'TD')) {
            CurrentRow_InTableForLiterature = (target.tagName == 'TD') ? GetNumRow(Table_for_literature, target) : GetNumRow(Table_for_literature, target.parentNode);
            allocationCurrentRow(Table_for_literature, CurrentRow_InTableForLiterature);
        }
        else {
            return;
        }
    }
    //удаление строки из таблицы "Table_for_literature"
    function del_str_from_TableLiterature(event) {
        event.stopPropagation();
        Table_for_literature.rows[CurrentRow_InTableForLiterature].remove();
        //изменение текущей выбранной ячейки
        if (Table_for_literature.rows.length == 1) {
            CurrentRow_InTableForLiterature = 0;
        }
        else if (CurrentRow_InTableForLiterature == Table_for_literature.rows.length) {
            CurrentRow_InTableForLiterature--;
        }
        else {
            CurrentRow_InTableForLiterature++;
        }
        allocationCurrentRow(Table_for_literature, CurrentRow_InTableForLiterature);
    }
    //добавление строки в конец таблицы "Table_for_literature"    
    function AddRowInEnd_for_literature() {
        if (CurrentRow_InTableForLiterature == Table_for_literature.rows.length - 1) {
            var tr = document.createElement("TR");

            for (var i = 0; i < 3; i++) {
                var td = document.createElement("TD");
                td.className = "GridViewCss";
                tr.appendChild(td);
            }

            tr.cells[0].className = "GridViewCss TypeLiterColumn";
            tr.cells[2].className = "GridViewCss FindLiterBtnColumn";

            var select = document.createElement("SELECT");

            var option_mainLiter = document.createElement("OPTION");
            option_mainLiter.text = "Основная";
            var option_DopLiter = document.createElement("OPTION");
            option_DopLiter.text = "Дополнительная";
            var option_VirtualResource = document.createElement("OPTION");
            option_VirtualResource.text = "Электронный ресурс";

            select.appendChild(option_mainLiter);
            select.appendChild(option_DopLiter);
            select.appendChild(option_VirtualResource);
            select.oninput = Literature.AddRowInEnd_for_literature;

            tr.cells[0].appendChild(select);

            var inputText = document.createElement("input");
            inputText.type = "text";
            inputText.oninput = Literature.AddRowInEnd_for_literature;
            inputText.className = "textBox_AboutLiter";
            tr.cells[1].appendChild(inputText);

            var inputBtn = document.createElement("input");
            inputBtn.type = "button";
            inputBtn.className = "bttn";
            inputBtn.value = "Найти";
            inputBtn.onclick = function () {
                Literature.AddRowInEnd_for_literature();
                Literature.ShowPopUp_for_find_liter('block');
            }
            tr.cells[2].appendChild(inputBtn);

            Table_for_literature.appendChild(tr);

            Update_NameAttr_in_InputElem_in_Table_for_Literature();

            window.location.href = '#end';
        }
    }

    function Update_NameAttr_in_InputElem_in_Table_for_Literature() {
        for (var i = 0; i < Table_for_literature.rows.length; i++) {
            Table_for_literature.rows[i].cells[0].childNodes[0].name = "TypeLiter" + i.toString();
            Table_for_literature.rows[i].cells[1].childNodes[0].name = "AboutLiter" + i.toString();
        }
        document.getElementById('RowCountLiterTable').value = Table_for_literature.rows.length - 1;
    }
    /*
        Показать/скрыть вспылвающее псевдоокно для выбора литературного источника
    */
    function ShowPopUp_for_find_liter(state) {
        document.getElementById('pop-up-window').style.display = state;
        document.getElementById('wrap_for_pop-up-window').style.display = state;
    }
    //очистка всех полей и таблицы, предназначенных для поиска источников литературы
    function ClearAllElement_in_findLiterWindow() {
        //очистка таблицы со списком источников
        //и остальных поелй ввода
        /*var tempTable = document.getElementById('Table_for_liter');
        while (tempTable.rows.length != 1) {
            tempTable.deleteRow(tempTable.rows.length - 1);
        }
        document.getElementById('TextBox_KeyWord').value = '';
        document.getElementById('TextBox_Author').value = '';
        document.getElementById('TextBox_NameBook').value = '';
        document.getElementById('TextBox_Year').value = '';*/
    }

    function BackgroundColor_SelectStr_inFindLiter(event) {
        var Table = document.getElementById('Table_for_liter');
        var target = event.target;
        if ((target.tagName == 'TR') || (target.parentNode.tagName == 'TR')) {
            var CurRow = (target.tagName == 'TR') ? GetNumRow(Table, target.cells[0]) : GetNumRow(Table, target);
            for (var i = 1; i < Table.rows.length; i++) {
                for (var j = 0; j < Table.rows[i].cells.length; j++) {
                    Table.rows[i].cells[j].style.backgroundColor = "";
                }
            }
            for (var j = 0; j < Table.rows[CurRow].cells.length; j++) {
                Table.rows[CurRow].cells[j].style.backgroundColor = "#BBD9ED";
            }
        }
    }

    function BackGround_OutStr_inFindLiter(event) {
        var Table = document.getElementById('Table_for_liter');
        var target = event.target;
        if (target.tagName == 'TR') {
            var CurRow = (target.tagName == 'TR') ? GetNumRow(Table, target.cells[0]) : GetNumRow(Table, target);
            for (var i = 1; i < Table.rows.length; i++) {
                for (var j = 0; j < Table.rows[i].cells.length; j++) {
                    Table.rows[i].cells[j].style.backgroundColor = "";
                }
            }
        }
    }

    /*
        Добавить выбранный источник в основную таблицу со списком литературы
    */
    function AddLiterToTextBox(event) {
        var Table_list_Liter = document.getElementById('Table_for_liter');
        //поле, в которое будет записываться источник
        var textbox = Table_for_literature.rows[CurrentRow_InTableForLiterature].cells[1].childNodes[0];
        //текущая строка, из которой берется источник
        var target = event.target;
        var CurRow;
        if ((target.tagName == 'TD') || (target.parentNode.tagName == 'TD')) {
            CurRow = (target.tagName == 'TD') ? GetNumRow(Table_list_Liter, target) : GetNumRow(Table_list_Liter, target.parentNode);
        }
        else {
            return;
        }
        //заполянем поле ввода
        textbox.value = Table_list_Liter.rows[CurRow].cells[1].innerText.trim() + ' ' +
                        Table_list_Liter.rows[CurRow].cells[0].innerText.trim() + '. - ' +
                        Table_list_Liter.rows[CurRow].cells[2].innerText.trim() + '. ' +
                        Table_list_Liter.rows[CurRow].cells[3].innerText.trim() + ', ' +
                        Table_list_Liter.rows[CurRow].cells[4].innerText.trim() + '.';
        ClearAllElement_in_findLiterWindow();
        ShowPopUp_for_find_liter('none');
        AddRowInEnd_for_literature();
        window.location.href = '#end';
    }


    Update_NameAttr_in_InputElem_in_Table_for_Literature();
  

    Literature.ClickOnCell_intbl_liter = ClickOnCell_intbl_liter;
    Literature.del_str_from_TableLiterature = del_str_from_TableLiterature;
    Literature.AddRowInEnd_for_literature = AddRowInEnd_for_literature;
    Literature.ShowPopUp_for_find_liter = ShowPopUp_for_find_liter;

    Literature.BackgroundColor_SelectStr_inFindLiter = BackgroundColor_SelectStr_inFindLiter;
    Literature.BackGround_OutStr_inFindLiter = BackGround_OutStr_inFindLiter;
    Literature.ClearAllElement_in_findLiterWindow = ClearAllElement_in_findLiterWindow;
    Literature.AddLiterToTextBox = AddLiterToTextBox;
    // "экспортировать" Literature наружу из модуля
    window.Literature = Literature;
}());