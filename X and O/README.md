# X si O

O simpla implementare a joului de X si O.
Aplicatia este facuta atribuind fiecarui patrat un script "Clicked" ce memoreaza numarul patratului si poate apela o metoda din
GameManager daca a fost apasat o singura data. 
GameManager-ul are un vector ce se bazeaza pe numarul fiecarui patrat unde memoreaza ce simbol se afla pe fiecare patrat.
Dupa ce un patrat a fost apasat GameManager-ul plaseaza obiectul corespunzator pe patratul apasat si verifica daca jocul a fost castigat
sau daca este remiza si afiseaza un mesaj corespunzator inainte sa reincarcce jocul.
De asemenea verifica daca "escape" a fost apasat pentru a inchide aplicatia.

# X and O

A simple implementation of the X and O game.
The application is made by giving the "Clicked" script to each square. The script has the number of each square and can call a method
from the GameManager if the square has been clicked once.
The GameManager has an array based on each square's number where it keep tracks of what symbol is on which square.
After a square has been pressed the GameManager places the corresponding object on the square and checks if the game has been won or if
it is a draw and prints a message on the screen then restarts the game.
It also checks if "escape" has been pressed in order to close the application.
