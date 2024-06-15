![alt text](https://vizja.pl/wp-content/themes/divi-child/images/Logo_Akademia_poziom_1.png)


# GameGalaxy

Projekt został opracowany przez: <br>
Kacper Łacniak - 48943 <br>
Igor Dudkowski - 49037 <br>
Jonasz Majcherczyk - 48696 <br>

Docelowymi użytkownikami GameGalaxy są osoby zainteresowane zarządzaniem i przeglądaniem listy gier.

Celem tego projektu jest demonstrowanie zastosowania wzorca projektowego MVC (Model-View-Controller)
przy użyciu języka C# i frameworka .NET oraz pokazanie implementacji podstawowych operacji CRUD (Create, Read, Update, Delete) z przyjaznym interfejsem użytkownika.

## Wstęp:
GameGalaxy to aplikacja webowa, która pozwala użytkownikom zarządzać i przeglądać listę gier. Projekt stosuje wzorzec projektowy MVC, zapewniając wyraźne rozdzielenie warstw logiki i łatwość utrzymania. Użytkownicy mogą dodawać, przeglądać, aktualizować i usuwać wpisy gier, a także przeglądać listę dostępnych gier.

## Technologie:
* **C# i .NET Framework:** Logika backendu oraz architektura MVC zostały zaimplementowane przy użyciu języka C# i frameworka .NET.
* **Bootstrap:** Framework CSS użyty do stworzenia responsywnego i estetycznego interfejsu użytkownika.

## Kroki realizacji projektu:
1. **Planowanie:** Określenie wymagań projektu oraz podział zadań w zespole.
2. **Projektowanie:** Zaprojektowanie architektury aplikacji z wykorzystaniem wzorca MVC.
3. **Implementacja:**<br>
    * Model: Definicja modeli danych oraz operacji CRUD.
    * Kontroler: Implementacja logiki aplikacji oraz obsługa żądań użytkowników.
    * Widok: Tworzenie interfejsu użytkownika z wykorzystaniem Bootstrap.
7. **Testowanie:** Przeprowadzenie testów jednostkowych i integracyjnych.

## Podsumowanie / Wnioski:
GameGalaxy to praktyczny przykład zastosowania wzorca MVC z użyciem języka C# i frameworka .NET.<br> Projekt demonstruje podstawowe operacje CRUD oraz integrację z Bootstrapem dla estetycznego i responsywnego interfejsu użytkownika. Dzięki jasnej architekturze i dobrze zorganizowanemu kodowi, projekt jest łatwy do rozwijania i utrzymania.
Aplikacja może znaleźć zastosowanie w zarządzaniu bazą danych gier, szczególnie dla kolekcjonerów, sprzedawców detalicznych oraz platform e-commerce.
<br>
### Możliwości przyszłej rozbudowy:
* **Logowanie:** System autoryzacji i autentykacji użytkowników.
* **Integracja z API:** Automatyczne pobieranie danych o grach z zewnętrznych źródeł.
* **Interaktywne dashboardy:** Wizualizacja danych o grach.
* **Multijęzyczność:** Obsługa wielu języków.

## Code Sample:
```C# - GamesController
//Operację tworzenia nowej gry w aplikacji
[HttpPost]
// Zapobiega atakom CSRF (Cross-Site Request Forgery)
[ValidateAntiForgeryToken] 
public IActionResult Create([Bind("Name,Producer,Price,Rating,ReleaseDate,ImageUrl")] Game game)
{
    // Sprawdza, czy dane przesłane przez użytkownika są poprawne
    if (ModelState.IsValid) 
    {
        // Pobiera aktualną listę gier z kontekstu danych
        var games = _context.GetGames();
        // Ustawia unikalne Id dla nowej gry
        game.Id = games.Count > 0 ? games.Max(g => g.Id) + 1 : 1; 
        games.Add(game); // Dodaje nową grę do listy
        _context.SaveGames(games); // Zapisuje zaktualizowaną listę gier
        // Przekierowuje użytkownika na stronę z listą gier
        return RedirectToAction(nameof(Index)); 
    }
    // Jeśli dane są niepoprawne, ponownie wyświetla formularz z błędami
    return View(game); 
}

```
```C# - JsonFileContext
//Operację pobierania listy gier z pliku Json
public List<Game> GetGames()
{
    // Sprawdza, czy plik z danymi istnieje
    if (!File.Exists(_filePath))
    {
        // Jeśli plik nie istnieje, zwraca pustą listę gier
        return new List<Game>();
    }

    // Odczytuje dane z pliku
    var jsonData = File.ReadAllText(_filePath);
    // Deserializuje dane JSON do listy obiektów Game; jeśli deserializacja się nie powiedzie, zwraca pustą listę
    return JsonConvert.DeserializeObject<List<Game>>(jsonData) ?? new List<Game>();
}

```
```C# - GamesController
//Operacja Edycji gry
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, [Bind("Id,Name,Producer,Price,Rating,ReleaseDate,ImageUrl")] Game game)
{
    // Sprawdza, czy id w URL i id w modelu są takie same
    if (id != game.Id)
    {
        // Zwraca odpowiedź NotFound, jeśli id nie pasują
        return NotFound();
    }
    // Sprawdza, czy dane przesłane przez użytkownika są poprawne
    if (ModelState.IsValid)
    {
        // Pobiera aktualną listę gier z kontekstu danych
        var games = _context.GetGames();
        // Znajduje indeks gry na podstawie id
        var gameIndex = games.FindIndex(g => g.Id == id);
        // Sprawdza, czy gra została znaleziona
        if (gameIndex == -1)
        {
            // Zwraca odpowiedź NotFound, jeśli gra nie została znaleziona
            return NotFound();
        }
        // Aktualizuje grę w liście na podstawie indeksu
        games[gameIndex] = game;
        // Zapisuje zaktualizowaną listę gier
        _context.SaveGames(games);
        // Przekierowuje użytkownika na stronę z listą gier
        return RedirectToAction(nameof(Index));
    }
    // Jeśli dane są niepoprawne, ponownie wyświetla formularz z błędami
    return View(game);
}
```

## App preview:

### Landing Page

![image](https://github.com/Taidio1/GameGalaxy/assets/115781273/bb78d6c3-d589-410f-8d67-86bc23f5771a)


### Game list


![image](https://github.com/Taidio1/GameGalaxy/assets/115781273/9317f693-ab90-4961-954c-4762be0ee952)


### ADD GAME


![image](https://github.com/Taidio1/GameGalaxy/assets/115781273/62a133c7-ea4b-4819-aa37-735dc273a45c)


### Edit


![image](https://github.com/Taidio1/GameGalaxy/assets/115781273/37393194-0ac7-4eb4-bd58-c69e975d48aa)


### Delete


![image](https://github.com/Taidio1/GameGalaxy/assets/115781273/cf064f29-ad55-4e34-b326-efb05657cbcc)


