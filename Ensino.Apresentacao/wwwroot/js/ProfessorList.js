$(document).ready(function () {

    if (document.getElementById("tabelaProfessor")) {
        $.ajax({
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            url: "/Professor/List/",
            context: this,
            success: function (data_retorno) {

                $('#tabelaProfessor')
                    .DataTable({
                        responsive: {
                            details: true
                        },
                        "data": data_retorno,
                        "columns": [
                            { "data": "id" },
                            { "data": "nome" },
                            {
                                "data": null,
                                "render": function (coluna, type, row, meta) {
                                    if (type === 'display') {
                                        coluna = '<a href=Aluno/Index/' + row.id + '>Alunos</a>';
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