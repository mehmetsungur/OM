$(function () {
    $("#btnCompanySave").click(function () {
        var formData = new FormData();
        var file = $("#fuLogo").get(0).files[0];
        formData.append("file", file);

        $.ajax({
            url: "/DashBoard/Customer/UploadCompanyLogo",
            method: "post",
            datatype: "json",
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.Result) {
                    var vm =
                    {
                        Logo: response.Logo,
                        Name: $("#txtCompanyName").val(),
                        City: $("#txtCompanyCity").val(),
                        District: $("#txtCompanyDistrict").val(),
                        Email: $("#txtCompanyEmail").val(),
                        Phone: $("#txtCompanyPhone").val(),
                        State: $("#txtCompanyState").val(),
                        Description: $("#txtCompanyDescription").val()
                    };
                    $.ajax({
                        url: "/DashBoard/Customer/CreateCompany",
                        method: "post",
                        datatype: "json",
                        data: vm,
                        success: function (response) {
                            $("#CreateCompany").hide();
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
                                    html: "Şirket Kaydedilemedi! <br><h5>Tüm Alanları Doldurarak</h5> Tekrar Deneyiniz ..."
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
            },
            error: function () {

            }
        });        
    });

    $("body").on("click", "#imgCompanyEdit", function () {
        var CompanyId = $(this).attr("CompanyId");

        var UpName = $("#spnName").html();
        var UpCity = $("#spnCity").html();
        var UpDistrict = $("#spnDistrict").html();
        var UpEmail = $("#spnEmail").html();
        var UpPhone = $("#spnPhone").html();
        var UpState = $("#spnState").html();
        var UpDescription = $("#spnDescription").html();

        $("#hfCompanyIdEdit").val(CompanyId);
        $("#txtCompanyEditName").val(UpName);
        $("#txtCompanyEditCity").val(UpCity);
        $("#txtCompanyEditDistrict").val(UpDistrict);
        $("#txtCompanyEditEmail").val(UpEmail);
        $("#txtCompanyEditPhone").val(UpPhone);
        $("#txtCompanyEditState").val(UpState);
        $("#txtCompanyEditDescription").val(UpDescription);

        $("#divCompanyEdit").modal('show');
    });

    $("body").on("click", "#imgCompanyDelete", function () {
        var CustomerId = $(this).attr("CustomerId");
        swal({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Şirket kaydı silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#67d630',
            cancelButtonColor: '#d33',
            cancelButtonText: "Hayır, vazgeç!",
            confirmButtonText: 'Evet, Silme işlemine devam edilsin!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: "/DashBoard/Customer/DeleteCompany/" + CustomerId,
                    method: "post",
                    success: function (response) {
                        if (response.Result) {
                            swal({
                                type: 'success',
                                title: 'İşlem Başarılı',
                                text: "Görüşme Başarıyla Silindi"
                            }).then((result) => {
                                window.location.reload();
                            });
                        }
                    }
                });
            }
        })
    });

    $("#btnCompanyUpdate").click(function () {
        var id = $("#hfCompanyIdEdit").val();
        var vm =
        {
            Id: id,
            Name: $("#txtCompanyEditName").val(),
            City: $("#txtCompanyEditCity").val(),
            District: $("#txtCompanyEditDistrict").val(),
            Email: $("#txtCompanyEditEmail").val(),
            Phone: $("#txtCompanyEditPhone").val(),
            State: $("#txtCompanyEditState").val(),
            Description: $("#txtCompanyEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Customer/UpdateCompany",
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
                        text: 'Şirket güncellenemedi. Lütfen tekrar deneyiniz!'
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