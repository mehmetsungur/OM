$(document).ready(function () {
    $("#frmLogIn").validate({
        rules: {
            txtUserName: {
                required: true,
                minlength: 2
            },
            txtPassword: "required",
            txtSecurityCode: "required"
        },

        messages: {
            txtUserName: {
                required: "Lütfen Kullanıcı Adı Giriniz",
                minlength: "Kullanıcı Adı min. 2 karakter olmalı!"
            },
            txtPassword: "Lütfen Şifre Giriniz",
            txtSecurityCode: "Lütfen Güvenlik Kodunu Giriniz"
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents(".form-group").addClass("has-error").removeClass("has-success");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents(".form-group").addClass("has-success").removeClass("has-error");
        }
    });
    if (localStorage.getItem("UserName") != "") {
        $("#txtUserName").val(localStorage.getItem("UserName"));
    }
    if (localStorage.getItem("Password") != "") {
        $("#txtPassword").val(localStorage.getItem("Password"));
    }
    $("#btnLogIn").click(function () {
        if ($("#frmLogIn").valid()) {
            var vm =
            {
                UserName: $("#txtUserName").val(),
                Password: $("#txtPassword").val(),
                SecurityCode: $("#txtSecurityCode").val()
            };
            if ($("#checkbox-signin").is(':checked')) {
                localStorage.setItem("UserName", vm.UserName);
                localStorage.setItem("Password", vm.Password);
            }
            $.ajax({
                url: "/DashBoard/LogX/LogIn",
                method: "post",
                datatype: "json",
                data: vm,
                success: function (response) {
                    if (response.Result) {
                        window.location.href = "/DashBoard/DashBoard/Index";
                    }
                    else {
                        swal({
                            type: 'error',
                            title: 'İşlem Başarısız',
                            text: response.Message
                        }).then((result) => {
                            window.location.reload();
                        });
                    }
                },
                error: function () {
                    swal({
                        type: 'error',
                        title: 'İşlem Başarısız',
                        text: response.Message
                    }).then((result) => {
                        window.location.reload();
                    });
                }
            });
        }
    });
});