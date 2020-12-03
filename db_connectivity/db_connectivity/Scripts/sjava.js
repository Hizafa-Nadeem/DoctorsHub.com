
function checkpassword() {


    var password1 = document.getElementById("password").value;
    var rpassword = document.getElementById("repeatpassword").value;

    if (password1 != rpassword) {
        alert("Password not same");
    }
}
/*function checkemptyfields()
{
    alert("hi");
   // var password1 = document.getElementById("password").value;
    //var rpassword = document.getElementById("repeatpassword").value;
    var username = document.getElementById("uname").value;
   // var Email = document.getElementById("email").value;
    //var gender = document.getElementById("gender1").value;
    if (username==""){// || password1=="" || Email =="" || gender == ""|| rpassword==""){
    alert("Please Enter All Fields");
    }
}*/
function check() {
    var password1 = document.getElementById("password").value;
    var rpassword = document.getElementById("repeatpassword").value;

    if (password1 != rpassword) {
        alert("Password not same");
    }
    var password1 = document.getElementById("password").value;
    var rpassword = document.getElementById("repeatpassword").value;
    var username = document.getElementById("uname").value;
    var Email = document.getElementById("email").value;
    var d = document.getElementById("d").checked;
    var p = document.getElementById("p").checked;
    var m = document.getElementById("m").checked;
    var f = document.getElementById("f").checked;
    if (username == "" || password1 == "" || Email == "" || rpassword == "" || (p == false && d == false) || (m == false && f == false)) {
        //alert(d); alert(p);
        // if (p == false && d == false) {
        //alert(d);
        alert("Please Enter All Fields");
        // }
    } else {
        var dot = 0; var text = 0; var at = 0; var foo = 0;
        for (var i = 0; i < Email.length; i++) {
            if (Email[i] == '@') {
                text = i;
                at = 1;
            }
            if (Email[i] == '.') {
                dot = 1;
                if (text + 1 != i) {
                    foo = 1;
                }
            }

        }
        if (foo == 0 || dot == 0 || at == 0) {
            alert("incorrect email");
        } else {
           // alert("thank you for logging in!!!!");
        }
    }
}
function check1() {
    var password = document.getElementById("password").value;
    var uid = document.getElementById("uid").value;
    var d = document.getElementById("d").checked;
    var p = document.getElementById("p").checked;
    if (uid == "" || password1 == "" ) {
        //alert(d); alert(p);
        if (p == false && d == false) {
        //alert(d);
            alert("Please Enter All Fields");
            }
        // }
    } else {
       // alert("thank you for logging in!!!!");
    }
}

//(function ($) {
//    "use strict";

//    /*==================================================================
//    [ Focus Contact2 ]*/
//    $('.input100').each(function(){
//        $(this).on('blur', function(){
//            if($(this).val().trim() != "") {
//                $(this).addClass('has-val');
//            }
//            else {
//                $(this).removeClass('has-val');
//            }
//        })    
//    })


/*==================================================================
//[ Validate after type ]*/
//$('.validate-input .input100').each(function(){
//    $(this).on('blur', function(){
//        if(validate(this) == false){
//            showValidate(this);
//        }
//        else {
//            $(this).parent().addClass('true-validate');
//        }
//    })    
//})

/*==================================================================
//    [ Validate ]*/
//    var input = $('.validate-input .input100');

//    $('.validate-form').on('submit',function(){
//        var check = true;

//        for(var i=0; i<input.length; i++) {
//            if(validate(input[i]) == false){
//                showValidate(input[i]);
//                check=false;
//            }
//        }

//        return check;
//    });


//    $('.validate-form .input100').each(function(){
//        $(this).focus(function(){
//           hideValidate(this);
//           $(this).parent().removeClass('true-validate');
//        });
//    });

//    function validate (input) {
//        if($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
//            if($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
//                return false;
//            }
//        }
//        else {
//            if($(input).val().trim() == ''){
//                return false;
//            }
//        }
//    }

//    function showValidate(input) {
//        var thisAlert = $(input).parent();

//        $(thisAlert).addClass('alert-validate');
//    }

//    function hideValidate(input) {
//        var thisAlert = $(input).parent();

//        $(thisAlert).removeClass('alert-validate');
//    }



//})(jQuery);