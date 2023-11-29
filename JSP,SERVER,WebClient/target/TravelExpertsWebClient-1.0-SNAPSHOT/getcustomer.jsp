<%--
  Created by IntelliJ IDEA.
  User: komal
  Date: 2023-10-23
  Time: 12:38 a.m.
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Customer List</title>
    <script src="jquery.js"></script>
    <script>
        function loadCustomers()
        {
          //load customers, getJSON will let us specify the URL
            $.getJSON("http://localhost:8080/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/getallcustomers",
            function (data){
                //get reference to our table
                var theTable = document.getElementById("myTable");
                for (i=0; i<data.length; i++)
                {
                    var customer = data[i];
                    //create a row
                    var theRow = document.createElement("tr");
                    theTable.appendChild(theRow);  // append row to the table
                        var array= []
                    for (var [key, value] of Object.entries(customer)) {
                        array.push(value);
                    }
                    for (j=0; j<array.length; j++){
                        var theCell = document.createElement("td");
                        theRow.appendChild(theCell); // append the cell onto the Row
                        theCell.appendChild(document.createTextNode(array[j]));
                    }
                }
            });
        }
    </script>
</head>
<body>
    <h1>Customer List</h1>
    <table id="myTable">

    </table>
    <script>
        $(document).ready(loadCustomers);
    </script>
</body>
</html>
