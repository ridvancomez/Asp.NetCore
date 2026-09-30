# Asp.NetCore — Kişisel Portföy & Blog Sistemi

ASP.NET Core 8 ile geliştirilmiş, yazar alanı (Writer Area) ve REST API içeren kişisel portföy platformu.

---

## Özellikler

- Hakkımda, deneyim, beceriler, portföy, hizmetler, referanslar bölümleri
- Yazar paneli (Writer Area) — içerik yönetimi
- Admin paneli — site geneli kontrol
- Mesajlaşma ve iletişim formu
- ToDoList, duyurular, sosyal medya yönetimi
- Ziyaretçi haritası (VisitorMap)
- ViewComponent mimarisi — her bölüm bağımsız component
- FluentValidation ile form doğrulama
- Ayrı REST API projesi

---

## Mimari

```
Core_Proje/
├── Core_Proje           # MVC UI — Controllers, Views, ViewComponents, Areas/Writer
├── Core_Proje_Api       # REST API
├── BusinessLayer        # Abstract interfaces + Concrete services + ValidationRules
├── DataAccessLayer      # Repository Pattern, EF EntityFramework, Migrations
└── EntityLayer          # Entity sınıfları
```

**ViewComponents:** About, Contact, Dashboard, Experience, Feature, NotificationNavbar, Portfolio, Service, Skill, SocialMedia, Testimonial, ToDoList, VisitorMap

---

## Teknoloji

| | |
|---|---|
| Framework | ASP.NET Core 8 |
| ORM | Entity Framework Core (Code First) |
| Veritabanı | MSSQL |
| Mimari | N-Tier, Repository Pattern, DI |
| Doğrulama | FluentValidation |
| API | ASP.NET Core Web API |

---

## Kurulum

**Gereksinimler:** .NET 8 SDK, MSSQL Server

```bash
git clone https://github.com/ridvancomez/Asp.NetCore.git
cd Asp.NetCore/Core_Proje
```

`Core_Proje/appsettings.json` ve `Core_Proje_Api/appsettings.json` dosyalarındaki connection string'leri güncelle:

```bash
dotnet ef database update
dotnet run
```
