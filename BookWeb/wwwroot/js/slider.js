var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblSliders").DataTable({
        "ajax": {
            "url": "/admin/sliders/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idslider", "width": "5%" },
            { "data": "nombre", "width": "35%" },
            { "data": "estado", "width": "20%" },
            {
                "data": "urlimagen",
                "render": function (imagen) {
                    return `<img src="../${imagen}" width="200">`
                }
            },
            {
                "data": "idslider",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/admin/Sliders/Edit/${data}" class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-edit'></i> Editar
                                </a>
                                &nbsp;
                                <a onclick=Delete("/admin/Sliders/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                                    <i class='far fa-trash-alt'></i> Borrar
                                </a>
                            </div>
                            `;
                }, "width": "35%"
            },
        ],
        "language": {
            "emptyTable": "No hay registros."
        },
        "width": "100%"
    });
}

function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}