const welcomeMessage = document.getElementById("welcomeMessage"); // Index.cshtml
const scanQRCode = document.getElementById("scanQRCode"); // Index.cshtml

const pin = document.getElementById("pin"); // Pin.cshtml
const keyPin = document.getElementById("keyPin"); // Pin.cshtml

const helloMessage = document.getElementById("helloMessage"); // Home.cshtml
const helloQuestion = document.getElementById("helloQuestion"); // Home.cshtml
const getCash = document.getElementById("getCash"); // Home.cshtml
const withdrawCash = document.getElementById("withdrawCash"); // Home.cshtml
const nonCashService = document.getElementById("nonCashService"); // Home.cshtml
const activateCard = document.getElementById("activateCard"); // Home.cshtml
const balanceEnquiry = document.getElementById("balanceEnquiry"); // Home.cshtml

let isEnglish = true;

function toggleLanguage() {
    isEnglish = !isEnglish;
    if (!isEnglish) {
        if (welcomeMessage != null) {
            welcomeMessage.innerHTML = "<h1>欢迎来到华侨银行!</h1>";
        }
        if (scanQRCode != null) {
            scanQRCode.innerHTML = "<h4>请扫描二维码或将卡插入读卡器</h4>";
        }
        if (pin != null) {
            pin.innerHTML = "<h1>使用 PIN 码登录!</h1>";
        }
        if (keyPin != null) {
            keyPin.innerHTML = "<h4>请使用键盘输入您的 PIN 码:</h4>";
        }
        if (helloMessage != null) {
            helloMessage.innerHTML = "<h1>您好, Xavier</h1>";
        }
        if (helloQuestion != null) {
            helloQuestion.innerHTML = "<h4>今天您想做什么？</h4>"
        }
        if (getCash != null) {
            getCash.innerHTML = "<p style='padding-bottom:20px, font-size:30px'<b>提取现金</b></p>";
        }
        if (withdrawCash != null) {
            withdrawCash.innerHTML = "<a>提款</a>"
        }
        if (nonCashService != null) {
            nonCashService.innerHTML = "<b>非现金服务</b>";
        }
        if (activateCard != null) {
            activateCard.innerHTML = "<a>启动卡</a>";
        }
        if (balanceEnquiry != null) {
            balanceEnquiry.innerHTML = "<a>余额查询</a>";
        }

    } else {
        if (welcomeMessage != null) {
            welcomeMessage.innerHTML = "<h1>Welcome to OCBC!</h1>";
        }
        if (scanQRCode != null) {
            scanQRCode.innerHTML = "<h4>Please scan the QR code or insert card in the reader</h4>";
        }
        if (pin != null) {
            pin.innerHTML = "<h1>Sign in with PIN!</h1>";
        }
        if (keyPin != null) {
            keyPin.innerHTML = "<h4>Please key in your pin with the keypad:</h4>";
        }
        if (helloMessage != null) {
            helloMessage.innerHTML = "<h1>Hello Xavier</h1>";
        }
        if (helloQuestion != null) {
            helloQuestion.innerHTML = "<h4>What would you like to do today?</h4>"
        }
        if (getCash != null) {
            getCash.innerHTML = "<p style='padding-bottom:20px; font-size:30px'><b>Get Cash</b></p>";
        }
        if (withdrawCash != null) {
            withdrawCash.innerHTML = "<a>提款</a>"
        }
        if (nonCashService != null) {
            nonCashService.innerHTML = "<b>非现金服务</b>";
        }
        if (activateCard != null) {
            activateCard.innerHTML = "<a>启动卡</a>";
        }
        if (balanceEnquiry != null) {
            balanceEnquiry.innerHTML = "<a>余额查询</a>";
        }

    }
    event.preventDefault();
}



