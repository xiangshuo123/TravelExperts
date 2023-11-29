package com.example.travelexperts;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.TextView;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.travelexperts.model.Customer;

import java.util.ArrayList;
import java.util.List;

public class CustomersAdapter extends RecyclerView.Adapter<CustomersAdapter.CustomersViewHolder> implements Filterable {

    private List<Customer> customerList;
    private final List<Customer> customerListFull; // For searching
    private final Context context;
    private OnItemClickListener listener;
    private OnItemLongClickListener longClickListener;

    public interface OnItemClickListener {
        void onItemClick(int position);
    }

    public interface OnItemLongClickListener {
        void onItemLongClick(int position);
    }

    public void setOnItemClickListener(OnItemClickListener listener) {
        this.listener = listener;
    }

    public void setOnItemLongClickListener(OnItemLongClickListener longClickListener) {
        this.longClickListener = longClickListener;
    }
    public void updateCustomerList(List<Customer> newCustomerList) {
        this.customerList = newCustomerList;
        notifyDataSetChanged();
    }

    public CustomersAdapter(List<Customer> customerList, Context context) {
        this.customerList = new ArrayList<>(customerList); // Create a new list from the given one
        this.context = context;
        this.customerListFull = new ArrayList<>(customerList); // Use a deep copy for the full list
    }

    public void removeCustomerFromFullList(int position) {
        customerListFull.remove(position);
        customerList.remove(position);
        notifyDataSetChanged();
    }

    public void addCustomerToFullList(Customer customer) {
        customerListFull.add(customer);
        customerList.add(customer);
        notifyDataSetChanged();
    }

    @NonNull
    @Override
    public CustomersViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(context).inflate(R.layout.item_customer, parent, false);
        return new CustomersViewHolder(itemView);
    }

    @Override
    public void onBindViewHolder(@NonNull CustomersViewHolder holder, int position) {
        Customer currentCustomer = customerList.get(position);
        holder.tvCustomerId.setText(String.valueOf(currentCustomer.getCustomerId()));
        holder.tvCustFirstName.setText(currentCustomer.getCustFirstName());
        holder.tvCustLastName.setText(currentCustomer.getCustLastName());
        holder.tvCustEmail.setText(currentCustomer.getCustEmail());
    }

    @Override
    public int getItemCount() {
        return customerList.size();
    }

    @Override
    public Filter getFilter() {
        return customerFilter;
    }

    private final Filter customerFilter = new Filter() {
        @Override
        protected FilterResults performFiltering(CharSequence constraint) {
            List<Customer> filteredList = new ArrayList<>();

            if (constraint == null || constraint.length() == 0) {
                filteredList.addAll(customerListFull);
            } else {
                String filterPattern = constraint.toString().toLowerCase().trim();
                for (Customer customer : customerListFull) {
                    if (customer.getCustLastName().toLowerCase().contains(filterPattern) || customer.getCustFirstName().toLowerCase().contains(filterPattern)) {
                        filteredList.add(customer);
                    }
                }
            }

            FilterResults results = new FilterResults();
            results.values = filteredList;
            results.count = filteredList.size();
            return results;
        }

        @SuppressWarnings("unchecked")
        @Override
        protected void publishResults(CharSequence constraint, FilterResults results) {
            customerList.clear();
            customerList.addAll((List<Customer>) results.values);
            notifyDataSetChanged();
        }
    };

    public class CustomersViewHolder extends RecyclerView.ViewHolder {
        TextView tvCustomerId, tvCustFirstName, tvCustLastName, tvCustEmail;

        public CustomersViewHolder(@NonNull View itemView) {
            super(itemView);
            tvCustomerId = itemView.findViewById(R.id.tvCustomerId);
            tvCustFirstName = itemView.findViewById(R.id.tvCustFirstName);
            tvCustLastName = itemView.findViewById(R.id.tvCustLastName);
            tvCustEmail = itemView.findViewById(R.id.tvCustEmail);

            itemView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    if (listener != null) {
                        int position = getAdapterPosition();
                        if (position != RecyclerView.NO_POSITION) {
                            listener.onItemClick(position);
                        }
                    }
                }
            });

            itemView.setOnLongClickListener(new View.OnLongClickListener() {
                @Override
                public boolean onLongClick(View v) {
                    if (longClickListener != null) {
                        int position = getAdapterPosition();
                        if (position != RecyclerView.NO_POSITION) {
                            longClickListener.onItemLongClick(position);
                            return true;
                        }
                    }
                    return false;
                }
            });
        }
    }

}
