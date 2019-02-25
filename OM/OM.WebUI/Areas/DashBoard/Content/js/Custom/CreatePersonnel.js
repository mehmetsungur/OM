$(function () {
    $("#btnPersonnelSave").click(function () {
        var vm =
        {
            ProcessDate: $("#txtPersonnelProcessDate").val(),
            Process: $("#txtPersonnelProcess").val(),
            CompanyName: $("#txtPersonnelCompanyName").val(),
            PayDate: $("#txtPersonnelPayDate").val(),
            Price: $("#txtPersonnelPrice").val(),
            Description: $("#txtPersonnelDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Expense/CreatePersonnel",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                $("#CreatePersonnel").hide();
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
                        html: "Gider Kaydedilemedi! <br><h5>Tüm Alanları Doldurarak</h5> Tekrar Deneyiniz ..."
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

    $("body").on("click", "#imgPersonnelEdit", function () {
        var PersonnelId = $(this).attr("PersonnelId");
        var tr = $(this).parent("td").parent("tr");

        var UpProcessDate = tr.find("#spnProcessDate").html();
        var UpProcess = tr.find("#spnProcess").html();
        var UpCompanyName = tr.find("#spnCompanyName").html();
        var UpPayDate = tr.find("#spnPayDate").html();
        var UpPrice = tr.find("#spnPrice").html();
        var UpDescription= tr.find("#spnDescription").html();

        $("#hfPersonnelIdEdit").val(PersonnelId);
        $("#txtPersonnelEditProcessDate").val(UpProcessDate);
        $("#txtPersonnelEditProcess").val(UpProcess);
        $("#txtPersonnelEditCompanyName").val(UpCompanyName);
        $("#txtPersonnelEditPayDate").val(UpPayDate);
        $("#txtPersonnelEditPrice").val(UpPrice);
        $("#txtPersonnelEditDescription").val(UpDescription);

        $("#divPersonnelEdit").modal('show');
    });

    $("body").on("click", "#imgPersonnelDelete", function () {
        var PersonnelId = $(this).attr("PersonnelId");
        swal({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Personel gider kaydı silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#67d630',
            cancelButtonColor: '#d33',
            cancelButtonText: "Hayır, vazgeç!",
            confirmButtonText: 'Evet, Silme işlemine devam edilsin!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: "/DashBoard/Expense/DeletePersonnel/" + PersonnelId,
                    method: "post",
                    success: function (response) {
                        if (response.Result) {
                            swal({
                                type: 'success',
                                title: 'İşlem Başarılı',
                                text: "Gider Başarıyla Silindi"
                            }).then((result) => {
                                window.location.reload();
                            });
                        }
                    }
                });
            }
        })
    });

    $("#btnPersonnelUpdate").click(function () {
        var id = $("#hfPersonnelIdEdit").val();
        var vm =
        {
            Id: id,
            ProcessDate: $("#txtPersonnelEditProcessDate").val(),
            Process: $("#txtPersonnelEditProcess").val(),
            CompanyName: $("#txtPersonnelEditCompanyName").val(),
            PayDate: $("#txtPersonnelEditPayDate").val(),
            Price: $("#txtPersonnelEditPrice").val(),
            Description: $("#txtPersonnelEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Expense/UpdatePersonnel",
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
                        text: 'Personel gideri güncellenemedi. Lütfen tekrar deneyiniz!'
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