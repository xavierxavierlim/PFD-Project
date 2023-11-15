if (sessionStorage.getItem("useCam") == null) {
    sessionStorage.setItem("useCam", 'true')
}
var cam = (sessionStorage.getItem("useCam") === 'true');
var firsttimeonpage = true;

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
function detectface() {
    var video = document.getElementById('video');
    var canvas = document.getElementById('canvas');
    var context = canvas.getContext('2d');

    var tracker = new tracking.ObjectTracker('face');
    tracker.setInitialScale(4);
    tracker.setStepSize(2);
    tracker.setEdgesDensity(0.1);

    tracking.track(video, tracker, { camera: true });

    tracker.on('track', function (event) {
        context.clearRect(0, 0, canvas.width, canvas.height);

        event.data.forEach(function (rect) {
            context.strokeStyle = '#a64ceb';
            context.strokeRect(rect.x, rect.y, rect.width, rect.height);
            context.font = '11px Helvetica';
            context.fillStyle = "#fff";
            context.fillText('x: ' + rect.x + 'px', rect.x + rect.width + 5, rect.y + 11);
            context.fillText('y: ' + rect.y + 'px', rect.x + rect.width + 5, rect.y + 22);
        });
        if (event.data.length === 0) {
            console.log("No face detected");
        }
        else if (event.data.length === 1) {
            console.log("1 face detected")
        }
        else if (event.data.length > 1) {
            console.log("More than one face detected");
        }
        else {
            console.log(event.data.length);
        }
    });

    var gui = new dat.GUI();
    gui.add(tracker, 'edgesDensity', 0.1, 0.5).step(0.01);
    gui.add(tracker, 'initialScale', 1.0, 10.0).step(0.1);
    gui.add(tracker, 'stepSize', 1, 5).step(0.1);
};
const closeCam = () => {
    const displayContainer = document.getElementById('camContainer');
    displayContainer.style.display = 'none';
    sessionStorage.setItem("useCam", 'false');
    cam = (sessionStorage.getItem("useCam") === 'true');

};
const openCam = () => {
    const displayContainer = document.getElementById('camContainer');
    displayContainer.style.display = 'block';
    if (firsttimeonpage) {
        firsttimeonpage = false;
        detectface();
    }
    sessionStorage.setItem("useCam", 'true');
    cam = (sessionStorage.getItem("useCam") === 'true');
}

function toggleCam() {
    cam ? closeCam() : openCam();
}
function initialiseCam() {
    dragElement(document.getElementById('dragCamCon'));
    if (cam) {
        openCam();
    }
    else {
        closeCam();
    }
}
initialiseCam();

