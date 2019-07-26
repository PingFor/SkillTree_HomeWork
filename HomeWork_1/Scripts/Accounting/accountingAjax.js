function saveSuccess(data) {
    alert(data);
    reflash(data);    
}

function saveFail() {
    alert("Fail");
}

function reflash(ob) {
    if (ob == "Success") {
        $("#Amount").val("");
        $("#Type").val("");
        $("#Date").val("");
        $("#Remark").val("");
        $.ajax({
            type: "Get",
            url: "/Home/AccountingDetailView",
            success: function (result) {
                $("#AccountingDetail").html(result);
            }
        });
    }
}