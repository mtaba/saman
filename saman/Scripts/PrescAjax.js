       $(document).ready(function () {

           $('#datatab tfoot th').each(function () {
               $(this).html('<input type="text" />');
           });

           var oTable = $('#datatab').DataTable({
               "serverSide": true,
               "ajax": {
                   "type": "GET",
                   "url": '/Prescriptions/DataHandler/',
                   "contentType": 'application/json; charset=utf-8',
                   'data': function (data) {
                       return data = JSON.stringify(data);
                   }
               },
               "dom": 'frtiS',
               "scrollY": 500,
               "scrollX": false,
               "scrollCollapse": false,
               "scroller": {
                   loadingIndicator: false
               },
               "processing": false,
               "paging": true,
               "deferRender": false,
               "columns": [
              { "data": "PersonId" }
             
               ],
               "order": [0, "asc"]

           });

           oTable.columns().every(function () {
               var that = this;

               $('input', this.footer()).on('keyup change', function () {
                   that
                       .search(this.value)
                       .draw();
               });
           });

       });

