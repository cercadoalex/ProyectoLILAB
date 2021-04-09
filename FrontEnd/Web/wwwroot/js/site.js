// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function pruebaTexto() {
    console.log("ingresio e");

}
function contadormas(index) {
    console.log(index);
    document.getElementById(`${index}`).value++;
   
}

function contadormenos(index) {
    document.getElementById(`${index}`).value--;
}