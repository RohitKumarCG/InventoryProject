
<script>
    $(document).ready(function () {
        $(function () {
            $('#createButton').attr('disabled', 'disabled');
        });

        $('input[type=text],input[type=text],input[type=text]').keyup(function () {
            if ($('.rawMaterialName').val().length > 2 && $('.rawMaterialCode').val().length > 2 && $('.rawMaterialPrice').val() != '') {
                $('#createButton').removeAttr('disabled');
            }
            else {
                $('#createButton').attr('disabled', 'disabled');
            }
        });
    });
</script>
