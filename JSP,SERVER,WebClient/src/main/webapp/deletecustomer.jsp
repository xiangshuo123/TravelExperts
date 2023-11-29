<%--
  Created by IntelliJ IDEA.
  User: hpeters
  Date: 10/10/2023
  Time: 1:52 PM
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Delete Customer</title>
    <script src="jquery.js"></script>
    <script>
        function loadSelectCustomers()
        {
            $.getJSON("http://localhost:8080/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/getallcustomers",
                function (data){
                    var theSelect = document.getElementById("customerselect");
                    for (i=0; i<data.length; i++)
                    {
                        var customer = data[i];
                        var theOption = document.createElement("option");
                        theSelect.appendChild(theOption);
                        theOption.setAttribute("value", customer.customerId);
                        theOption.appendChild(document.createTextNode(customer.custFirstName + " " + customer.custLastName));
                    }
                });
        }

        function getCustomer(customerId)
        {
            $.get("http://localhost:8080/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/getselectcustomer/" + customerId,
                function(data){
                    $("#customerId").val(data.customerId);
                    $("#custFirstName").val(data.custFirstName);
                    $("#custLastName").val(data.custLastName);
                    $("#custAddress").val(data.custAddress);
                    $("#custCity").val(data.custCity);
                    $("#custProv").val(data.custProv);
                    $("#custPostal").val(data.custPostal);
                    $("#custCountry").val(data.custCountry);
                    $("#custHomePhone").val(data.custHomePhone);
                    $("#custBusPhone").val(data.custBusPhone);
                    $("#custEmail").val(data.custEmail);
                    $("#agentId").val(data.agent);
                });
        }

        function deleteCustomer()
        {
            var customerId = ($("#customerId").val());
            $.ajax({
                url: "http://localhost:8080/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/deletecustomer/" + customerId,
                method: "DELETE",
                config: { headers:{
                        "Access-Control-Allow-Headers": "Origin, Content-Type, Accept, Authorization",
                        "Access-Control-Allow-Origin": "*"
                    }
                },
                "crossDomain":true,
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
<select id="customerselect" onchange="getCustomer(this.value)">
    <option value="">Select a customer to delete</option>
</select>
<form>
    Id: <input id="customerId" type="text" disabled="disabled" /><br />
    First Name: <input id="custFirstName" type="text" disabled="disabled" /><br />
    Last Name: <input id="custLastName" type="text" disabled="disabled" /><br />
    Address: <input id="custAddress" type="text" disabled="disabled" /><br />
    City: <input id="custCity" type="text" disabled="disabled" /><br />
    Prov: <input id="custProv" type="text" disabled="disabled" /><br />
    Postal: <input id="custPostal" type="text" disabled="disabled" /><br />
    Country: <input id="custCountry" type="text" disabled="disabled" /><br />
    Home Phone: <input id="custHomePhone" type="text" disabled="disabled" /><br />
    Bus Phone: <input id="custBusPhone" type="text" disabled="disabled" /><br />
    Email: <input id="custEmail" type="text" disabled="disabled" /><br />
    Agent Id: <input id="agentId" type="text" disabled="disabled" /><br />
    <button type="button" id="btnDelete">Delete</button>
</form>
<p id="message">message area</p>
<script>
    $(document).ready(loadSelectCustomers);
    $("#btnDelete").click(deleteCustomer);
</script>
</body>
</html>

