document.getElementById('customFile').onchange = function () {
    var file = this.files[0];

    var reader = new FileReader();
    reader.onload = function (progressEvent) {

        var alunos = [];
        var lines = this.result.split('\n');
        for (var line = 1; line < lines.length; line++) {
            alunos[line - 1] = ObterDadosEnvio(lines[line]);
            if (alunos[line - 1] == false) {
                $('#customFile').val("");
                return false;
            }
        }
        SalvarInformacoes(JSON.stringify(alunos));
        $('#customFile').val("");
    };
    reader.readAsText(file);
};

function ObterDadosEnvio(line) {

    var registro = line.split('||', 4);
    if (registro.length === 3) {
        return {
            "Nome": registro[0],
            "Mensalidade": registro[1],
            "DataVencimento": registro[2]
        };

    } else {
        if (registro.length === 4) {
            return {
                "Nome": registro[0],
                "Mensalidade": registro[1],
                "DataVencimento": registro[2],
                "ProfessorDto": {
                    "Nome": registro[3]
                }
            };
        } else {
            alert("Arquivo deve conter 3 ou 4 colunas separadas por \"||\".\nA primeira coluna não será importada.\nPara importar ALUNO insira:\n\"NomeAluno||ValorMensalidade||DataVencimento\"\nPara importar ALUNO/PROFESSOR insira:\n\"NomeAluno||ValorMensalidade||DataVencimento||Professor\"\nO profesor deve estar cadastrado e seu nome deve ser igual, caso contrário, a linha não será importada.");
            return false;
        }
    }
}

function SalvarInformacoes(objetoList) {

    $.ajax({
        type: "POST",
        dataType: "json",
        data: { aluno: objetoList },
        url: "/Aluno/FileUpload",
        context: this,
        success: function (data_retorno) {

            document.location.reload(true);
            alert(data_retorno);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr + ' - ' + ajaxOptions + ' - ' + thrownError);
        },
    });

}