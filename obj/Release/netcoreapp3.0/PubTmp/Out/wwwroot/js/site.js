var savePlaysarr = [];
var respDblist;
var arrayVideos = [];
var isLoadWindow = 0;
var loopIndex = 0;
var videotime = [];

$(document).ready(function () {
   GetloopVideos();
   
});
var testid;
var playMovie = function (player, videos, options) {

    if (!videos.length) {
        return false;
    }

    console.log(videos);

    var video = 'https://vimeo.com/' + videos.shift();

    if (!player) {
        options.url = video;
        console.log(video);
        testid = video;

        player = new Vimeo.Player('video-container', options);
        player.play();
        //  toggleFullScreen();
        player.on('ended', function () {
            
            playMovie(player, videos, options)

        })

    } else {
        console.log(video);
        testid = video;
        player.loadVideo(video)
            .then(function () {

                console.log(arrayVideos);
                player.play();
            })
            .catch(function (error) {
                console.log(testid + '*');
                console.warn(error);
            });
    }
    player.getEnded(true).then(function (ended) {
        // `ended` indicates whether the video has ended
        if (videos.length == 3) {
            var date = new Date();
            FormatedDate = moment(date).format("yyyy-MM-DDTHH:mm:ss");
            videotime.push(FormatedDate);
         }
        else if (videos.length == 2) {
            var date = new Date();
            FormatedDate = moment(date).format("yyyy-MM-DDTHH:mm:ss");
            videotime.push(FormatedDate);
         }
        else if (videos.length == 1) {
            var date = new Date();
            FormatedDate = moment(date).format("yyyy-MM-DDTHH:mm:ss");
            videotime.push(FormatedDate);
        }else if (videos.length == 0) {
            isLoadWindow = 1;
            loopIndex++;
            GetloopVideos();
            SavePlays(respDblist);

        }
       
    });
}
function SavePlays(data) {
    console.log(data);
    savePlaysarr = [];
    data.VideosLists.map(function (val, index) {
       
        if (val.VSVAccountID != null) {
             var obj = {
                VSVAccountID:val.VSVAccountID,
                VidId:val.VidId,
               PlayTimeStamp:videotime[0]
            }
            videotime.shift();
            savePlaysarr.push(obj);
        }
        
    })
    
    if (savePlaysarr.length > 0) {
        $.ajax({
            type: "POST",
            url: ApiUrl+'/Home/SavePlaysVideos',
            data: JSON.stringify(savePlaysarr),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data, status) {
                window.location.href = "/";
            },
            error: function (data, status) {


            }
        });
    }
   
}

function logout() {
    $.ajax({
        type: "POST",
        url: ApiUrl +'/Home/logout',
        data: null,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data, status) {
            window.location.href = "/";
        },
        error: function (data, status) {


        }
    });
    return false;
}
function toggleFullScreen() {
    var element = document.getElementById("video-container");
    element.requestFullscreen();

}
function GetloopVideos() {
    arrayVideos = [];
   
   
    $.ajax({
        type: "POST",
        url: ApiUrl +'/Home/GetEntertainmentVideos?loopIndex=' + loopIndex,
        data: null,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data, status) {
            respDblist = data;
         
            data.VideosLists.map(function (val, index) {

                arrayVideos.push(val.VideoId)
            })
            if (data.LoopEnded == true) {
                loopIndex = 0;
            }
            if (isLoadWindow === 1) {
                arrayVideos.unshift(isLoadWindow);
                playMovie(null, arrayVideos, options)
            } else {
                playMovie(null, arrayVideos, options)
            }

        },
        error: function (data, status) {


        }
    });
    var options = {
        width: "1000",
        height: "500"
    };


}
