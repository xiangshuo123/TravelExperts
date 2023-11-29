package com.example.travelexperts;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.AlertDialog;
import android.content.DialogInterface;

import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import androidx.appcompat.widget.SearchView;

import android.widget.Spinner;
import android.widget.Toast;

import com.example.travelexperts.api.ApiService;
import com.example.travelexperts.api.RetrofitClient;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

import com.example.travelexperts.model.Agent;
import com.example.travelexperts.model.Customer;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;


public class CustomersActivity extends AppCompatActivity {

    private RecyclerView recyclerViewCustomers;
    private CustomersAdapter customersAdapter;
    private List<Customer> customerList;
    private List<Integer> agentIds;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_customers);

        SearchView searchView = findViewById(R.id.searchView);
        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
            @Override
            public boolean onQueryTextSubmit(String query) {
                return false;
            }

            @Override
            public boolean onQueryTextChange(String newText) {
                customersAdapter.getFilter().filter(newText);
                return false;
            }
        });

        recyclerViewCustomers = findViewById(R.id.recyclerViewCustomers);
        recyclerViewCustomers.setLayoutManager(new LinearLayoutManager(this));

        customerList = new ArrayList<>();
        customersAdapter = new CustomersAdapter(customerList, this);

        // Set item click listener for the adapter
        customersAdapter.setOnItemClickListener(new CustomersAdapter.OnItemClickListener() {
            @Override
            public void onItemClick(int position) {
                Customer selectedCustomer = customerList.get(position);
                showCustomerDialog(selectedCustomer);  // We're editing, so we pass the selected customer
            }
        });

        customersAdapter.setOnItemLongClickListener(new CustomersAdapter.OnItemLongClickListener() {
            @Override
            public void onItemLongClick(int position) {
                showDeletionDialog(position);
            }
        });

        recyclerViewCustomers.setAdapter(customersAdapter);

        FloatingActionButton fabAddCustomer = findViewById(R.id.fabAddCustomer);
        fabAddCustomer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showCustomerDialog(null);
            }
        });
        fetchCustomers();
        fetchAndPopulateAgentIds();
    }
    private void fetchCustomers() {
        ApiService apiService = RetrofitClient.getInstance().create(ApiService.class);
        Call<List<Customer>> call = apiService.getAllCustomers();

        call.enqueue(new Callback<List<Customer>>() {
            @Override
            public void onResponse(Call<List<Customer>> call, Response<List<Customer>> response) {
                if(response.isSuccessful() && response.body() != null) {
                    customerList = response.body();
                    customersAdapter = new CustomersAdapter(customerList, CustomersActivity.this);
                    recyclerViewCustomers.setAdapter(customersAdapter);
                    // Set item click listener for the adapter
                    customersAdapter.setOnItemClickListener(new CustomersAdapter.OnItemClickListener() {
                        @Override
                        public void onItemClick(int position) {
                            Customer selectedCustomer = customerList.get(position);
                            showCustomerDialog(selectedCustomer);  // We're editing, so we pass the selected customer
                        }
                    });

                    customersAdapter.setOnItemLongClickListener(new CustomersAdapter.OnItemLongClickListener() {
                        @Override
                        public void onItemLongClick(int position) {
                            showDeletionDialog(position);
                        }
                    });

                } else {
                    Toast.makeText(CustomersActivity.this, "Failed to fetch customers.", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Customer>> call, Throwable t) {
                Toast.makeText(CustomersActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void fetchAndPopulateAgentIds() {
        ApiService apiService = RetrofitClient.getInstance().create(ApiService.class);
        Call<List<Agent>> call = apiService.getAgentDetails();
        call.enqueue(new Callback<List<Agent>>() {
            @Override
            public void onResponse(Call<List<Agent>> call, Response<List<Agent>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    agentIds = new ArrayList<>();
                    for (Agent agent : response.body()) {
                        agentIds.add(agent.getAgentId());
                    }
                    // Trigger any updates to UI components that rely on agentIds here, if needed.
                } else {
                    Toast.makeText(CustomersActivity.this, "Failed to fetch agent IDs", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Agent>> call, Throwable t) {
                Toast.makeText(CustomersActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }


    private void showCustomerDialog(Customer customerToEdit) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        LayoutInflater inflater = getLayoutInflater();
        View dialogView = inflater.inflate(R.layout.dialog_edit_customer, null);
        builder.setView(dialogView);

        EditText editTextCustomerId = dialogView.findViewById(R.id.editTextCustomerId);
        editTextCustomerId.setEnabled(false);
        EditText editTextCustFirstName = dialogView.findViewById(R.id.editTextCustFirstName);
        EditText editTextCustLastName = dialogView.findViewById(R.id.editTextCustLastName);
        EditText editTextCustAddress = dialogView.findViewById(R.id.editTextCustAddress);
        EditText editTextCustCity = dialogView.findViewById(R.id.editTextCustCity);
        EditText editTextCustProv = dialogView.findViewById(R.id.editTextCustProv);
        EditText editTextCustPostal = dialogView.findViewById(R.id.editTextCustPostal);
        EditText editTextCustCountry = dialogView.findViewById(R.id.editTextCustCountry);
        EditText editTextCustHomePhone = dialogView.findViewById(R.id.editTextCustHomePhone);
        EditText editTextCustBusPhone = dialogView.findViewById(R.id.editTextCustBusPhone);
        EditText editTextCustEmail = dialogView.findViewById(R.id.editTextCustEmail);
        Spinner spinnerAgentId = dialogView.findViewById(R.id.spinnerAgentId);
        if (agentIds == null) {
            agentIds = new ArrayList<>();
        }
        ArrayAdapter<Integer> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, agentIds);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerAgentId.setAdapter(adapter);

        if (customerToEdit != null) {
            editTextCustomerId.setText(String.valueOf(customerToEdit.getCustomerId()));
            editTextCustFirstName.setText(customerToEdit.getCustFirstName());
            editTextCustLastName.setText(customerToEdit.getCustLastName());
            editTextCustAddress.setText(customerToEdit.getCustAddress());
            editTextCustCity.setText(customerToEdit.getCustCity());
            editTextCustProv.setText(customerToEdit.getCustProv());
            editTextCustPostal.setText(customerToEdit.getCustPostal());
            editTextCustCountry.setText(customerToEdit.getCustCountry());
            editTextCustHomePhone.setText(customerToEdit.getCustHomePhone());
            editTextCustBusPhone.setText(customerToEdit.getCustBusPhone());
            editTextCustEmail.setText(customerToEdit.getCustEmail());
            int agentIdPosition = agentIds.indexOf(customerToEdit.getAgentId());
            if (agentIdPosition != -1) {
                spinnerAgentId.setSelection(agentIdPosition);
            }
            builder.setTitle("Edit Customer");
        } else {
            builder.setTitle("Add Customer");
        }

        builder.setPositiveButton(customerToEdit != null ? "Update" : "Add", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        int customerId;
                        if (customerToEdit != null) {
                            customerId = customerToEdit.getCustomerId();
                        } else {
                            customerId = -1;  // default value for a new customer as it's auto-incremented in the database
                        }
                        String custFirstName = editTextCustFirstName.getText().toString().trim();
                        String custLastName = editTextCustLastName.getText().toString().trim();
                        String custAddress = editTextCustAddress.getText().toString().trim();
                        String custCity = editTextCustCity.getText().toString().trim();
                        String custProv = editTextCustProv.getText().toString().trim();
                        String custPostal = editTextCustPostal.getText().toString().trim();
                        String custCountry = editTextCustCountry.getText().toString().trim();
                        String custHomePhone = editTextCustHomePhone.getText().toString().trim();
                        String custBusPhone = editTextCustBusPhone.getText().toString().trim();
                        String custEmail = editTextCustEmail.getText().toString().trim();
                        int agentId = (int) spinnerAgentId.getSelectedItem();

                        // Create a new Customer object using the fetched data
                        Customer newCustomer = new Customer(customerId, custFirstName, custLastName,
                                custAddress, custCity, custProv, custPostal, custCountry, custHomePhone,
                                custBusPhone, custEmail, agentId);

                        // Decide whether to add or update based on the customerToEdit value
                        if (customerToEdit != null) {
                            updateCustomerInDatabase(newCustomer,customerToEdit);
                        } else {
                            addCustomerToDatabase(newCustomer);
                        }
                    }
                })
                .setNegativeButton("Cancel", null);

        AlertDialog dialog = builder.create();
        dialog.show();
    }

    private void addCustomerToDatabase(Customer customer) {
        // Basic validation before sending the customer to the API
        if (customer == null ||
                TextUtils.isEmpty(customer.getCustFirstName()) ||
                TextUtils.isEmpty(customer.getCustLastName()) ||
                TextUtils.isEmpty(customer.getCustAddress()) ||
                TextUtils.isEmpty(customer.getCustCity()) ||
                TextUtils.isEmpty(customer.getCustProv()) ||
                TextUtils.isEmpty(customer.getCustPostal()) ||
                TextUtils.isEmpty(customer.getCustCountry()) ||
                TextUtils.isEmpty(customer.getCustHomePhone()) ||
                TextUtils.isEmpty(customer.getCustBusPhone()) ||
                TextUtils.isEmpty(customer.getCustEmail())) {

            Toast.makeText(CustomersActivity.this, "Please ensure all fields are filled.", Toast.LENGTH_SHORT).show();
            return;
        }

        ApiService apiService = RetrofitClient.getInstance().create(ApiService.class);

        Call<Void> call = apiService.postCustomer(customer);
        call.enqueue(new Callback<Void>() {
            @Override
            public void onResponse(Call<Void> call, Response<Void> response) {
                if (response.isSuccessful()) {
                    // Successfully added to the database
                    customerList.add(customer);
                    customersAdapter.addCustomerToFullList(customer); // Assuming you have this method
                    customersAdapter.notifyItemInserted(customerList.size() - 1);
                    Toast.makeText(CustomersActivity.this, "Customer added successfully.", Toast.LENGTH_SHORT).show();
                } else {
                    // Failed to add customer. Maybe server-side validation failed or some other issue.
                    Toast.makeText(CustomersActivity.this, "Failed to add customer. Response code: " + response.code(), Toast.LENGTH_SHORT).show();
                    if (response.errorBody() != null) {
                        try {
                            Log.e("API_ERROR", response.errorBody().string());
                        } catch (IOException e) {
                            e.printStackTrace();
                        }
                    }
                }
            }

            @Override
            public void onFailure(Call<Void> call, Throwable t) {
                // Network error or exception while making the API call
                Toast.makeText(CustomersActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
    private void updateCustomerInDatabase(Customer customer, Customer customerToEdit) {
        // Initialize Retrofit service
        ApiService apiService = RetrofitClient.getInstance().create(ApiService.class);
        // Update customer in the database
        Call<Void> call = apiService.postCustomer(customer);
        call.enqueue(new Callback<Void>() {
            @Override
            public void onResponse(Call<Void> call, Response<Void> response) {
                if (response.isSuccessful()) {
                    fetchCustomers();
                    // Handle success
                    int position = customerList.indexOf(customerToEdit);
                    if (position != -1) {
                        // Update the local list
                        customerList.set(position, customer);
                        // Refresh the entire dataset (this is more expensive but will guarantee a refresh)
                        customersAdapter.notifyDataSetChanged();
                        Toast.makeText(getApplicationContext(), "Customer updated successfully!", Toast.LENGTH_SHORT).show();
                    } else {
                        Toast.makeText(getApplicationContext(), "Updated customer not found in the local list!", Toast.LENGTH_LONG).show();
                    }
                } else {
                    // Handle error
                    Toast.makeText(getApplicationContext(), "Update failed! " + response.message(), Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<Void> call, Throwable t) {
                // Handle failure
                Toast.makeText(getApplicationContext(), "Network error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }



    private void showDeletionDialog(int position) {
        new AlertDialog.Builder(this)
                .setTitle("Delete Customer")
                .setMessage("Are you sure you want to delete this customer?")
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        // Get the customerId of the customer to be deleted
                        ApiService apiService = RetrofitClient.getInstance().create(ApiService.class);
                        int customerId = customerList.get(position).getCustomerId();

                        // Call the API endpoint to delete the customer
                        Call<Void> call = apiService.deleteCustomer(customerId);
                        call.enqueue(new Callback<Void>() {
                            @Override
                            public void onResponse(Call<Void> call, Response<Void> response) {
                                if (response.isSuccessful()) {
                                    // Remove the customer from the local list and update the RecyclerView
                                    customerList.remove(position);
                                    customersAdapter.notifyItemRemoved(position);
                                    // Update the customerListFull too
                                    customersAdapter.removeCustomerFromFullList(position);
                                    Toast.makeText(CustomersActivity.this, "Customer deleted", Toast.LENGTH_SHORT).show();
                                } else {
                                    Toast.makeText(CustomersActivity.this, "Failed to delete customer", Toast.LENGTH_SHORT).show();
                                }
                            }

                            @Override
                            public void onFailure(Call<Void> call, Throwable t) {
                                Toast.makeText(CustomersActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
                            }
                        });
                    }
                })
                .setNegativeButton("No", null)
                .setIcon(android.R.drawable.ic_dialog_alert)
                .show();
    }

}
