$(function () {
    $("#btnTaskSave").click(function () {
        var vm =
        {
            UserId: $("#txtTaskUserId").val(),
            Name: $("#txtTaskName").val()
        };
        $.ajax({
            url: "/DashBoard/DashBoard/CreateTask",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                $("#CreateTask").hide();
                if (response.Result) {
                    swal({
                        type: 'success',
                        title: 'İşlem Başarılı',
                        text: response.Message
                    }).then((result) => {
                        window.location.reload();
                    });
                }
                else {
                    swal({
                        type: 'error',
                        title: 'İşlem Başarısız',
                        html: "Görev Kaydedilemedi! <br><h5>Tüm Alanları Doldurarak</h5> Tekrar Deneyiniz ..."
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
    });

    $("body").on("click", "#imgTaskEdit", function () {
        var TaskId = $(this).attr("TaskId");

        var UpFromAss = $("#spnFromAss").html();
        var UpToAss = $("#spnToAss").html();
        var UpCreated = $("#spnCreated").html();
        var UpName = $("#spnName").html();
        var UpIsState = $("span.label").attr("IsTaskState");
        var UpModified = $("#spnModified").html();
        var UpDescription = $("#spnDescription").html();

        $("#hfTaskIdEdit").val(TaskId);
        $("#txtTaskEditFromAss").val(UpFromAss);
        $("#txtTaskEditToAAss").val(UpToAss);
        $("#txtTaskEditCreated").val(UpCreated);
        $("#txtTaskEditName").val(UpName);
        UpIsState == "true" ? $("#rdbTrue").prop("checked", true) : $("#rdbFalse").prop("checked", true);
        $("#txtTaskEditModified").val(UpModified);
        $("#txtTaskEditDescription").val(UpDescription);

        $("#divTaskEdit").modal('show');
    });

    $("body").on("click", "#imgTaskDelete", function () {
        var TaskId = $(this).attr("TaskId");
        swal({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Proje kaydı silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#67d630',
            cancelButtonColor: '#d33',
            cancelButtonText: "Hayır, vazgeç!",
            confirmButtonText: 'Evet, Silme işlemine devam edilsin!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: "/DashBoard/DashBoard/DeleteTask/" + TaskId,
                    method: "post",
                    success: function (response) {
                        if (response.Result) {
                            swal({
                                type: 'success',
                                title: 'İşlem Başarılı',
                                text: "Proje Başarıyla Silindi"
                            }).then((result) => {
                                window.location.reload();
                            });
                        }
                    }
                });
            }
        })
    });

    $("#btnTaskUpdate").click(function () {
        var id = $("#hfTaskIdEdit").val();
        var vm =
        {
            Id: id,
            Name: $("#txtTaskEditName").val(),
            State: $("#rdbTrue").is(":checked"),
            Description: $("#txtTaskEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/DashBoard/UpdateTask",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                if (response.Result) {
                    swal({
                        type: 'success',
                        title: 'İşlem Başarılı',
                        text: response.Message
                    }).then((result) => {
                        window.location.reload();
                    });
                }
                else {
                    swal({
                        type: 'error',
                        title: 'İşlem Başarısız',
                        text: 'Görev güncellenemedi. Lütfen tekrar deneyiniz!'
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
    });
});