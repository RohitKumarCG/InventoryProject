$(document).ready(function () {
    var apiBaseUrl = "http://localhost:52606/";
    $('#btnGetData').click(function () {
        $.ajax({
            url: apiBaseUrl + "api/rawmaterials",
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                var $table = $('<table />').addClass('dataTable table table-bordered table-striped');
                $table.attr('id', 'table1');
                var $header = $('<thead />').html('<tr><th>ID</th><th>Name</th><th>Code</th><th>Price</th><th>Creation Date</th><th>Last Modified Date</th></tr>');
                $table.append($header);
                var $body = $('<tbody />');
                $table.append($body);
                $.each(data, function (i, val) {
                    var $row = $('<tr />');
                    $row.append($('<td />').html(val.RawMaterialID));
                    $row.append($('<td />').html(val.RawMaterialName));
                    $row.append($('<td />').html(val.RawMaterialCode));
                    $row.append($('<td />').html(val.RawMaterialUnitPrice));
                    $row.append($('<td />').html(val.CreationDateTime));
                    $row.append($('<td />').html(val.LastUpdateDateTime));
                    
                    $body.append($row);
                });
                $('#updatePanel').html($table);
                $('#table1').DataTable();
            },
            error: function () {
                alert('Error!');
            }
        });
    });
});
