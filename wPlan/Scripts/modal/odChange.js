$(function () {

    $.ajaxSetup({ cache: false });

    $("a[odrorir-dialogs]").on("click", function (e) {
        //nytt

        // hide dropdown if any
        $(e.target).closest('.btn-group').children('.dropdown-toggle').dropdown('toggle');
        $('#detailsContent').load(this.href, function () {
            $('#detailsModal').modal({
                backdrop: true,
                keyboard: true
            }, 'show');
            bindFormDetails(this);
        });
        return false;
    });
});

function bindFormDetails(dialog) {

    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#detailsModal').modal('hide');
                    //Refresh
                    location.reload();
                } else {
                    $('#detailsContent').html(result);
                    bindFormDetails();
                }
            }
        });
        return false;
    });
}