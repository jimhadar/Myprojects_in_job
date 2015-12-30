(function () {
    function forMainPage() {

    }
    /*Будет происходить перед обратной отправкой формы
        в отправляемые данные запишем переменную SaveData,
        которая будет определять, что данные сохраняются
    */
    function ForSaveDataOnDB_or_PC(SaveData) {
        var formData = new FormData();
        formData.append("SaveDataToXml", "");
    }
    window.ForMainPage = forMainPage;
}());