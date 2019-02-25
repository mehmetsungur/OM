$(function () {
    $("#btnMeetSave").click(function () {
        var vm =
        {
            CompanyName: $("#txtMeetCompanyName").val(),
            Contact: $("#txtMeetContact").val(),
            Caption: $("#txtMeetCaption").val(),
            Type: $("#txtMeetType").val(),
            City: $("#txtMeetCity").val(),
            District: $("#txtMeetDistrict").val(),
            Email: $("#txtMeetEmail").val(),
            Phone: $("#txtMeetPhone").val(),
            Description: $("#txtMeetDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Customer/CreateMeet",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                $("#CreateMeet").hide();
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
                        html: "Görüşme Kaydedilemedi! <br><h5>Tüm Alanları Doldurarak</h5> Tekrar Deneyiniz ..."
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

    $("body").on("click", "#imgMeetEdit", function () {
        var MeetId = $(this).attr("MeetId");
        var tr = $(this).parent("td").parent("tr");

        var UpCompanyName = tr.find("#spnCompanyName").html();
        var UpContact = tr.find("#spnContact").html();
        var UpCaption = tr.find("#spnCaption").html();
        var UpType = tr.find("#spnType").html();
        var UpCity = tr.find("#spnCity").html();
        var UpDistrict = tr.find("#spnDistrict").html();
        var UpEmail = tr.find("#spnEmail").html();
        var UpPhone = tr.find("#spnPhone").html();
        var UpDescription = tr.find("#spnDescription").html();

        $("#hfMeetIdEdit").val(MeetId);
        $("#txtMeetEditCompanyName").val(UpCompanyName);
        $("#txtMeetEditContact").val(UpContact);
        $("#txtMeetEditCaption").val(UpCaption);
        $("#txtMeetEditType").val(UpType);
        $("#txtMeetEditCity").val(UpCity);
        $("#txtMeetEditDistrict").val(UpDistrict);
        $("#txtMeetEditEmail").val(UpEmail);
        $("#txtMeetEditPhone").val(UpPhone);
        $("#txtMeetEditDescription").val(UpDescription);

        $("#divMeetEdit").modal('show');
    });

    $("body").on("click", "#imgMeetDelete", function () {
        var MeetId = $(this).attr("MeetId");
        swal({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Müşteri görşme kaydı silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#67d630',
            cancelButtonColor: '#d33',
            cancelButtonText: "Hayır, vazgeç!",
            confirmButtonText: 'Evet, Silme işlemine devam edilsin!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: "/DashBoard/Customer/DeleteMeet/" + MeetId,
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

    $("#btnMeetUpdate").click(function () {
        var id = $("#hfMeetIdEdit").val();
        var vm =
        {
            Id: id,
            CompanyName: $("#txtMeetEditCompanyName").val(),
            Contact: $("#txtMeetEditContact").val(),
            Caption: $("#txtMeetEditCaption").val(),
            Type: $("#txtMeetEditType").val(),
            City: $("#txtMeetEditCity").val(),
            District: $("#txtMeetEditDistrict").val(),
            Email: $("#txtMeetEditEmail").val(),
            Phone: $("#txtMeetEditPhone").val(),
            Description: $("#txtMeetEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Customer/UpdateMeet",
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
                        text: 'Görüşme güncellenemedi. Lütfen tekrar deneyiniz!'
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