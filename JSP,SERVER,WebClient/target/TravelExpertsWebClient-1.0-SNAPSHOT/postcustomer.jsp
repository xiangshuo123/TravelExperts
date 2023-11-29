<%--
  Created by IntelliJ IDEA.
  User: komal
  Date: 2023-10-24
  Time: 3:02 p.m.
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Update Customer </title>
    <script src="jquery.js"></script>
    <script>
        function loadSelectCustomers()
        {
            //load customers, getJSON will let us specify the URL
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
                    document.getElementById("customerId").value = data.customerId;
                    document.getElementById("custFirstName").value = data.custFirstName;
                    document.getElementById("custLastName").value = data.custLastName;
                    document.getElementById("custAddress").value = data.custAddress;
                    document.getElementById("custCity").value = data.custCity;
                    document.getElementById("custProv").value = data.custProv;
                    document.getElementById("custPostal").value = data.custPostal;
                    document.getElementById("custCountry").value = data.custCountry;
                    document.getElementById("custHomePhone").value = data.custHomePhone;
                    document.getElementById("custBusPhone").value = data.custBusPhone;
                    document.getElementById("custEmail").value = data.custEmail;
                    document.getElementById("agentId").value = data.agent;
                });
        }

        function buildJSON()
        {
            var data = "{" +
                "\"customerId\": \"" + document.getElementById("customerId").value + "\", " +
                "\"custFirstName\": \"" + document.getElementById("custFirstName").value + "\", " +
                "\"custLastName\": \"" + document.getElementById("custLastName").value + "\", " +
                "\"custAddress\": \"" + document.getElementById("custAddress").value + "\", " +
                "\"custCity\": \"" + document.getElementById("custCity").value + "\", " +
                "\"custProv\": \"" + document.getElementById("custProv").value + "\", " +
                "\"custPostal\": \"" + document.getElementById("custPostal").value + "\", " +
                "\"custCountry\": \"" + document.getElementById("custCountry").value + "\", " +
                "\"custHomePhone\": \"" + document.getElementById("custHomePhone").value + "\", " +
                "\"custBusPhone\": \"" + document.getElementById("custBusPhone").value + "\", " +
                "\"custEmail\": \"" + document.getElementById("custEmail").value + "\", " +
                "\"agent\": \"" + document.getElementById("agentId").value + "\"" +
                "}";
            return data;
        }

        function postCustomer()
        {
            var jsonString = buildJSON();
            $.ajax({
                url: "http://localhost:8080/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/postcustomer",
                method: "post",
                data: jsonString,
                accept: "application/json",
                dataType: "json",
                contentType: "application/json",
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
    <option value="">Select a customer to edit</option>
</select>
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
    <button type="button" id="btnUpdate">Update</button>
</form>
<p id="message">message area</p>
<script>
    $(document).ready(loadSelectCustomers);
    $("#btnUpdate").click(postCustomer);
</script>
</body>
</html>
