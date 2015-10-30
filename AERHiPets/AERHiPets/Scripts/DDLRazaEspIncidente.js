$(document).ready(function () {
    var cont = 0;


   // $('#razaId option').remove();
   // $('#razaId').append('<option value=""></option');

    // First dropdown selection change event handler modificacion
    $('#especieId').change(function () {
        var catid = $(this).find(":selected").val();
        if (catid.length > 0) {
            // Populate products.
            $.getJSON('/Incidentes/getRazas', { intEspID: catid }, function (data) {
                // Ajax success callback function.
                // Populate dropdown from Json data returned from server.
                $('#razaId option').remove();
                $('#razaId').append('<option value=""></option');
                for (i = 0; i <= data.length; i++) {
                    $('#razaId').append('<option value="' +
                    data[i].Id + '">' + data[i].nombre + '</option');
                }
            }).fail(function (jqXHR, textStatus, errorThrown) {
                // Ajax fail callback function.
                alert('Error cargando Razas!');
            });
        }
        else {
            // Remove all second dropdown options if
            // empty option is selected in first dropdown.
            $('#razaId option').remove();
            $('#razaId').append('<option value=""></option');
        }
    });

    $('#razaId').change(function () {
        if (cont == 0) {
            var catid = $(this).find(":selected").val();
            if (catid.length > 0) {
                // Populate products.
                $.getJSON('/Incidentes/getRazas', { intEspID: catid }, function (data) {
                    // Ajax success callback function.
                    // Populate dropdown from Json data returned from server.
                    $('#razaId option').remove();
                    $('#razaId').append('<option value=""></option');
                    for (i = 0; i <= data.length; i++) {
                        $('#razaId').append('<option value="' +
                        data[i].Id + '">' + data[i].nombre + '</option');
                    }
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    // Ajax fail callback function.
                    alert('Error cargando Razas!');
                });
            }
            else {
                // Remove all second dropdown options if
                // empty option is selected in first dropdown.
                $('#razaId option').remove();
                $('#razaId').append('<option value=""></option');
            }

        }
        cont++;
    });



     /*   
    // Populate categories when the page is loaded.
    $.getJSON('/Incidentes/getEspecies', function (data) {
        // Ajax success callback function.
        // Populate dropdown from Json data returned from server.
        $('#especieId option').remove();
        $('#especieId').append('<option value=""></option');
        for (i = 0; i <= data.length; i++) {
            $('#especieId').append('<option value="' +
            data[i].Id + '">' + data[i].nombre + '</option');
        }
       
    }).fail(function (jqXHR, textStatus, errorThrown) {
        // Ajax fail callback function.
        alert('Error cargando Especies!');
    });
    */

});



