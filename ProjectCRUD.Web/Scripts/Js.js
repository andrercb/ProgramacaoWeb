///Mascara para campo aceitar apenas números 
function MascaraNumerico(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function Letras() {
    tecla = event.keyCode;
    if (tecla >= 48 && tecla <= 57) {
        return false;
    } else {
        return true;
    }
}