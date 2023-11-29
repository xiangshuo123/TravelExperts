package com.example.travelexperts.model;

import com.google.gson.annotations.SerializedName;

import java.util.Date;

public class Booking {
    @SerializedName("bookingId")
    private int BookingId;
    @SerializedName("bookingDate")
    private Date BookingDate;
    @SerializedName("bookingNo")
    private String BookingNo;
    @SerializedName("travelerCount")
    private int TravelerCount;
    @SerializedName("customer")
    private int CustomerId;
    @SerializedName("tripType")
    private String TripTypeId;
    @SerializedName("packageId")
    private int PackageId;


    public Booking(int bookingId, Date bookingDate, String bookingNo, int travelerCount, int customerId, String tripTypeId, int packageId) {
        BookingId = bookingId;
        BookingDate = bookingDate;
        BookingNo = bookingNo;
        TravelerCount = travelerCount;
        CustomerId = customerId;
        TripTypeId = tripTypeId;
        PackageId = packageId;
    }

    public int getBookingId() {
        return BookingId;
    }

    public void setBookingId(int bookingId) {
        BookingId = bookingId;
    }

    public Date getBookingDate() {
        return BookingDate;
    }

    public void setBookingDate(Date bookingDate) {
        BookingDate = bookingDate;
    }

    public String getBookingNo() {
        return BookingNo;
    }

    public void setBookingNo(String bookingNo) {
        BookingNo = bookingNo;
    }

    public int getTravelerCount() {
        return TravelerCount;
    }

    public void setTravelerCount(int travelerCount) {
        TravelerCount = travelerCount;
    }

    public int getCustomerId() {
        return CustomerId;
    }

    public void setCustomerId(int customerId) {
        CustomerId = customerId;
    }

    public String getTripTypeId() {
        return TripTypeId;
    }

    public void setTripTypeId(String tripTypeId) {
        TripTypeId = tripTypeId;
    }

    public int getPackageId() {
        return PackageId;
    }

    public void setPackageId(int packageId) {
        PackageId = packageId;
    }
}
