$(document).ready(function () {
    $("#btnLogLock").click(function () {
        var vm =
        {
            Password: $("#txtPassword").val()
        };
        $.ajax({
            url: "/DashBoard/LogX/LogLock",
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

            }
        });
    });
});