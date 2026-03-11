using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CyberQuiz.UI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuizSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Text",
                value: "They let you reuse the same password everywhere");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Text",
                value: "They generate and store unique, strong passwords");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Text",
                value: "They disable MFA");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Text",
                value: "They make passwords visible to everyone");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Text",
                value: "Guessing passwords by trying every combination");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Text",
                value: "Reusing leaked login credentials on other services");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Text",
                value: "Sending malicious attachments by email");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Text",
                value: "Intercepting Wi-Fi traffic with a router");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Text",
                value: "SMS code");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Text",
                value: "Authenticator app or security key");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Text",
                value: "Security question");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Text",
                value: "No extra protection is needed");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Text",
                value: "The email has perfect grammar and a correct domain");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 22,
                column: "Text",
                value: "Urgency or threats and a suspicious-looking link");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Text",
                value: "It always comes from an internal address");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 24,
                column: "Text",
                value: "It never contains links");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 25,
                column: "Text",
                value: "Click quickly to see what it is");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Text",
                value: "Reply and ask for more information");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 27,
                column: "Text",
                value: "Verify through an official channel and avoid the link");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 28,
                column: "Text",
                value: "Forward the link to everyone");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 29,
                column: "Text",
                value: "A mass email to the whole internet");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Text",
                value: "Targeted phishing aimed at a specific person or organization");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Text",
                value: "Phishing through an analog phone line");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Text",
                value: "An antivirus program");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 33,
                column: "Text",
                value: "Attachments may contain malware or malicious macros");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 34,
                column: "Text",
                value: "Attachments cannot harm computers");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 35,
                column: "Text",
                value: "Attachments are always encrypted");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 36,
                column: "Text",
                value: "PDF files are always safe");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 37,
                column: "Text",
                value: "Trust the displayed sender name");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 38,
                column: "Text",
                value: "Verify through a known contact method");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 39,
                column: "Text",
                value: "Click and log in to check");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 40,
                column: "Text",
                value: "Reply and ask if it is real");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Unknown sites may offer malware-infected files" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "Unknown sites are always faster" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 43,
                column: "Text",
                value: "Downloads from unknown sites are automatically safe");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 44,
                column: "Text",
                value: "Browsers will always remove all threats");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 45,
                column: "Text",
                value: "Open the link immediately");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 46,
                column: "Text",
                value: "Check where the link actually leads");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 47,
                column: "Text",
                value: "Turn off browser warnings");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 48,
                column: "Text",
                value: "Assume all short links are safe");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "Pirated software is safer because many people use it" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Pirated software may contain malware or backdoors" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 51,
                column: "Text",
                value: "Pirated software is always open source");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 52,
                column: "Text",
                value: "Pirated software updates automatically from trusted vendors");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Unexpected pop-ups and suspicious domain names" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "A clean design and readable text" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 55,
                column: "Text",
                value: "A login page from a known company");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 56,
                column: "Text",
                value: "A site using images and colors");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 57,
                column: "Text",
                value: "Ignore the warning and continue");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Leave the site instead of proceeding" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "Disable browser protection permanently" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 60,
                column: "Text",
                value: "Install whatever the site suggests");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 61,
                column: "Text",
                value: "A physical cable type");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 62,
                column: "Text",
                value: "A logical endpoint for a network service on a device");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 63,
                column: "Text",
                value: "A Wi-Fi password");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 64,
                column: "Text",
                value: "An operating system");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 65,
                column: "Text",
                value: "It encrypts all traffic automatically");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 66,
                column: "Text",
                value: "It translates domain names into IP addresses");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 67,
                column: "Text",
                value: "It blocks spam emails");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 68,
                column: "Text",
                value: "It creates user accounts");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "It allows or blocks traffic based on rules" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "It creates strong passwords" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 71,
                column: "Text",
                value: "It increases internet speed");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 72,
                column: "Text",
                value: "It deletes cookies");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "Give everyone admin access" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Provide only the minimum access needed" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 75,
                column: "Text",
                value: "Block all users permanently");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 76,
                column: "Text",
                value: "Use the same account for everyone");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 77,
                column: "Text",
                value: "FTP");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "HTTP" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "HTTPS" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 80,
                column: "Text",
                value: "Telnet");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Core security principles and common threats.", "Basic Cybersecurity" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Networking, web security, and internet safety.", "Network & Web Security" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 3, "Authentication, authorization, and user access.", "Identity & Access Management" },
                    { 4, "Protecting devices, operating systems, and endpoints.", "System & Device Security" }
                });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "A strong password is long, unique, and hard to guess.", "Which password is the strongest?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "MFA means Multi-Factor Authentication.", "What does MFA stand for?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "They help users create and store strong, unique passwords.", "Why are password managers useful?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Attackers reuse leaked login details on other services.", "What is credential stuffing?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Authenticator apps or hardware security keys are generally stronger than SMS.", "Which MFA method is usually stronger than SMS?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Urgency, threats, and suspicious links are common warning signs.", "Which is a common sign of phishing?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Do not open the link; verify through an official channel.", "What should you do if you receive a suspicious link in an email?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Spear phishing is targeted phishing aimed at a specific person or group.", "What is spear phishing?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "They may contain malware or malicious macros.", "Why are attachments in unknown emails risky?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Use a known, independent contact method.", "What is the safest way to verify whether an email is legitimate?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Unknown sources may distribute malicious or modified files.", "Why should you avoid downloading files from unknown websites?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Check the destination carefully before opening it.", "What is a safer habit before clicking a link?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "It may contain malware or hidden backdoors.", "Why is pirated software risky?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Unexpected pop-ups, fake alerts, or suspicious domain names are warning signs.", "What is one warning sign of a malicious website?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "The safest action is usually to leave the site.", "What should you do if a browser warns that a site is unsafe?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "A port is a logical endpoint for a network service on a device.", "What is a port in networking?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "DNS translates domain names into IP addresses.", "What does DNS do?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "A firewall allows or blocks traffic based on rules.", "What does a firewall do in simple terms?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Users should only have the access they actually need.", "What does the principle of least privilege mean?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "HTTPS is HTTP secured with TLS.", "Which protocol is typically used for encrypted web traffic?" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Strong passwords and multi-factor authentication.", "Passwords & MFA" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Recognizing scams and manipulation.", "Phishing & Social Engineering" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "OrderIndex" },
                values: new object[] { 1, "Avoiding risky links, files, and websites.", "Safe Browsing & Downloads", 3 });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "OrderIndex" },
                values: new object[] { "Ports, DNS, firewalls, and protocols.", "Network Fundamentals", 1 });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OrderIndex" },
                values: new object[,]
                {
                    { 5, 2, "HTTPS, cookies, and common web vulnerabilities.", "Web Security", 2 },
                    { 6, 2, "Email safety and domain-related protections.", "Email & DNS Security", 3 }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Explanation", "OrderIndex", "SubCategoryId", "Text" },
                values: new object[,]
                {
                    { 21, "It helps protect data from interception and tampering in transit.", 1, 5, "What does HTTPS mainly protect against?" },
                    { 22, "XSS happens when attackers inject scripts into pages viewed by other users.", 2, 5, "What is XSS (Cross-Site Scripting)?" },
                    { 23, "SQL injection manipulates database queries through unsafe input.", 3, 5, "What is SQL injection?" },
                    { 24, "Anti-forgery tokens and SameSite cookies help reduce CSRF risk.", 4, 5, "Which is a common defense against CSRF?" },
                    { 25, "If the database leaks, hashed passwords are harder to recover than plain text ones.", 5, 5, "Why should passwords be hashed in a database?" },
                    { 26, "Spoofing can trick users into trusting a fake sender.", 1, 6, "Why is email spoofing dangerous?" },
                    { 27, "DNS helps users reach websites by translating names into IP addresses.", 2, 6, "What does DNS help users do?" },
                    { 28, "Unexpected links may lead to phishing or malware.", 3, 6, "Why should users be cautious with links in unexpected emails?" },
                    { 29, "Small spelling changes in the domain name can indicate fraud.", 4, 6, "What is one sign that an email domain may be fake?" },
                    { 30, "Type the address manually or use a saved bookmark instead of clicking the email link.", 5, 6, "What is the safest way to open an important website after receiving an email about it?" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "OrderIndex" },
                values: new object[,]
                {
                    { 7, 3, "How login and identity verification work.", "Authentication Basics", 1 },
                    { 8, 3, "Permissions and limiting access.", "Authorization & Least Privilege", 2 },
                    { 9, 3, "Managing users and access levels.", "Accounts, Roles & Permissions", 3 },
                    { 10, 4, "Basic operating system protection.", "Operating System Security", 1 },
                    { 11, 4, "Keeping systems secure through updates.", "Updates & Patch Management", 2 },
                    { 12, 4, "Protecting devices from malicious software.", "Malware & Endpoint Protection", 3 }
                });

            migrationBuilder.InsertData(
                table: "AnswerOptions",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 81, false, 21, "It stops all phishing attacks" },
                    { 82, true, 21, "It protects against interception and tampering in transit" },
                    { 83, false, 21, "It makes passwords unnecessary" },
                    { 84, false, 21, "It automatically deletes cookies" },
                    { 85, false, 22, "When the database crashes" },
                    { 86, true, 22, "When attackers inject scripts that run in another user's browser" },
                    { 87, false, 22, "When the network is slow" },
                    { 88, false, 22, "When a user forgets a password" },
                    { 89, false, 23, "Using SQL Server normally" },
                    { 90, true, 23, "Manipulating database queries through unsafe input" },
                    { 91, false, 23, "Encrypting a table" },
                    { 92, false, 23, "Indexing a column" },
                    { 93, true, 24, "Anti-forgery tokens and SameSite cookies" },
                    { 94, false, 24, "Turning off HTTPS" },
                    { 95, false, 24, "Saving passwords in localStorage" },
                    { 96, false, 24, "Using longer URLs" },
                    { 97, false, 25, "So support staff can read passwords easily" },
                    { 98, true, 25, "So leaked database contents do not expose plain-text passwords" },
                    { 99, false, 25, "To make login slower" },
                    { 100, false, 25, "To avoid using MFA" },
                    { 101, true, 26, "It helps users trust fake senders" },
                    { 102, false, 26, "It makes all email encrypted" },
                    { 103, false, 26, "It prevents phishing completely" },
                    { 104, false, 26, "It only affects internal mail systems" },
                    { 105, true, 27, "It translates names into IP addresses" },
                    { 106, false, 27, "It creates email attachments" },
                    { 107, false, 27, "It scans devices for malware" },
                    { 108, false, 27, "It resets passwords" },
                    { 109, true, 28, "Unexpected links may lead to phishing or malware" },
                    { 110, false, 28, "Unexpected links are always internal" },
                    { 111, false, 28, "Unexpected links are safe if the email looks formal" },
                    { 112, false, 28, "Unexpected links cannot be dangerous on mobile devices" },
                    { 113, true, 29, "Small spelling changes in the domain" },
                    { 114, false, 29, "The sender uses punctuation" },
                    { 115, false, 29, "The email contains a logo" },
                    { 116, false, 29, "The message is short" },
                    { 117, false, 30, "Click the email link immediately" },
                    { 118, true, 30, "Type the address manually or use a bookmark" },
                    { 119, false, 30, "Disable browser security checks first" },
                    { 120, false, 30, "Forward the email before visiting the site" }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Explanation", "OrderIndex", "SubCategoryId", "Text" },
                values: new object[,]
                {
                    { 31, "Authentication is the process of verifying who a user is.", 1, 7, "What is authentication?" },
                    { 32, "A password is a classic authentication factor based on knowledge.", 2, 7, "Which is an example of something you know?" },
                    { 33, "A security key or phone can be an ownership factor.", 3, 7, "Which is an example of something you have?" },
                    { 34, "It is harder for attackers to compromise more than one factor.", 4, 7, "Why is using multiple authentication factors more secure?" },
                    { 35, "Answers may be easy to guess or find online.", 5, 7, "What is a common weakness of security questions?" },
                    { 36, "Authorization determines what an authenticated user is allowed to do.", 1, 8, "What is authorization?" },
                    { 37, "It reduces damage if an account is misused or compromised.", 2, 8, "Why is least privilege important?" },
                    { 38, "Excessive privileges increase security risk and the chance of mistakes.", 3, 8, "What can happen if too many users have admin rights?" },
                    { 39, "Permissions should be reviewed regularly and when roles change.", 4, 8, "When should permissions be reviewed?" },
                    { 40, "Start with minimal access and grant more only when needed.", 5, 8, "What is a safer default for new accounts?" },
                    { 41, "A role is a group of permissions assigned based on responsibilities.", 1, 9, "What is a role in access management?" },
                    { 42, "Shared accounts reduce accountability and make auditing harder.", 2, 9, "Why should shared accounts usually be avoided?" },
                    { 43, "Their access should be removed promptly.", 3, 9, "What should happen to access when an employee leaves?" },
                    { 44, "It helps ensure people only access what they need for their tasks.", 4, 9, "Why is it useful to separate user roles?" },
                    { 45, "Use them only for admin tasks, not everyday work.", 5, 9, "What is a good practice for privileged accounts?" },
                    { 46, "It prevents unauthorized access while you are away.", 1, 10, "Why should you lock your computer when leaving it unattended?" },
                    { 47, "It reduces the impact of mistakes and malware.", 2, 10, "What is one benefit of using a standard user account instead of an admin account for daily work?" },
                    { 48, "It helps protect data if the device is lost or stolen.", 3, 10, "Why is disk encryption useful on laptops?" },
                    { 49, "Only install software from trusted and verified sources.", 4, 10, "What is a secure habit when installing software?" },
                    { 50, "They help defend the system against common threats.", 5, 10, "Why should you avoid disabling built-in security features?" },
                    { 51, "Updates often fix known vulnerabilities.", 1, 11, "Why are software updates important for security?" },
                    { 52, "A patch is an update that fixes a vulnerability or security issue.", 2, 11, "What is a security patch?" },
                    { 53, "Attackers may exploit flaws that already have public fixes.", 3, 11, "Why is delaying important updates risky?" },
                    { 54, "Automatic updates are usually safer than ignoring updates completely.", 4, 11, "Which is safer: automatic updates or never updating?" },
                    { 55, "All supported devices and software should be updated.", 5, 11, "Which types of devices should receive security updates?" },
                    { 56, "Malware is software designed to harm, exploit, or misuse systems.", 1, 12, "What is malware?" },
                    { 57, "Ransomware encrypts data or locks systems and demands payment.", 2, 12, "What is ransomware?" },
                    { 58, "It can detect, block, or remove known threats.", 3, 12, "How can antivirus or endpoint protection help?" },
                    { 59, "Malware often spreads through malicious attachments, downloads, or exploited vulnerabilities.", 4, 12, "What is a common way malware spreads?" },
                    { 60, "Disconnect it from the network and report the issue promptly.", 5, 12, "What should you do if you suspect a device is infected?" }
                });

            migrationBuilder.InsertData(
                table: "AnswerOptions",
                columns: new[] { "Id", "IsCorrect", "QuestionId", "Text" },
                values: new object[,]
                {
                    { 121, true, 31, "Verifying who a user is" },
                    { 122, false, 31, "Deciding what files a user can delete" },
                    { 123, false, 31, "Encrypting internet traffic" },
                    { 124, false, 31, "Creating backups" },
                    { 125, true, 32, "A password" },
                    { 126, false, 32, "A phone token" },
                    { 127, false, 32, "A fingerprint" },
                    { 128, false, 32, "A security badge" },
                    { 129, true, 33, "A hardware security key" },
                    { 130, false, 33, "A PIN you memorize" },
                    { 131, false, 33, "Your surname" },
                    { 132, false, 33, "A secret question answer" },
                    { 133, true, 34, "It is harder for attackers to compromise multiple factors" },
                    { 134, false, 34, "It removes the need for passwords forever" },
                    { 135, false, 34, "It guarantees no account can ever be hacked" },
                    { 136, false, 34, "It only helps with physical security" },
                    { 137, true, 35, "Answers can often be guessed or found online" },
                    { 138, false, 35, "They are always encrypted with hardware keys" },
                    { 139, false, 35, "They require a second device" },
                    { 140, false, 35, "They cannot be reset" },
                    { 141, true, 36, "Determining what a user is allowed to do" },
                    { 142, false, 36, "Verifying a user's identity with a password" },
                    { 143, false, 36, "Turning on antivirus protection" },
                    { 144, false, 36, "Creating a network connection" },
                    { 145, true, 37, "It limits damage if an account is compromised" },
                    { 146, false, 37, "It gives faster internet access" },
                    { 147, false, 37, "It makes users memorize fewer passwords" },
                    { 148, false, 37, "It removes the need for logging" },
                    { 149, true, 38, "Security risk increases and mistakes can do more harm" },
                    { 150, false, 38, "Nothing changes because admin rights are harmless" },
                    { 151, false, 38, "Users will stop receiving phishing emails" },
                    { 152, false, 38, "Encryption becomes unnecessary" },
                    { 153, true, 39, "Regularly and whenever roles change" },
                    { 154, false, 39, "Only once when the account is created" },
                    { 155, false, 39, "Never, because permissions should stay fixed" },
                    { 156, false, 39, "Only after a ransomware attack" },
                    { 157, true, 40, "Start with minimal access" },
                    { 158, false, 40, "Give full admin rights immediately" },
                    { 159, false, 40, "Copy another user's permissions without checking" },
                    { 160, false, 40, "Allow access to everything by default" },
                    { 161, true, 41, "A group of permissions tied to responsibilities" },
                    { 162, false, 41, "A password reset token" },
                    { 163, false, 41, "A type of antivirus scan" },
                    { 164, false, 41, "A backup file" },
                    { 165, true, 42, "They reduce accountability and make auditing harder" },
                    { 166, false, 42, "They are more secure because many people know the password" },
                    { 167, false, 42, "They automatically enforce MFA" },
                    { 168, false, 42, "They remove the need for logs" },
                    { 169, true, 43, "Access should be removed promptly" },
                    { 170, false, 43, "Access should remain for convenience" },
                    { 171, false, 43, "Only email access should be removed" },
                    { 172, false, 43, "Nothing needs to happen if the account is inactive" },
                    { 173, true, 44, "It helps ensure users only access what they need" },
                    { 174, false, 44, "It makes all users administrators" },
                    { 175, false, 44, "It replaces authentication" },
                    { 176, false, 44, "It prevents software updates" },
                    { 177, true, 45, "Use privileged accounts only for admin tasks" },
                    { 178, false, 45, "Use privileged accounts for all daily browsing and email" },
                    { 179, false, 45, "Share privileged accounts with the whole team" },
                    { 180, false, 45, "Disable logging for privileged accounts" },
                    { 181, true, 46, "To prevent unauthorized access while you are away" },
                    { 182, false, 46, "To improve internet speed" },
                    { 183, false, 46, "To stop software updates" },
                    { 184, false, 46, "To avoid using passwords" },
                    { 185, true, 47, "It reduces the impact of mistakes and malware" },
                    { 186, false, 47, "It gives better graphics performance" },
                    { 187, false, 47, "It disables phishing attempts" },
                    { 188, false, 47, "It removes the need for antivirus" },
                    { 189, true, 48, "It protects data if the laptop is lost or stolen" },
                    { 190, false, 48, "It makes passwords visible to administrators" },
                    { 191, false, 48, "It removes the need for backups" },
                    { 192, false, 48, "It makes all files public" },
                    { 193, true, 49, "Install software only from trusted sources" },
                    { 194, false, 49, "Install random tools from pop-up ads" },
                    { 195, false, 49, "Disable warnings before installation" },
                    { 196, false, 49, "Use pirated installers when possible" },
                    { 197, true, 50, "They help defend the system against common threats" },
                    { 198, false, 50, "They are unnecessary on modern computers" },
                    { 199, false, 50, "They always slow the computer to unusable levels" },
                    { 200, false, 50, "They only protect against hardware damage" },
                    { 201, true, 51, "They often fix known vulnerabilities" },
                    { 202, false, 51, "They make passwords unnecessary" },
                    { 203, false, 51, "They are only for changing colors and icons" },
                    { 204, false, 51, "They only matter for new computers" },
                    { 205, true, 52, "An update that fixes a vulnerability or security issue" },
                    { 206, false, 52, "A type of firewall rule" },
                    { 207, false, 52, "A password stored in a browser" },
                    { 208, false, 52, "An email attachment" },
                    { 209, true, 53, "Attackers may exploit flaws that already have fixes" },
                    { 210, false, 53, "Delaying updates makes systems faster" },
                    { 211, false, 53, "Security issues disappear on their own" },
                    { 212, false, 53, "Updates are only needed after hardware failure" },
                    { 213, true, 54, "Automatic updates are usually safer" },
                    { 214, false, 54, "Never updating is safer" },
                    { 215, false, 54, "Security updates should only be installed once a year" },
                    { 216, false, 54, "Only games need automatic updates" },
                    { 217, true, 55, "All supported devices and software" },
                    { 218, false, 55, "Only smartphones" },
                    { 219, false, 55, "Only servers" },
                    { 220, false, 55, "Only software used for email" },
                    { 221, true, 56, "Software designed to harm, exploit, or misuse systems" },
                    { 222, false, 56, "A type of printer driver" },
                    { 223, false, 56, "A secure backup format" },
                    { 224, false, 56, "A normal browser update" },
                    { 225, true, 57, "Malware that encrypts data or locks systems for payment" },
                    { 226, false, 57, "Software that improves file compression" },
                    { 227, false, 57, "A harmless screen saver" },
                    { 228, false, 57, "A browser password manager" },
                    { 229, true, 58, "It can detect, block, or remove known threats" },
                    { 230, false, 58, "It guarantees zero risk forever" },
                    { 231, false, 58, "It replaces the need for updates" },
                    { 232, false, 58, "It only works when the computer is offline" },
                    { 233, true, 59, "Malicious attachments, risky downloads, or exploited vulnerabilities" },
                    { 234, false, 59, "Only through official app stores" },
                    { 235, false, 59, "Only through monitors and keyboards" },
                    { 236, false, 59, "Only through encrypted websites" },
                    { 237, true, 60, "Disconnect it from the network and report it" },
                    { 238, false, 60, "Ignore it and keep working as usual" },
                    { 239, false, 60, "Forward suspicious files to coworkers" },
                    { 240, false, 60, "Disable all security tools and restart repeatedly" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 9,
                column: "Text",
                value: "De gör att du kan återanvända samma lösenord överallt");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 10,
                column: "Text",
                value: "De genererar och lagrar unika, starka lösenord");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 11,
                column: "Text",
                value: "De stänger av MFA");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 12,
                column: "Text",
                value: "De gör lösenord synliga för alla i teamet");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 13,
                column: "Text",
                value: "Gissa lösenord genom att prova alla kombinationer");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 14,
                column: "Text",
                value: "Återanvända läckta inloggningar på andra tjänster");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 15,
                column: "Text",
                value: "Skicka skadliga bilagor via e-post");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 16,
                column: "Text",
                value: "Avlyssna Wi-Fi med en router");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 17,
                column: "Text",
                value: "SMS-kod");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 18,
                column: "Text",
                value: "App-baserad engångskod eller säkerhetsnyckel");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 19,
                column: "Text",
                value: "Lösenordsfråga (”mors flicknamn”)");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 20,
                column: "Text",
                value: "Inget extra skydd behövs");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 21,
                column: "Text",
                value: "Mejlet har perfekt grammatik och korrekt domän");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 22,
                column: "Text",
                value: "Brådska/hot och en länk som ser konstig ut");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 23,
                column: "Text",
                value: "Det kommer alltid från en intern adress");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 24,
                column: "Text",
                value: "Det innehåller aldrig länkar");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 25,
                column: "Text",
                value: "Klicka snabbt för att se vad det är");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 26,
                column: "Text",
                value: "Svara och be om mer information");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 27,
                column: "Text",
                value: "Verifiera via officiell kanal och undvik länken");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 28,
                column: "Text",
                value: "Skicka länken till alla kollegor");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 29,
                column: "Text",
                value: "Massutskick till hela internet");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 30,
                column: "Text",
                value: "Riktad phishing mot en specifik person eller organisation");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 31,
                column: "Text",
                value: "Phishing via telefonledning (analog)");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 32,
                column: "Text",
                value: "Ett antivirusprogram");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 33,
                column: "Text",
                value: "Bilagor kan innehålla skadlig kod/makron");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 34,
                column: "Text",
                value: "Bilagor kan inte skada datorer");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 35,
                column: "Text",
                value: "Bilagor är alltid krypterade");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 36,
                column: "Text",
                value: "PDF-filer är alltid säkra");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 37,
                column: "Text",
                value: "Lita på avsändarnamnet som visas");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 38,
                column: "Text",
                value: "Verifiera via en känd kontaktväg (t.ex. ring växeln)");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 39,
                column: "Text",
                value: "Klicka och logga in för att kontrollera");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 40,
                column: "Text",
                value: "Svar direkt och fråga om det är äkta");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "En fysisk kabeltyp" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "En logisk adress för en tjänst på en host" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 43,
                column: "Text",
                value: "Ett wifi-lösenord");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 44,
                column: "Text",
                value: "Ett operativsystem");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 45,
                column: "Text",
                value: "Krypterar all trafik automatiskt");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 46,
                column: "Text",
                value: "Översätter domännamn till IP-adresser");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 47,
                column: "Text",
                value: "Blockerar spammejl");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 48,
                column: "Text",
                value: "Skapar användarkonton");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Tillåter/blockerar trafik enligt regler" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "Skapar starka lösenord" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 51,
                column: "Text",
                value: "Ökar internet-hastigheten");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 52,
                column: "Text",
                value: "Rensar cookies");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "Alla ska ha admin för att slippa problem" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Minsta möjliga behörighet för att göra jobbet" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 55,
                column: "Text",
                value: "Ge alltid full åtkomst i testmiljö");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 56,
                column: "Text",
                value: "Blockera alla användare");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 57,
                column: "Text",
                value: "FTP");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 58,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "HTTP" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 59,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "HTTPS" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 60,
                column: "Text",
                value: "Telnet");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 61,
                column: "Text",
                value: "Att stoppa all phishing");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 62,
                column: "Text",
                value: "Avlyssning och manipulation av trafik i transit");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 63,
                column: "Text",
                value: "Att göra lösenord onödiga");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 64,
                column: "Text",
                value: "Att radera cookies automatiskt");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 65,
                column: "Text",
                value: "När databasen kraschar");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 66,
                column: "Text",
                value: "När attacker injicerar script som körs i användarens webbläsare");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 67,
                column: "Text",
                value: "När nätverket är långsamt");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 68,
                column: "Text",
                value: "När användaren glömmer lösenordet");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 69,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "När man använder SQL Server" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 70,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Manipulera SQL-frågor via osanerad input" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 71,
                column: "Text",
                value: "När man krypterar en tabell");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 72,
                column: "Text",
                value: "När man indexerar en kolumn");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 73,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Anti-forgery token / SameSite cookies" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 74,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "Att slå av HTTPS" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 75,
                column: "Text",
                value: "Att spara lösenord i localStorage");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 76,
                column: "Text",
                value: "Att använda längre URL:er");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 77,
                column: "Text",
                value: "Så att lösenord kan läsas enkelt vid support");

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 78,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { true, "Om DB läcker ska lösenord inte kunna läsas i klartext" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 79,
                columns: new[] { "IsCorrect", "Text" },
                values: new object[] { false, "För att göra inloggning långsammare" });

            migrationBuilder.UpdateData(
                table: "AnswerOptions",
                keyColumn: "Id",
                keyValue: 80,
                column: "Text",
                value: "För att slippa använda MFA");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Basprinciper och vanliga hot.", "Grundläggande cybersäkerhet" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Nätverkssäkerhet och webbsäkerhet.", "Nätverk & webb" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Längd + variation + inget ord i ordlista är bra.", "Vilket lösenord är starkast?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "MFA = Multi-Factor Authentication.", "Vad betyder MFA?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "De hjälper dig att ha unika, starka lösenord.", "Varför är lösenordshanterare bra?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Återanvända läckta inloggningar på andra sajter.", "Vad är 'credential stuffing'?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "App-baserade engångskoder eller säkerhetsnyckel är bättre.", "Vilken MFA-metod är oftast starkare än SMS?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Brådska + hot + konstig avsändare är vanligt.", "Vilket är ett vanligt tecken på phishing?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Öppna inte länken; verifiera via officiell kanal.", "Vad bör du göra om du får en misstänkt länk i ett mejl?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Riktad phishing mot en specifik person/grupp.", "Vad är 'spear phishing'?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "De kan innehålla skadlig kod/makron.", "Varför är bilagor i okända mejl farliga?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Verifiera via en känd, oberoende kontaktväg.", "Vilket är säkrast sätt att kontrollera om ett mejl är äkta?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "En logisk adress för tjänster på en host.", "Vad är en port (i nätverkssammanhang)?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Översätter domännamn till IP-adresser.", "Vad gör DNS?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Tillåter/blockerar trafik enligt regler.", "Vad gör en brandvägg (firewall) i enklaste form?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Minsta möjliga behörighet för att göra jobbet.", "Vad innebär 'least privilege'?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "HTTPS (HTTP över TLS).", "Vilket protokoll används typiskt för krypterad webbtrafik?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Avlyssning och manipulation av trafik i transit.", "Vad skyddar HTTPS främst mot?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "När attacker injicerar script som körs i användarens webbläsare.", "Vad är XSS (Cross-Site Scripting)?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Manipulera SQL-frågor via osanerad input.", "Vad är SQL-injection?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Anti-forgery token / SameSite cookies.", "Vad är en säker åtgärd mot CSRF?" });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "Explanation", "Text" },
                values: new object[] { "Om DB läcker ska lösenord inte kunna läsas i klartext.", "Varför ska man hasha lösenord i databasen?" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Starka lösenord och multifaktor.", "Lösenord & MFA" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Känna igen bedrägerier.", "Phishing & social engineering" });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CategoryId", "Description", "Name", "OrderIndex" },
                values: new object[] { 2, "Portar, DNS, brandväggar.", "Nätverksgrunder", 1 });

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Name", "OrderIndex" },
                values: new object[] { "HTTPS, cookies, vanliga webbsårbarheter.", "Webbsäkerhet", 2 });
        }
    }
}
