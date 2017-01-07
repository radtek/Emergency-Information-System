$(document).ready(function () {
    //==模态框==
    //操作对象添加类"btn-show-modal"
    $(".btn-show-modal").click(function (event) {
        eisShowModal();
    });

    //==弹出式提示框==
    $(function () {
        $("[data-toggle='tooltip']").tooltip();
    });

    //==设置指定时间控件值为当前时间==
    //操作对象添加类"btn-set-time-now"；添加自定义特性"data-for-set-time-now"，值为指定时间控件的ID。
    $(".btn-set-time-now").click(function (event) {
        eisShowModal();

        setTimeNow($(this).data("forSetTimeNow"));

        eisHideModal();
    });
});





function eisShowModal() {
    $('#ModalMain').modal({
        backdrop: 'static'
    });
}

function eisHideModal() {
    $('#ModalMain').modal('hide');
}

//设置指定ID的元素的值为当前时间
function setTimeNow(id) {
    var date = new Date();

    var year = date.getFullYear();
    var month = (date.getMonth() + 1) < 10 ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1);
    var day = date.getDate() < 10 ? '0' + date.getDate() : date.getDate();
    var hour = date.getHours() < 10 ? '0' + date.getHours() : date.getHours();
    var minute = date.getMinutes() < 10 ? '0' + date.getMinutes() : date.getMinutes();

    var str = year + '-' + month + '-' + day + 'T' + hour + ':' + minute;

    document.getElementById(id).value = str;
}

//检测日期合法性-不能运作
function checkDateFormat(str) {
    var reg = /^(\d+)-(\d{ 1,2})-(\d{ 1,2})T(\d{ 1,2}):(\d{1,2})$/;
    var r = str.match(reg);
    if (r == null) {
        return false;
    }
    else {
        r[2] = r[2] - 1;
        var d = new Date(r[1], r[2], r[3], r[4], r[5], r[6]);
        if (d.getFullYear() != r[1]) return false;
        if (d.getMonth() != r[2]) return false;
        if (d.getDate() != r[3]) return false;
        if (d.getHours() != r[4]) return false;
        if (d.getMinutes() != r[5]) return false;
        //if (d.getSeconds() != r[6]) return false;
        return true;
    }
}

//在变化时通过JSON处理
function eisOnchangeUseJson(targetUrl, changingElementId, resultFunction) {
    $.ajax({
        url: targetUrl,
        type: "POST",
        dataType: "json",
        data: {
            id: $('#' + changingElementId).val()
        },
        //success: function (data) {
        //    if (data.result == true) {
        //        resultFunction(true);
        //    }
        //    else {
        //        resultFunction(false);
        //    };
        success: function (data) {
            resultFunction(data);
        }
    });
}