$("#btnCadastrar").on('click', function () {
    if (ValidaFormulario()) {

        var novoProfessor = ObterDadosEnvio();

        var objeto = JSON.stringify({
            "nome": novoProfessor[0].Nome
        });

        $.ajax({
            url: "/Professor/Cadastro/",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            data: objeto,
            beforeSend: function (xhr) {
                $("#divCarregando").show();
            },
            success: function (data) {
                $('#divCarregando').fadeOut('slow');
                setTimeout(function () { }, 3000);
                $.growl.notice({ message: "Professor cadastrado com sucesso !" });
                $('#inputNome').val("");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $('#divCarregando').fadeOut('slow');
                $.growl.error({ message: "Houve um erro ao tentar salvar as informações !" });
            },
        });

    }
});

function ValidaFormulario() {

    var formulario = $("#frmCadastraProfessor");

    formulario.validate({
        rules: {
            'inputNome': {
                required: true
            }
        },
        messages: {
            inputNome: "Informe o nome do Professor !"
        }
    });

    if (formulario.valid()) {
        return true;
    }
    else {
        return false;
    }
}

function ObterDadosEnvio() {
    return [{
        Nome: $('#inputNome').val()
    }];
}