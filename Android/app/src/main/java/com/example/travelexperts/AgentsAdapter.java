package com.example.travelexperts;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.travelexperts.model.Agent;

import java.util.List;

public class AgentsAdapter extends RecyclerView.Adapter<AgentsAdapter.AgentViewHolder> {

    private List<Agent> agentList;
    private Context context;
    private OnAgentListener onAgentListener;
    private OnItemLongClickListener mLongClickListener;


    public AgentsAdapter(List<Agent> agentList, Context context, OnAgentListener onAgentListener) {
        this.agentList = agentList;
        this.context = context;
        this.onAgentListener = onAgentListener;
    }

    @NonNull
    @Override
    public AgentViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_agent, parent, false);
        return new AgentViewHolder(view, onAgentListener,mLongClickListener);
    }

    @Override
    public void onBindViewHolder(@NonNull AgentViewHolder holder, int position) {
        Agent agent = agentList.get(position);

        // Bind data to the views
        holder.tvAgentFirstName.setText(agent.getAgtFirstName());
        holder.tvAgentLastName.setText(agent.getAgtLastName());
        holder.tvAgentEmail.setText(agent.getAgtEmail());
    }

    @Override
    public int getItemCount() {
        return agentList.size();
    }

    public static class AgentViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {
        TextView tvAgentFirstName, tvAgentLastName, tvAgentEmail;
        OnAgentListener onAgentListener;
        OnItemLongClickListener mLongClickListener;

        public AgentViewHolder(@NonNull View itemView, OnAgentListener onAgentListener,OnItemLongClickListener longClickListener) {
            super(itemView);

            tvAgentFirstName = itemView.findViewById(R.id.tvAgtFirstName);
            tvAgentLastName = itemView.findViewById(R.id.tvAgtLastName);
            tvAgentEmail = itemView.findViewById(R.id.tvAgtEmail);

            this.onAgentListener = onAgentListener;
            this.mLongClickListener = longClickListener;
            itemView.setOnClickListener(this);

            itemView.setOnLongClickListener(new View.OnLongClickListener() {
                @Override
                public boolean onLongClick(View v) {
                    if (mLongClickListener != null) {
                        int position = getAdapterPosition();
                        if (position != RecyclerView.NO_POSITION) {
                            mLongClickListener.onItemLongClick(position);
                            return true;
                        }
                    }
                    return false;
                }
            });
        }

        @Override
        public void onClick(View v) {
            onAgentListener.onAgentClick(getAdapterPosition());
        }
    }

    public interface OnAgentListener {
        void onAgentClick(int position);
    }
    public interface OnItemLongClickListener {
        void onItemLongClick(int position);
    }

    public void setOnItemLongClickListener(OnItemLongClickListener listener) {
        this.mLongClickListener = listener;
    }
    public void updateList(List<Agent> list){
        agentList = list;
        notifyDataSetChanged();
    }


}
