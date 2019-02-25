$(function () {
    $("#btnProjectSave").click(function () {
        var vm =
        {
            CompanyName: $("#txtProjectCompanyName").val(),
            Model: $("#txtProjectModel").val(),
            StartDate: $("#txtProjectStartDate").val(),
            EndDate: $("#txtProjectEndDate").val(),
            BillDate: $("#txtProjectBillDate").val(),
            BillNumber: $("#txtProjectBillNumber").val(),
            Price: $("#txtProjectPrice").val(),
            Description: $("#txtProjectDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Customer/CreateProject",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                $("#CreateProject").hide();
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
                        html: "Proje Kaydedilemedi! <br><h5>Tüm Alanları Doldurarak</h5> Tekrar Deneyiniz ..."
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

    $("body").on("click", "#imgProjectEdit", function () {
        var ProjectId = $(this).attr("ProjectId");

        var UpCompanyName = $("#spnCompanyName").html();
        var UpModel = $("#spnModel").html();
        var UpStartDate = $("#spnStartDate").html();
        var UpEndDate = $("#spnEndDate").html();
        var UpBillDate = $("#spnBillDate").html();
        var UpBillNumber = $("#spnBillNumber").html();
        var UpPrice = $("#spnPrice").html();
        var UpDescription = $("#spnDescription").html();
        var UpIsPay = $("span.label").attr("IsPayState");

        $("#hfProjectIdEdit").val(ProjectId);
        $("#txtProjectEditCompanyName").val(UpCompanyName);
        $("#txtProjectEditModel").val(UpModel);
        $("#txtProjectEditStartDate").val(UpStartDate);
        $("#txtProjectEditEndDate").val(UpEndDate);
        $("#txtProjectEditBillDate").val(UpBillDate);
        $("#txtProjectEditBillNumber").val(UpBillNumber);
        $("#txtProjectEditPrice").val(UpPrice);
        $("#txtProjectEditDescription").val(UpDescription);
        UpIsPay == "true" ? $("#rdbTrue").prop("checked", true) : $("#rdbFalse").prop("checked", true);

        $("#divProjectEdit").modal('show');
    });

    $("body").on("click", "#imgProjectDelete", function () {
        var ProjectId = $(this).attr("ProjectId");
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
                    url: "/DashBoard/Customer/DeleteProject/" + ProjectId,
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

    $("#btnProjectUpdate").click(function () {
        var id = $("#hfProjectIdEdit").val();
        var vm =
        {
            Id: id,
            CompanyName: $("#txtProjectEditCompanyName").val(),
            Model: $("#txtProjectEditModel").val(),
            StartDate: $("#txtProjectEditStartDate").val(),
            EndDate: $("#txtProjectEditEndDate").val(),
            BillDate: $("#txtProjectEditBillDate").val(),
            BillNumber: $("#txtProjectEditBillNumber").val(),
            Price: $("#txtProjectEditPrice").val(),
            IsPay: $("#rdbTrue").is(":checked"),
            Description: $("#txtProjectEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Customer/UpdateProject",
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
                        text: 'Proje güncellenemedi. Lütfen tekrar deneyiniz!'
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