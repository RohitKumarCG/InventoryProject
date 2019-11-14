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
                var $header = $('<thead />').html('<tr><th>ID</th><th>Name</th><th>Code</th><th>Price(INR)</th><th>Action</th></tr>');
                $table.append($header);
                var $body = $('<tbody />');
                $table.append($body);
                $.each(data, function (i, val) {
                    var $button = $('<button onClick="deleteRM(this)">Delete</button>').addClass('btn btn-danger');
                    var $row = $('<tr />');   
                    $row.append($('<td />').html(val.RawMaterialID));
                    $row.append($('<td />').html(val.RawMaterialName));
                    $row.append($('<td />').html(val.RawMaterialCode));
                    $row.append($('<td />').html(val.RawMaterialUnitPrice));
                    $row.append($('<td />').html($button));
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


//delete function
function deleteRM(rm)
{
    confirm("Are You Sure?");
    var rawmaterial = new Object();
    var rmid = $(rm).closest("tr").find("td:eq(0)").text();
    rawmaterial.RawMaterialID = rmid;
    $.ajax({
        url: "api/rawmaterials",
        type: 'DELETE',
        data: rawmaterial,
        success: function (data) {
            if (data == true)
            {
                alert("Deleted!");
                location.reload();

            }
            else
                alert("Deletion Failed!");
        },
        error: function () {
            alert('Error!');
        }
    });
}
