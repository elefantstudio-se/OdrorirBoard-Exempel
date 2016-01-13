$(function () {

    $.ajaxSetup({ cache: false });

    $("a[odrorir-dialogs]").on("click", function (e) {
        //nytt

        // hide dropdown if any
        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');
        $('#deleteContent').load(this.href, function () {
            $('#deleteModal').modal({
                backdrop: true,
                keyboard: true
            }, 'show');
            bindFormDelete(this);
        });
        return false;
    });
});

function bindFormDelete(dialog) {

    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#deleteModal').modal('hide');
                    //Refresh
                    location.reload();
                } else {
                    $('#deleteContent').html(result);
                    bindFormDelete();
                }
            }
        });
        return false;
    });
}