# 🚚 Fleet Manager: System Zarządzania Flotą (Project ROVER)
## 📋 Opis Projektu
Fleet Manager to krytyczny system desktopowy służący do monitorowania i zarządzania flotą pojazdów logistycznych. System pozwala na podgląd stanu paliwa, zmianę statusów operacyjnych oraz zarządzanie bazą pojazdów w czasie rzeczywistym.

Projekt jest realizowany w ramach cyklu SDLC przez dwuosobowe załogi inżynierskie.

## 🎯 Cele Biznesowe (Wymagania)
System musi realizować następujące funkcjonalności:
- Monitoring Floty: Wyświetlanie listy pojazdów przy użyciu dedykowanych komponentów graficznych (UserControl).
- Zarządzanie paliwem: Wizualizacja poziomu paliwa i operacja tankowania.
- Kontrola Statusów: Zarządzanie stanami: Available, InRoute, Service.
- Walidacja Logiki:
  - Blokada tankowania, gdy pojazd jest InRoute.
  - Blokada wysyłki w trasę, gdy paliwo < 15% lub status to Service.

## 🛠️ Stos Techniczny (Tech Stack)
- Framework: Avalonia UI (Cross-platform .NET UI)
- Wzorzec: MVVM (Model-View-ViewModel)
- Biblioteka Reaktywna: ReactiveUI
- Źródło Danych: Plik JSON zarządzany przez asynchroniczny Serwis.

## 🏗️ Architektura Systemu
Aplikacja opiera się na trzech filarach:
- Model: Klasa Vehicle z powiadomieniami o zmianach (RaiseAndSetIfChanged).
- Service Layer: IVehicleService – odizolowana logika zapisu/odczytu danych.
- View Layer: UserControl (VehicleItemView) jako powtarzalny element listy.

## 🚀 Instrukcja dla Załogi (Deployment)
- Analiza: Zapoznaj się z kanałem #📋-brief-biznesowy.
- Planowanie: Przenieś zadania do sekcji GitHub Projects (Kanban).

Uruchomienie:
```
git clone [URL_TWOJEGO_REPOZYTORIUM]
dotnet restore
dotnet run
```

##🛡️ Zasady Misji (SDLC Rules)
- **Clean Code**: Używamy asynchroniczności (Task, async/await) przy operacjach na plikach.
- **Safety First**: System nie może ulec awarii przy braku pliku vehicles.json.
  - Aplikacja musi implementować mechanizm *Graceful Degradation* (Łagodne schodzenie z funkcji). 
  - Oznacza to, że w przypadku błędu krytycznego (np. brak bazy danych, uszkodzony plik JSON), program nie może zostać przerwany przez system operacyjny (crash), lecz musi przejść w bezpieczny tryb awaryjny.
- **Telemetria**: Każdy postęp musi być widoczny na kanale Discord dzięki skonfigurowanemu Webhookowi.





