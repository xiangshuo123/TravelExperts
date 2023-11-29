package com.example.travelexperts;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.travelexperts.model.Booking;

import java.util.ArrayList;
import java.util.List;

public class BookingAdapter extends RecyclerView.Adapter<BookingAdapter.BookingViewHolder> {

    private Context context;
    private List<Booking> bookingList;
    private OnBookingListener onBookingListener;
    private OnBookingLongClickListener mBookingLongClickListener;

    public BookingAdapter(Context context, List<Booking> bookings, OnBookingListener onBookingListener) {
        this.context = context;
        this.bookingList = bookings;
        this.onBookingListener = onBookingListener;
    }

    @NonNull
    @Override
    public BookingViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View itemView = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.item_booking, parent, false);

        return new BookingViewHolder(itemView, onBookingListener, mBookingLongClickListener);
    }

    @Override
    public void onBindViewHolder(@NonNull BookingViewHolder holder, int position) {
        Booking booking = bookingList.get(position);
        holder.tvBookingNo.setText("Booking No: " + booking.getBookingNo());
        holder.tvBookingDate.setText(booking.getBookingDate().toString());
        holder.tvCustomerId.setText("Customer ID: " + String.valueOf(booking.getCustomerId()));
    }

    @Override
    public int getItemCount() {
        return bookingList.size();
    }


    public static class BookingViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener, View.OnLongClickListener {
        TextView tvBookingDate, tvBookingNo, tvCustomerId;
        OnBookingListener onBookingListener;
        OnBookingLongClickListener mBookingLongClickListener;

        BookingViewHolder(View itemView, OnBookingListener onBookingListener, OnBookingLongClickListener mBookingLongClickListener) {
            super(itemView);
            tvBookingNo = itemView.findViewById(R.id.tvBookingNo);
            tvBookingDate = itemView.findViewById(R.id.tvBookingDate);
            tvCustomerId = itemView.findViewById(R.id.tvCustomerId);

            this.onBookingListener = onBookingListener;
            this.mBookingLongClickListener = mBookingLongClickListener;

            itemView.setOnClickListener(this);
            itemView.setOnLongClickListener(this);
        }

        @Override
        public void onClick(View v) {
            onBookingListener.onBookingClick(getAdapterPosition());
        }

        @Override
        public boolean onLongClick(View v) {
            if (mBookingLongClickListener != null) {
                int position = getAdapterPosition();
                if (position != RecyclerView.NO_POSITION) {
                    mBookingLongClickListener.onBookingLongClick(position);
                    return true;
                }
            }
            return false;
        }
    }

    public interface OnBookingListener {
        void onBookingClick(int position);
    }

    public interface OnBookingLongClickListener {
        void onBookingLongClick(int position);
    }

    public void setOnBookingLongClickListener(OnBookingLongClickListener listener) {
        this.mBookingLongClickListener = listener;
    }

    public void updateList(List<Booking> list){
        bookingList = list;
        notifyDataSetChanged();
    }
}
