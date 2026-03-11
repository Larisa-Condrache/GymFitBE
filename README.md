# 🏋️ GymFit

O aplicație web fullstack pentru gestionarea unei săli de sport, cu sistem de autentificare și roluri distincte pentru clienți și traineri.

> ⚠️ Proiect în dezvoltare — funcționalitățile implementate includ autentificarea și gestionarea rolurilor.

---

## 🚀 Funcționalități implementate

- **Înregistrare și autentificare** pentru două tipuri de utilizatori:
  - 👤 **Client** — acces la funcționalitățile destinate membrilor sălii
  - 🏃 **Trainer** — acces la funcționalitățile destinate antrenorilor
- **Sistem de roluri** — redirecționare și acces diferențiat în funcție de tipul contului
- **API REST** backend pentru gestionarea autentificării

---

## 🛠️ Tehnologii folosite

### Backend
- **C# / ASP.NET** — API REST
- **PostgreSQL** — bază de date relațională
- **pgAdmin 4** — administrarea bazei de date

### Frontend
- **React** — interfață utilizator
- **JavaScript / HTML / CSS** — structură și stilizare

---

## 🗂️ Structura proiectului

```
GymFitBE/
├── GymFitBE/          # Backend ASP.NET (C#)
├── gymfit-frontend/   # Frontend React
├── GymFitBE.sln       # Solution file Visual Studio
└── package.json       # Dependențe Node.js
```

---

## ⚙️ Rulare locală

### Backend
```bash
# Deschide GymFitBE.sln în Visual Studio
# Configurează connection string-ul pentru PostgreSQL în appsettings.json
# Rulează proiectul (F5)
```

### Frontend
```bash
cd gymfit-frontend
npm install
npm start
```

---

## 🔮 Funcționalități planificate

- Gestionarea abonamentelor clienților
- Programarea ședințelor cu trainerii
- Dashboard pentru traineri cu lista de clienți
- Vizualizarea și urmărirea progresului

---
