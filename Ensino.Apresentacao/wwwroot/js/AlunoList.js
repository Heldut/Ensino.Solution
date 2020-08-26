$(document).ready(function () {

    if (document.getElementById("tabelaAluno")) {
        $.ajax({
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            url: "/Aluno/List/" + $('input#inputIdProfessor').val(),
            context: this,
            success: function (data_retorno) {
                $('#tabelaAluno')
                    .DataTable({
                        responsive: {
                            details: true
                        },
                        "data": data_retorno,
                        "columns": [
                            { "data": "id" },
                            { "data": "nome" },
                            {
                                data: "mensalidade",
                                type: 'decimal',
                                render: $.fn.dataTable.render.number('.', ',', 2)
                            },
                            {
                                data: "dataVencimento",
                                type: 'date',
                                render: function (data, type, row) { return data ? moment(data).format('DD/MM/YYYY') : ''; }
                            },
                            {
                                data: 'professorDto.nome',
                                render: function (data, type, row, meta) { return data != null ? data : ' - '; }
                            },
                            {
                                "data": "id",
                                "render": function (coluna, type, row, meta) {
                                    if (type === 'display') {
                                        coluna = '<button style="border:none;background-color: transparent;outline: none;" onClick="ExcluirRegistro(' + row.id + ');">Excluir</button>';
                                    }
                                    return coluna;
                                }
                            }
                        ]
                    });
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr + ' - ' + ajaxOptions + ' - ' + thrownError);
                console.log('Erro acesso !');
            },
        });
    }


})

function ExcluirRegistro(id) {

    $.ajax({
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        async: false,
        url: "/Aluno/Delete/" + id,
        context: this,
        success: function (data_retorno) {
            table = $('#tabelaAluno').DataTable();
            $('#tabelaAluno tbody').on('click', 'tr', function () {
                table.row(this).remove().draw(false);
            });
            $.growl.notice({ message: "Registro excluído com sucesso !" });
        },
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr + ' - ' + ajaxOptions + ' - ' + thrownError);
            console.log('Erro acesso !');
        },
    });
}
