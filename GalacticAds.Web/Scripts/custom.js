function globalAjaxCursorChange() {
    $("html").bind("ajaxStart", function () {
        $(this).addClass('busy');
    }).bind("ajaxStop", function () {
        $(this).removeClass('busy');
    });
}