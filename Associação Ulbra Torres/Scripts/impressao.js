function imprimir(id) {
    $('#divCarregando').show();
    
    $.ajax({
        type: "GET",
        url: '/Associados/GerarCarteira?pIdAssociado=' + id,
        dataType: 'html',
        cache: false,
        async: true,
        success: function (data) {
            $('#divCarregando').hide();
            var myWindow = window.open();
            myWindow.document.write(data);
        }
    })
}