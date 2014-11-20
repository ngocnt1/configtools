function showLoader() {
    try {
        $('.btn-has-loader').hide();
        $('.loader').show();
    } catch (e) {

    }
}

try {
    $('#projects').on("change",
        function () {
            $.cookie('project', $(this).val(), { expires: 7 });
            showLoader();
            window.location.reload();
        });
} catch (e) {

}

try {
    $('#queries').on("change",
        function () {
            $.cookie('query', $(this).val(), { expires: 7 });
            showLoader();
            window.location.reload();
        });
} catch (e) {

}

try {
    $('.btn-has-loader').on("click",
        function () {
            showLoader();
            return true;
        });
} catch (e) {

}

