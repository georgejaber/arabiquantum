// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    function disableEnable(id1) {
        let tBox = document.getElementById(id1.slice(0, -2));
    let eBtn = document.getElementById(id1);
    let sBtn = document.getElementById(id1.slice(0, -1)+"s");
    //console.log(typeof (id1) + "" + id1.slice(0, -1)+"s");
    if (tBox.disabled == true) {

        tBox.disabled = "";
    tBox.style.borderStyle ="solid" ;
    eBtn.style.visibility = "hidden";
    sBtn.style.visibility = 'visible';;
           
        } 
    }


