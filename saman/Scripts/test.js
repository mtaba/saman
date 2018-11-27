// JavaScript source code
function searchPerson() {
    var personalCode = $("#Person_PersonalCode").val();
   
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

                        $("#Person_Name").val(data[0].Name);
                        $("#Person_Name").text(data[0].Name);
                        $("#Person_Family").val(data[0].LName);
                        $("#Person_Family").text(data[0].LName);
                        $("#Person_CodeMelli").val(data[0].CodeMelli);
                        $("#Person_CodeMelli").text(data[0].CodeMelli);
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
