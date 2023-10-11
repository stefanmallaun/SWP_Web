using Microsoft.AspNetCore.Mvc;
using Web_Grundlagen.Models;


namespace Web_Grundlagen.Controllers {
    public class UserController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }
        public IActionResult Login() {
            return View();
        }
        public IActionResult Registration() {
            return View(
                new User() {
                    Name = "admin",
                    Birthdate = DateTime.Now
                }
                ); 
        }
        //  User user .. hier sind die Daten des Formulars enthalten
        [HttpPost]
        public IActionResult Registration(User user) {
            //  Formulardaten überprüfen (validieren)
            //  Überprüfung der Formulardaten am Server muss immer stattfinden
            if (user.Name.Trim().Length < 2) {
                ModelState.AddModelError("Name", "Der Name muss min. 2 Zeichen lang sein!");
            }
            if (!user.Email.Contains('@')) {
                ModelState.AddModelError("Email", "Bitte gültige Mail-adresse eingeben!");
            }
            //  Geb-datum ist kein Pflichtfeld & es muss sich in der Vergangenheit befinden
            if((user.Birthdate != DateTime.Now) && (user.Birthdate > DateTime.Now)) {
                ModelState.AddModelError("Birthdate", "Geburtsdatum muss in der Vergangenheit liegen!");

            }
            

            //  OK -> in DB abspeichern + Erfolgsmeldung

            //  nicht OK -> Formular erneut mit den eingeg. Daten anzeigen
            //              inkl Fehlermeldungen
            return View(user);
        }
        public IActionResult ShowOneUser() {
            //  Daten (einen User) vom Controller an die View übergeben
            //  die Userdaten kommen normalerweise aus einer DB-Tabelle

            User u = new User() {
                Id = 1000,
                Name = "Testuser",
                Birthdate = new DateTime(2005, 5, 19),
                Email = "t@gmx.at"
            };
            //  User an die View übergeben
            return View(u);
        }
        public IActionResult ShowMultipleUser() {
            //  Daten (einen Userliste) vom Controller an die View übergeben
            List<User> users = new List<User>() {
            new User() {
                Id = 1000,
                Name = "Testuser",
                Birthdate = new DateTime(2005, 5, 19),
                Email = "t@gmx.at"
            },
            new User() {
                Id = 1001,
                Name = "user 2",
                Birthdate = new DateTime(2010, 5, 1),
                Email = "t2@gmx.at"
            },
            new User() {
                Id = 1002,
                Name = "User 3",
                Birthdate = new DateTime(2000, 8, 9),
                Email = "t3@gmx.at"
            }
        };
            return View(users);
        }
    }
}
