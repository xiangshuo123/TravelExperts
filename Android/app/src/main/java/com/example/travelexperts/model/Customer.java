package com.example.travelexperts.model;

import com.google.gson.annotations.SerializedName;

public class Customer {
    @SerializedName("customerId")
    private int CustomerId;
    @SerializedName("custFirstName")
    private String CustFirstName;
    @SerializedName("custLastName")
    private String CustLastName;
    @SerializedName("custAddress")
    private String CustAddress;
    @SerializedName("custCity")
    private String CustCity;
    @SerializedName("custProv")
    private String CustProv;
    @SerializedName("custPostal")
    private String CustPostal;
    @SerializedName("custCountry")
    private String CustCountry;
    @SerializedName("custHomePhone")
    private String CustHomePhone;
    @SerializedName("custBusPhone")
    private String CustBusPhone;
    @SerializedName("custEmail")
    private String CustEmail;
    @SerializedName("agent")
    private int AgentId;

    public Customer(int customerId, String custFirstName, String custLastName, String custAddress, String custCity, String custProv, String custPostal, String custCountry, String custHomePhone, String custBusPhone, String custEmail, int agentId) {
        CustomerId = customerId;
        CustFirstName = custFirstName;
        CustLastName = custLastName;
        CustAddress = custAddress;
        CustCity = custCity;
        CustProv = custProv;
        CustPostal = custPostal;
        CustCountry = custCountry;
        CustHomePhone = custHomePhone;
        CustBusPhone = custBusPhone;
        CustEmail = custEmail;
        AgentId = agentId;
    }
    public Customer(Customer originalCustomer){
        this.CustomerId = originalCustomer.CustomerId;
        this.CustFirstName = originalCustomer.CustFirstName;
        this.CustLastName = originalCustomer.CustLastName;
        this.CustAddress = originalCustomer.CustAddress;
        this.CustCity = originalCustomer.CustCity;
        this.CustProv = originalCustomer.CustProv;
        this.CustPostal = originalCustomer.CustPostal;
        this.CustCountry = originalCustomer.CustCountry;
        this.CustHomePhone = originalCustomer.CustHomePhone;
        this.CustBusPhone = originalCustomer.CustBusPhone;
        this.CustEmail = originalCustomer.CustEmail;
        this.AgentId = originalCustomer.AgentId;
    }


    public int getCustomerId() {
        return CustomerId;
    }

    public void setCustomerId(int customerId) {
        CustomerId = customerId;
    }

    public String getCustFirstName() {
        return CustFirstName;
    }

    public void setCustFirstName(String custFirstName) {
        CustFirstName = custFirstName;
    }

    public String getCustLastName() {
        return CustLastName;
    }

    public void setCustLastName(String custLastName) {
        CustLastName = custLastName;
    }

    public String getCustAddress() {
        return CustAddress;
    }

    public void setCustAddress(String custAddress) {
        CustAddress = custAddress;
    }

    public String getCustCity() {
        return CustCity;
    }

    public void setCustCity(String custCity) {
        CustCity = custCity;
    }

    public String getCustProv() {
        return CustProv;
    }

    public void setCustProv(String custProv) {
        CustProv = custProv;
    }

    public String getCustPostal() {
        return CustPostal;
    }

    public void setCustPostal(String custPostal) {
        CustPostal = custPostal;
    }

    public String getCustCountry() {
        return CustCountry;
    }

    public void setCustCountry(String custCountry) {
        CustCountry = custCountry;
    }

    public String getCustHomePhone() {
        return CustHomePhone;
    }

    public void setCustHomePhone(String custHomePhone) {
        CustHomePhone = custHomePhone;
    }

    public String getCustBusPhone() {
        return CustBusPhone;
    }

    public void setCustBusPhone(String custBusPhone) {
        CustBusPhone = custBusPhone;
    }

    public String getCustEmail() {
        return CustEmail;
    }

    public void setCustEmail(String custEmaill) {
        CustEmail = custEmaill;
    }

    public int getAgentId() {
        return AgentId;
    }

    public void setAgentId(int agentId) {
        AgentId = agentId;
    }

}
