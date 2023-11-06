var popup = false;
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