$(function() {
    //Modal Dialog
    $('body').on('click', '.modal-link', function(e) {
        e.preventDefault();
        $(this).attr('data-target', '#modal-container');
        $(this).attr('data-toggle', 'modal');
    });

    //attach listner to .modal-close-btn
    $('body').on('click', '.modal-close-btn', function() {
        $('#modal-container').modal('hide');

    });

    //Clear modal cache. so new shiet can load.
    $('#modal-container').on('hidden.bs.modal', function() {
        $(this).removeData('bs.modal');
    });

});