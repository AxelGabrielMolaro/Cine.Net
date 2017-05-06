$(document).ready(function () {

    /*
        !!!!!!!FORMULARIO RESERVA 1!!!!!!!! comente los mss pq no se puede validar con jquery
    
    */
  $("#paso1").show();




    //botones anterior
     $("#botonAnterior1").click(function () {
     
         $("#progreso").text("0%");
         $("#progreso").css("color", "red");
         $("#paso1").fadeIn(1000);
          $("#paso2").hide();
         


     });
     $("#botonAnterior2").click(function () {

         $("#progreso").text("25%");
         $("#progreso").css("color", "yellow");
         $("#paso2").fadeIn(1000);
         $("#paso3").hide();



     });
     $("#botonAnterior3").click(function () {
         $("#progreso").css("color", "lightgreen");
         $("#progreso").text("50%");
         $("#paso3").fadeIn(1000);
         $("#paso4").hide();



     });
    


//botones siguiente
 

    
 
    $("#botonSiguiente1").click(function () {
        var version = $("input[type = 'checkbox' ]:checked");
        if (version.length == 0 || version.length == 2) {
           // $("#mensaje1").fadeIn(100);
            return false;
        }
        else {
            $("#paso1").hide();
            $("#paso2").fadeIn(1000);
           
            $("#progreso").text("25%");
            $("#progreso").css("color", "yellow");
          
        }
    });
    //sede
    $("#botonSiguiente2").click(function () {
        var sede = $("#sede").val();
        if (validarQueElSelectNoSea0(sede) == false)
        {
            //$("#mensaje2").fadeIn(100);
       
            return false;
        }
        else {
            $("#paso2").hide();
            $("#paso3").fadeIn(1000);
            $("#progreso").text("50%");
            $("#progreso").css("color", "lightgreen");
        }
    });

    //dia
    $("#botonSiguiente3").click(function () {
        var dia = $("#dia").val();
        if (validarQueElSelectNoSea0(dia) == false) {
            //$("#mensaje3").fadeIn(100);
            return false;
           

        }
        else {
            $("#paso3").hide();
            $("#paso4").fadeIn(1000);
            $("#progreso").text("75%");
            $("#progreso").css("color", "green");
        }
    });

    //horario 
    $("#reservaBotonEnviar").click(function () {
        var horario = $("#horario").val();
        if (validarQueElSelectNoSea0(horario) == false) {
            //$("#mensaje4").fadeIn(100);
            
            return false;
            

        }
        else {
            $("#progreso").text("100%");
            $("#progreso").css("color", "green");
            return true;
        }
    });

    $("#horario").change(function() {

        
            var horario = $("#horario").val();
            if (validarQueElSelectNoSea0(horario) == true) {

                $("#progreso").text("100%");
                $("#progreso").css("color", "green");
            }
            else {
                $("#progreso").text("75%");
                $("#progreso").css("color", "green");
            }
        
    });
    /*
         !!!!!!!FIN FORMULARIO RESERVA 1!!!!!!!!
     
     */
    //*************************************************************************************//
    /*
        !!!!!!!FORMULARIO RESERVA 2!!!!!!!! lo comente pq no se puede validar on jquery
    
    */
    /*

    $("#btnReserva2").click(function () {
        var nombre = $("#nombreReserva").val();
        var tipoDoc = $("#tipoDocReserva").val();
        var numeroDoc = $("#numeroDocReserva").val();
        var cantEntradas = $("#cantidadDeEntradasReserva").val();
        if (nombre.length == 0 || nombre.length>25)
        {
            $("#mensaje").fadeIn(1000);
        
            return false;
        }
        if (validarQueElSelectNoSea0(tipoDoc) == false) {
            $("#mensaje2").fadeIn(1000);

            return false;
        }
        if (numeroDoc.length !=8) {
            $("#mensaje3").fadeIn(1000);

            return false;
        }
        if (cantEntradas <= 0 || cantEntradas>=15)
        {
            $("#mensaje4").fadeIn(1000);

            return false;
        }
    });*/
    /*
        !!!!!!!FIN FORMULARIO RESERVA 2!!!!!!!!
    
    */
    //--datepicker reportes
    $("#fechaInicio").datepicker();
    $("#fechaHasta").datepicker();
});

function validarQueElSelectNoSea0(e)
{
    
    if (e == 0) {
        return false;
    }
    else {
        return true
    }
}

