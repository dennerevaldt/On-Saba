
    function getEndereco() {
        if ($.trim($("#cep").val()) != "") {
            $.getScript("http://cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + $("#cep").val(), function () {
                if (resultadoCEP["resultado"] != 0) {
                    $("#cidade").val(unescape(resultadoCEP["cidade"]));
                    $("#estado").val(unescape(resultadoCEP["uf"]));
                } else {
                    $("#cidade").val("");
                    $("#estado").val("");
                }
            });
        }
    }
