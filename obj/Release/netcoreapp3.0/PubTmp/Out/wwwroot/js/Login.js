
$(document).ready(function () {

    $("#loginAuth").click(function () {
    
        var obj = {
            Email: document.getElementById("Email").value,
            Password: document.getElementById("Password").value
        }

        $.ajax({
            type: "POST",
            url: ApiUrl+'/Home/Login',
            data: JSON.stringify(obj),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data, status) {

                if (data.Status === 200) {
                    document.cookie = "AccountID=" + data.VsvaccountId;

                    window.location.href = "Home/Index";
                } else {
                    document.getElementById("errorMsg").style.display = "block"
                }


            },
            error: function (data, status) {


            }
        });
        return false;
    });

});