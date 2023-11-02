var cam = false;

const closeCam = () => {
    const video = document.getElementById("streamCam");
    let stream = video.srcObject;
    var tracks = stream.getVideoTracks();
    tracks.forEach(track => track.enabled = false);

    const displayContainer = document.getElementById('camContainer');
    displayContainer.style.display = 'none';

    cam = false;
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
            });
    }

    const displayContainer = document.getElementById('camContainer');
    displayContainer.style.display = 'block';

    cam = true;
}

function toggleCam() {
    cam ? closeCam() : openCam();
}