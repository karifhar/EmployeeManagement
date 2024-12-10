
function deleteHandler(id, pathUrl) {
    $('#modalHeader').addClass('bg-danger text-white');

    $('#delete-btn').off('click').on('click', function() {
        $.ajax({
            url: pathUrl,
            type: 'DELETE',
            data: id,
            success: (response) => {
                $('.btn').hide();
                $('#modalHeader').removeClass('bg-danger').addClass('bg-success text-white');
                SuccesModalHandler(response.success);
            },
            error: (response) => {
                $('.btnModal').hide();
                $('#modalIconContainer').html('<i class="bi bi-x-circle-fill text-danger" style="font-size: 3rem;"></i>');
                SuccesModalHandler(false);
            }
        });
    });
}


function SuccesModalHandler(isSuccess) {
    if(isSuccess) {
        // $('#modalHeader').removeClass('bg-danger').addClass('bg-success text-white');
        // $('#successModalLabel').text('Success');
        $('#modalIconContainer').html('<i class="bi bi-check-circle-fill text-success" style="font-size: 3rem;"></i>');
        $('#modalMessage').text('Your operation was completed successfully!');
        
        $('#deleteModal').removeAttr('inert');
        $('#successModal').modal('show');

        setTimeout(()=>{
            $('#successModal').modal('hide');
        }, 3000)
        
    } else {
        $('#modalHeader').removeClass('bg-success').addClass('bg-danger text-white');
        $('#successModalLabel').text('Error');
        $('#modalIconContainer').html('<i class="bi bi-x-circle-fill text-danger" style="font-size: 3rem;"></i>');
        $('#modalMessage').text('An error occurred.');

        $('#successModal').modal('show');

        setTimeout(()=>{
            $('#successModal').modal('hide');
        }, 3000)
    }
}

