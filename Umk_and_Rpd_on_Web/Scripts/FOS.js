(function () {
    function FOS() {

    }
    /*добавляем выбранную компетенцию в текстовое поле*/
    function AddTextToTextBoxCompet(event) {
        event.stopPropagation();
        var target = event.target;
        if (target.tagName == "SELECT") {
            /*получаем ячейку, которая содержит текстовое поле и список с компетенциями*/
            var parent = target.parentNode;
            //добавляемый в текстовое поле текст. Текст выбирается из выпадающего списка компетенций
            var select = parent.childNodes[1];
            var textBox = parent.childNodes[0];
            if (select.options.length > 0) {
                var addText = select.options[select.options.selectedIndex].text;
                if (textBox.value != '') {
                    textBox.value += ", " + addText;
                }
                else {
                    textBox.value = addText;
                }
                select.selectedIndex = 0;
            }
        }
    }
    FOS.AddTextToTextBoxCompet = AddTextToTextBoxCompet;
    window.FOS = FOS;
}());