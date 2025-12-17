# SQL Portfolio

This folder contains a curated set of SQL examples demonstrating practical, real-world skills used in IT Service Delivery, Application Support, Data/Reporting roles, and general systems analysis.

The examples use two well-known sample databases:
- **Northwind** (small, business-friendly schema)
- **AdventureWorks** (enterprise-scale production-style schema)

The goal is to showcase clean SQL, good structure, and patterns that apply to everyday work in modern IT environments.

---

## 📁 Stored Procedures

### **1. GetCustomerOrderSummary.sql**  
**Database:** Northwind  
**Skills Demonstrated:**  
- INNER JOINs  
- Optional date filtering with parameters  
- Aggregations with business logic  
- Grouping and ordering  
- Clean, production-style T-SQL

**Description:**  
Returns a customer’s order history, including total order value, with optional start/end date filtering.

---

### **2. usp_GetSalesByTerritoryAndDate.sql**  
**Database:** AdventureWorks  
**Skills Demonstrated:**  
- Multi-table JOINs across Sales and Production schemas  
- Parameterized filtering (safe and optional)  
- Real-world reporting logic  
- Clean enterprise-style structure

**Description:**  
Generates a sales report for a territory within a given date range, including product details and line totals.

---

## 📁 Queries

### **1. SampleJoins.sql**  
Shows INNER and LEFT JOIN patterns, including:  
- Match-only queries  
- Keep-all-left queries  
- Multi-step JOIN chains  
- NULL-handling with LEFT JOINs

---

### **2. GroupByExamples.sql**  
Examples of:  
- Aggregate functions  
- Grouping by multiple columns  
- Filtering with HAVING vs WHERE  
- Business-style summary queries

---

### **3. SubqueryExamples.sql**  
Includes:  
- Scalar subqueries  
- Correlated subqueries  
- EXISTS vs IN patterns  
- Real-world use cases (e.g., customers with no orders)

---

### **4. WindowFunctions.sql**  
(Optional, if included)

Examples of:  
- ROW_NUMBER(), RANK(), DENSE_RANK()  
- Running totals  
- Partitioned analytics  
- Business reporting patterns

---

## ⭐ Why This Portfolio Matters

These examples highlight strengths in:
- SQL fundamentals (JOINs, GROUP BY, filtering)
- Writing clear, maintainable queries
- Understanding business logic in data
- Navigating both simple and complex schemas
- Producing production-ready stored procedures
- Supporting reporting, analytics, and application logic

This SQL collection is intentionally focused, clean, and practical — designed to show real capability rather than contrived textbook problems.

---

## ✔ How to Run These Examples
Both Northwind and AdventureWorks can be installed on SQL Server (Express or Developer Edition).

- **Northwind:** Available via Microsoft sample databases  
- **AdventureWorks:** Download from Microsoft SQL Server Samples (AdventureWorks OLTP)

---

## 📌 Contact
If you are reviewing this repository for hiring or technical evaluation and would like to discuss any SQL examples, stored procedures, or data modeling approaches, feel free to reach out.

**Nick DeNora**  
Buffalo, NY  
Email: *calitrano@msn.com*  

