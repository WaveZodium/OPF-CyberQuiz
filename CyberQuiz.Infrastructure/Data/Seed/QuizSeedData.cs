using CyberQuiz.Infrastructure.Entities;

namespace CyberQuiz.Infrastructure.Data.Seed;

public static class QuizSeedData
{
    // -------- Lists --------

    public static readonly List<Category> CategoriesList =
    [
        new Category { Id = 1, Name = "Basic Cybersecurity", Description = "Core security principles and common threats." },
        new Category { Id = 2, Name = "Network & Web Security", Description = "Networking, web security, and internet safety." },
        new Category { Id = 3, Name = "Identity & Access Management", Description = "Authentication, authorization, and user access." },
        new Category { Id = 4, Name = "System & Device Security", Description = "Protecting devices, operating systems, and endpoints." }
    ];

    public static readonly List<SubCategory> SubCategoriesList =
    [
        // Category 1
        new SubCategory { Id = 1,  CategoryId = 1, Name = "Passwords & MFA", Description = "Strong passwords and multi-factor authentication.", OrderIndex = 1 },
        new SubCategory { Id = 2,  CategoryId = 1, Name = "Phishing & Social Engineering", Description = "Recognizing scams and manipulation.", OrderIndex = 2 },
        new SubCategory { Id = 3,  CategoryId = 1, Name = "Safe Browsing & Downloads", Description = "Avoiding risky links, files, and websites.", OrderIndex = 3 },

        // Category 2
        new SubCategory { Id = 4,  CategoryId = 2, Name = "Network Fundamentals", Description = "Ports, DNS, firewalls, and protocols.", OrderIndex = 1 },
        new SubCategory { Id = 5,  CategoryId = 2, Name = "Web Security", Description = "HTTPS, cookies, and common web vulnerabilities.", OrderIndex = 2 },
        new SubCategory { Id = 6,  CategoryId = 2, Name = "Email & DNS Security", Description = "Email safety and domain-related protections.", OrderIndex = 3 },

        // Category 3
        new SubCategory { Id = 7,  CategoryId = 3, Name = "Authentication Basics", Description = "How login and identity verification work.", OrderIndex = 1 },
        new SubCategory { Id = 8,  CategoryId = 3, Name = "Authorization & Least Privilege", Description = "Permissions and limiting access.", OrderIndex = 2 },
        new SubCategory { Id = 9,  CategoryId = 3, Name = "Accounts, Roles & Permissions", Description = "Managing users and access levels.", OrderIndex = 3 },

        // Category 4
        new SubCategory { Id = 10, CategoryId = 4, Name = "Operating System Security", Description = "Basic operating system protection.", OrderIndex = 1 },
        new SubCategory { Id = 11, CategoryId = 4, Name = "Updates & Patch Management", Description = "Keeping systems secure through updates.", OrderIndex = 2 },
        new SubCategory { Id = 12, CategoryId = 4, Name = "Malware & Endpoint Protection", Description = "Protecting devices from malicious software.", OrderIndex = 3 }
    ];

    public static readonly List<Question> QuestionsList =
    [
        // -------------------------
        // SubCategory 1: Passwords & MFA
        // -------------------------
        new Question { Id = 1,  SubCategoryId = 1, OrderIndex = 1, Text = "Which password is the strongest?", Explanation = "A strong password is long, unique, and hard to guess." },
        new Question { Id = 2,  SubCategoryId = 1, OrderIndex = 2, Text = "What does MFA stand for?", Explanation = "MFA means Multi-Factor Authentication." },
        new Question { Id = 3,  SubCategoryId = 1, OrderIndex = 3, Text = "Why are password managers useful?", Explanation = "They help users create and store strong, unique passwords." },
        new Question { Id = 4,  SubCategoryId = 1, OrderIndex = 4, Text = "What is credential stuffing?", Explanation = "Attackers reuse leaked login details on other services." },
        new Question { Id = 5,  SubCategoryId = 1, OrderIndex = 5, Text = "Which MFA method is usually stronger than SMS?", Explanation = "Authenticator apps or hardware security keys are generally stronger than SMS." },

        // -------------------------
        // SubCategory 2: Phishing & Social Engineering
        // -------------------------
        new Question { Id = 6,  SubCategoryId = 2, OrderIndex = 1, Text = "Which is a common sign of phishing?", Explanation = "Urgency, threats, and suspicious links are common warning signs." },
        new Question { Id = 7,  SubCategoryId = 2, OrderIndex = 2, Text = "What should you do if you receive a suspicious link in an email?", Explanation = "Do not open the link; verify through an official channel." },
        new Question { Id = 8,  SubCategoryId = 2, OrderIndex = 3, Text = "What is spear phishing?", Explanation = "Spear phishing is targeted phishing aimed at a specific person or group." },
        new Question { Id = 9,  SubCategoryId = 2, OrderIndex = 4, Text = "Why are attachments in unknown emails risky?", Explanation = "They may contain malware or malicious macros." },
        new Question { Id = 10, SubCategoryId = 2, OrderIndex = 5, Text = "What is the safest way to verify whether an email is legitimate?", Explanation = "Use a known, independent contact method." },

        // -------------------------
        // SubCategory 3: Safe Browsing & Downloads
        // -------------------------
        new Question { Id = 11, SubCategoryId = 3, OrderIndex = 1, Text = "Why should you avoid downloading files from unknown websites?", Explanation = "Unknown sources may distribute malicious or modified files." },
        new Question { Id = 12, SubCategoryId = 3, OrderIndex = 2, Text = "What is a safer habit before clicking a link?", Explanation = "Check the destination carefully before opening it." },
        new Question { Id = 13, SubCategoryId = 3, OrderIndex = 3, Text = "Why is pirated software risky?", Explanation = "It may contain malware or hidden backdoors." },
        new Question { Id = 14, SubCategoryId = 3, OrderIndex = 4, Text = "What is one warning sign of a malicious website?", Explanation = "Unexpected pop-ups, fake alerts, or suspicious domain names are warning signs." },
        new Question { Id = 15, SubCategoryId = 3, OrderIndex = 5, Text = "What should you do if a browser warns that a site is unsafe?", Explanation = "The safest action is usually to leave the site." },

        // -------------------------
        // SubCategory 4: Network Fundamentals
        // -------------------------
        new Question { Id = 16, SubCategoryId = 4, OrderIndex = 1, Text = "What is a port in networking?", Explanation = "A port is a logical endpoint for a network service on a device." },
        new Question { Id = 17, SubCategoryId = 4, OrderIndex = 2, Text = "What does DNS do?", Explanation = "DNS translates domain names into IP addresses." },
        new Question { Id = 18, SubCategoryId = 4, OrderIndex = 3, Text = "What does a firewall do in simple terms?", Explanation = "A firewall allows or blocks traffic based on rules." },
        new Question { Id = 19, SubCategoryId = 4, OrderIndex = 4, Text = "What does the principle of least privilege mean?", Explanation = "Users should only have the access they actually need." },
        new Question { Id = 20, SubCategoryId = 4, OrderIndex = 5, Text = "Which protocol is typically used for encrypted web traffic?", Explanation = "HTTPS is HTTP secured with TLS." },

        // -------------------------
        // SubCategory 5: Web Security
        // -------------------------
        new Question { Id = 21, SubCategoryId = 5, OrderIndex = 1, Text = "What does HTTPS mainly protect against?", Explanation = "It helps protect data from interception and tampering in transit." },
        new Question { Id = 22, SubCategoryId = 5, OrderIndex = 2, Text = "What is XSS (Cross-Site Scripting)?", Explanation = "XSS happens when attackers inject scripts into pages viewed by other users." },
        new Question { Id = 23, SubCategoryId = 5, OrderIndex = 3, Text = "What is SQL injection?", Explanation = "SQL injection manipulates database queries through unsafe input." },
        new Question { Id = 24, SubCategoryId = 5, OrderIndex = 4, Text = "Which is a common defense against CSRF?", Explanation = "Anti-forgery tokens and SameSite cookies help reduce CSRF risk." },
        new Question { Id = 25, SubCategoryId = 5, OrderIndex = 5, Text = "Why should passwords be hashed in a database?", Explanation = "If the database leaks, hashed passwords are harder to recover than plain text ones." },

        // -------------------------
        // SubCategory 6: Email & DNS Security
        // -------------------------
        new Question { Id = 26, SubCategoryId = 6, OrderIndex = 1, Text = "Why is email spoofing dangerous?", Explanation = "Spoofing can trick users into trusting a fake sender." },
        new Question { Id = 27, SubCategoryId = 6, OrderIndex = 2, Text = "What does DNS help users do?", Explanation = "DNS helps users reach websites by translating names into IP addresses." },
        new Question { Id = 28, SubCategoryId = 6, OrderIndex = 3, Text = "Why should users be cautious with links in unexpected emails?", Explanation = "Unexpected links may lead to phishing or malware." },
        new Question { Id = 29, SubCategoryId = 6, OrderIndex = 4, Text = "What is one sign that an email domain may be fake?", Explanation = "Small spelling changes in the domain name can indicate fraud." },
        new Question { Id = 30, SubCategoryId = 6, OrderIndex = 5, Text = "What is the safest way to open an important website after receiving an email about it?", Explanation = "Type the address manually or use a saved bookmark instead of clicking the email link." },

        // -------------------------
        // SubCategory 7: Authentication Basics
        // -------------------------
        new Question { Id = 31, SubCategoryId = 7, OrderIndex = 1, Text = "What is authentication?", Explanation = "Authentication is the process of verifying who a user is." },
        new Question { Id = 32, SubCategoryId = 7, OrderIndex = 2, Text = "Which is an example of something you know?", Explanation = "A password is a classic authentication factor based on knowledge." },
        new Question { Id = 33, SubCategoryId = 7, OrderIndex = 3, Text = "Which is an example of something you have?", Explanation = "A security key or phone can be an ownership factor." },
        new Question { Id = 34, SubCategoryId = 7, OrderIndex = 4, Text = "Why is using multiple authentication factors more secure?", Explanation = "It is harder for attackers to compromise more than one factor." },
        new Question { Id = 35, SubCategoryId = 7, OrderIndex = 5, Text = "What is a common weakness of security questions?", Explanation = "Answers may be easy to guess or find online." },

        // -------------------------
        // SubCategory 8: Authorization & Least Privilege
        // -------------------------
        new Question { Id = 36, SubCategoryId = 8, OrderIndex = 1, Text = "What is authorization?", Explanation = "Authorization determines what an authenticated user is allowed to do." },
        new Question { Id = 37, SubCategoryId = 8, OrderIndex = 2, Text = "Why is least privilege important?", Explanation = "It reduces damage if an account is misused or compromised." },
        new Question { Id = 38, SubCategoryId = 8, OrderIndex = 3, Text = "What can happen if too many users have admin rights?", Explanation = "Excessive privileges increase security risk and the chance of mistakes." },
        new Question { Id = 39, SubCategoryId = 8, OrderIndex = 4, Text = "When should permissions be reviewed?", Explanation = "Permissions should be reviewed regularly and when roles change." },
        new Question { Id = 40, SubCategoryId = 8, OrderIndex = 5, Text = "What is a safer default for new accounts?", Explanation = "Start with minimal access and grant more only when needed." },

        // -------------------------
        // SubCategory 9: Accounts, Roles & Permissions
        // -------------------------
        new Question { Id = 41, SubCategoryId = 9, OrderIndex = 1, Text = "What is a role in access management?", Explanation = "A role is a group of permissions assigned based on responsibilities." },
        new Question { Id = 42, SubCategoryId = 9, OrderIndex = 2, Text = "Why should shared accounts usually be avoided?", Explanation = "Shared accounts reduce accountability and make auditing harder." },
        new Question { Id = 43, SubCategoryId = 9, OrderIndex = 3, Text = "What should happen to access when an employee leaves?", Explanation = "Their access should be removed promptly." },
        new Question { Id = 44, SubCategoryId = 9, OrderIndex = 4, Text = "Why is it useful to separate user roles?", Explanation = "It helps ensure people only access what they need for their tasks." },
        new Question { Id = 45, SubCategoryId = 9, OrderIndex = 5, Text = "What is a good practice for privileged accounts?", Explanation = "Use them only for admin tasks, not everyday work." },

        // -------------------------
        // SubCategory 10: Operating System Security
        // -------------------------
        new Question { Id = 46, SubCategoryId = 10, OrderIndex = 1, Text = "Why should you lock your computer when leaving it unattended?", Explanation = "It prevents unauthorized access while you are away." },
        new Question { Id = 47, SubCategoryId = 10, OrderIndex = 2, Text = "What is one benefit of using a standard user account instead of an admin account for daily work?", Explanation = "It reduces the impact of mistakes and malware." },
        new Question { Id = 48, SubCategoryId = 10, OrderIndex = 3, Text = "Why is disk encryption useful on laptops?", Explanation = "It helps protect data if the device is lost or stolen." },
        new Question { Id = 49, SubCategoryId = 10, OrderIndex = 4, Text = "What is a secure habit when installing software?", Explanation = "Only install software from trusted and verified sources." },
        new Question { Id = 50, SubCategoryId = 10, OrderIndex = 5, Text = "Why should you avoid disabling built-in security features?", Explanation = "They help defend the system against common threats." },

        // -------------------------
        // SubCategory 11: Updates & Patch Management
        // -------------------------
        new Question { Id = 51, SubCategoryId = 11, OrderIndex = 1, Text = "Why are software updates important for security?", Explanation = "Updates often fix known vulnerabilities." },
        new Question { Id = 52, SubCategoryId = 11, OrderIndex = 2, Text = "What is a security patch?", Explanation = "A patch is an update that fixes a vulnerability or security issue." },
        new Question { Id = 53, SubCategoryId = 11, OrderIndex = 3, Text = "Why is delaying important updates risky?", Explanation = "Attackers may exploit flaws that already have public fixes." },
        new Question { Id = 54, SubCategoryId = 11, OrderIndex = 4, Text = "Which is safer: automatic updates or never updating?", Explanation = "Automatic updates are usually safer than ignoring updates completely." },
        new Question { Id = 55, SubCategoryId = 11, OrderIndex = 5, Text = "Which types of devices should receive security updates?", Explanation = "All supported devices and software should be updated." },

        // -------------------------
        // SubCategory 12: Malware & Endpoint Protection
        // -------------------------
        new Question { Id = 56, SubCategoryId = 12, OrderIndex = 1, Text = "What is malware?", Explanation = "Malware is software designed to harm, exploit, or misuse systems." },
        new Question { Id = 57, SubCategoryId = 12, OrderIndex = 2, Text = "What is ransomware?", Explanation = "Ransomware encrypts data or locks systems and demands payment." },
        new Question { Id = 58, SubCategoryId = 12, OrderIndex = 3, Text = "How can antivirus or endpoint protection help?", Explanation = "It can detect, block, or remove known threats." },
        new Question { Id = 59, SubCategoryId = 12, OrderIndex = 4, Text = "What is a common way malware spreads?", Explanation = "Malware often spreads through malicious attachments, downloads, or exploited vulnerabilities." },
        new Question { Id = 60, SubCategoryId = 12, OrderIndex = 5, Text = "What should you do if you suspect a device is infected?", Explanation = "Disconnect it from the network and report the issue promptly." }
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
        new AnswerOption { Id = 9,  QuestionId = 3, Text = "They let you reuse the same password everywhere", IsCorrect = false },
        new AnswerOption { Id = 10, QuestionId = 3, Text = "They generate and store unique, strong passwords", IsCorrect = true },
        new AnswerOption { Id = 11, QuestionId = 3, Text = "They disable MFA", IsCorrect = false },
        new AnswerOption { Id = 12, QuestionId = 3, Text = "They make passwords visible to everyone", IsCorrect = false },

        // Q4
        new AnswerOption { Id = 13, QuestionId = 4, Text = "Guessing passwords by trying every combination", IsCorrect = false },
        new AnswerOption { Id = 14, QuestionId = 4, Text = "Reusing leaked login credentials on other services", IsCorrect = true },
        new AnswerOption { Id = 15, QuestionId = 4, Text = "Sending malicious attachments by email", IsCorrect = false },
        new AnswerOption { Id = 16, QuestionId = 4, Text = "Intercepting Wi-Fi traffic with a router", IsCorrect = false },

        // Q5
        new AnswerOption { Id = 17, QuestionId = 5, Text = "SMS code", IsCorrect = false },
        new AnswerOption { Id = 18, QuestionId = 5, Text = "Authenticator app or security key", IsCorrect = true },
        new AnswerOption { Id = 19, QuestionId = 5, Text = "Security question", IsCorrect = false },
        new AnswerOption { Id = 20, QuestionId = 5, Text = "No extra protection is needed", IsCorrect = false },

        // Q6
        new AnswerOption { Id = 21, QuestionId = 6, Text = "The email has perfect grammar and a correct domain", IsCorrect = false },
        new AnswerOption { Id = 22, QuestionId = 6, Text = "Urgency or threats and a suspicious-looking link", IsCorrect = true },
        new AnswerOption { Id = 23, QuestionId = 6, Text = "It always comes from an internal address", IsCorrect = false },
        new AnswerOption { Id = 24, QuestionId = 6, Text = "It never contains links", IsCorrect = false },

        // Q7
        new AnswerOption { Id = 25, QuestionId = 7, Text = "Click quickly to see what it is", IsCorrect = false },
        new AnswerOption { Id = 26, QuestionId = 7, Text = "Reply and ask for more information", IsCorrect = false },
        new AnswerOption { Id = 27, QuestionId = 7, Text = "Verify through an official channel and avoid the link", IsCorrect = true },
        new AnswerOption { Id = 28, QuestionId = 7, Text = "Forward the link to everyone", IsCorrect = false },

        // Q8
        new AnswerOption { Id = 29, QuestionId = 8, Text = "A mass email to the whole internet", IsCorrect = false },
        new AnswerOption { Id = 30, QuestionId = 8, Text = "Targeted phishing aimed at a specific person or organization", IsCorrect = true },
        new AnswerOption { Id = 31, QuestionId = 8, Text = "Phishing through an analog phone line", IsCorrect = false },
        new AnswerOption { Id = 32, QuestionId = 8, Text = "An antivirus program", IsCorrect = false },

        // Q9
        new AnswerOption { Id = 33, QuestionId = 9, Text = "Attachments may contain malware or malicious macros", IsCorrect = true },
        new AnswerOption { Id = 34, QuestionId = 9, Text = "Attachments cannot harm computers", IsCorrect = false },
        new AnswerOption { Id = 35, QuestionId = 9, Text = "Attachments are always encrypted", IsCorrect = false },
        new AnswerOption { Id = 36, QuestionId = 9, Text = "PDF files are always safe", IsCorrect = false },

        // Q10
        new AnswerOption { Id = 37, QuestionId = 10, Text = "Trust the displayed sender name", IsCorrect = false },
        new AnswerOption { Id = 38, QuestionId = 10, Text = "Verify through a known contact method", IsCorrect = true },
        new AnswerOption { Id = 39, QuestionId = 10, Text = "Click and log in to check", IsCorrect = false },
        new AnswerOption { Id = 40, QuestionId = 10, Text = "Reply and ask if it is real", IsCorrect = false },

        // Q11
        new AnswerOption { Id = 41, QuestionId = 11, Text = "Unknown sites may offer malware-infected files", IsCorrect = true },
        new AnswerOption { Id = 42, QuestionId = 11, Text = "Unknown sites are always faster", IsCorrect = false },
        new AnswerOption { Id = 43, QuestionId = 11, Text = "Downloads from unknown sites are automatically safe", IsCorrect = false },
        new AnswerOption { Id = 44, QuestionId = 11, Text = "Browsers will always remove all threats", IsCorrect = false },

        // Q12
        new AnswerOption { Id = 45, QuestionId = 12, Text = "Open the link immediately", IsCorrect = false },
        new AnswerOption { Id = 46, QuestionId = 12, Text = "Check where the link actually leads", IsCorrect = true },
        new AnswerOption { Id = 47, QuestionId = 12, Text = "Turn off browser warnings", IsCorrect = false },
        new AnswerOption { Id = 48, QuestionId = 12, Text = "Assume all short links are safe", IsCorrect = false },

        // Q13
        new AnswerOption { Id = 49, QuestionId = 13, Text = "Pirated software is safer because many people use it", IsCorrect = false },
        new AnswerOption { Id = 50, QuestionId = 13, Text = "Pirated software may contain malware or backdoors", IsCorrect = true },
        new AnswerOption { Id = 51, QuestionId = 13, Text = "Pirated software is always open source", IsCorrect = false },
        new AnswerOption { Id = 52, QuestionId = 13, Text = "Pirated software updates automatically from trusted vendors", IsCorrect = false },

        // Q14
        new AnswerOption { Id = 53, QuestionId = 14, Text = "Unexpected pop-ups and suspicious domain names", IsCorrect = true },
        new AnswerOption { Id = 54, QuestionId = 14, Text = "A clean design and readable text", IsCorrect = false },
        new AnswerOption { Id = 55, QuestionId = 14, Text = "A login page from a known company", IsCorrect = false },
        new AnswerOption { Id = 56, QuestionId = 14, Text = "A site using images and colors", IsCorrect = false },

        // Q15
        new AnswerOption { Id = 57, QuestionId = 15, Text = "Ignore the warning and continue", IsCorrect = false },
        new AnswerOption { Id = 58, QuestionId = 15, Text = "Leave the site instead of proceeding", IsCorrect = true },
        new AnswerOption { Id = 59, QuestionId = 15, Text = "Disable browser protection permanently", IsCorrect = false },
        new AnswerOption { Id = 60, QuestionId = 15, Text = "Install whatever the site suggests", IsCorrect = false },

        // Q16
        new AnswerOption { Id = 61, QuestionId = 16, Text = "A physical cable type", IsCorrect = false },
        new AnswerOption { Id = 62, QuestionId = 16, Text = "A logical endpoint for a network service on a device", IsCorrect = true },
        new AnswerOption { Id = 63, QuestionId = 16, Text = "A Wi-Fi password", IsCorrect = false },
        new AnswerOption { Id = 64, QuestionId = 16, Text = "An operating system", IsCorrect = false },

        // Q17
        new AnswerOption { Id = 65, QuestionId = 17, Text = "It encrypts all traffic automatically", IsCorrect = false },
        new AnswerOption { Id = 66, QuestionId = 17, Text = "It translates domain names into IP addresses", IsCorrect = true },
        new AnswerOption { Id = 67, QuestionId = 17, Text = "It blocks spam emails", IsCorrect = false },
        new AnswerOption { Id = 68, QuestionId = 17, Text = "It creates user accounts", IsCorrect = false },

        // Q18
        new AnswerOption { Id = 69, QuestionId = 18, Text = "It allows or blocks traffic based on rules", IsCorrect = true },
        new AnswerOption { Id = 70, QuestionId = 18, Text = "It creates strong passwords", IsCorrect = false },
        new AnswerOption { Id = 71, QuestionId = 18, Text = "It increases internet speed", IsCorrect = false },
        new AnswerOption { Id = 72, QuestionId = 18, Text = "It deletes cookies", IsCorrect = false },

        // Q19
        new AnswerOption { Id = 73, QuestionId = 19, Text = "Give everyone admin access", IsCorrect = false },
        new AnswerOption { Id = 74, QuestionId = 19, Text = "Provide only the minimum access needed", IsCorrect = true },
        new AnswerOption { Id = 75, QuestionId = 19, Text = "Block all users permanently", IsCorrect = false },
        new AnswerOption { Id = 76, QuestionId = 19, Text = "Use the same account for everyone", IsCorrect = false },

        // Q20
        new AnswerOption { Id = 77, QuestionId = 20, Text = "FTP", IsCorrect = false },
        new AnswerOption { Id = 78, QuestionId = 20, Text = "HTTP", IsCorrect = false },
        new AnswerOption { Id = 79, QuestionId = 20, Text = "HTTPS", IsCorrect = true },
        new AnswerOption { Id = 80, QuestionId = 20, Text = "Telnet", IsCorrect = false },

        // Q21
        new AnswerOption { Id = 81, QuestionId = 21, Text = "It stops all phishing attacks", IsCorrect = false },
        new AnswerOption { Id = 82, QuestionId = 21, Text = "It protects against interception and tampering in transit", IsCorrect = true },
        new AnswerOption { Id = 83, QuestionId = 21, Text = "It makes passwords unnecessary", IsCorrect = false },
        new AnswerOption { Id = 84, QuestionId = 21, Text = "It automatically deletes cookies", IsCorrect = false },

        // Q22
        new AnswerOption { Id = 85, QuestionId = 22, Text = "When the database crashes", IsCorrect = false },
        new AnswerOption { Id = 86, QuestionId = 22, Text = "When attackers inject scripts that run in another user's browser", IsCorrect = true },
        new AnswerOption { Id = 87, QuestionId = 22, Text = "When the network is slow", IsCorrect = false },
        new AnswerOption { Id = 88, QuestionId = 22, Text = "When a user forgets a password", IsCorrect = false },

        // Q23
        new AnswerOption { Id = 89, QuestionId = 23, Text = "Using SQL Server normally", IsCorrect = false },
        new AnswerOption { Id = 90, QuestionId = 23, Text = "Manipulating database queries through unsafe input", IsCorrect = true },
        new AnswerOption { Id = 91, QuestionId = 23, Text = "Encrypting a table", IsCorrect = false },
        new AnswerOption { Id = 92, QuestionId = 23, Text = "Indexing a column", IsCorrect = false },

        // Q24
        new AnswerOption { Id = 93, QuestionId = 24, Text = "Anti-forgery tokens and SameSite cookies", IsCorrect = true },
        new AnswerOption { Id = 94, QuestionId = 24, Text = "Turning off HTTPS", IsCorrect = false },
        new AnswerOption { Id = 95, QuestionId = 24, Text = "Saving passwords in localStorage", IsCorrect = false },
        new AnswerOption { Id = 96, QuestionId = 24, Text = "Using longer URLs", IsCorrect = false },

        // Q25
        new AnswerOption { Id = 97, QuestionId = 25, Text = "So support staff can read passwords easily", IsCorrect = false },
        new AnswerOption { Id = 98, QuestionId = 25, Text = "So leaked database contents do not expose plain-text passwords", IsCorrect = true },
        new AnswerOption { Id = 99, QuestionId = 25, Text = "To make login slower", IsCorrect = false },
        new AnswerOption { Id = 100, QuestionId = 25, Text = "To avoid using MFA", IsCorrect = false },

        // Q26
        new AnswerOption { Id = 101, QuestionId = 26, Text = "It helps users trust fake senders", IsCorrect = true },
        new AnswerOption { Id = 102, QuestionId = 26, Text = "It makes all email encrypted", IsCorrect = false },
        new AnswerOption { Id = 103, QuestionId = 26, Text = "It prevents phishing completely", IsCorrect = false },
        new AnswerOption { Id = 104, QuestionId = 26, Text = "It only affects internal mail systems", IsCorrect = false },

        // Q27
        new AnswerOption { Id = 105, QuestionId = 27, Text = "It translates names into IP addresses", IsCorrect = true },
        new AnswerOption { Id = 106, QuestionId = 27, Text = "It creates email attachments", IsCorrect = false },
        new AnswerOption { Id = 107, QuestionId = 27, Text = "It scans devices for malware", IsCorrect = false },
        new AnswerOption { Id = 108, QuestionId = 27, Text = "It resets passwords", IsCorrect = false },

        // Q28
        new AnswerOption { Id = 109, QuestionId = 28, Text = "Unexpected links may lead to phishing or malware", IsCorrect = true },
        new AnswerOption { Id = 110, QuestionId = 28, Text = "Unexpected links are always internal", IsCorrect = false },
        new AnswerOption { Id = 111, QuestionId = 28, Text = "Unexpected links are safe if the email looks formal", IsCorrect = false },
        new AnswerOption { Id = 112, QuestionId = 28, Text = "Unexpected links cannot be dangerous on mobile devices", IsCorrect = false },

        // Q29
        new AnswerOption { Id = 113, QuestionId = 29, Text = "Small spelling changes in the domain", IsCorrect = true },
        new AnswerOption { Id = 114, QuestionId = 29, Text = "The sender uses punctuation", IsCorrect = false },
        new AnswerOption { Id = 115, QuestionId = 29, Text = "The email contains a logo", IsCorrect = false },
        new AnswerOption { Id = 116, QuestionId = 29, Text = "The message is short", IsCorrect = false },

        // Q30
        new AnswerOption { Id = 117, QuestionId = 30, Text = "Click the email link immediately", IsCorrect = false },
        new AnswerOption { Id = 118, QuestionId = 30, Text = "Type the address manually or use a bookmark", IsCorrect = true },
        new AnswerOption { Id = 119, QuestionId = 30, Text = "Disable browser security checks first", IsCorrect = false },
        new AnswerOption { Id = 120, QuestionId = 30, Text = "Forward the email before visiting the site", IsCorrect = false },

        // Q31
        new AnswerOption { Id = 121, QuestionId = 31, Text = "Verifying who a user is", IsCorrect = true },
        new AnswerOption { Id = 122, QuestionId = 31, Text = "Deciding what files a user can delete", IsCorrect = false },
        new AnswerOption { Id = 123, QuestionId = 31, Text = "Encrypting internet traffic", IsCorrect = false },
        new AnswerOption { Id = 124, QuestionId = 31, Text = "Creating backups", IsCorrect = false },

        // Q32
        new AnswerOption { Id = 125, QuestionId = 32, Text = "A password", IsCorrect = true },
        new AnswerOption { Id = 126, QuestionId = 32, Text = "A phone token", IsCorrect = false },
        new AnswerOption { Id = 127, QuestionId = 32, Text = "A fingerprint", IsCorrect = false },
        new AnswerOption { Id = 128, QuestionId = 32, Text = "A security badge", IsCorrect = false },

        // Q33
        new AnswerOption { Id = 129, QuestionId = 33, Text = "A hardware security key", IsCorrect = true },
        new AnswerOption { Id = 130, QuestionId = 33, Text = "A PIN you memorize", IsCorrect = false },
        new AnswerOption { Id = 131, QuestionId = 33, Text = "Your surname", IsCorrect = false },
        new AnswerOption { Id = 132, QuestionId = 33, Text = "A secret question answer", IsCorrect = false },

        // Q34
        new AnswerOption { Id = 133, QuestionId = 34, Text = "It is harder for attackers to compromise multiple factors", IsCorrect = true },
        new AnswerOption { Id = 134, QuestionId = 34, Text = "It removes the need for passwords forever", IsCorrect = false },
        new AnswerOption { Id = 135, QuestionId = 34, Text = "It guarantees no account can ever be hacked", IsCorrect = false },
        new AnswerOption { Id = 136, QuestionId = 34, Text = "It only helps with physical security", IsCorrect = false },

        // Q35
        new AnswerOption { Id = 137, QuestionId = 35, Text = "Answers can often be guessed or found online", IsCorrect = true },
        new AnswerOption { Id = 138, QuestionId = 35, Text = "They are always encrypted with hardware keys", IsCorrect = false },
        new AnswerOption { Id = 139, QuestionId = 35, Text = "They require a second device", IsCorrect = false },
        new AnswerOption { Id = 140, QuestionId = 35, Text = "They cannot be reset", IsCorrect = false },

        // Q36
        new AnswerOption { Id = 141, QuestionId = 36, Text = "Determining what a user is allowed to do", IsCorrect = true },
        new AnswerOption { Id = 142, QuestionId = 36, Text = "Verifying a user's identity with a password", IsCorrect = false },
        new AnswerOption { Id = 143, QuestionId = 36, Text = "Turning on antivirus protection", IsCorrect = false },
        new AnswerOption { Id = 144, QuestionId = 36, Text = "Creating a network connection", IsCorrect = false },

        // Q37
        new AnswerOption { Id = 145, QuestionId = 37, Text = "It limits damage if an account is compromised", IsCorrect = true },
        new AnswerOption { Id = 146, QuestionId = 37, Text = "It gives faster internet access", IsCorrect = false },
        new AnswerOption { Id = 147, QuestionId = 37, Text = "It makes users memorize fewer passwords", IsCorrect = false },
        new AnswerOption { Id = 148, QuestionId = 37, Text = "It removes the need for logging", IsCorrect = false },

        // Q38
        new AnswerOption { Id = 149, QuestionId = 38, Text = "Security risk increases and mistakes can do more harm", IsCorrect = true },
        new AnswerOption { Id = 150, QuestionId = 38, Text = "Nothing changes because admin rights are harmless", IsCorrect = false },
        new AnswerOption { Id = 151, QuestionId = 38, Text = "Users will stop receiving phishing emails", IsCorrect = false },
        new AnswerOption { Id = 152, QuestionId = 38, Text = "Encryption becomes unnecessary", IsCorrect = false },

        // Q39
        new AnswerOption { Id = 153, QuestionId = 39, Text = "Regularly and whenever roles change", IsCorrect = true },
        new AnswerOption { Id = 154, QuestionId = 39, Text = "Only once when the account is created", IsCorrect = false },
        new AnswerOption { Id = 155, QuestionId = 39, Text = "Never, because permissions should stay fixed", IsCorrect = false },
        new AnswerOption { Id = 156, QuestionId = 39, Text = "Only after a ransomware attack", IsCorrect = false },

        // Q40
        new AnswerOption { Id = 157, QuestionId = 40, Text = "Start with minimal access", IsCorrect = true },
        new AnswerOption { Id = 158, QuestionId = 40, Text = "Give full admin rights immediately", IsCorrect = false },
        new AnswerOption { Id = 159, QuestionId = 40, Text = "Copy another user's permissions without checking", IsCorrect = false },
        new AnswerOption { Id = 160, QuestionId = 40, Text = "Allow access to everything by default", IsCorrect = false },

        // Q41
        new AnswerOption { Id = 161, QuestionId = 41, Text = "A group of permissions tied to responsibilities", IsCorrect = true },
        new AnswerOption { Id = 162, QuestionId = 41, Text = "A password reset token", IsCorrect = false },
        new AnswerOption { Id = 163, QuestionId = 41, Text = "A type of antivirus scan", IsCorrect = false },
        new AnswerOption { Id = 164, QuestionId = 41, Text = "A backup file", IsCorrect = false },

        // Q42
        new AnswerOption { Id = 165, QuestionId = 42, Text = "They reduce accountability and make auditing harder", IsCorrect = true },
        new AnswerOption { Id = 166, QuestionId = 42, Text = "They are more secure because many people know the password", IsCorrect = false },
        new AnswerOption { Id = 167, QuestionId = 42, Text = "They automatically enforce MFA", IsCorrect = false },
        new AnswerOption { Id = 168, QuestionId = 42, Text = "They remove the need for logs", IsCorrect = false },

        // Q43
        new AnswerOption { Id = 169, QuestionId = 43, Text = "Access should be removed promptly", IsCorrect = true },
        new AnswerOption { Id = 170, QuestionId = 43, Text = "Access should remain for convenience", IsCorrect = false },
        new AnswerOption { Id = 171, QuestionId = 43, Text = "Only email access should be removed", IsCorrect = false },
        new AnswerOption { Id = 172, QuestionId = 43, Text = "Nothing needs to happen if the account is inactive", IsCorrect = false },

        // Q44
        new AnswerOption { Id = 173, QuestionId = 44, Text = "It helps ensure users only access what they need", IsCorrect = true },
        new AnswerOption { Id = 174, QuestionId = 44, Text = "It makes all users administrators", IsCorrect = false },
        new AnswerOption { Id = 175, QuestionId = 44, Text = "It replaces authentication", IsCorrect = false },
        new AnswerOption { Id = 176, QuestionId = 44, Text = "It prevents software updates", IsCorrect = false },

        // Q45
        new AnswerOption { Id = 177, QuestionId = 45, Text = "Use privileged accounts only for admin tasks", IsCorrect = true },
        new AnswerOption { Id = 178, QuestionId = 45, Text = "Use privileged accounts for all daily browsing and email", IsCorrect = false },
        new AnswerOption { Id = 179, QuestionId = 45, Text = "Share privileged accounts with the whole team", IsCorrect = false },
        new AnswerOption { Id = 180, QuestionId = 45, Text = "Disable logging for privileged accounts", IsCorrect = false },

        // Q46
        new AnswerOption { Id = 181, QuestionId = 46, Text = "To prevent unauthorized access while you are away", IsCorrect = true },
        new AnswerOption { Id = 182, QuestionId = 46, Text = "To improve internet speed", IsCorrect = false },
        new AnswerOption { Id = 183, QuestionId = 46, Text = "To stop software updates", IsCorrect = false },
        new AnswerOption { Id = 184, QuestionId = 46, Text = "To avoid using passwords", IsCorrect = false },

        // Q47
        new AnswerOption { Id = 185, QuestionId = 47, Text = "It reduces the impact of mistakes and malware", IsCorrect = true },
        new AnswerOption { Id = 186, QuestionId = 47, Text = "It gives better graphics performance", IsCorrect = false },
        new AnswerOption { Id = 187, QuestionId = 47, Text = "It disables phishing attempts", IsCorrect = false },
        new AnswerOption { Id = 188, QuestionId = 47, Text = "It removes the need for antivirus", IsCorrect = false },

        // Q48
        new AnswerOption { Id = 189, QuestionId = 48, Text = "It protects data if the laptop is lost or stolen", IsCorrect = true },
        new AnswerOption { Id = 190, QuestionId = 48, Text = "It makes passwords visible to administrators", IsCorrect = false },
        new AnswerOption { Id = 191, QuestionId = 48, Text = "It removes the need for backups", IsCorrect = false },
        new AnswerOption { Id = 192, QuestionId = 48, Text = "It makes all files public", IsCorrect = false },

        // Q49
        new AnswerOption { Id = 193, QuestionId = 49, Text = "Install software only from trusted sources", IsCorrect = true },
        new AnswerOption { Id = 194, QuestionId = 49, Text = "Install random tools from pop-up ads", IsCorrect = false },
        new AnswerOption { Id = 195, QuestionId = 49, Text = "Disable warnings before installation", IsCorrect = false },
        new AnswerOption { Id = 196, QuestionId = 49, Text = "Use pirated installers when possible", IsCorrect = false },

        // Q50
        new AnswerOption { Id = 197, QuestionId = 50, Text = "They help defend the system against common threats", IsCorrect = true },
        new AnswerOption { Id = 198, QuestionId = 50, Text = "They are unnecessary on modern computers", IsCorrect = false },
        new AnswerOption { Id = 199, QuestionId = 50, Text = "They always slow the computer to unusable levels", IsCorrect = false },
        new AnswerOption { Id = 200, QuestionId = 50, Text = "They only protect against hardware damage", IsCorrect = false },

        // Q51
        new AnswerOption { Id = 201, QuestionId = 51, Text = "They often fix known vulnerabilities", IsCorrect = true },
        new AnswerOption { Id = 202, QuestionId = 51, Text = "They make passwords unnecessary", IsCorrect = false },
        new AnswerOption { Id = 203, QuestionId = 51, Text = "They are only for changing colors and icons", IsCorrect = false },
        new AnswerOption { Id = 204, QuestionId = 51, Text = "They only matter for new computers", IsCorrect = false },

        // Q52
        new AnswerOption { Id = 205, QuestionId = 52, Text = "An update that fixes a vulnerability or security issue", IsCorrect = true },
        new AnswerOption { Id = 206, QuestionId = 52, Text = "A type of firewall rule", IsCorrect = false },
        new AnswerOption { Id = 207, QuestionId = 52, Text = "A password stored in a browser", IsCorrect = false },
        new AnswerOption { Id = 208, QuestionId = 52, Text = "An email attachment", IsCorrect = false },

        // Q53
        new AnswerOption { Id = 209, QuestionId = 53, Text = "Attackers may exploit flaws that already have fixes", IsCorrect = true },
        new AnswerOption { Id = 210, QuestionId = 53, Text = "Delaying updates makes systems faster", IsCorrect = false },
        new AnswerOption { Id = 211, QuestionId = 53, Text = "Security issues disappear on their own", IsCorrect = false },
        new AnswerOption { Id = 212, QuestionId = 53, Text = "Updates are only needed after hardware failure", IsCorrect = false },

        // Q54
        new AnswerOption { Id = 213, QuestionId = 54, Text = "Automatic updates are usually safer", IsCorrect = true },
        new AnswerOption { Id = 214, QuestionId = 54, Text = "Never updating is safer", IsCorrect = false },
        new AnswerOption { Id = 215, QuestionId = 54, Text = "Security updates should only be installed once a year", IsCorrect = false },
        new AnswerOption { Id = 216, QuestionId = 54, Text = "Only games need automatic updates", IsCorrect = false },

        // Q55
        new AnswerOption { Id = 217, QuestionId = 55, Text = "All supported devices and software", IsCorrect = true },
        new AnswerOption { Id = 218, QuestionId = 55, Text = "Only smartphones", IsCorrect = false },
        new AnswerOption { Id = 219, QuestionId = 55, Text = "Only servers", IsCorrect = false },
        new AnswerOption { Id = 220, QuestionId = 55, Text = "Only software used for email", IsCorrect = false },

        // Q56
        new AnswerOption { Id = 221, QuestionId = 56, Text = "Software designed to harm, exploit, or misuse systems", IsCorrect = true },
        new AnswerOption { Id = 222, QuestionId = 56, Text = "A type of printer driver", IsCorrect = false },
        new AnswerOption { Id = 223, QuestionId = 56, Text = "A secure backup format", IsCorrect = false },
        new AnswerOption { Id = 224, QuestionId = 56, Text = "A normal browser update", IsCorrect = false },

        // Q57
        new AnswerOption { Id = 225, QuestionId = 57, Text = "Malware that encrypts data or locks systems for payment", IsCorrect = true },
        new AnswerOption { Id = 226, QuestionId = 57, Text = "Software that improves file compression", IsCorrect = false },
        new AnswerOption { Id = 227, QuestionId = 57, Text = "A harmless screen saver", IsCorrect = false },
        new AnswerOption { Id = 228, QuestionId = 57, Text = "A browser password manager", IsCorrect = false },

        // Q58
        new AnswerOption { Id = 229, QuestionId = 58, Text = "It can detect, block, or remove known threats", IsCorrect = true },
        new AnswerOption { Id = 230, QuestionId = 58, Text = "It guarantees zero risk forever", IsCorrect = false },
        new AnswerOption { Id = 231, QuestionId = 58, Text = "It replaces the need for updates", IsCorrect = false },
        new AnswerOption { Id = 232, QuestionId = 58, Text = "It only works when the computer is offline", IsCorrect = false },

        // Q59
        new AnswerOption { Id = 233, QuestionId = 59, Text = "Malicious attachments, risky downloads, or exploited vulnerabilities", IsCorrect = true },
        new AnswerOption { Id = 234, QuestionId = 59, Text = "Only through official app stores", IsCorrect = false },
        new AnswerOption { Id = 235, QuestionId = 59, Text = "Only through monitors and keyboards", IsCorrect = false },
        new AnswerOption { Id = 236, QuestionId = 59, Text = "Only through encrypted websites", IsCorrect = false },

        // Q60
        new AnswerOption { Id = 237, QuestionId = 60, Text = "Disconnect it from the network and report it", IsCorrect = true },
        new AnswerOption { Id = 238, QuestionId = 60, Text = "Ignore it and keep working as usual", IsCorrect = false },
        new AnswerOption { Id = 239, QuestionId = 60, Text = "Forward suspicious files to coworkers", IsCorrect = false },
        new AnswerOption { Id = 240, QuestionId = 60, Text = "Disable all security tools and restart repeatedly", IsCorrect = false }
    ];

    // -------- Arrays --------

    public static Category[] Categories => CategoriesList.ToArray();
    public static SubCategory[] SubCategories => SubCategoriesList.ToArray();
    public static Question[] Questions => QuestionsList.ToArray();
    public static AnswerOption[] AnswerOptions => AnswerOptionsList.ToArray();
}