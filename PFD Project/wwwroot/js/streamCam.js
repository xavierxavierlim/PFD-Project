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

dragElement(document.getElementById("dragCamCon"));

function dragElement(elmnt) {
    var pos1 = 0, pos2 = 0, pos3 = 0, pos4 = 0;
    if (document.getElementById(elmnt.id)) {
        // if present, the header is where you move the DIV from:
        document.getElementById(elmnt.id).onmousedown = dragMouseDown;
    } else {
        // otherwise, move the DIV from anywhere inside the DIV:
        elmnt.onmousedown = dragMouseDown;
    }

    function dragMouseDown(e) {
        e = e || window.event;
        e.preventDefault();
        // get the mouse cursor position at startup:
        pos3 = e.clientX;
        pos4 = e.clientY;
        document.onmouseup = closeDragElement;
        // call a function whenever the cursor moves:
        document.onmousemove = elementDrag;
    }

    function elementDrag(e) {
        e = e || window.event;
        e.preventDefault();
        // calculate the new cursor position:
        pos1 = pos3 - e.clientX;
        pos2 = pos4 - e.clientY;
        pos3 = e.clientX;
        pos4 = e.clientY;
        // set the element's new position:
        elmnt.style.top = (elmnt.offsetTop - pos2) + "px";
        elmnt.style.left = (elmnt.offsetLeft - pos1) + "px";
    }

    function closeDragElement() {
        // stop moving when mouse button is released:
        document.onmouseup = null;
        document.onmousemove = null;
    }
}
