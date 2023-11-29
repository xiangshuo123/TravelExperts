package com.example.travelexperts;

public class ValidationUtility {

    // Check if input is null
    public static boolean isNotNull(Object input) {
        return input != null;
    }

    // Check if input matches email format
    public static boolean isValidEmail(String email) {
        if (email == null) return false;

        String emailPattern = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,6}$";
        return email.matches(emailPattern);
    }

    // Check if input matches Canadian postal code format
    public static boolean isValidCanadianPostalCode(String postalCode) {
        if (postalCode == null) return false;

        // Pattern matches postal codes like "A1A 1A1"
        String postalCodePattern = "^[A-Za-z]\\d[A-Za-z][ -]?\\d[A-Za-z]\\d$";
        return postalCode.matches(postalCodePattern);
    }

    // Check if input exceeds 20 characters
    public static boolean isLengthBelowOrEqualTo20(String input) {
        if (input == null) return false;

        return input.length() <= 20;
    }

    // Check if input character length is not greater than 1
    public static boolean isSingleChar(String input) {
        if (input == null) return false;

        return input.length() == 1;
    }

}
