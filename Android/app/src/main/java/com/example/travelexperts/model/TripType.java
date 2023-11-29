package com.example.travelexperts.model;

import com.google.gson.annotations.SerializedName;

public class TripType {
    @SerializedName("tripTypeId")
    private String TripTypeId;
    private String TTName;

    public TripType(String tripTypeId, String TTName) {
        TripTypeId = tripTypeId;
        this.TTName = TTName;
    }

    public String getTripTypeId() {
        return TripTypeId;
    }

    public void setTripTypeId(String tripTypeId) {
        TripTypeId = tripTypeId;
    }

    public String getTTName() {
        return TTName;
    }

    public void setTTName(String TTName) {
        this.TTName = TTName;
    }
}
