﻿var dataTable;

$(document).ready(function () {
    cargarDatatable();
});


function cargarDatatable() {
    dataTable = $("#tblEmpleados").DataTable({
        "ajax": {
            "url": "/admin/Empleados/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "idempleados", "width": "5%" },
            { "data": "nombre", "width": "50%" },
            { "data": "apa", "width": "50%" },
            { "data": "ama", "width": "50%" },
            { "data": "idperfiles", "width": "20%" },
            {
                "data": "idempleados",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/admin/Empleados/Edit/${data}' class='btn btn-success text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-edit'></i> Editar
                            </a>
                            &nbsp;
                            <a onclick=Delete("/admin/Empleados/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros"
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