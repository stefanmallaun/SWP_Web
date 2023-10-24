using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Grundlagen.DB;
using Web_Grundlagen.Models;


namespace Web_Grundlagen.Controllers {
    public class UserController : Controller {
        PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }
        public IActionResult Login() {
            return View(
                new User()

                );
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
        public async Task<IActionResult> Registration(User user) {
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
            //  Überprüfen, ob Pwd und PwdRetype gleich ist
            if(user.Pwd != user.PwdRetype)
            {
                ModelState.AddModelError("Pwd", "Das Passwort muss übereinstimmen!");
            }


            
            

            //  OK -> in DB abspeichern + Erfolgsmeldung
            if(ModelState.IsValid) {
                // Hash the password
                
                user.Pwd = passwordHasher.HashPassword(user, user.Pwd);
                

                // Now, save the hashed password to the database
                using (var dbContext = new DBManager()) // Replace YourDbContext with your actual DbContext class
                {
                    dbContext.Users.Add(user);
                    await SaveToDbAsync(dbContext); // Save the changes to the database
                }

                //  in DB abspeichern (ORM) - Rückgabewert von SaveChangesAsync() verwenden
                //      -> entsprechende Meldungen ausgeben
                ///TODO: DB-Teil
                /*
                    ORM (EF-Core) verwenden

                        1. 3 Pakete installieren done
                        2. DbContext-Klasse programmieren
                                (DbSet<>, OnModelCreating() done
                        3. Fluent API bzw. Annotations (eMail (unique), PwdRetype (sollte nicht in der DB aufscheinen))
                        4. Migrations (2 Befehle) 
                        5. erzeugte DB überprüfens
                        6. Db-Teil in der Registration()-Methode einbauen
                                Pwd sollte gehashed werden (PasswordHasher)
                                => in DB abspeichern
                        7. Login: 
                            a. View erzeugen
                            b. Methode programmieren (Login())
                            c. überprüfen, ob User mit PWD in der DB existiert + Erfolgs- bzw. Fehlermeldung 
                 */


                //  View mit der Erfolgsmeldung anzeigen
                return View("Message", new Message() {
                    Title = "Registrierung",
                    MsgTxt= "Sie wurden erfolgreich registriert!"
                });

            }


            //  nicht OK -> Formular erneut mit den eingeg. Daten anzeigen
            //              inkl Fehlermeldungen
            return View(user);
        }
        public static async Task SaveToDbAsync(DbContext dbContext)
        {

            try
            {
                //  das Speichern erfolgt asynchron (parallel) - auf einem anderen Thread 
                //      => das Programm bleibt responsive (es kann damit weitergearbeitet werden)
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //  loggen
                Console.WriteLine("Fehler: DBUpdate");
            }
            catch (DbUpdateException)
            {
                //  loggen
                Console.WriteLine("Fehler: DBUpdate");
            }

        }
        
        
        [HttpPost]
        public async Task<IActionResult> Login(User u) {
            using (DBManager dbManager = new DBManager()) {
                User userFromDB = await dbManager.Users.FindAsync(u.Email);
                if (userFromDB != null) {
                    u.Name= userFromDB.Name;
                    u.Birthdate= userFromDB.Birthdate;
                    u.PwdRetype = u.Pwd;


                    PasswordVerificationResult passwordResult = passwordHasher.VerifyHashedPassword(u, userFromDB.Pwd, u.Pwd);
                    
                    if(passwordResult == PasswordVerificationResult.Success) {
                        return RedirectToAction("Index", "Home");
                    }
                else {
                    return View("Message", new Message() {
                        Title = "Login",
                        MsgTxt = "Email oder Passwort ist falsch!"
                    });
                }
                }
                
                else {
                    
                        return View("Message", new Message() {
                            Title = "Login",
                            MsgTxt = "Sie müssen sich zuerst registrieren!"
                        });
                
                }
            }
        }
       
        
        public IActionResult ShowOneUser() {
            //  Daten (einen User) vom Controller an die View übergeben
            //  die Userdaten kommen normalerweise aus einer DB-Tabelle

            User u = new User() {
                
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
                
                Name = "Testuser",
                Birthdate = new DateTime(2005, 5, 19),
                Email = "t@gmx.at"
            },
            new User() {
                
                Name = "user 2",
                Birthdate = new DateTime(2010, 5, 1),
                Email = "t2@gmx.at"
            },
            new User() {
                
                Name = "User 3",
                Birthdate = new DateTime(2000, 8, 9),
                Email = "t3@gmx.at"
            }
        };
            return View(users);
        }
        
        public async Task<IActionResult> ShowAllUser() {
            //  Daten (einen Userliste) vom Controller an die View übergeben
            
            using (DBManager dbManager = new DBManager()) {
                List<User> allUserFromDB = await dbManager.Users.ToListAsync<User>();
                return View(allUserFromDB);
            };
            
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            return View(ShowMultipleUser);
        }
        
    }
}
