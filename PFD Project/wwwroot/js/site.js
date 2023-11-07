// Index.cshtml
const welcomeMessage = document.getElementById("welcomeMessage"); // Index.cshtml
const scanQRCode = document.getElementById("scanQRCode"); // Index.cshtml

// Pin.cshtml
const pin = document.getElementById("pin"); // Pin.cshtml
const keyPin = document.getElementById("keyPin"); // Pin.cshtml

// Home.cshtml
const helloMessage = document.getElementById("helloMessage"); // Home.cshtml
const helloQuestion = document.getElementById("helloQuestion"); // Home.cshtml
const getCash = document.getElementById("getCash"); // Home.cshtml
const withdrawCash = document.getElementById("withdrawCash"); // Home.cshtml
const nonCashService = document.getElementById("nonCashService"); // Home.cshtml
const activateCard = document.getElementById("activateCard"); // Home.cshtml
const balanceEnquiry = document.getElementById("balanceEnquiry"); // Home.cshtml

// WithdrawAmount.cshtml
const getCashHeader = document.getElementById("getCashHeader"); // WithdrawAmount.cshtml
const otherAmount = document.getElementById("otherAmount"); // WithdrawAmount.cshtml
const enterAmountPlaceholder = document.getElementById("enterAmountPlaceholder"); // WithdrawAmount.cshtml

// WithdrawMessage.cshtml
const withdrawMessage = document.getElementById("withdrawMessage");

// Receipt.cshtml
const withdrawAmountAmount = document.getElementById("withdrawAmountAmount");
const receipt = document.getElementById("receipt");
const yesShow = document.getElementById("yesShow");
const yesHide = document.getElementById("yesHide");
const showCardBalance = document.getElementById("showCardBalance");
const hideCardBalance = document.getElementById("hideCardBalance");
const no = document.getElementById("no");


// FeedbackStars.cshtml
const rateExperience = document.getElementById("rateExperience"); // FeedbackStars.cshtml

// FeedackOptions.cshtml
const area = document.getElementById("area");
const slowTransactionProcessing = document.getElementById("slowTransactionProcessing");
const difficultyWithATM = document.getElementById("difficultyWithATM");
const displayUninteractive = document.getElementById("displayUninteractive");
const inadequateLighting = document.getElementById("inadequateLighting");
const transactionErrors = document.getElementById("transactionErrors");
const accessibilityIssues = document.getElementById("accessibilityIssues");
const securityIssues = document.getElementById("securityIssues");
const others = document.getElementById("others");

// Thanks.cshtml
const thanks = document.getElementById("thanks");
const reachOut = document.getElementById("reachOut");
const returnToHome = document.getElementById("returnToHome");
const additionalFeedback = document.getElementById("additionalFeedback")
const changetoChinese = () => {
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
        getCash.innerHTML = "<p style='padding-bottom:20px, font-size:30px'><b>提取现金</b></p>";
    }
    if (withdrawCash != null) {
        withdrawCash.innerHTML = "<a asp-controller='Home' asp-action='WithdrawAmount' style='font-size:30px; text-decoration:none'>提款</a>";
    }
    if (nonCashService != null) {
        nonCashService.innerHTML = "<p><b>非现金服务</b></p>";
    }
    if (activateCard != null) {
        activateCard.innerHTML = "<a asp-controller='Home' asp-action='' style:'font-size:30px; text-decoration:none'>启动卡</a>";
    }
    if (balanceEnquiry != null) {
        balanceEnquiry.innerHTML = "<a asp-controller='Home' asp-action='' style='font-size:30px; text-decoration:none'>余额查询</a>";
    }
    if (getCashHeader != null) {
        getCashHeader.innerHTML = "<h1>提取现金</h1>";
    }
    if (otherAmount != null) {
        otherAmount.innerHTML = "<p><b class='form-control-lg mr-2' style='white-space: nowrap;'>其他金额:</b></p>";
    }
    if (enterAmountPlaceholder != null) {
        enterAmountPlaceholder.placeholder = "输入金额";
        enterAmountPlaceholder.style.width = "100%";
    }
    if (withdrawMessage != null) {
        withdrawMessage.innerHTML = "正在提款，请稍候...";
    }
    if (withdrawAmountAmount != null) {
        withdrawAmountAmount.innerHTML = "取款数量: $50";
    }
    if (receipt != null) {
        receipt.innerHTML = "您想要收据吗?";
    }
    if (yesShow != null) {
        yesShow.innerHTML = "是";
    }
    if (yesHide != null) {
        yesHide.innerHTML = "是";
    }
    if (showCardBalance != null) {
        showCardBalance.innerHTML = "(显示卡余额)";
    }
    if (hideCardBalance != null) {
        hideCardBalance.innerHTML = "(隐藏卡余额)";
    }
    if (no != null) {
        no.innerHTML = "不";
    }
    if (rateExperience != null) {
        rateExperience.innerHTML = "<h1 style='white-space:nowrap'>您如何评价您今天的经历?</h1>"
    }
    if (area != null) {
        area.innerHTML = "<h1>我们可以改进哪些领域?</h1>";
    }
    if (slowTransactionProcessing != null) {
        slowTransactionProcessing.innerHTML = "交易处理速度慢"
    }
    if (difficultyWithATM != null) {
        difficultyWithATM.innerHTML = "使用ATM机有困难"
    }
    if (displayUninteractive != null) {
        displayUninteractive.innerHTML = "显示非交互式"
    }
    if (inadequateLighting != null) {
        inadequateLighting.innerHTML = "照明不足"
    }
    if (transactionErrors != null) {
        transactionErrors.innerHTML = "交易错误"
    }
    if (accessibilityIssues != null) {
        accessibilityIssues.innerHTML = "可访问性问题"
    }
    if (securityIssues != null) {
        securityIssues.innerHTML = "安全问题"
    }
    if (others != null) {
        others.innerHTML = "其他"
    }
    if (thanks != null) {
        thanks.innerHTML = "<h1>感谢您的反馈意见!</h1>"
    }
    if (reachOut != null) {
        reachOut.innerHTML = "<h4 style='whitespace:nowrap'>如果您想进一步联系我们，请联系 +65 6363 3333</h4>"
    }
    if (returnToHome != null) {
        returnToHome.innerHTML = "<h5>[5秒后返回首页]</h5>"
    }
    if (additionalFeedback) {
        additionalFeedback.innerHTML = "<a asp-controller='Home' asp-action='FeedbackOptions' class='addFeedback'>提交另一个反馈</a>"
    }
}
const changetoEnglish = () => {
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
        withdrawCash.innerHTML = "<a asp-controller='Home' asp-action='WithdrawAmount' style='font-size:30px; text-decoration:none'>Withdraw Cash</a>"
    }
    if (nonCashService != null) {
        nonCashService.innerHTML = "<p><b>Non Cash Services</b></p>";
    }
    if (activateCard != null) {
        activateCard.innerHTML = "<a asp-controller:'Home' asp-action='' style:'font-size:30px; text-decoration:none'>Activate Card</a>";
    }
    if (balanceEnquiry != null) {
        balanceEnquiry.innerHTML = "<a asp-controller='Home' asp-action='' style='font-size:30px; text-decoration:none'>Balance Enquiry</a>";
    }
    if (getCashHeader != null) {
        getCashHeader.innerHTML = "<h1>Get Cash</h1>";
    }
    if (otherAmount != null) {
        otherAmount.innerHTML = "<p><b class='form-control-lg mr-2'>Other Amount:</b></p>";
    }
    if (enterAmountPlaceholder != null) {
        enterAmountPlaceholder.placeholder = "Enter amount";
    }
    if (withdrawMessage != null) {
        withdrawMessage.innerHTML = "Withdrawing money, please wait..."
    }
    if (withdrawAmountAmount != null) {
        withdrawAmountAmount.innerHTML = "Withdraw Amount: $50";
    }
    if (receipt != null) {
        receipt.innerHTML = "Would you like a receipt?";
    }
    if (yesShow != null) {
        yesShow.innerHTML = "Yes";
    }
    if (yesHide != null) {
        yesHide.innerHTML = "Yes";
    }
    if (showCardBalance != null) {
        showCardBalance.innerHTML = "(show card balance)";
    }
    if (hideCardBalance != null) {
        hideCardBalance.innerHTML = "(hide card balance)";
    }
    if (no != null) {
        no.innerHTML = "No";
    }
    if (rateExperience != null) {
        rateExperience.innerHTML = "<h1 style='white-space:nowrap'>How would you rate your experience today?</h1>";
    }
    if (area != null) {
        area.innerHTML = "<h1>What are the areas we can improve on?</h1>";
    }
    if (slowTransactionProcessing != null) {
        slowTransactionProcessing.innerHTML = "Slow transaction processing";
    }
    if (difficultyWithATM != null) {
        difficultyWithATM.innerHTML = "Difficulty using the ATM"
    }
    if (displayUninteractive != null) {
        displayUninteractive.innerHTML = "Display uninteractive"
    }
    if (inadequateLighting != null) {
        inadequateLighting.innerHTML = "Inadequate Lighting"
    }
    if (transactionErrors != null) {
        transactionErrors.innerHTML = "Transaction Errors"
    }
    if (accessibilityIssues != null) {
        accessibilityIssues.innerHTML = "ccessibility Issues"
    }
    if (securityIssues != null) {
        securityIssues.innerHTML = "Security Issues"
    }
    if (others != null) {
        others.innerHTML = "Others"
    }
    if (thanks != null) {
        thanks.innerHTML = "<h1>Thank you for your feedback!</h1>"
    }
    if (reachOut != null) {
        reachOut.innerHTML = "<h4 style='whitespace:nowrap'>Please contact +65 6363 3333 if you would like to further reach out to us</h4>"
    }
    if (returnToHome != null) {
        returnToHome.innerHTML = "<h5>[Returning to home page after 5 seconds]</h5>"
    }
    if (additionalFeedback) {
        additionalFeedback.innerHTML = "<a asp-controller='Home' asp-action='FeedbackOptions' class='addFeedback'>Submit additional feedback</a>"
    }
}
if (sessionStorage.getItem("isEnglish") == null) {
    sessionStorage.setItem("isEnglish", String(true))
}
var isEnglish = (sessionStorage.getItem("isEnglish") === 'true');
console.log(isEnglish);
function initialiseLang() {
    if (!isEnglish) {
        changetoChinese();
    }
}
initialiseLang();

function toggleLanguage() {
    if (isEnglish) { //if english , value must be true;
        changetoChinese();
    }
    else {
        changetoEnglish();
    }
    isEnglish = !isEnglish;
    sessionStorage.setItem("isEnglish", String(isEnglish));
    event.preventDefault();
}

document.getElementById('enterAmountPlaceholder').addEventListener('input', function () {
    const amount = this.value.trim();
    const submitButton = document.getElementById('submitButton');

    // Check if the input is a valid number with or without a leading $
    if (/^\$?\d+$/.test(amount)) {
        submitButton.removeAttribute('disabled');
    } else {
        submitButton.setAttribute('disabled', 'true');
    }
});