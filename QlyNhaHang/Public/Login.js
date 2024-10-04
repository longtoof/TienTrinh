const container = document.querySelector(".containers"),
    pwShowHide = document.querySelector(".showHide"),
    pwFields = document.querySelector(".password");

//js code to show/hide password change icon
pwShowHide.forEach(eyeIcon => {
    eyeIcon.addEventListener("click", () => {
        pwFields.forEach(pwFields => {
            if (pwFields.type === "password") {
                pwFields.type = "text";

                pwShowHide.forEach(icon => {
                    icon.pwShowHide.classList.replace("uil-eye-slash", "uil-eye");
                })
            } else {
                pwFields.type="password"
            }
        })
    })
})