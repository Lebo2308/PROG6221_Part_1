using System.Collections;
using System.Linq;
using System.Text;
using System;
using System.IO;
using System.Collections.Generic;

namespace PROG6221_Part_1
{
    public class chatbot
    {
        
            // Variable declaration
            List<string> replies = new List<string>();
            List<string> ignore = new List<string>();

            // Constructor
            public chatbot()
            {
                try
                {
                    // Display welcome message and ask for the user's name
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("====================================================================");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("||   Welcome to the Molebogeng's Cybersecurity Chatbot Program!   ||");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("====================================================================");
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.Write("Chatbot : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please enter your name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("User : ");
                    Console.ForegroundColor = ConsoleColor.White;   
                    string userName = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Chatbot : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Hello, {userName}! You can ask me questions about security."); 

                    // Call both methods to auto store the values
                    store_ignore();
                    store_replies();

                    string question;
                    do
                    {
                        // Prompt the user for their question
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot : ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Please enter your question. Type 'exit' to quit.");

                        // Display the user's name in green before reading the question
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"{userName} : ");
                        Console.ResetColor();

                        question = Console.ReadLine()?.ToLower(); // Convert input to lowercase

                        // Exit condition
                        if (string.Equals(question, "exit", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Chatbot: ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\nThank you for using Molebogeng's Cybersecurity Chatbot Program. Goodbye!");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        }

                        // Splitting input into words and filtering
                        string[] words = question.Split(' ');
                        ArrayList filteredWords = new ArrayList(words.Where(word => !ignore.Contains(word)).ToList()); // Convert to a List first

                        // Variables for message building
                        bool found = false;
                        string message = null;

                        // Filter replies for matches using LINQ
                        foreach (string word in filteredWords)
                        {
                            var matchingReplies = replies.Cast<string>().Where(reply => reply.ToLower().Contains(word)); // Ignore case in replies
                            foreach (string reply in matchingReplies)
                            {
                                if (message == null) 
                                { 
                                    message = reply;//assign first found
                                }
                                else if (!message.ToString().Contains(reply))
                                {
                                    message += reply;//concatenate mutliple replies
                                }
                                found = true;
                                break;
                            }
                        }

                        // Display error message or answers
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Chatbot: ");
                        Console.ResetColor();

                        Console.WriteLine(found ? $"{message}" : "Search something related to security.");
                    } while (true); // Loop continues until the user types 'exit'
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            // Method for storing replies
            private void store_replies()
            {
                replies.Add("I am good thanks and you");
                replies.Add("My purpose is to simulate real-life scenarios where users might encounter cyber \nthreats and provide guidance on avoiding common traps.");
                replies.Add("You can ask me questions about password safety, phishing and recognising suspicious links.");
                replies.Add("Passwords need to be protected and kept safe. Password need to be atleast 12 characters\n long, they need to include a mix of uppercase and lowercase letters, numbers, and special characters."
                    + "\nDo not create or use easily guessable information such as your name, birthdate, or common words\n for your passwords. You can use Two-Factor Authentication to add an extra layer of security. Avoid"
                    + "\nreusing password across multiple accounts and never share your passwords with other people. \nTips you can use:\nAvoid entering sensitive information or logging into accounts on public Wi-Fi networks." 
                   + "\n You can use a secure browser, such as Tor, to protect your online activity.\nRegularly update your operating system, browser, and other software to ensure you have the latest security patches.");

                replies.Add("Safe browsing is essential to protect yourself from online threats, such as malware, phishing, and ransomware.\nSafe Browsing Tips:\nKeep your browser and operating system up-to-date: Ensure you have the latest security patches and updates." +
                    "\nUse antivirus software: Install and regularly update antivirus software to protect against malware.\nAvoid using public computers or public Wi-Fi because they may be compromised by malware or hackers.\nUse a VPN: Consider using a virtual private network (VPN) to encrypt your internet traffic." +
                    "\nOnly download files from trusted sources, and avoid downloading files with suspicious extensions.\nCheck the URL: Verify the website's URL is legitimate and spelled correctly.\n Ensure the website uses HTTPS (Hypertext Transfer Protocol Secure) instead of HTTP.\nCheck for misspellings and grammatical errors because legitimate websites usually don't have errors");

                replies.Add("Phishing is a type of cybercrime that involves tricking individuals into revealing sensitive information,\n such as passwords, credit card numbers, or personal data. You can spot phishing by: \nSuspicious Sender: Verify the sender's email address or phone number.\n" +
                    "Urgent or Threatening Language: Be cautious of messages that create a sense of urgency or threat.\nSpelling and Grammar Mistakes: Legitimate messages usually don't contain errors.\n Suspicious Links or Attachments " +
                    "You can protect yourself from phishing by: Verifying information; using Strong Passwords; enabling Two-Factor authentication;\n keeping Software Up-to-Date and Be Cautious with Public Wi-Fi.");
            }//end of storing answers method

            // Method for storing ignored words
            private void store_ignore()
            { 
                ignore.Add("what");
                ignore.Add("is");
                ignore.Add("your");
                ignore.Add("how");
                ignore.Add("are");
                ignore.Add("can");
                ignore.Add("i");
                ignore.Add("sports");
                ignore.Add("tell");
                ignore.Add("me");
                ignore.Add("about");
            }//end of storing ingored words methods
        }//end of class
}//end of namespace