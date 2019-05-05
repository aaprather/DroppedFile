function setUploadButtonState() {

    var maxFileSize = 31457280; // 30MB -> 30 * 1024 * 1024
    var fileUpload = $('#FileUpload1');

    if (fileUpload.val() === '') {
        return false;
    }
    else {
        if (fileUpload[0].files[0].size < maxFileSize) {
            $('#uploadButton').prop('disabled', false);
            $('#uploadButton').show();
            $('#Label10').text('');
            return true;
        } else {
            $('#Label10').text('File is larger than 30MB!');
            $('#uploadButton').prop('disabled', true);
            $('#uploadButton').hide();
            return false;
        }
    }
}
