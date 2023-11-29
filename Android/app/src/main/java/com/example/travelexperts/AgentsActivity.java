package com.example.travelexperts;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.SearchView;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.travelexperts.api.ApiService;
import com.example.travelexperts.api.RetrofitClient;
import com.example.travelexperts.model.Agency;
import com.example.travelexperts.model.Agent;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AgentsActivity extends AppCompatActivity implements AgentsAdapter.OnAgentListener {

    private RecyclerView recyclerViewAgents;
    private AgentsAdapter agentsAdapter;
    private List<Agent> agentList = new ArrayList<>();
    private List<Integer> agencyIds;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_agents);

        SearchView searchView = findViewById(R.id.searchViewAgents);
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

        recyclerViewAgents = findViewById(R.id.recyclerViewAgents);
        recyclerViewAgents.setLayoutManager(new LinearLayoutManager(this));
        agentsAdapter = new AgentsAdapter(agentList, this, this);
        recyclerViewAgents.setAdapter(agentsAdapter);

        FloatingActionButton fabAddCustomer = findViewById(R.id.fabAddAgent);
        fabAddCustomer.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showAgentDialog(null);
            }
        });
        agentsAdapter.setOnItemLongClickListener(new AgentsAdapter.OnItemLongClickListener() {
            @Override
            public void onItemLongClick(int position) {
                showDeletionDialog(position);
            }
        });

        fetchAgentsFromDatabase();
        fetchAgencyIds();
    }
    private void filter(String text) {
        List<Agent> filteredList = new ArrayList<>();
        for (Agent agent : agentList) {
            // If the agent name (or any other relevant field) contains the given text, add to the filtered list
            if (agent.getAgtFirstName().toLowerCase().contains(text.toLowerCase()) || agent.getAgtLastName().toLowerCase().contains(text.toLowerCase())) {
                filteredList.add(agent);
            }
        }
        agentsAdapter.updateList(filteredList);
    }

    private void fetchAgentsFromDatabase() {
        // Assuming you've set up Retrofit similarly to the CustomersActivity
        ApiService apiService = RetrofitClient.getInstance().create(ApiService.class);
        Call<List<Agent>> call = apiService.getAgents();
        call.enqueue(new Callback<List<Agent>>() {
            @Override
            public void onResponse(Call<List<Agent>> call, Response<List<Agent>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    agentList.clear();
                    agentList.addAll(response.body());
                    agentsAdapter.notifyDataSetChanged();
                } else {
                    Toast.makeText(AgentsActivity.this, "Failed to fetch agents.", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<List<Agent>> call, Throwable t) {
                Toast.makeText(AgentsActivity.this, "Network error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    @Override
    public void onAgentClick(int position) {
        Agent selectedAgent = agentList.get(position);
        // Handle agent item click here, like opening the edit dialog
        showAgentDialog(selectedAgent);
    }

    private void showAgentDialog(Agent agentToEdit) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        LayoutInflater inflater = this.getLayoutInflater();
        View dialogView = inflater.inflate(R.layout.dialog_edit_agent, null);
        builder.setView(dialogView);

        // Initialize your edit dialog's views here, and set the agent's data to them
        EditText editTextAgentId = dialogView.findViewById(R.id.editTextAgentId);
        editTextAgentId.setEnabled(false);
        EditText editTextAgtFirstName = dialogView.findViewById(R.id.editTextAgtFirstName);
        EditText editTextAgtMiddleInitial = dialogView.findViewById(R.id.editTextAgtMiddleInitial);
        EditText editTextAgtLastName = dialogView.findViewById(R.id.editTextAgtLastName);
        EditText editTextAgtBusPhone = dialogView.findViewById(R.id.editTextAgtBusPhone);
        EditText editTextAgtEmail = dialogView.findViewById(R.id.editTextAgtEmail);
        EditText editTextAgtPosition = dialogView.findViewById(R.id.editTextAgtPosition);
        Spinner spinnerAgencyId = dialogView.findViewById(R.id.spinnerAgencyId);
        if (agencyIds == null) {
            agencyIds = new ArrayList<>();
        }
        ArrayAdapter<Integer> adapter = new ArrayAdapter<>(this, android.R.layout.simple_spinner_item, agencyIds);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        spinnerAgencyId.setAdapter(adapter);


        if (agentToEdit != null) {
            editTextAgentId.setText(String.valueOf(agentToEdit.getAgentId()));
            editTextAgtFirstName.setText(agentToEdit.getAgtFirstName());
            editTextAgtMiddleInitial.setText(agentToEdit.getAgtMiddleInitial());
            editTextAgtLastName.setText(agentToEdit.getAgtLastName());
            editTextAgtEmail.setText(agentToEdit.getAgtEmail());
            editTextAgtBusPhone.setText(agentToEdit.getAgtBusPhone());
            editTextAgtPosition.setText(agentToEdit.getAgtPosition());
            int agencyIdPosition = agencyIds.indexOf(agentToEdit.getAgencyId());
            if (agencyIdPosition != -1) {
                spinnerAgencyId.setSelection(agencyIdPosition);
            }
            builder.setTitle("Edit Agent");
        }
        builder.setPositiveButton(agentToEdit != null ? "Update" : "Add", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        int agentId;
                        if (agentToEdit != null) {
                            agentId = agentToEdit.getAgentId();
                        } else {
                            agentId = -1;
                        }
                        String agtFirstName = editTextAgtFirstName.getText().toString().trim();
                        String agtMiddleInitial = editTextAgtMiddleInitial.getText().toString().trim();
                        String agtLastName = editTextAgtLastName.getText().toString().trim();
                        String agtEmail = editTextAgtEmail.getText().toString().trim();
                        String agtBusPhone = editTextAgtBusPhone.getText().toString().trim();
                        String agtPosition = editTextAgtPosition.getText().toString().trim();
                        int agencyId = (int) spinnerAgencyId.getSelectedItem();

                        // Validation Checks
                        if (agtFirstName.isEmpty() ||
                                agtLastName.isEmpty() ||
                                agtBusPhone.isEmpty() ||
                                agtEmail.isEmpty() ||
                                agtPosition.isEmpty()) {
                            Toast.makeText(AgentsActivity.this, "Fields cannot be empty!", Toast.LENGTH_SHORT).show();
                            return;
                        }

                        if (!ValidationUtility.isValidEmail(agtEmail)) {
                            Toast.makeText(AgentsActivity.this, "Invalid email format!", Toast.LENGTH_SHORT).show();
                            return;
                        }

                        if (agtMiddleInitial.length() > 1) {
                            Toast.makeText(AgentsActivity.this, "Middle Initial cannot be longer than 1 character!", Toast.LENGTH_SHORT).show();
                            return;
                        }

                        // Create a new Agent object using the fetched data
                        Agent newAgent = new Agent(agentId,agtFirstName,agtMiddleInitial,agtLastName,agtBusPhone,agtEmail,agtPosition,agencyId);
                        saveAgentToDatabase(newAgent);
                    }
                })
                .setNegativeButton("Cancel", null);

        AlertDialog dialog = builder.create();
        dialog.show();
    }

    private void saveAgentToDatabase(Agent agent) {
        ApiService service = RetrofitClient.getInstance().create(ApiService.class);
        Call<Void> call = service.postAgent(agent);
        call.enqueue(new Callback<Void>() {
            @Override
            public void onResponse(Call<Void> call, Response<Void> response) {
                if (response.isSuccessful()) {
                    Toast.makeText(AgentsActivity.this, agent.getAgentId() == -1 ? "Agent added successfully!" : "Agent updated successfully!", Toast.LENGTH_SHORT).show();
                    fetchAgentsFromDatabase(); // Refresh the list
                } else {
                    Toast.makeText(AgentsActivity.this, "Failed to save agent.", Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onFailure(Call<Void> call, Throwable t) {
                Toast.makeText(AgentsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }
    private void showDeletionDialog(int position) {
        new AlertDialog.Builder(this)
                .setTitle("Delete Agent")
                .setMessage("Are you sure you want to delete this agent?")
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        // Get the agentId of the agent to be deleted
                        ApiService apiService = RetrofitClient.getInstance().create(ApiService.class);
                        int agentId = agentList.get(position).getAgentId();

                        // Call the API endpoint to delete the agent
                        Call<Void> call = apiService.deleteAgent(agentId);
                        call.enqueue(new Callback<Void>() {
                            @Override
                            public void onResponse(Call<Void> call, Response<Void> response) {
                                if (response.isSuccessful()) {
                                    // Remove the agent from the local list and update the RecyclerView
                                    agentList.remove(position);
                                    agentsAdapter.notifyItemRemoved(position);
                                    Toast.makeText(AgentsActivity.this, "Agent deleted", Toast.LENGTH_SHORT).show();
                                } else {
                                    Toast.makeText(AgentsActivity.this, "Failed to delete agent", Toast.LENGTH_SHORT).show();
                                }
                            }

                            @Override
                            public void onFailure(Call<Void> call, Throwable t) {
                                Toast.makeText(AgentsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
                            }
                        });
                    }
                })
                .setNegativeButton("No", null)
                .setIcon(android.R.drawable.ic_dialog_alert)
                .show();
    }
    private void fetchAgencyIds() {
        ApiService service = RetrofitClient.getInstance().create(ApiService.class);
        Call<List<Agency>> call = service.getAgency();
        call.enqueue(new Callback<List<Agency>>() {
            @Override
            public void onResponse(Call<List<Agency>> call, Response<List<Agency>> response) {
                if (response.isSuccessful()) {
                    List<Agency> agencies = response.body();
                    agencyIds = new ArrayList<>();
                    for (Agency agency : agencies) {
                        Log.d("AGENCY_ID", String.valueOf(agency.getAgencyId()));
                        agencyIds.add(agency.getAgencyId());
                    }
                } else {
                    Toast.makeText(AgentsActivity.this, "Failed to fetch agency IDs", Toast.LENGTH_SHORT).show();
                }
            }
            @Override
            public void onFailure(Call<List<Agency>> call, Throwable t) {
                Toast.makeText(AgentsActivity.this, "Error: " + t.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }

}
