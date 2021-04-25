# Adrian Kmak

Zadanie domowe na potrzeby rozmowy kwalifikacyjnej

Założenia

Zaprojektuj i stwórz fragment aplikacji w technologii ASP.NET.MVC, który będzie zarządzał kartoteką 
użytkowników i ich uprawnieniami. Rozwiązanie proszę wysłać na adres tomasz.pierzchala@ibcs.pl

Wymagania:

Baza danych
-SQL Server 2008 lub SQL Server 2012 lub wyższym - może być wersja Express

Tabele
1. Stwórz tabele i zaproponuj typy kolumn.

Użytkownicy
-id
-login
-hasło
-imię
-nazwisko
-pesel
-data urodzenia
-miejsce urodzenia
-stanowisko pracy

Uprawnienia
-id
-kod
-nazwa uprawnienia

2. Dodaj jeszcze jedną tabelę, które powiąże użytkownika z jego uprawnieniami
3. Wykonaj obsługę dodawania, edycji i usuwania danych. Obsłuż również wszystkie wyjątki, np.
   błąd podczas dodawania użytkownika o tym samym numerze Pesel, lub loginie. Preferowane
   jest wykorzystanie ORM.
4. Przykładowe uprawnia (do wprowadzenia na sztywno w bazie danych - nie potrzeba obsługi
   w aplikacji): administracja, dostęp do archiwum, dostęp do kartotek, dostęp do parametrów
   
Aplikacja

Aplikacja powinna być wykonana przy wykorzystaniu Visual Studio 2012 lub nowszym(mogą być w
wersji Express) oraz technologii ASP.NET.MVC

Okienka aplikacji
Głównym okienkiem aplikacji będzie formatka z gridem, gdzie będzie lista użytkowników, oraz
dostępne przyciski dodawania, edycji i usuwania użytkowników. Dodawanie i edycja użytkownikó
powinna odbywać się w nowym okienku, gdzie należy wprowadzić wszystkie dane o użytkowniku i
nadać mu odpowiednie uprawnienia.

Wymagania walidacji
Podczas dodawania i edycji użytkowników system powinien walidować wprowadzane dane i nie
pozwolić na zapisanie pozycji jeżeli pola nie są poprawnie zwalidowane. Wymagania:
-pesel - 11 znaków
-potwierdzenie hasła (identyczne w obydwu polach)
Wymagane pola:
-login
-hasło
-imię
-nazwisko
-pesel
