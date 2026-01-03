# Inlämningsuppgift 1 för C#/.NET fortsättningskurs.

### Beskrivning
Uppgiften handlar om att skapa en databas med möjlighet att lagra olika
blogginlägg för ett community där olika användare kan läsa dessa. All
information skall sparas i en databas som du själv skapar. Det skall finnas ett
web api som skapas med ASP.NET web api, genom vilket det finns möjlighet att
kommunicera med databasen (via EF). Det skall gå att komma åt all
funktionalitet genom att anropa alla metoder i web api:et via POSTMAN.

### Kravspec
- Det skall gå att lägga upp ett användarkonto med användarnamn, lösenord
och email. En användare skall kunna logga in. Det skall även gå att uppdatera
samt ta bort ett användarkonto. När en användare loggar in skall användarid
returneras och detta skall sedan användas i andra anrop. Ni väljer om ni vill
göra på det sättet eller använda JWT.

- En inloggad användare skall kunna skapa blogginlägg. Då skickas användarens
id med i anropet och inlägget kopplas till denna användare . Följande
information skall kunna registreras och sparas för ett inlägg: titel, text, och
kategori (typ av inlägg). Är man inte inloggad skall det bara gå att läsa och
söka på inlägg.

- Det skall gå att ange vilken kategori av inlägg det är. Exempel på kategorier
kan vara Träning, Mode, Hälsa mm. Giltiga värden skall vara lagrade i en egen
tabell i databasen.

- Det skall gå att spara ett nytt blogginlägg i databasen men också uppdatera ett
som redan finns. Det skall även gå att ta bort ett inlägg och det skall då
försvinna från databasen. Bara den användare som skapat inlägget skall
kunna ta bort eller uppdatera det.

- En inloggad användare kan kommentera andra användares inlägg. Man skall
inte kunna kommentera sina egna inlägg.

- Det skall gå att söka efter inlägg på titel. Sökningen skall fungera som ett urval
på titel och få träffar på de inlägg som matchar sökvillkoret. Det skall även gå
att söka på kategori.

- Web api:et skall ha stöd för all denna funktionalitet och vara uppbyggt enligt
de principer som vi pratat om på lektionerna. Det skall dokumenteras med
Swagger.

- Lösningen måste göras objektorienterat och följa de riktlinjer som vi går
igenom på lektionerna. Koden skall fungera och web api:et skall gå att köra
utan fel dvs alla metoder skall kunna anropas via POSTMAN och de skall
returnera lämpliga koder och data
