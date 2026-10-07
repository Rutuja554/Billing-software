# 🧾 Billing Software – Invoice Management System

A web-based **Billing and Invoice Management System** developed using **ASP.NET Core MVC (.NET 8)**, **Entity Framework Core**, and **SQL Server**.

The application helps manage customers and products, generate invoices, calculate GST-based totals, record invoice payments, track payment status, and view/print invoices.

---

## 📌 Project Overview

The **Billing Software** is designed to simplify the billing process for businesses.

Users can:

* Manage customer information
* Manage product information
* Create new invoices
* Add multiple products to an invoice
* Calculate product totals with GST
* Record invoice payments
* Track paid, unpaid, and partially paid invoices
* View complete invoice details
* Print invoices

---

## 🚀 Features

### 👤 Customer Management

* Add new customers
* View customer list
* Edit customer information
* Delete customers
* Store customer name, mobile number, and city

### 📦 Product Management

* Add products
* View product list
* Edit product information
* Delete products
* Store product name, rate, GST, and stock quantity
* Product names are maintained as unique records

### 🧾 Invoice Management

* Create new invoices
* Select customers and products
* Automatically fetch product rate, GST, and stock information
* Enter product quantity
* Calculate GST and total amount
* Add multiple products to an invoice
* Generate and save invoices

### 💳 Payment Management

* Record invoice payments
* Store payment date
* Store payment amount
* Store payment mode
* Add payment description
* Track payment history

### 📊 Payment Status

The system calculates invoice payment status based on the total amount and payments received:

* **UnPaid**
* **Partial Paid**
* **Paid**

It also calculates:

* Total Amount
* Paid Amount
* Remaining Amount

### 🖨️ Invoice View & Print

* View complete invoice details
* Display customer information
* Display purchased products
* Display payment history
* Print invoice directly from the browser

---

## 🛠️ Technologies Used

| Technology                  | Purpose                                         |
| --------------------------- | ----------------------------------------------- |
| **C#**                      | Backend programming                             |
| **ASP.NET Core MVC**        | Web application framework                       |
| **.NET 8**                  | Application platform                            |
| **Entity Framework Core 8** | Database access / ORM                           |
| **SQL Server**              | Database                                        |
| **Razor Views**             | UI rendering                                    |
| **HTML5**                   | Page structure                                  |
| **CSS3**                    | Styling                                         |
| **Bootstrap**               | Responsive UI                                   |
| **JavaScript**              | Client-side functionality                       |
| **jQuery**                  | DOM manipulation and AJAX-related functionality |
| **Fetch API**               | Asynchronous API requests                       |
| **Dependency Injection**    | Service management                              |

---

## 🏗️ Project Architecture

The project follows the **ASP.NET Core MVC architecture**.

```text
Billing-software
│
├── Controllers
│   ├── CustomerController.cs
│   ├── HomeController.cs
│   ├── InvoiceDetailController.cs
│   └── ProductController.cs
│
├── Models
│   ├── InvoicebillingDbContext.cs
│   ├── Tblcustomer.cs
│   ├── Tblproduct.cs
│   ├── Tblinvoicedetail.cs
│   ├── Tblinvoiceproduct.cs
│   ├── Tblinvoicepayment.cs
│   └── invoicemodel.cs
│
├── Services
│   ├── Customer
│   │   ├── ICustomer.cs
│   │   └── Customer.cs
│   │
│   ├── Product
│   │   ├── IProduct.cs
│   │   └── Product.cs
│   │
│   └── Invoices
│       ├── IInvoice.cs
│       └── Invoice.cs
│
├── Views
│   ├── Customer
│   ├── Product
│   ├── InvoiceDetail
│   └── Shared
│
├── wwwroot
│   ├── css
│   ├── js
│   └── lib
│
├── Program.cs
├── appsettings.json
└── Billing-software.csproj
```

---

## 🗄️ Database Structure

The application uses **SQL Server** with the following main tables:

```text
tblcustomer
     │
     │
     ▼
tblinvoicedetail
     │
     ├──────────────► tblinvoiceproduct
     │                       │
     │                       ▼
     │                  tblproduct
     │
     └──────────────► tblinvoicepayment
```

### Main Tables

#### `tblcustomer`

Stores customer information.

```text
customer_id
customer_name
mobile_no
city
```

#### `tblproduct`

Stores product information.

```text
product_id
product_name
rate
gst
stock_quantity
```

#### `tblinvoicedetail`

Stores invoice information.

```text
invoice_id
customer_id
invoice_date
total_amt
```

#### `tblinvoiceproduct`

Stores products associated with each invoice.

```text
invoice_productid
invoice_id
product_id
quantity
```

#### `tblinvoicepayment`

Stores payment information.

```text
payment_id
invoice_id
payment_date
payment_amt
payment_mode
payment_description
```

---

## 🔄 Invoice Workflow

```text
Select Customer
       ↓
Select Product
       ↓
Fetch Product Rate & GST
       ↓
Enter Quantity
       ↓
Calculate GST + Total
       ↓
Add Product to Invoice
       ↓
Generate Invoice
       ↓
Invoice Saved
       ↓
Make Payment
       ↓
Payment Status Updated
       ↓
View / Print Invoice
```

---

## 🧮 GST Calculation

The invoice calculates the product amount and GST using the following logic:

```text
Product Amount = Rate × Quantity

GST Amount = Product Amount × GST / 100

Total = Product Amount + GST Amount
```

### Example

```text
Rate     = ₹100
Quantity = 2
GST      = 18%

Product Amount = 100 × 2
               = ₹200

GST Amount     = 200 × 18 / 100
               = ₹36

Total          = 200 + 36
               = ₹236
```

---

## 💳 Payment Status Logic

The application compares the total invoice amount with the total payments received.

```text
Paid Amount = 0
     ↓
UnPaid
```

```text
0 < Paid Amount < Total Amount
     ↓
Partial Paid
```

```text
Paid Amount >= Total Amount
     ↓
Paid
```

The remaining amount is calculated as:

```text
Remaining Amount = Total Amount - Paid Amount
```

---

## 🔌 Dependency Injection

The project uses ASP.NET Core Dependency Injection for application services.

The following services are registered in `Program.cs`:

```csharp
builder.Services.AddTransient<ICustomer, Customer>();
builder.Services.AddTransient<IProduct, Product>();
builder.Services.AddTransient<IInvoice, Invoice>();
```

Controllers receive these services through constructor injection.

Example:

```csharp
public InvoiceDetailController(
    ICustomer customer,
    IProduct product,
    IInvoice invoice)
{
    this.customer = customer;
    this.product = product;
    this.invoice = invoice;
}
```

---

## 📡 Important Endpoints

### Customer

```text
/Customer
```

### Product

```text
/Product
```

### Invoice

```text
/InvoiceDetail
```

### New Invoice

```text
/InvoiceDetail/NewInvoice
```

### Generate Invoice

```text
POST /InvoiceDetail/GenerateInvoice
```

### Payment

```text
/InvoiceDetail/PayInvoice/{id}
```

### View Invoice

```text
/InvoiceDetail/ViewInvoice/{id}
```

---

# ⚙️ Installation & Setup

## 1. Clone the Repository

```bash
git clone https://github.com/your-username/Billing-software.git
```

Navigate to the project:

```bash
cd Billing-software
```

---

## 2. Prerequisites

Make sure the following are installed:

* Visual Studio 2022 or later
* .NET 8 SDK
* SQL Server
* SQL Server Management Studio (SSMS)
* Git

---

## 3. Configure SQL Server

Create the required SQL Server database and tables.

The application uses the following database:

```text
invoicebilling_db
```

Update the connection string in:

```text
appsettings.json
```

Example:

```json
"ConnectionStrings": {
  "MyCon": "Server=YOUR_SERVER;Database=invoicebilling_db;Trusted_Connection=True;TrustServerCertificate=True"
}
```

Replace:

```text
YOUR_SERVER
```

with your SQL Server instance name.

---

## 4. Restore NuGet Packages

Run:

```bash
dotnet restore
```

---

## 5. Build the Project

```bash
dotnet build
```

---

## 6. Run the Application

```bash
dotnet run
```

Or open the project in **Visual Studio** and press:

```text
Ctrl + F5
```

or

```text
F5
```

---

# 🔐 Important Security Note

Do **not** upload real database credentials, passwords, API keys, or sensitive connection strings to a public GitHub repository.

Before making the repository public, replace the local SQL Server connection string with a safe configuration approach such as:

* User Secrets
* Environment Variables
* Azure Key Vault
* Deployment environment configuration

For example:

```json
"ConnectionStrings": {
  "MyCon": "YOUR_CONNECTION_STRING"
}
```

---

## 📸 Screens / Modules

The application contains the following major screens:

* 🏠 Dashboard / Home
* 👤 Customer Management
* 📦 Product Management
* 🧾 New Invoice
* 📋 Invoice List
* 💳 Payment Form
* 🔍 Invoice Details
* 🖨️ Printable Invoice

## 📸 Screenshots

### 👤 Customer Management
![Customer Management](Images/customer.png)

### 📦 Product Management
![Product Management](Images/product.png)

### 🧾 New Invoice
![New Invoice](Images/new-invoice.png)

### 📋 Invoice Details
![Invoice Details](Images/invoice-details.png)
# 🎯 Project Objectives

The main objectives of this project are:

* To simplify the billing process
* To maintain customer and product information
* To generate invoices efficiently
* To calculate GST automatically
* To maintain invoice payment records
* To track payment status
* To provide printable invoice details
* To reduce manual billing work

---

# 💡 Key Learning Outcomes

Through this project, I gained practical experience in:

* ASP.NET Core MVC
* C# programming
* Entity Framework Core
* SQL Server
* MVC architecture
* Razor Views
* Dependency Injection
* CRUD operations
* Entity relationships
* LINQ
* JavaScript
* jQuery
* Fetch API
* Bootstrap
* Form handling
* Invoice and payment management

---

# 🔮 Future Enhancements

The project can be enhanced with:

* User authentication and authorization
* Role-based access control
* PDF invoice generation
* Email invoice functionality
* Advanced invoice search and filtering
* Product stock validation
* Automatic stock deduction after invoice generation
* Sales reports and dashboards
* Date-wise sales reports
* Export reports to Excel
* Cloud deployment
* Responsive mobile-first improvements

---

# 👩‍💻 Developer

**Rutuja Gophane**

MCA | .NET / Full Stack Developer

### Skills

```text
C#
ASP.NET Core MVC
.NET 8
Entity Framework Core
SQL Server
HTML
CSS
Bootstrap
JavaScript
jQuery
React.js
```

---

## ⭐ If you find this project useful

If you like this project, please consider giving the repository a ⭐ on GitHub.

---

## 📄 License

This project is created for **educational and portfolio purposes**.
