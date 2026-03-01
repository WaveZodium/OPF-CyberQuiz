using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CyberQuiz.UI.Migrations
{
    /// <inheritdoc />
    public partial class SeedQuizData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Basprinciper och vanliga hot.", "Grundläggande cybersäkerhet" },
                    { 2, "Nätverkssäkerhet och webbsäkerhet.", "Nätverk & webb" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OrderIndex" },
                values: new object[,]
                {
                    { 1, 1, "Starka lösenord och multifaktor.", "Lösenord & MFA", 1 },
                    { 2, 1, "Känna igen bedrägerier.", "Phishing & social engineering", 2 },
                    { 3, 2, "Portar, DNS, brandväggar.", "Nätverksgrunder", 1 },
                    { 4, 2, "HTTPS, cookies, vanliga webbsårbarheter.", "Webbsäkerhet", 2 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Explanation", "OrderIndex", "SubCategoryId", "Text" },
                values: new object[,]
                {
                    { 1, "Längd + variation + inget ord i ordlista är bra.", 1, 1, "Vilket lösenord är starkast?" },
                    { 2, "MFA = Multi-Factor Authentication.", 2, 1, "Vad betyder MFA?" },
                    { 3, "De hjälper dig att ha unika, starka lösenord.", 3, 1, "Varför är lösenordshanterare bra?" },
                    { 4, "Återanvända läckta inloggningar på andra sajter.", 4, 1, "Vad är 'credential stuffing'?" },
                    { 5, "App-baserade engångskoder eller säkerhetsnyckel är bättre.", 5, 1, "Vilken MFA-metod är oftast starkare än SMS?" },
                    { 6, "Brådska + hot + konstig avsändare är vanligt.", 1, 2, "Vilket är ett vanligt tecken på phishing?" },
                    { 7, "Öppna inte länken; verifiera via officiell kanal.", 2, 2, "Vad bör du göra om du får en misstänkt länk i ett mejl?" },
                    { 8, "Riktad phishing mot en specifik person/grupp.", 3, 2, "Vad är 'spear phishing'?" },
                    { 9, "De kan innehålla skadlig kod/makron.", 4, 2, "Varför är bilagor i okända mejl farliga?" },
                    { 10, "Verifiera via en känd, oberoende kontaktväg.", 5, 2, "Vilket är säkrast sätt att kontrollera om ett mejl är äkta?" },
                    { 11, "En logisk adress för tjänster på en host.", 1, 3, "Vad är en port (i nätverkssammanhang)?" },
                    { 12, "Översätter domännamn till IP-adresser.", 2, 3, "Vad gör DNS?" },
                    { 13, "Tillåter/blockerar trafik enligt regler.", 3, 3, "Vad gör en brandvägg (firewall) i enklaste form?" },
                    { 14, "Minsta möjliga behörighet för att göra jobbet.", 4, 3, "Vad innebär 'least privilege'?" },
                    { 15, "HTTPS (HTTP över TLS).", 5, 3, "Vilket protokoll används typiskt för krypterad webbtrafik?" },
                    { 16, "Avlyssning och manipulation av trafik i transit.", 1, 4, "Vad skyddar HTTPS främst mot?" },
                    { 17, "När attacker injicerar script som körs i användarens webbläsare.", 2, 4, "Vad är XSS (Cross-Site Scripting)?" },
                    { 18, "Manipulera SQL-frågor via osanerad input.", 3, 4, "Vad är SQL-injection?" },
                    { 19, "Anti-forgery token / SameSite cookies.", 4, 4, "Vad är en säker åtgärd mot CSRF?" },
                    { 20, "Om DB läcker ska lösenord inte kunna läsas i klartext.", 5, 4, "Varför ska man hasha lösenord i databasen?" }
                });

            migrationBuilder.InsertData(
                table: "AnswerOptions",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 1, false, 1, "Summer2024" },
                    { 2, false, 1, "P@ssw0rd" },
                    { 3, true, 1, "t7!Qv#9zL2@pX5" },
                    { 4, false, 1, "12345678" },
                    { 5, true, 2, "Multi-Factor Authentication" },
                    { 6, false, 2, "Managed File Access" },
                    { 7, false, 2, "Main Firewall Agent" },
                    { 8, false, 2, "Mobile Fast Approval" },
                    { 9, false, 3, "De gör att du kan återanvända samma lösenord överallt" },
                    { 10, true, 3, "De genererar och lagrar unika, starka lösenord" },
                    { 11, false, 3, "De stänger av MFA" },
                    { 12, false, 3, "De gör lösenord synliga för alla i teamet" },
                    { 13, false, 4, "Gissa lösenord genom att prova alla kombinationer" },
                    { 14, true, 4, "Återanvända läckta inloggningar på andra tjänster" },
                    { 15, false, 4, "Skicka skadliga bilagor via e-post" },
                    { 16, false, 4, "Avlyssna Wi-Fi med en router" },
                    { 17, false, 5, "SMS-kod" },
                    { 18, true, 5, "App-baserad engångskod eller säkerhetsnyckel" },
                    { 19, false, 5, "Lösenordsfråga (”mors flicknamn”)" },
                    { 20, false, 5, "Inget extra skydd behövs" },
                    { 21, false, 6, "Mejlet har perfekt grammatik och korrekt domän" },
                    { 22, true, 6, "Brådska/hot och en länk som ser konstig ut" },
                    { 23, false, 6, "Det kommer alltid från en intern adress" },
                    { 24, false, 6, "Det innehåller aldrig länkar" },
                    { 25, false, 7, "Klicka snabbt för att se vad det är" },
                    { 26, false, 7, "Svara och be om mer information" },
                    { 27, true, 7, "Verifiera via officiell kanal och undvik länken" },
                    { 28, false, 7, "Skicka länken till alla kollegor" },
                    { 29, false, 8, "Massutskick till hela internet" },
                    { 30, true, 8, "Riktad phishing mot en specifik person eller organisation" },
                    { 31, false, 8, "Phishing via telefonledning (analog)" },
                    { 32, false, 8, "Ett antivirusprogram" },
                    { 33, true, 9, "Bilagor kan innehålla skadlig kod/makron" },
                    { 34, false, 9, "Bilagor kan inte skada datorer" },
                    { 35, false, 9, "Bilagor är alltid krypterade" },
                    { 36, false, 9, "PDF-filer är alltid säkra" },
                    { 37, false, 10, "Lita på avsändarnamnet som visas" },
                    { 38, true, 10, "Verifiera via en känd kontaktväg (t.ex. ring växeln)" },
                    { 39, false, 10, "Klicka och logga in för att kontrollera" },
                    { 40, false, 10, "Svar direkt och fråga om det är äkta" },
                    { 41, false, 11, "En fysisk kabeltyp" },
                    { 42, true, 11, "En logisk adress för en tjänst på en host" },
                    { 43, false, 11, "Ett wifi-lösenord" },
                    { 44, false, 11, "Ett operativsystem" },
                    { 45, false, 12, "Krypterar all trafik automatiskt" },
                    { 46, true, 12, "Översätter domännamn till IP-adresser" },
                    { 47, false, 12, "Blockerar spammejl" },
                    { 48, false, 12, "Skapar användarkonton" },
                    { 49, true, 13, "Tillåter/blockerar trafik enligt regler" },
                    { 50, false, 13, "Skapar starka lösenord" },
                    { 51, false, 13, "Ökar internet-hastigheten" },
                    { 52, false, 13, "Rensar cookies" },
                    { 53, false, 14, "Alla ska ha admin för att slippa problem" },
                    { 54, true, 14, "Minsta möjliga behörighet för att göra jobbet" },
                    { 55, false, 14, "Ge alltid full åtkomst i testmiljö" },
                    { 56, false, 14, "Blockera alla användare" },
                    { 57, false, 15, "FTP" },
                    { 58, false, 15, "HTTP" },
                    { 59, true, 15, "HTTPS" },
                    { 60, false, 15, "Telnet" },
                    { 61, false, 16, "Att stoppa all phishing" },
                    { 62, true, 16, "Avlyssning och manipulation av trafik i transit" },
                    { 63, false, 16, "Att göra lösenord onödiga" },
                    { 64, false, 16, "Att radera cookies automatiskt" },
                    { 65, false, 17, "När databasen kraschar" },
                    { 66, true, 17, "När attacker injicerar script som körs i användarens webbläsare" },
                    { 67, false, 17, "När nätverket är långsamt" },
                    { 68, false, 17, "När användaren glömmer lösenordet" },
                    { 69, false, 18, "När man använder SQL Server" },
                    { 70, true, 18, "Manipulera SQL-frågor via osanerad input" },
                    { 71, false, 18, "När man krypterar en tabell" },
                    { 72, false, 18, "När man indexerar en kolumn" },
                    { 73, true, 19, "Anti-forgery token / SameSite cookies" },
                    { 74, false, 19, "Att slå av HTTPS" },
                    { 75, false, 19, "Att spara lösenord i localStorage" },
                    { 76, false, 19, "Att använda längre URL:er" },
                    { 77, false, 20, "Så att lösenord kan läsas enkelt vid support" },
                    { 78, true, 20, "Om DB läcker ska lösenord inte kunna läsas i klartext" },
                    { 79, false, 20, "För att göra inloggning långsammare" },
                    { 80, false, 20, "För att slippa använda MFA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
