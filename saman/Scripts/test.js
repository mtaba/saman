// JavaScript source code
function searchPerson() {
    var personalCode = $("#Prescription_Person_PesonalCode").val();
   
    if (personalCode.length == 5) {
        $.ajax({
            url: 'GetPerson',
            type: 'Post',
            dataType: 'Json',
            data: { PersonalCode: personalCode },
            success: function (result) {
                if (result.Success) {
                    var data = JSON.parse(result.Html)

                    if (data.length == 1) {

                        $("#Prescription_Person_Name").val(data[0].Name);
                        $("#Prescription_Person_Name").text(data[0].Name);
                        $("#Prescription_Person_LName").val(data[0].LName);
                        $("#Prescription_Person_LName").text(data[0].LName);
                        $("#Prescription_PersonId").val(data[0].CodeMelli);
                        $("#Prescription_PersonId").text(data[0].CodeMelli);
                        //  html = "";
                        //  $("#Personlist").html(html);
                    }
                }
            },
            error: function (result) {

            }
        })
    } // #if(personalCode.length !=0)
}
