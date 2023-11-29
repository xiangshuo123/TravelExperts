package com.example.travelexperts.api;
import com.example.travelexperts.model.Agency;
import com.example.travelexperts.model.Agent;

import com.example.travelexperts.model.Booking;
import com.example.travelexperts.model.Customer;
import com.example.travelexperts.model.Package;
import com.example.travelexperts.model.TripType;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.DELETE;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.PUT;
import retrofit2.http.Path;

import java.util.List;

public interface ApiService {
    @GET("/TravelExpertsWebService-1.0-SNAPSHOT/api/agent/getallagents")
    Call<List<Agent>> getAgentDetails();

    // Get all customers
    @GET("/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/getallcustomers")
    Call<List<Customer>> getAllCustomers();

    // Create (POST) a new customer
    @POST("/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/postcustomer")
    Call<Void> postCustomer(@Body Customer customer);

    // Update (PUT) an existing customer
    // Note: It appears the customer ID is not in the URL or body for PUT.
    // Adjust as needed if this isn't correct.
    @PUT("/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/putcustomer")
    Call<Void> putCustomer(@Body Customer customer);

    // Delete a customer
    @DELETE("/TravelExpertsWebService-1.0-SNAPSHOT/api/customer/deletecustomer/{customerId}")
    Call<Void> deleteCustomer(@Path("customerId") int customerId);


    //-------------------------------------------------Agents------------------------------------------
    @GET("/TravelExpertsWebService-1.0-SNAPSHOT/api/agent/getallagents")
    Call<List<Agent>> getAgents();

    @POST("/TravelExpertsWebService-1.0-SNAPSHOT/api/agent/postagent")
    Call<Void> postAgent(@Body Agent agent);

    @DELETE("/TravelExpertsWebService-1.0-SNAPSHOT/api/agent/deleteagent/{id}")
    Call<Void> deleteAgent(@Path("id") int agentId);

    @GET("/TravelExpertsWebService-1.0-SNAPSHOT/api/agency/getallagencies")
    Call<List<Agency>> getAgency();

    //---------------------------------------------Bookings--------------------------------------------
    @GET("TravelExpertsWebService-1.0-SNAPSHOT/api/booking/getallbookings")
    Call<List<Booking>> getAllBookings();

    @POST("TravelExpertsWebService-1.0-SNAPSHOT/api/booking/postbooking")
    Call<Void> postBooking(@Body Booking booking);

    @DELETE("TravelExpertsWebService-1.0-SNAPSHOT/api/booking/deletebooking/{bookingId}")
    Call<Void> deleteBooking(@Path("bookingId") int bookingId);

    @GET("TravelExpertsWebService-1.0-SNAPSHOT/api/package/getallpackages")
    Call<List<Package>> getAllPackages();

    @GET("TravelExpertsWebService-1.0-SNAPSHOT/api/triptype/getalltriptypes")
    Call<List<TripType>> getAllTripTypes();


}
