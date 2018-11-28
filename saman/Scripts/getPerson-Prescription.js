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
                    $("#Person_Name").val(data.Name);
                    $("#Person_Name").text(data.Name);
                    $("#Person_Family").val(data.LName);
                    $("#Person_Family").text(data.LName);
                    $("#Person_CodeMelli").val(data.CodeMelli);
                    $("#Person_CodeMelli").text(data.CodeMelli);
                }
            },
            error: function (result) {
                console.log(result.error)

            }
        })
    } 
}
