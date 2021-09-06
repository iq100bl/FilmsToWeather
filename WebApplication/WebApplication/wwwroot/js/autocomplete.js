 $(function () {
     $("#City-input").autocomplete({
         source: function (request, response) {
             $.ajax({
                 url: '/UserAccount/AutoComplete/',
                 data: {"prefix": request.term},
                 type: "POST",
                 success: function (data) {
                     response($.map(data, function (item) {
                         return item;
                     }))
                 },
                 error: function (response) {
                     alert(response.responseText);
                 },
                 failure: function (response) {
                     alert(response.responseText);
                 }
             });
         },
         select: function (e, i) {
             $("#hfCity").val(i.item.val);
         },
         minLength: 0
     }).focus(function () {
         $(this).autocomplete("search");
     });
 });
