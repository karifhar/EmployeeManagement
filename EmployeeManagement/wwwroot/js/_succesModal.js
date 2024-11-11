function SuccesModalHandler(isSuccess) {
    if(isSuccess) {
        $('#modalHeader').removeClass('bg-danger').addClass('bg-success text-white');
        $('#successModalLabel').text('Success');
        $('#modalIconContainer').html('<i class="bi bi-check-circle-fill text-success" style="font-size: 3rem;"></i>');
        $('#modalMessage').text('Your operation was completed successfully!');
        
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