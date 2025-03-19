# User Details App (React + ASP.NET + MongoDB)

This is a **full-stack web application** that allows users to **save and retrieve details** using a **React Frontend**, **ASP.NET Web API Backend**, and **MongoDB Database**.

## **Features**
✔ Save user details (First Name, City, Year of Joining)  
✔ Retrieve the last saved user from MongoDB  
✔ Secure API using an **API Key**  
✔ Fully responsive UI with **Tailwind CSS**  

---

## **1️⃣ Tech Stack**
- **Frontend:** React (Create React App) with Tailwind CSS
- **Backend:** ASP.NET Web API (C#)
- **Database:** MongoDB
- **Security:** API Key Authentication

---

# **3️⃣ Steps to Set Up and Run the Project**
Follow these steps to **install, configure, and run** the project.

### **1️ Clone the Repository**
```sh
git clone https://github.com/AnirudhKalva/OhioHealth_Technical_Kata.git
cd OhioHealth_Technical_Kata
```

### **2 Backend Setup:**

   ```sh
   cd Backend_Webservice
   dotnet restore
   ```
```sh
    Create Configuration File
    Create a new appsettings.json file inside the Backend_Webservice/ folder and add:
    {
  "MongoDB": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "UserDatabase",
    "CollectionName": "Users"
  },
  "API_KEY": "your-secure-api-key"
}
```
```sh
   dotnet run
```
### **3 Frontend Setup:**
   ```sh
   cd ../form-app
   npm install
   ```
```sh
   Create a new .env file inside form-app/ and add:

   REACT_APP_API_URL=http://localhost:5166/api
   REACT_APP_API_KEY=your-secure-api-key
```
```sh   
   npm start
```
