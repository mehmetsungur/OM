$(function () {
    $("#btnCustomerSave").click(function () {
        var vm =
        {
            CompanyName: $("#txtCustomerCompanyName").val(),
            Contact: $("#txtCustomerContact").val(),
            Caption: $("#txtCustomerCaption").val(),
            City: $("#txtCustomerCity").val(),
            District: $("#txtCustomerDistrict").val(),
            Email: $("#txtCustomerEmail").val(),
            Phone: $("#txtCustomerPhone").val(),
            Description: $("#txtCustomerDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Customer/CreateCustomer",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                $("#CreateCustomer").hide();
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
                        html: "Müşteri Kaydedilemedi! <br><h5>Tüm Alanları Doldurarak</h5> Tekrar Deneyiniz ..."
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

    $("body").on("click", "#imgCustomerEdit", function () {
        var CustomerId = $(this).attr("CustomerId");
        var tr = $(this).parent("td").parent("tr");

        var UpCompanyName = tr.find("#spnCompanyName").html();
        var UpContact = tr.find("#spnContact").html();
        var UpCaption = tr.find("#spnCaption").html();
        var UpCity = tr.find("#spnCity").html();
        var UpDistrict = tr.find("#spnDistrict").html();
        var UpEmail = tr.find("#spnEmail").html();
        var UpPhone = tr.find("#spnPhone").html();
        var UpDescription = tr.find("#spnDescription").html();

        $("#hfCustomerIdEdit").val(CustomerId);
        $("#txtCustomerEditCompanyName").val(UpCompanyName);
        $("#txtCustomerEditContact").val(UpContact);
        $("#txtCustomerEditCaption").val(UpCaption);
        $("#txtCustomerEditCity").val(UpCity);
        $("#txtCustomerEditDistrict").val(UpDistrict);
        $("#txtCustomerEditEmail").val(UpEmail);
        $("#txtCustomerEditPhone").val(UpPhone);
        $("#txtCustomerEditDescription").val(UpDescription);

        $("#divCustomerEdit").modal('show');
    });

    $("body").on("click", "#imgCustomerDelete", function () {
        var CustomerId = $(this).attr("CustomerId");
        swal({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Müşteri kaydı silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#67d630',
            cancelButtonColor: '#d33',
            cancelButtonText: "Hayır, vazgeç!",
            confirmButtonText: 'Evet, Silme işlemine devam edilsin!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: "/DashBoard/Customer/DeleteCustomer/" + CustomerId,
                    method: "post",
                    success: function (response) {
                        if (response.Result) {
                            swal({
                                type: 'success',
                                title: 'İşlem Başarılı',
                                text: "Müşteri Başarıyla Silindi"
                            }).then((result) => {
                                window.location.reload();
                            });
                        }
                    }
                });
            }
        })
    });

    $("#btnCustomerUpdate").click(function () {
        var id = $("#hfCustomerIdEdit").val();
        var vm =
        {
            Id: id,
            CompanyName: $("#txtCustomerEditCompanyName").val(),
            Contact: $("#txtCustomerEditContact").val(),
            Caption: $("#txtCustomerEditCaption").val(),
            City: $("#txtCustomerEditCity").val(),
            District: $("#txtCustomerEditDistrict").val(),
            Email: $("#txtCustomerEditEmail").val(),
            Phone: $("#txtCustomerEditPhone").val(),
            Description: $("#txtCustomerEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Customer/UpdateCustomer",
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
                        text: 'Müşteri güncellenemedi. Lütfen tekrar deneyiniz!'
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