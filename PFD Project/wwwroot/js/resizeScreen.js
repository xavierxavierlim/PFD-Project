

var popup = false;
var defaultP = document.getElementById("defaultPreset");
var preset1 = document.getElementById("p1Preset");
var preset2 = document.getElementById("p2Preset");

const closeResize = () => {
    document.getElementById("resizePopUp").style.display = "none";
    popup = false;
}
const openResize = () => {
    document.getElementById("resizePopUp").style.display = "block";
    popup = true;
}
function toggleResize() {
    popup ? closeResize() : openResize();
}
function updateResize(value) {
    console.log("update:" + value);
    sessionStorage.setItem("fontSize", String(value));
    var sub = value + 50;
    var title = value + 75;
    if (document.getElementsByClassName("rTitle") != null) {
        for (var i = 0, len = document.getElementsByClassName("rTitle").length; i < len; i++) {
            document.getElementsByClassName("rTitle")[i].style.fontSize = title + "%"
        }
    };
    if (document.getElementsByClassName("rSub") != null) {
        //document.getElementsByClassName("rSub").style.fontSize = sub + "%";
        for (var i = 0, len = document.getElementsByClassName("rSub").length; i < len; i++) {
            document.getElementsByClassName("rSub")[i].style.fontSize = sub + "%"
        }
    };
    if (document.getElementsByClassName("rCon") != null) {
        //document.getElementsByClassName("rCon").style.fontSize = value + "%";
        for (var i = 0, len = document.getElementsByClassName("rCon").length; i < len; i++) {
            document.getElementsByClassName("rCon")[i].style.fontSize = value + "%"
        }
    };
}

function selectDefault(value) {
    defaultP.style.backgroundColor = "rgb(199, 212, 255)";
    preset1.style.backgroundColor = "";
    preset2.style.backgroundColor = "";
    sessionStorage.setItem("Preset", "0");
    updateResize(value);
}
function selectp1(value) {
    defaultP.style.backgroundColor = "";
    preset1.style.backgroundColor = "rgb(199, 212, 255)";
    preset2.style.backgroundColor = "";
    sessionStorage.setItem("Preset", "1");
    updateResize(value);
}
function selectp2(value) {
    defaultP.style.backgroundColor = "";
    preset1.style.backgroundColor = "";
    preset2.style.backgroundColor = "rgb(199, 212, 255)";
    sessionStorage.setItem("Preset", "2");
    updateResize(value);
}

if (sessionStorage.getItem("fontSize") == null) {
    sessionStorage.setItem("fontSize", "100");
    updateResize(100);
}
else {
    updateResize(Number(sessionStorage.getItem("fontSize")));
}
if (sessionStorage.getItem("Preset") == null) {
    sessionStorage.setItem("Preset", "0");
    selectDefault(100);
}
else {
    if (sessionStorage.getItem("Preset") == "1") {
        selectp1(120);
    }
    else if (sessionStorage.getItem("Preset") == "2") {
        selectp2(130);
    }
    else {
        selectDefault(100);
    }
}