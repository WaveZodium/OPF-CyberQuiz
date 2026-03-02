using CyberQuiz.Infrastructure.Entities;

namespace CyberQuiz.Infrastructure.Data.Seed;

public static class QuizSeedData
{
    // -------- Lists (lätt att bygga ut) --------

    public static readonly List<Category> CategoriesList =
    [
        new Category { Id = 1, Name = "Grundläggande cybersäkerhet", Description = "Basprinciper och vanliga hot." },
        new Category { Id = 2, Name = "Nätverk & webb", Description = "Nätverkssäkerhet och webbsäkerhet." }
    ];

    public static readonly List<SubCategory> SubCategoriesList =
    [
        new SubCategory { Id = 1, CategoryId = 1, Name = "Lösenord & MFA", Description = "Starka lösenord och multifaktor.", OrderIndex = 1 },
        new SubCategory { Id = 2, CategoryId = 1, Name = "Phishing & social engineering", Description = "Känna igen bedrägerier.", OrderIndex = 2 },

        new SubCategory { Id = 3, CategoryId = 2, Name = "Nätverksgrunder", Description = "Portar, DNS, brandväggar.", OrderIndex = 1 },
        new SubCategory { Id = 4, CategoryId = 2, Name = "Webbsäkerhet", Description = "HTTPS, cookies, vanliga webbsårbarheter.", OrderIndex = 2 }
    ];

    public static readonly List<Question> QuestionsList =
    [
        // SubCategory 1: Lösenord & MFA
        new Question { Id = 1,  SubCategoryId = 1, OrderIndex = 1, Text = "Vilket lösenord är starkast?", Explanation = "Längd + variation + inget ord i ordlista är bra." },
        new Question { Id = 2,  SubCategoryId = 1, OrderIndex = 2, Text = "Vad betyder MFA?", Explanation = "MFA = Multi-Factor Authentication." },
        new Question { Id = 3,  SubCategoryId = 1, OrderIndex = 3, Text = "Varför är lösenordshanterare bra?", Explanation = "De hjälper dig att ha unika, starka lösenord." },
        new Question { Id = 4,  SubCategoryId = 1, OrderIndex = 4, Text = "Vad är 'credential stuffing'?", Explanation = "Återanvända läckta inloggningar på andra sajter." },
        new Question { Id = 5,  SubCategoryId = 1, OrderIndex = 5, Text = "Vilken MFA-metod är oftast starkare än SMS?", Explanation = "App-baserade engångskoder eller säkerhetsnyckel är bättre." },

        // SubCategory 2: Phishing
        new Question { Id = 6,  SubCategoryId = 2, OrderIndex = 1, Text = "Vilket är ett vanligt tecken på phishing?", Explanation = "Brådska + hot + konstig avsändare är vanligt." },
        new Question { Id = 7,  SubCategoryId = 2, OrderIndex = 2, Text = "Vad bör du göra om du får en misstänkt länk i ett mejl?", Explanation = "Öppna inte länken; verifiera via officiell kanal." },
        new Question { Id = 8,  SubCategoryId = 2, OrderIndex = 3, Text = "Vad är 'spear phishing'?", Explanation = "Riktad phishing mot en specifik person/grupp." },
        new Question { Id = 9,  SubCategoryId = 2, OrderIndex = 4, Text = "Varför är bilagor i okända mejl farliga?", Explanation = "De kan innehålla skadlig kod/makron." },
        new Question { Id = 10, SubCategoryId = 2, OrderIndex = 5, Text = "Vilket är säkrast sätt att kontrollera om ett mejl är äkta?", Explanation = "Verifiera via en känd, oberoende kontaktväg." },

        // SubCategory 3: Nätverksgrunder
        new Question { Id = 11, SubCategoryId = 3, OrderIndex = 1, Text = "Vad är en port (i nätverkssammanhang)?", Explanation = "En logisk adress för tjänster på en host." },
        new Question { Id = 12, SubCategoryId = 3, OrderIndex = 2, Text = "Vad gör DNS?", Explanation = "Översätter domännamn till IP-adresser." },
        new Question { Id = 13, SubCategoryId = 3, OrderIndex = 3, Text = "Vad gör en brandvägg (firewall) i enklaste form?", Explanation = "Tillåter/blockerar trafik enligt regler." },
        new Question { Id = 14, SubCategoryId = 3, OrderIndex = 4, Text = "Vad innebär 'least privilege'?", Explanation = "Minsta möjliga behörighet för att göra jobbet." },
        new Question { Id = 15, SubCategoryId = 3, OrderIndex = 5, Text = "Vilket protokoll används typiskt för krypterad webbtrafik?", Explanation = "HTTPS (HTTP över TLS)." },

        // SubCategory 4: Webbsäkerhet
        new Question { Id = 16, SubCategoryId = 4, OrderIndex = 1, Text = "Vad skyddar HTTPS främst mot?", Explanation = "Avlyssning och manipulation av trafik i transit." },
        new Question { Id = 17, SubCategoryId = 4, OrderIndex = 2, Text = "Vad är XSS (Cross-Site Scripting)?", Explanation = "När attacker injicerar script som körs i användarens webbläsare." },
        new Question { Id = 18, SubCategoryId = 4, OrderIndex = 3, Text = "Vad är SQL-injection?", Explanation = "Manipulera SQL-frågor via osanerad input." },
        new Question { Id = 19, SubCategoryId = 4, OrderIndex = 4, Text = "Vad är en säker åtgärd mot CSRF?", Explanation = "Anti-forgery token / SameSite cookies." },
        new Question { Id = 20, SubCategoryId = 4, OrderIndex = 5, Text = "Varför ska man hasha lösenord i databasen?", Explanation = "Om DB läcker ska lösenord inte kunna läsas i klartext." }
    ];

    public static readonly List<AnswerOption> AnswerOptionsList =
    [
        // Q1
        new AnswerOption { Id = 1,  QuestionId = 1, Text = "Summer2024", IsCorrect = false },
        new AnswerOption { Id = 2,  QuestionId = 1, Text = "P@ssw0rd", IsCorrect = false },
        new AnswerOption { Id = 3,  QuestionId = 1, Text = "t7!Qv#9zL2@pX5", IsCorrect = true },
        new AnswerOption { Id = 4,  QuestionId = 1, Text = "12345678", IsCorrect = false },

        // Q2
        new AnswerOption { Id = 5,  QuestionId = 2, Text = "Multi-Factor Authentication", IsCorrect = true },
        new AnswerOption { Id = 6,  QuestionId = 2, Text = "Managed File Access", IsCorrect = false },
        new AnswerOption { Id = 7,  QuestionId = 2, Text = "Main Firewall Agent", IsCorrect = false },
        new AnswerOption { Id = 8,  QuestionId = 2, Text = "Mobile Fast Approval", IsCorrect = false },

        // Q3
        new AnswerOption { Id = 9,  QuestionId = 3, Text = "De gör att du kan återanvända samma lösenord överallt", IsCorrect = false },
        new AnswerOption { Id = 10, QuestionId = 3, Text = "De genererar och lagrar unika, starka lösenord", IsCorrect = true },
        new AnswerOption { Id = 11, QuestionId = 3, Text = "De stänger av MFA", IsCorrect = false },
        new AnswerOption { Id = 12, QuestionId = 3, Text = "De gör lösenord synliga för alla i teamet", IsCorrect = false },

        // Q4
        new AnswerOption { Id = 13, QuestionId = 4, Text = "Gissa lösenord genom att prova alla kombinationer", IsCorrect = false },
        new AnswerOption { Id = 14, QuestionId = 4, Text = "Återanvända läckta inloggningar på andra tjänster", IsCorrect = true },
        new AnswerOption { Id = 15, QuestionId = 4, Text = "Skicka skadliga bilagor via e-post", IsCorrect = false },
        new AnswerOption { Id = 16, QuestionId = 4, Text = "Avlyssna Wi-Fi med en router", IsCorrect = false },

        // Q5
        new AnswerOption { Id = 17, QuestionId = 5, Text = "SMS-kod", IsCorrect = false },
        new AnswerOption { Id = 18, QuestionId = 5, Text = "App-baserad engångskod eller säkerhetsnyckel", IsCorrect = true },
        new AnswerOption { Id = 19, QuestionId = 5, Text = "Lösenordsfråga (”mors flicknamn”)", IsCorrect = false },
        new AnswerOption { Id = 20, QuestionId = 5, Text = "Inget extra skydd behövs", IsCorrect = false },

        // Q6
        new AnswerOption { Id = 21, QuestionId = 6, Text = "Mejlet har perfekt grammatik och korrekt domän", IsCorrect = false },
        new AnswerOption { Id = 22, QuestionId = 6, Text = "Brådska/hot och en länk som ser konstig ut", IsCorrect = true },
        new AnswerOption { Id = 23, QuestionId = 6, Text = "Det kommer alltid från en intern adress", IsCorrect = false },
        new AnswerOption { Id = 24, QuestionId = 6, Text = "Det innehåller aldrig länkar", IsCorrect = false },

        // Q7
        new AnswerOption { Id = 25, QuestionId = 7, Text = "Klicka snabbt för att se vad det är", IsCorrect = false },
        new AnswerOption { Id = 26, QuestionId = 7, Text = "Svara och be om mer information", IsCorrect = false },
        new AnswerOption { Id = 27, QuestionId = 7, Text = "Verifiera via officiell kanal och undvik länken", IsCorrect = true },
        new AnswerOption { Id = 28, QuestionId = 7, Text = "Skicka länken till alla kollegor", IsCorrect = false },

        // Q8
        new AnswerOption { Id = 29, QuestionId = 8, Text = "Massutskick till hela internet", IsCorrect = false },
        new AnswerOption { Id = 30, QuestionId = 8, Text = "Riktad phishing mot en specifik person eller organisation", IsCorrect = true },
        new AnswerOption { Id = 31, QuestionId = 8, Text = "Phishing via telefonledning (analog)", IsCorrect = false },
        new AnswerOption { Id = 32, QuestionId = 8, Text = "Ett antivirusprogram", IsCorrect = false },

        // Q9
        new AnswerOption { Id = 33, QuestionId = 9, Text = "Bilagor kan innehålla skadlig kod/makron", IsCorrect = true },
        new AnswerOption { Id = 34, QuestionId = 9, Text = "Bilagor kan inte skada datorer", IsCorrect = false },
        new AnswerOption { Id = 35, QuestionId = 9, Text = "Bilagor är alltid krypterade", IsCorrect = false },
        new AnswerOption { Id = 36, QuestionId = 9, Text = "PDF-filer är alltid säkra", IsCorrect = false },

        // Q10
        new AnswerOption { Id = 37, QuestionId = 10, Text = "Lita på avsändarnamnet som visas", IsCorrect = false },
        new AnswerOption { Id = 38, QuestionId = 10, Text = "Verifiera via en känd kontaktväg (t.ex. ring växeln)", IsCorrect = true },
        new AnswerOption { Id = 39, QuestionId = 10, Text = "Klicka och logga in för att kontrollera", IsCorrect = false },
        new AnswerOption { Id = 40, QuestionId = 10, Text = "Svar direkt och fråga om det är äkta", IsCorrect = false },

        // Q11
        new AnswerOption { Id = 41, QuestionId = 11, Text = "En fysisk kabeltyp", IsCorrect = false },
        new AnswerOption { Id = 42, QuestionId = 11, Text = "En logisk adress för en tjänst på en host", IsCorrect = true },
        new AnswerOption { Id = 43, QuestionId = 11, Text = "Ett wifi-lösenord", IsCorrect = false },
        new AnswerOption { Id = 44, QuestionId = 11, Text = "Ett operativsystem", IsCorrect = false },

        // Q12
        new AnswerOption { Id = 45, QuestionId = 12, Text = "Krypterar all trafik automatiskt", IsCorrect = false },
        new AnswerOption { Id = 46, QuestionId = 12, Text = "Översätter domännamn till IP-adresser", IsCorrect = true },
        new AnswerOption { Id = 47, QuestionId = 12, Text = "Blockerar spammejl", IsCorrect = false },
        new AnswerOption { Id = 48, QuestionId = 12, Text = "Skapar användarkonton", IsCorrect = false },

        // Q13
        new AnswerOption { Id = 49, QuestionId = 13, Text = "Tillåter/blockerar trafik enligt regler", IsCorrect = true },
        new AnswerOption { Id = 50, QuestionId = 13, Text = "Skapar starka lösenord", IsCorrect = false },
        new AnswerOption { Id = 51, QuestionId = 13, Text = "Ökar internet-hastigheten", IsCorrect = false },
        new AnswerOption { Id = 52, QuestionId = 13, Text = "Rensar cookies", IsCorrect = false },

        // Q14
        new AnswerOption { Id = 53, QuestionId = 14, Text = "Alla ska ha admin för att slippa problem", IsCorrect = false },
        new AnswerOption { Id = 54, QuestionId = 14, Text = "Minsta möjliga behörighet för att göra jobbet", IsCorrect = true },
        new AnswerOption { Id = 55, QuestionId = 14, Text = "Ge alltid full åtkomst i testmiljö", IsCorrect = false },
        new AnswerOption { Id = 56, QuestionId = 14, Text = "Blockera alla användare", IsCorrect = false },

        // Q15
        new AnswerOption { Id = 57, QuestionId = 15, Text = "FTP", IsCorrect = false },
        new AnswerOption { Id = 58, QuestionId = 15, Text = "HTTP", IsCorrect = false },
        new AnswerOption { Id = 59, QuestionId = 15, Text = "HTTPS", IsCorrect = true },
        new AnswerOption { Id = 60, QuestionId = 15, Text = "Telnet", IsCorrect = false },

        // Q16
        new AnswerOption { Id = 61, QuestionId = 16, Text = "Att stoppa all phishing", IsCorrect = false },
        new AnswerOption { Id = 62, QuestionId = 16, Text = "Avlyssning och manipulation av trafik i transit", IsCorrect = true },
        new AnswerOption { Id = 63, QuestionId = 16, Text = "Att göra lösenord onödiga", IsCorrect = false },
        new AnswerOption { Id = 64, QuestionId = 16, Text = "Att radera cookies automatiskt", IsCorrect = false },

        // Q17
        new AnswerOption { Id = 65, QuestionId = 17, Text = "När databasen kraschar", IsCorrect = false },
        new AnswerOption { Id = 66, QuestionId = 17, Text = "När attacker injicerar script som körs i användarens webbläsare", IsCorrect = true },
        new AnswerOption { Id = 67, QuestionId = 17, Text = "När nätverket är långsamt", IsCorrect = false },
        new AnswerOption { Id = 68, QuestionId = 17, Text = "När användaren glömmer lösenordet", IsCorrect = false },

        // Q18
        new AnswerOption { Id = 69, QuestionId = 18, Text = "När man använder SQL Server", IsCorrect = false },
        new AnswerOption { Id = 70, QuestionId = 18, Text = "Manipulera SQL-frågor via osanerad input", IsCorrect = true },
        new AnswerOption { Id = 71, QuestionId = 18, Text = "När man krypterar en tabell", IsCorrect = false },
        new AnswerOption { Id = 72, QuestionId = 18, Text = "När man indexerar en kolumn", IsCorrect = false },

        // Q19
        new AnswerOption { Id = 73, QuestionId = 19, Text = "Anti-forgery token / SameSite cookies", IsCorrect = true },
        new AnswerOption { Id = 74, QuestionId = 19, Text = "Att slå av HTTPS", IsCorrect = false },
        new AnswerOption { Id = 75, QuestionId = 19, Text = "Att spara lösenord i localStorage", IsCorrect = false },
        new AnswerOption { Id = 76, QuestionId = 19, Text = "Att använda längre URL:er", IsCorrect = false },

        // Q20
        new AnswerOption { Id = 77, QuestionId = 20, Text = "Så att lösenord kan läsas enkelt vid support", IsCorrect = false },
        new AnswerOption { Id = 78, QuestionId = 20, Text = "Om DB läcker ska lösenord inte kunna läsas i klartext", IsCorrect = true },
        new AnswerOption { Id = 79, QuestionId = 20, Text = "För att göra inloggning långsammare", IsCorrect = false },
        new AnswerOption { Id = 80, QuestionId = 20, Text = "För att slippa använda MFA", IsCorrect = false }
    ];

    // -------- Arrays (smidigt för HasData) --------

    public static Category[] Categories => CategoriesList.ToArray();
    public static SubCategory[] SubCategories => SubCategoriesList.ToArray();
    public static Question[] Questions => QuestionsList.ToArray();
    public static AnswerOption[] AnswerOptions => AnswerOptionsList.ToArray();
}