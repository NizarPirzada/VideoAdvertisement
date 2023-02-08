var videotime = [];
var videos = [1, 2, 3, 4, 5, 6];
$(document).ready(function () {
    try {
        
      
        videos.map(function (val, index) {
            
            if (index == 4) {
              //  alert('4')
                var date = new Date().toLocaleString();

                videotime.push(val);
                console.log(videotime);

            } else if (index == 3) {
               // alert('3')
            } else if (videos.length == 2)
            {
             //   alert('2')
            }
                
            videos.shift();
        })
    }
    catch (err) {
        console.log(err)
    }

    $("#loginAuth").click(function () {
    
        var obj = {
            Email: document.getElementById("Email").value,
            Password: document.getElementById("Password").value
        }

        $.ajax({
            type: "POST",
            url: 'https://localhost:44346/Home/Login',
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