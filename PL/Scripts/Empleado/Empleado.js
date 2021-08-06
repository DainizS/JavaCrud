$(document).ready(function () {
    GetAll();


    // drop down list entidadesfederativas
    CatEntidadFederativaGetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: '/Empleado/GetData',
        dataType: 'json',
        
        success: function (result) { //200 OK
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, Empleado) {
                var filas =
                    '<tr>'

                        + '<td > <button class="btn btn-warning glyphicon glyphicon-edit" onclick="GetById(' + Empleado.Id + ')"></button></td>'
                        + "<td >" + Empleado.NumeroNomina + "</td>"
                        + "<td >" + Empleado.Nombre + "</td>"
                        + "<td >" + Empleado.ApellidoPaterno + "</ td>"
                        + "<td >" + Empleado.ApellidoMaterno + "</td>"
                        + "<td >" + Empleado.CatEntidadFederativa.Estado + "</td>"
                        + '<td > <button class="btn btn-danger" onclick="Eliminar(' + Empleado.Id + ')"><span class="glyphicon glyphicon-trash" ></span></button></td>'

                    + "</tr>";
                $("#Empleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};
function GetAll1() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:4865/api/Empleado/GetAll',     
        success: function (result) { //200 OK
            $('#Empleados tbody').empty();
            $.each(result.Objects, function (i, Empleado) {
                var filas =
                    '<tr>'
                   
                        + '<td > <button class="btn btn-warning glyphicon glyphicon-edit" onclick="GetById(' + Empleado.Id + ')"></button></td>'
                        + "<td >" + Empleado.NumeroNomina + "</td>"
                        + "<td >" + Empleado.Nombre + "</td>"
                        + "<td >" + Empleado.ApellidoPaterno + "</ td>"
                        + "<td >" + Empleado.ApellidoMaterno + "</td>"
                        + "<td >" + Empleado.CatEntidadFederativa.Estado + "</td>"
                        + '<td > <button class="btn btn-danger" onclick="Eliminar(' + Empleado.Id + ')"><span class="glyphicon glyphicon-trash" ></span></button></td>'

                    + "</tr>";
                $("#Empleados tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


function CatEntidadFederativaGetAll() {
    $("#ddlEntidades").empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:4865/api/CatEntidadFederativa/GetAll',
        success: function (result) {
            $("#ddlEntidades").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, entidad) {
                $("#ddlEntidades").append('<option value="'
                                           + entidad.Id + '">'
                                           + entidad.Estado + '</option>');
            });
        }
    });
}

//// inicializar mi modal utilizado con los campos vacios 
function InitializedControls() {
    $('#txtIdEmpleado').val("");
    $('#txtNombre').val("");
    $('#txtApellidoPaterno').val("");
    $('#txtApellidoMaterno').val("");

    $('#ddlEntidades').val(0);
    $('#ModalUpdate').modal('show');

};

function Form(IdEmpleado) {
    
    if (IdEmpleado == "") {
        Add();
    }
    else {
        Update();
    }

};
function Add() {
    

    var empleado = {
        Id: 0,
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        
        CatEntidadFederativa: {

            Id: $('#ddlEntidades').val()
        }
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:4865/api/Empleado/Add',
        dataType: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal();   //      by id, class, atributes,  
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:4865/api/Empleado/GetById/' + IdEmpleado,
        success: function (result) {
            $('#txtIdEmpleado').val(result.Object.Id);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);

            $('#ddlEntidades').val(result.Object.CatEntidadFederativa.Id);

            $('#ModalUpdate').modal('show');
           
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

}


function Update() {

    var empleado = {
        Id: $('#txtIdEmpleado').val(),
        Nombre: $('#txtNombre').val(),
        ApellidoPaterno: $('#txtApellidoPaterno').val(),
        ApellidoMaterno: $('#txtApellidoMaterno').val(),
        
        CatEntidadFederativa: {
            Id: $('#ddlEntidades').val()
        }
    }

    $.ajax({
        type: 'POST',
        url: 'http://localhost:4865/api/Empleado/Update',
        datatype: 'json',
        data: empleado,
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
            //Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};



function Eliminar(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:4865/api/Empleado/Delete/' + IdEmpleado,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};