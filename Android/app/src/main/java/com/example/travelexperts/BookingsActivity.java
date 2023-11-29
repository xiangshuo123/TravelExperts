package com.example.travelexperts;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.widget.SearchView;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.travelexperts.api.ApiService;
import com.example.travelexperts.model.Agent;
import com.example.travelexperts.model.Booking;
import com.example.travelexperts.model.Package;
import com.example.travelexperts.model.TripType;
import com.example.travelexperts.model.Customer;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.example.travelexperts.api.RetrofitClient;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

public class BookingsActivity extends AppCompatActivity implements BookingAdapter.OnBookingListener, BookingAdapter.OnBookingLongClickListener {

    private RecyclerView recyclerViewBookings;
    private BookingAdapter bookingAdapter;
    private FloatingActionButton fabAddBooking;
    private List<Booking> bookingsList = new ArrayList<>();
    private List<Integer> packageIds;
    private List<String> tripTypeIds;
    private List<Integer> customerIds;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bookings);

        SearchView searchView = findViewById(R.id.searchViewBookings);
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                // Handle when search is submitted
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                // Filter our agents list based on newText
                filter(newText);
                return true;
            }
        });

        recyclerViewBookings = findViewById(R.id.recyclerViewBookings);
        fabAddBooking = findViewById(R.id.fabAddBooking);
        fabAddBooking.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                showBookingDialog(null);
            }
        });
        recyclerViewBookings.setLayoutManager(new LinearLayoutManager(this));
        fetchBookings();
        updateCustomerIdsList();
        updatePackageIdsList();
        updateTripTypeIdsList();
    }

    private void filter(String text) {
        List<Booking> filteredList = new ArrayList<>();
        for (Booking booking : bookingsList) {
            // If the agent name (or any other relevant field) contains the given text, add to the filtered list
            if (booking.getBookingNo().toLowerCase().contains(text.toLowerCase())) {
                filteredList.add(booking);
            }
        }
        bookingAdapter.updateList(filteredList);
    }

    @Override
    public void onBookingClick(int position) {
        if (position >= 0 && position < bookingsList.size()) {
            Booking selectedBooking = bookingsList.get(position);
            showBookingDialog(selectedBooking);
        } else {
            Log.e("BOOKING_CLICK", "Invalid position: " + bookingsList);
        }
    }
    @Override
    public void onBookingLongClick(int position) {
        Booking selectedBooking = bookingsList.get(position);
        showDeleteConfirmationDialog(selectedBooking.getBookingId());
    }

    private void showBookingDialog(Booking bookingToEdit) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        LayoutInflater inflater = getLayoutInflater();
        View dialogView = inflater.inflate(R.layout.dialog_edit_booking, null);
        builder.setView(dialogView);

        EditText editTextBookingId = dialogView.findViewById(R.id.editTextBookingId);
        editTextBookingId.setEnabled(false);
        DatePicker datePickerBookingDate = dialogView.findViewById(R.id.dpBookingDate);
        EditText editTextBookingNo = dialogView.findViewById(R.id.editTextBookingNo);
        EditText editTextTravelerCount = dialogView.findViewById(R.id.editTextTravelerCount);
        Spinner spinnerCustomerId = dialogView.findViewById(R.id.spinnerCustomerId);
        Spinner spinnerTripTypeId = dialogView.findViewById(R.id.spinnerTripTypeId);
        Spinner spinnerPackageId = dialogView.findViewById(R.id.spinnerPackageId);
        if (customerIds == null) {
            customerIds = new ArrayList<>();
        }
        if (tripTypeIds == null){
            tripTypeIds = new ArrayList<>();
        }
        if (packageIds == null){
            packageIds = new ArrayList<>();
        }

        ArrayAdapter<Integer> packageAdapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, packageIds);
        spinnerPackageId.setAdapter(packageAdapter);

        ArrayAdapter<String> tripTypeAdapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, tripTypeIds);
        spinnerTripTypeId.setAdapter(tripTypeAdapter);

        ArrayAdapter<Integer> customerAdapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, customerIds);
        spinnerCustomerId.setAdapter(customerAdapter);

        if (bookingToEdit != null) {
            editTextBookingId.setText(String.valueOf(bookingToEdit.getBookingId()));
            editTextBookingNo.setText(bookingToEdit.getBookingNo());
            editTextTravelerCount.setText(String.valueOf(bookingToEdit.getTravelerCount()));

            Calendar calendar = Calendar.getInstance();
            calendar.setTime(bookingToEdit.getBookingDate());
            datePickerBookingDate.updateDate(calendar.get(Calendar.YEAR), calendar.get(Calendar.MONTH), calendar.get(Calendar.DAY_OF_MONTH));

            spinnerCustomerId.setSelection(customerIds.indexOf(bookingToEdit.getCustomerId()));
            spinnerTripTypeId.setSelection(tripTypeIds.indexOf(bookingToEdit.getTripTypeId()));
            spinnerPackageId.setSelection(packageIds.indexOf(bookingToEdit.getPackageId()));
        }
        builder.setPositiveButton(bookingToEdit != null ? "Update" : "Add", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        // Check if it's an Add operation
                        if (bookingToEdit != null) {
                            // Update the bookingToEdit object
                            bookingToEdit.setBookingNo(editTextBookingNo.getText().toString());
                            bookingToEdit.setTravelerCount(Integer.parseInt(editTextTravelerCount.getText().toString()));
                            bookingToEdit.setCustomerId(customerIds.get(spinnerCustomerId.getSelectedItemPosition()));
                            bookingToEdit.setTripTypeId(tripTypeIds.get(spinnerTripTypeId.getSelectedItemPosition()));
                            bookingToEdit.setPackageId(packageIds.get(spinnerPackageId.getSelectedItemPosition()));

                            // Here get the date from the datePicker and set it in the bookingToEdit object
                            Calendar calendar = Calendar.getInstance();
                            calendar.set(datePickerBookingDate.getYear(), datePickerBookingDate.getMonth(), datePickerBookingDate.getDayOfMonth());
                            bookingToEdit.setBookingDate(calendar.getTime());

                            // Now make the API call
                            Call<Void> call = RetrofitClient.getInstance().create(ApiService.class).postBooking(bookingToEdit);
                            call.enqueue(new Callback<Void>() {
                                @Override
                                public void onResponse(Call<Void> call, Response<Void> response) {
                                    if(response.isSuccessful()) {
                                        // Update successful
                                        fetchBookings();  // Refresh your bookings list
                                    } else {
                                        Log.d("API_RESPONSE", "Error in response: " + response.errorBody());
                                    }
                                }

                                @Override
                                public void onFailure(Call<Void> call, Throwable t) {
                                    Log.e("API_FAILURE", "Failed to update booking", t);
                                }
                            });
                        } else {

                            // Retrieve values from the dialog
                            String bookingNo = editTextBookingNo.getText().toString().trim();
                            int travelerCount = Integer.parseInt(editTextTravelerCount.getText().toString().trim());

                            Calendar calendar = Calendar.getInstance();
                            calendar.set(datePickerBookingDate.getYear(), datePickerBookingDate.getMonth(), datePickerBookingDate.getDayOfMonth());
                            Date bookingDate = calendar.getTime();

                            int selectedCustomerId = customerIds.get(spinnerCustomerId.getSelectedItemPosition());
                            String selectedTripTypeId = tripTypeIds.get(spinnerTripTypeId.getSelectedItemPosition());
                            int selectedPackageId = packageIds.get(spinnerPackageId.getSelectedItemPosition());

                            // Create a new Booking object
                            Booking newBooking = new Booking(0, bookingDate, bookingNo, travelerCount, selectedCustomerId, selectedTripTypeId, selectedPackageId);

                            // Make a POST request to add the booking
                            Call<Void> call = RetrofitClient.getInstance().create(ApiService.class).postBooking(newBooking);
                            call.enqueue(new Callback<Void>() {
                                @Override
                                public void onResponse(Call<Void> call, Response<Void> response) {
                                    if (response.isSuccessful()) {
                                        Toast.makeText(BookingsActivity.this, "Booking added successfully", Toast.LENGTH_SHORT).show();
                                        fetchBookings(); // Refresh the bookings list
                                    } else {
                                        Toast.makeText(BookingsActivity.this, "Failed to add booking", Toast.LENGTH_SHORT).show();
                                    }
                                }
                                @Override
                                public void onFailure(Call<Void> call, Throwable t) {
                                    Toast.makeText(BookingsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
                                }
                            });
                        }
                    }
                })
                .setNegativeButton("Cancel", null);

        AlertDialog dialog = builder.create();
        dialog.show();
    }

    private void showDeleteConfirmationDialog(final int bookingId) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Confirm Deletion");
        builder.setMessage("Are you sure you want to delete this booking?");
        builder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                // Make the API call to delete the booking
                Call<Void> call = RetrofitClient.getInstance().create(ApiService.class).deleteBooking(bookingId);
                call.enqueue(new Callback<Void>() {
                    @Override
                    public void onResponse(Call<Void> call, Response<Void> response) {
                        if(response.isSuccessful()) {
                            // Deletion was successful
                            Toast.makeText(BookingsActivity.this, "Booking deleted successfully", Toast.LENGTH_SHORT).show();
                            fetchBookings();  // Refresh your bookings list
                        } else {
                            Log.d("API_RESPONSE", "Error in response: " + response.errorBody());
                            Toast.makeText(BookingsActivity.this, "Failed to delete booking", Toast.LENGTH_SHORT).show();
                        }
                    }

                    @Override
                    public void onFailure(Call<Void> call, Throwable t) {
                        Log.e("API_FAILURE", "Failed to delete booking", t);
                        Toast.makeText(BookingsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
                    }
                });
            }
        }).setNegativeButton("No", null);
        builder.create().show();
    }

    //------------------------------------------------------ Data fetch and populate -------------------------------------------------------
    private void fetchBookings() {
        Call<List<Booking>> call = RetrofitClient.getInstance().create(ApiService.class).getAllBookings();

        call.enqueue(new Callback<List<Booking>>() {
            @Override
            public void onResponse(Call<List<Booking>> call, Response<List<Booking>> response) {
                if(response.isSuccessful() && response.body() != null) {
                    Log.d("API_RESPONSE", "Number of bookings received: " + response.body().size());

                    bookingsList.clear();
                    bookingsList.addAll(response.body());

                    bookingAdapter = new BookingAdapter(BookingsActivity.this, bookingsList, BookingsActivity.this);
                    recyclerViewBookings.setAdapter(bookingAdapter);
                    bookingAdapter.setOnBookingLongClickListener(BookingsActivity.this);
                } else {
                    Log.d("API_RESPONSE", "Error in response: " + response.errorBody());
                }
            }
            @Override
            public void onFailure(Call<List<Booking>> call, Throwable t) {
                Log.e("API_FAILURE", "Failed to get bookings", t);
            }
        });
    }

    private void updateCustomerIdsList() {
        ApiService service = RetrofitClient.getInstance().create(ApiService.class);
        Call<List<Customer>> call = service.getAllCustomers();
        call.enqueue(new Callback<List<Customer>>() {
            @Override
            public void onResponse(Call<List<Customer>> call, Response<List<Customer>> response) {
                if (response.isSuccessful()) {
                    List<Customer> customers = response.body();
                    customerIds = new ArrayList<>();
                    for (Customer customer : customers) {
                        Log.d("CUSTOMER_ID", String.valueOf(customer.getCustomerId()));
                        customerIds.add(customer.getCustomerId());
                    }
                } else {
                    Toast.makeText(BookingsActivity.this, "Failed to fetch customer IDs", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Customer>> call, Throwable t) {
                Toast.makeText(BookingsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
    private void updatePackageIdsList() {
        ApiService service = RetrofitClient.getInstance().create(ApiService.class);
        Call<List<Package>> call = service.getAllPackages();
        call.enqueue(new Callback<List<Package>>() {
            @Override
            public void onResponse(Call<List<Package>> call, Response<List<Package>> response) {
                if (response.isSuccessful()) {
                    List<Package> packages = response.body();
                    packageIds = new ArrayList<>();
                    for (Package packageItem : packages) {
                        Log.d("PACKAGE_ID", String.valueOf(packageItem.getPackageId()));
                        packageIds.add(packageItem.getPackageId());
                    }
                } else {
                    Toast.makeText(BookingsActivity.this, "Failed to fetch package IDs", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Package>> call, Throwable t) {
                Toast.makeText(BookingsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
    private void updateTripTypeIdsList() {
        ApiService service = RetrofitClient.getInstance().create(ApiService.class);
        Call<List<TripType>> call = service.getAllTripTypes();
        call.enqueue(new Callback<List<TripType>>() {
            @Override
            public void onResponse(Call<List<TripType>> call, Response<List<TripType>> response) {
                if (response.isSuccessful()) {
                    List<TripType> tripTypes = response.body();
                    tripTypeIds = new ArrayList<>();
                    for (TripType tripType : tripTypes) {
                        Log.d("TRIPTYPE_ID", tripType.getTripTypeId());
                        tripTypeIds.add(tripType.getTripTypeId());
                    }
                } else {
                    Toast.makeText(BookingsActivity.this, "Failed to fetch trip type IDs", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<TripType>> call, Throwable t) {
                Toast.makeText(BookingsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
}
