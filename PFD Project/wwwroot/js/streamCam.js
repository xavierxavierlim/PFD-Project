if (sessionStorage.getItem("useCam") == null) {
    sessionStorage.setItem("useCam", false)
}
var cam = (sessionStorage.getItem("useCam") === 'true');

const closeCam = () => {
    const video = document.getElementById("streamCam");
    let stream = video.srcObject;
    var tracks = stream.getVideoTracks();
    //tracks.forEach(track => track.enabled = false);

    for (var i = 0; i < tracks.length; i++) {
        var track = tracks[i];
        track.stop();
    }
    video.srcObject = null;

    const icon = document.getElementsByClassName("fa-camera");
    icon.style.color = '#000000';

    sessionStorage.setItem("useCam", false);
    cam = (sessionStorage.getItem("useCam") === 'true');

};
const openCam = () => {

    //Initialize video
    const video = document.getElementById("streamCam");

    // validate video element
    if (navigator.mediaDevices.getUserMedia) {
        navigator.mediaDevices
            .getUserMedia({ video: true })
            .then((stream) => {
                video.srcObject = stream;
            })
            .catch(function (error) {
                console.log("Something went wrong!");
                console.log(error);
            });
            
    }

    const displayContainer = document.getElementById('camContainer');
    displayContainer.style.display = 'block';

    sessionStorage.setItem("useCam", true);
    cam = (sessionStorage.getItem("useCam") === 'true');
}

function toggleCam() {
    cam ? closeCam() : openCam();
}
function initialiseCam() {
    if (cam) {
        openCam();
    }
}
initialiseCam();