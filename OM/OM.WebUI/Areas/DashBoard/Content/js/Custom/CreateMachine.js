$(function () {
    $("#btnMachineSave").click(function () {
        var vm =
        {
            ProcessDate: $("#txtMachineProcessDate").val(),
            Process: $("#txtMachineProcess").val(),
            CompanyName: $("#txtMachineCompanyName").val(),
            PayDate: $("#txtMachinePayDate").val(),
            Price: $("#txtMachinePrice").val(),
            Description: $("#txtMachineDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Expense/CreateMachine",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                $("#CreateMachine").hide();
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

    $("body").on("click", "#imgMachineEdit", function () {
        var MachineId = $(this).attr("MachineId");
        var tr = $(this).parent("td").parent("tr");

        var UpProcessDate = tr.find("#spnProcessDate").html();
        var UpProcess = tr.find("#spnProcess").html();
        var UpCompanyName = tr.find("#spnCompanyName").html();
        var UpPayDate = tr.find("#spnPayDate").html();
        var UpPrice = tr.find("#spnPrice").html();
        var UpDescription = tr.find("#spnDescription").html();

        $("#hfMachineIdEdit").val(MachineId);
        $("#txtMachineEditProcessDate").val(UpProcessDate);
        $("#txtMachineEditProcess").val(UpProcess);
        $("#txtMachineEditCompanyName").val(UpCompanyName);
        $("#txtMachineEditPayDate").val(UpPayDate);
        $("#txtMachineEditPrice").val(UpPrice);
        $("#txtMachineEditDescription").val(UpDescription);

        $("#divMachineEdit").modal('show');
    });

    $("body").on("click", "#imgMachineDelete", function () {
        var MachineId = $(this).attr("MachineId");
        swal({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Makina gider kaydı silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#67d630',
            cancelButtonColor: '#d33',
            cancelButtonText: "Hayır, vazgeç!",
            confirmButtonText: 'Evet, Silme işlemine devam edilsin!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: "/DashBoard/Expense/DeleteMachine/" + MachineId,
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

    $("#btnMachineUpdate").click(function () {
        var id = $("#hfMachineIdEdit").val();
        var vm =
        {
            Id: id,
            ProcessDate: $("#txtMachineEditProcessDate").val(),
            Process: $("#txtMachineEditProcess").val(),
            CompanyName: $("#txtMachineEditCompanyName").val(),
            PayDate: $("#txtMachineEditPayDate").val(),
            Price: $("#txtMachineEditPrice").val(),
            Description: $("#txtMachineEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Expense/UpdateMachine",
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
                        text: 'Makina gideri güncellenemedi. Lütfen tekrar deneyiniz!'
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