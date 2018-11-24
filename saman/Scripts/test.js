// JavaScript source code
function searchPerson() {
    var codeMelli = $("#Prescription_PersonId").val();
    if (codeMelli.length == 10) {
        $.ajax({
            url: 'GetPerson',
            type: 'Post',
            dataType: 'Json',
            data: { NationalCode: codeMelli },
            success: function (result) {
                if (result.Success) {
                    var data = JSON.parse(result.Html)

                    if (data.length == 1) {

                        $("#Prescription_Person_Name").val(data[0].Name);
                        $("#Prescription_Person_Name").text(data[0].Name);
                        $("#Prescription_Person_LName").val(data[0].LName);
                        $("#Prescription_Person_LName").text(data[0].LName);
                        $("#Prescription_Person_FatherName").val(data[0].FatherName);
                        $("#Prescription_Person_FatherName").text(data[0].FatherName);
                        //  html = "";
                        //  $("#Personlist").html(html);
                    }
                }
            },
            error: function (result) {

            }
        })
    } // #if(codeMelli.length == 10)
}
