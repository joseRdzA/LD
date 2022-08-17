/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;*/

/*
    function verificarContrasenna() {
        var clave1 = document.getElementById("clave1").value;

        //la clave letras 
        if (clave1.search(/[a-z]/i) < 0) {
            document.getElementById("message").innerHTML = "La clave debe contener al menos una letra minúscula";
            return false;
        }
        if (clave1.search(/[A-Z]/i) < 0) {
            document.getElementById("message").innerHTML = "La clave debe contener al menos una letra mayúscula";
            return false;
        }

        //que no se envíe vacía
        if (clave1 == "") {
            document.getElementById("message").innerHTML = "Favor llenar el campo de clave";
            return false;
        }

        //min 8 caracteres
        if (clave1.length < 8) {
            document.getElementById("message").innerHTML = "La clave debe tener mínimo 8 caracteres";
            return false;
        }
       
        //max 12 caracteres
        if (clave1.length > 12) {
            document.getElementById("message").innerHTML = "La clave no debe exceder los 12 caracteres";
            return false;
        } else {
            alert("Clave correcta");
        }

       
        
        

       // var clave1 = ^ (?=.[A - Za - z])(?=.\d)(?=.[@$!%# ?&])[A - Za - z\d@$!%*# ?&]{ 8,} $;

       
       
    }
    */

function verificarContrasenna() {
    var p = document.getElementById('clave1').value,
        errors = [];
    if (p.length < 8) {
        //errors.push("Your password must be at least 8 characters");
        errors.push("La clave debe ser de entre 8-12 caracteres, contener una letra mayúscula, minúscula y un número.");
    }
    if (p.length > 12) {
        //errors.push("CLAVE 8 CARACTERES");
        errors.push("");
    }
    if (p.search(/[a-z]/i) < 0) {
        errors.push("");
    }
    if (p.search(/[A-Z]/i) < 0) {
        errors.push("");
    }
    if (p.search(/[0-9]/) < 0) {
        errors.push("");
    }
    if (errors.length > 0) {
        //alert(errors.join("\n"));
        document.getElementById("message").innerHTML = errors.join("\n");
        return false;
    }
    return true;
}