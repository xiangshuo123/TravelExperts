package com.example.travelexperts.api;

import android.util.Log;

import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonParseException;

import java.lang.reflect.Type;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Locale;

public class CustomDateDeserializer implements JsonDeserializer<Date> {
    private List<SimpleDateFormat> dateFormats = Arrays.asList(
            new SimpleDateFormat("yyyy-MM-dd HH:mm:ss", Locale.US),
            new SimpleDateFormat("MMM d, yyyy, h:mm:ss a", Locale.US)
    );

    @Override
    public Date deserialize(JsonElement je, Type type, JsonDeserializationContext jdc) throws JsonParseException {
        String dateString = je.getAsString().replace("\u202F", " ").replace("\u00A0", " ");
        for (SimpleDateFormat format : dateFormats) {
            try {
                return format.parse(dateString);
            } catch (ParseException ignored) {
            }
        }
        throw new JsonParseException("Unparseable date: \"" + dateString + "\"");
    }
}