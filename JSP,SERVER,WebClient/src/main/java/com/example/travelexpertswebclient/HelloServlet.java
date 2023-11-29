package com.example.travelexpertswebclient;

import java.io.*;
import jakarta.servlet.http.*;
import jakarta.servlet.annotation.*;

@WebServlet(name = "helloServlet", value = "")
public class HelloServlet extends HttpServlet {
    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        response.setContentType("text/html");

        // Create a PrintWriter
        PrintWriter out = response.getWriter();

        // Generate the HTML content with CSS styles
        out.println("<html><head>");
        out.println("<style>");
        out.println("body { font-family: Arial, sans-serif; background-color: #f0f0f0; }");
        out.println("h1 { background-color: #007bff; color: white; padding: 10px; }");
        out.println("ul { list-style: none; padding: 0; }");
        out.println("li { margin-bottom: 10px; }");
        out.println("a { text-decoration: none; background-color: #007bff; color: white; padding: 10px; display: block; border-radius: 5px; }");
        out.println("a:hover { background-color: #0056b3; }");
        out.println("</style>");
        out.println("</head><body>");
        out.println("<h1>Welcome to Travel Experts Web Client</h1>");
        out.println("<p>Choose an action:</p>");
        out.println("<ul>");
        out.println("<li><a href='http://localhost:8082/TravelExpertsWebClient-1.0-SNAPSHOT/getcustomer.jsp'>View Customers</a></li>");
        out.println("<li><a href='http://localhost:8082/TravelExpertsWebClient-1.0-SNAPSHOT/postcustomer.jsp'>Add Customer</a></li>");
        out.println("<li><a href='http://localhost:8082/TravelExpertsWebClient-1.0-SNAPSHOT/putcustomer.jsp'>Update Customer</a></li>");
        out.println("<li><a href='http://localhost:8082/TravelExpertsWebClient-1.0-SNAPSHOT/deletecustomer.jsp'>Delete Customer</a></li>");
        out.println("</ul>");
        out.println("</body></html>");
    }
}