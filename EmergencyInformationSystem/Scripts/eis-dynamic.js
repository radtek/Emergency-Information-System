$(document).ready(function () {
    //==动态组==
    $(function () {
        //“进入抢救室方式”改变
        eisOnchangeForInRescueRoomWayId();
        $("#InRescueRoomWayId").on("change", function () {
            eisOnchangeForInRescueRoomWayId();
        });
        //“进入留观室方式”改变
        eisOnchangeForInObserveRoomWayId();
        $("#InObserveRoomWayId").on("change", function () {
            eisOnchangeForInObserveRoomWayId();
        });
        //“绿色通道类型”改变
        eisOnchangeForGreenPathCategoryId();
        $("#GreenPathCategoryId").on("change", function () {
            eisOnchangeForGreenPathCategoryId();
        });
        //“预约首选科室”改变
        eisOnchangeForDestinationFirstId();
        $("#DestinationFirstId").on("change", function () {
            eisOnchangeForDestinationFirstId();
        });
        //“去向”改变
        eisOnchangeForDestinationId();
        $("#DestinationId").on("change", function () {
            eisOnchangeForDestinationId();
        });
    });
});





//=“进入抢救室方式”“InRescueRoomWayId”改变=
function eisOnchangeForInRescueRoomWayId() {
    eisOnchangeUseJson($("#InRescueRoomWayId").data("urlAction"), "InRescueRoomWayId", eisCheckInRescueRoomWay);
};
function eisCheckInRescueRoomWay(result) {
    if (result == null) {
    }
    else {
        //影响“InRescueRoomWayRemarks”
        if (result.IsHasAdditionalInfo) {
            $("#DivInRescueRoomWayRemarks").show(10, null);
            $("#InRescueRoomWayRemarks").removeAttr("disabled");
        }
        else {
            $("#DivInRescueRoomWayRemarks").hide(10, null);
            $("#InRescueRoomWayRemarks").attr("disabled", "disabled");
        }
    }
}

//=“进入留观室方式”“InObserveRoomWayId”改变=
function eisOnchangeForInObserveRoomWayId() {
    eisOnchangeUseJson($("#InObserveRoomWayId").data("urlAction"), "InObserveRoomWayId", eisCheckInObserveRoomWay);
};
function eisCheckInObserveRoomWay(result) {
    if (result == null) {
    }
    else {
        //影响“InObserveRoomWayRemarks”
        if (result.IsHasAdditionalInfo) {
            $("#DivInObserveRoomWayRemarks").show(10, null);
            $("#InObserveRoomWayRemarks").removeAttr("disabled");
        }
        else {
            $("#DivInObserveRoomWayRemarks").hide(10, null);
            $("#InObserveRoomWayRemarks").attr("disabled", "disabled");
        }
    }
}

//==“绿色通道类型”“GreenPathCategoryId”改变=
function eisOnchangeForGreenPathCategoryId() {
    eisOnchangeUseJson($("#GreenPathCategoryId").data("urlAction"), "GreenPathCategoryId", eisCheckGreenPathCategory)
}
function eisCheckGreenPathCategory(result) {
    if (result == null) {
    }
    else {
        //影响“GreenPathCategoryRemarks”
        if (result.IsHasAdditionalInfo) {
            $("#DivGreenPathCategoryRemarks").show(10, null);
            $("#GreenPathCategoryRemarks").removeAttr("disabled");
        }
        else {
            $("#DivGreenPathCategoryRemarks").hide(10, null);
            $("#GreenPathCategoryRemarks").attr("disabled", "disabled");
        }
    }
}

//=“预约首选科室”“DestinationFirstId”改变=
function eisOnchangeForDestinationFirstId() {
    eisOnchangeUseJson($("#DestinationFirstId").data("urlAction"), "DestinationFirstId", eisCheckDestinationFirst)
};
function eisCheckDestinationFirst(result) {
    if (result == null) {
    }
    else {
        //影响“DestinationFirstTime”、“DestinationFirstContact”、“DestinationSecondId”
        if (result.IsUseForEmpty) {
            $("#DivDestinationFirstTime").hide(10, null);
            $("#DivDestinationFirstContact").hide(10, null);
            $("#DivDestinationSecondId").hide(10, null);

            $("#DestinationFirstTime").attr("disabled", "disabled");
            $("#DestinationFirstContact").attr("disabled", "disabled");
            $("#DestinationSecondId").val($("#DestinationFirstId").val().toString()); //模型中此ID不可为空
        }
        else {
            $("#DivDestinationFirstTime").show(10, null);
            $("#DivDestinationFirstContact").show(10, null);
            $("#DivDestinationSecondId").show(10, null);

            $("#DestinationFirstTime").removeAttr("disabled");
            $("#DestinationFirstContact").removeAttr("disabled");
        }
    }
}

//=“去向”“DestinationId”改变=
function eisOnchangeForDestinationId() {
    eisOnchangeUseJson($("#DestinationId").data("urlAction"), "DestinationId", eisCheckDestination);
}
function eisCheckDestination(result) {
    if (result == null) {
    }
    else {
        //影响“DestinationRemarks”
        if (result.IsHasAdditionalInfo) {
            $("#DivDestinationRemarks").show(10, null);
            $("#DestinationRemarks").removeAttr("disabled");
        }
        else {
            $("#DivDestinationRemarks").hide(10, null);
            $("#DestinationRemarks").attr("disabled", "disabled");
        }

        //影响“OutDepartmentTime”、“HandleNurse”、“DiagnosisName”
        if (result.IsUseForEmpty) {
            $("#DivOutDepartmentTime").hide(10, null);
            $("#DivHandleNurse").hide(10, null);
            $("#DivDiagnosisName").hide(10, null);

            $("#OutDepartmentTime").attr("disabled", "disabled");
            $("#HandleNurse").attr("disabled", "disabled");
            $("#DiagnosisName").attr("disabled", "disabled");
        }
        else {
            $("#DivOutDepartmentTime").show(10, null);
            $("#DivHandleNurse").show(10, null);
            $("#DivDiagnosisName").show(10, null);

            $("#OutDepartmentTime").removeAttr("disabled");
            $("#HandleNurse").removeAttr("disabled");
            $("#DiagnosisName").removeAttr("disabled");
        }

        //影响“TransferReasonId”、“TransferTarget”
        if (result.IsTransfer) {
            $("#DivTransferReasonId").show(10, null);
            $("#DivTransferTarget").show(10, null);

            $("#TransferReasonId").removeAttr("disabled");
            $("#TransferTarget").removeAttr("disabled");
        }
        else {
            $("#DivTransferReasonId").hide(10, null);
            $("#DivTransferTarget").hide(10, null);

            $("#TransferReasonId").attr("disabled", "disabled");
            $("#TransferTarget").attr("disabled", "disabled");
        }

        //影响“TransferReasonId”、“ProfessionalTarget”
        if (result.IsProfessional) {
            $("#DivProfessionalTarget").show(10, null);

            $("#ProfessionalTarget").removeAttr("disabled");
        }
        else {
            $("#DivProfessionalTarget").hide(10, null);

            $("#ProfessionalTarget").attr("disabled", "disabled");
        }
    }
}