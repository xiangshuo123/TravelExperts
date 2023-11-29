<%--
  Created by IntelliJ IDEA.
  User: komal
  Date: 2023-10-26
  Time: 3:55 p.m.
  To change this template use File | Settings | File Templates.
--%>

<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Insert Customer</title>
    <script src="jquery.js"></script>
    <script>
        function buildJSON()
        {
            var data = "{" +
                "'custFirstName': '" + document.getElementById("custFirstName").value + "', " +
                "'custLastName': '" + document.getElementById("custLastName").value + "', " +
                "'custAddress': '" + document.getElementById("custAddress").value + "', " +
                "'custCity': '" + document.getElementById("custCity").value + "', " +
                "'custProv': '" + document.getElementById("custProv").value + "', " +
                "'custPostal': '" + document.getElementById("custPostal").value + "', " +
                "'custCountry': '" + document.getElementById("custCountry").value + "', " +
                "'custHomePhone': '" + document.getElementById("custHomePhone").value + "', " +
                "'custBusPhone': '" + document.getElementById("custBusPhone").value + "', " +
                "'custEmail': '" + document.getElementById("custEmail").value + "', " +
                "'agent': '" + document.getElementById("agentId").value + "'" +
                "}";
            return data;
        }

        function putCustomer()
        {
            var jsonString = buildJSON();
            alert(document.getElementById("custFirstName").value + document.getElementById("custLastName").value)
            $.ajax({
                url: "http://localhost:8080/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/putcustomer",
                method: "PUT",
                data: jsonString,
                accept: "application/json",
                dataType: "json",
                contentType: "application/json"
            }).done(function (data, text, xhr){
                var result = JSON.parse(xhr.responseText);
                $("#message").html(result.message);
            }).fail(function (xhr, text, error){
                $("#message").html(text + " | " + error);
            });
        }
    </script>
</head>
<body>
<form>
    Id: <input id="customerId" type="text" disabled="disabled" /><br />
    First Name: <input id="custFirstName" type="text" /><br />
    Last Name: <input id="custLastName" type="text" /><br />
    Address: <input id="custAddress" type="text" /><br />
    City: <input id="custCity" type="text" /><br />
    Prov: <input id="custProv" type="text" /><br />
    Postal: <input id="custPostal" type="text" /><br />
    Country: <input id="custCountry" type="text" /><br />
    Home Phone: <input id="custHomePhone" type="text" /><br />
    Bus Phone: <input id="custBusPhone" type="text" /><br />
    Email: <input id="custEmail" type="text" /><br />
    Agent Id: <input id="agentId" type="text" /><br />
    <button type="button" id="btnInsert">Insert</button>
</form>
<p id="message">message area</p>
<script>
    $("#btnInsert").click(putCustomer);
</script>
</body>
</html>
