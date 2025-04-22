# 🔐 Custom Access Control in ASP.NET Core

Coded by: **King [Alimohammad Eghbaldar]**  
🌐 [eghbaldar.ir](https://eghbaldar.ir)

---

## 🎯 Description

This project demonstrates custom access control in an ASP.NET Core application using attributes. Three different access strategies are shown:

---

### ✅ Query String-Based Access

- **ProtectedPage1**: Access denied by default due to the use of the `[CustomAccess]` attribute.
- **ProtectedPage1Allowed**: Accessible when a specific query string parameter is provided.

---

### 🍪 Cookie-Based Access

- **ProtectedPage2**: Access denied unless a valid cookie is set due to the `[CookieAccess]` attribute.
- **ProtectedPage2Allowed**: Accessible only after a valid cookie is created beforehand.

---

### 🧩 Attribute Parameter-Based Access

- **ParaPage**: Accessible only to users with the role of **Admin** via the `[ParaAccess(UserRole.Admin)]` attribute.
- To test different behaviors, you can change the attribute to another role like `[ParaAccess(UserRole.Viewer)]`.

---

## 🛠️ Features

- Custom authorization attributes
- Role-based and policy-based access
- Query string and cookie validation
- Clean, minimal ASP.NET Core example
