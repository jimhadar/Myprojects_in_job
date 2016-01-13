/*
    данный скрипт нужен для отправки временных данных на сервер с интервалом в 10 минут.
    временными данными является вся информация из состояния сеанса сервера + данные, полученные от клиента.
    Вся эта информация сохраняется в временное поле базы данных. Поле очищается после окончательного сохранения РПД/УМК в БД
*/

; (function () {
    function Timer_for_Sending_Data_to_Server() {
        //получаем адрес страницы
        var url_curStr = window.location.toString();
        var formData = new FormData();
        formData.append("UpdateTmpContents", "true");
        if (url_curStr.indexOf("Title", 0) > 0) {
            SendingDataToServerFromTitle(formData);
        }
        if (url_curStr.indexOf("Competetion", 0) > 0) {
            SendingDataToServerFromCompetetion(formData);
        }
        if (url_curStr.indexOf("SoderjRazdDiscip", 0) > 0) {
            SendingDataToServerFromSoderjRazdDiscip(formData);
        }
        if (url_curStr.indexOf("CurrentControl", 0) > 0) {
            SendingDataToServerFromCurrentControl(formData);
        }
        if (url_curStr.indexOf("RPD", 0) > 0) {
            SendingDataToServerFromRPD(formData);
        }
        if (url_curStr.indexOf("UMK", 0) > 0) {
            SendingDataToServerFromUMK(formData);
        }
        /*отсылаем сформированные данные на сервер*/
        //создаем объект XMLHttpRequest
        var XHR = new XMLHttpRequest();
        /*открываем соединение*/
        XHR.open("POST", "", true);
        //отсылаем запрос
        XHR.send(formData);
        //интервал 1 секунда
        var interval = 1000;
        /*будем запускать функцию с интервалом в 30 секунд*/
        setTimeout(Timer_for_Sending_Data_to_Server, 20 * interval);
    }
    /*
        отправка информации от клиента со страницы Competetion
    */
    function SendingDataToServerFromCompetetion(formData) {
        var GoalsDiscip = document.getElementById('TextBox_for_GoalsDiscip');
        var PlaceOOP = document.getElementById('TextBox_for_PlaceOOP');
        var Student_doljen_znat = document.getElementById('TextBox_for_Student_doljen_znat');
        var Student_doljen_umet = document.getElementById('TextBox_for_Student_doljen_umet');
        var Student_doljen_vladet = document.getElementById('TextBox_for_Student_doljen_vladet');
        formData.append("GoalsDiscip", GoalsDiscip.value);
        formData.append("PlaceOOP", PlaceOOP.value);
        formData.append("Student_doljen_znat", Student_doljen_znat.value);
        formData.append("Student_doljen_umet", Student_doljen_umet.value);
        formData.append("Student_doljen_vladet", Student_doljen_vladet.value);
    }
    /*
        отправка информации от клиента со страницы SoderjRazdDiscip
    */
    function SendingDataToServerFromSoderjRazdDiscip(formData) {
        var SoderjRazdelDiscip = document.getElementById('Table_for_soderjDiscip');
        formData.append("RowCountSoderjDiscip", document.getElementById("Table_for_soderjDiscip").rows.length - 1);
        for (var i = 1; i < SoderjRazdelDiscip.rows.length; i++) {
            var Row = Table_for_soderjDiscip.rows[i];
            //Вид
            formData.append(Row.cells[0].childNodes[0].name, Row.cells[0].childNodes[0].value);
            //Семестр
            if (Row.cells[0].childNodes[0].value.toString().trim() == "Раздел") {
                var select = Row.cells[1].childNodes[0];
                formData.append(select.name, select.options[select.options.selectedIndex].text);
            }
            //Содержание тем/занятий
            formData.append(Row.cells[2].childNodes[0].name, Row.cells[2].childNodes[0].value);
            //объем часов
            if(Row.cells[0].childNodes[0].value.toString().trim() != "Раздел" && 
                Row.cells[0].childNodes[0].value.toString().trim() != "Тема"){
                formData.append(Row.cells[3].childNodes[0].name, Row.cells[3].childNodes[0].value);
            }
            else{
                formData.append(Row.cells[4].childNodes[0].name, Row.cells[4].childNodes[0].value);
            }
        }
        var LiteratureTable = document.getElementById('Table_for_Literature');
        formData.append("RowCountLiteratureTable", LiteratureTable.rows.length - 1);
        for (var i = 1; i < LiteratureTable.rows.length; i++) {
            var Row = LiteratureTable.rows[i];
            var select = Row.cells[0].childNodes[0];
            formData.append(select.name, select.options[select.options.selectedIndex].text.trim());
            formData.append(Row.cells[1].childNodes[0].name, Row.cells[1].childNodes[0].value);
        }
    }
    /*
        отправка информации от клиента со страницы CurrentControl
    */
    function SendingDataToServerFromCurrentControl(formData) {
        var CurControlTable = document.getElementById('CurrentControlHtmlTable');
        formData.append("RowCountCurControl", CurControlTable.rows.length - 1);
        for (var i = 1; i < CurControlTable.rows.length; i++) {
            var Row = CurControlTable.rows[i];
            formData.append(Row.cells[0].childNodes[0].name, Row.cells[0].childNodes[0].value);
            formData.append(Row.cells[1].childNodes[0].name, Row.cells[1].childNodes[0].value);
            formData.append(Row.cells[2].childNodes[0].name, Row.cells[2].childNodes[0].value);
        }
    }
    /*
        отправка информации от клиента со страницы RPD
    */
    function SendingDataToServerFromRPD(formData) {
        //вид и форма промежуточной аттестации студентов
        formData.append("TypeAndFormCertification", document.getElementById('TypeAndFormCertificationTextBox').value);
        //Используемые образовательные технологии
        formData.append("UsedEcucateTechnology", document.getElementById('UsedEcucateTechnologyTextBox').value);
        //Образцы тестов и контрольных занятий текущего контроля
        formData.append("ExampleTestCurControl", document.getElementById('ExampleTestCurControlTextBox').value);
        //примерная тематика эссе, рефератов, докладов
        formData.append("ThemesOfEsseReferats", document.getElementById('ThemesOfEsseReferatsTextBox').value);
        //Примерные темы курсовых работ, критерии оценивания
        formData.append("ThemesOfCourseJob", document.getElementById('ThemesOfCourseJobTextBox').value);
        //Методические указания по организации самостоятельной работы
        formData.append("OrganizationOfIndependentWork", document.getElementById('OrganizationOfIndependentWorkTextBox').value);
        //Промежуточный контроль
        formData.append("InterMediateControl", document.getElementById('InterMediateControlTextBox').value);
        //Образцы тестов, заданий
        formData.append("ExampleTest", document.getElementById('ExampleTestTextBox').value);
        //Перечень вопросов к экзамену (зачету)
        formData.append("QuestionForExam", document.getElementById('QuestionForExamTextBox').value);
        //Материально-техническое обеспечение дисциплины
        formData.append("LogisticsDiscipline", document.getElementById('LogisticsDisciplineTextBox').value);
        //доля занятий с использованием интерактивных технологий
        formData.append("Part_InteractiveMethods", document.getElementById('TextBox_Part_InteractiveMethods').value);
    }
    /*
        отправка информации от клиента со страницы UMK
    */
    function SendingDataToServerFromUMK(formData) {
        //форма и правила проведения промежуточной аттестации
        formData.append("FormAndRulesCertification", document.getElementById('FormPromejAttestatTextBox').value);
        //перечень вопросов к экзамену/зачету
        formData.append("QuestionForExam", document.getElementById('QuestionForExamTextBox').value);
        //образцы экзаменационных тестов, заданий
        formData.append("ExampleExamTests", document.getElementById('ExampleExTestTextBox').value);
    }

    Timer_for_Sending_Data_to_Server();
}());