$(document).ready(function () {
    logoutHandle(); 
});

function logoutHandle() {
    $('#logoutButton').click(() => {
        $('#logoutModal').modal('show');
    });

    $('#confirmLogout').off('click').on('click', () => {
        $.ajax({
            url: '@Url.Action("Logout", "Account")',
            type: 'POST',
            success: (response) => {
                if(response.success) {
                    window.location.href = response.redirectUrl;
                }
            },
            error: (error) => {
                alert("Failed to sign out. Please try again.");
                console.log(error);
                
            }

        })
    })
}