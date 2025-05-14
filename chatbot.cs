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
        Dictionary<string, List<string>> replies = new Dictionary<string, List<string>>();
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
                Console.WriteLine($"Hello, {userName}! You can ask me questions about cybersecurity.");
                
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
                        Console.WriteLine($"Goodbye {userName}! Thank you for using Molebogeng's Cybersecurity Chatbot Program. Goodbye!");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }

                    if (question.Contains("interest"))
                    {

                    }

                    
                    // Splitting input into words and filtering
                    string[] words = question.Split(' ');
                    List<string> filteredWords = words.Where(word => !ignore.Contains(word)).ToList(); // Convert to a List first

                    // Variables for message building
                    bool found = false;
                    List<string> response = new List<string>();

                    // Filter replies for matches using LINQ
                    foreach (string word in filteredWords)
                    {
                        if (replies.ContainsKey(word))
                        {
                            // Select a random response from the list{Randomization}
                            Random rand = new Random();
                            string randomResponse = replies[word][rand.Next(replies[word].Count)];
                            response.Add(randomResponse); // Add matching response
                            found = true;
                        }
                        
                    }
                    
                    // Display error message or answers
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Chatbot: ");
                    Console.ResetColor();
                    Console.WriteLine(found ? string.Join("\n", response) : "I'm not sure I understand that. Can you rephrase or ask/search for something related to security.");//error handling when the chatbot does not understand what the user has entered
                } while (true); // Loop continues until the user types 'exit'
            }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
        }

            // Method for storing replies and it will randomly select from the stored answers and answer using key word recognition
            private void store_replies()
            {
            replies.Add("you", new List<string>
            {
                "im good thanks and you."
            });

            replies.Add("purpose", new List<string>
            {
                "My purpose is to simulate real-life scenarios where users might encounter cyber \nthreats and provide guidance on avoiding common traps."
            });
            //select a random answer from these lists
            replies.Add("password", new List<string>
            {
                "Passwords need be at least 12 characters long. Passwords need to be protected and kept safe.",
                "Use a mix of uppercase, lowercase, numbers, and special characters in passwords.",
                "You can Enable two-factor authentication to add an extra layer of security.",
                "Avoid entering sensitive information or logging into accounts on public Wi-Fi networks and \nregularly update your operating system, browser, and other software to ensure you have the latest security patches."
            });

            replies.Add("phishing", new List<string>
            {
                "Phishing is a type of cybercrime that involves tricking individuals into revealing sensitive information,\n such as passwords, credit card numbers, or personal data.",
                "Phishing emails often create urgency. Always verify the sender.",
                "Don't click on suspicious links in emails claiming to be from banks or services.\nYou can protect yourself from phishing by: Verifying information; using Strong Passwords; enabling Two-Factor authentication;",
                "Check for spelling mistakes in emails—legitimate companies rarely make errors."
            });

            replies.Add("safe browsing", new List<string>
            {
                "Safe browsing is essential to protect yourself from online threats, such as malware, phishing, and ransomware.",
                "Always check that websites use HTTPS for secure connections. Only download files from trusted sources, and avoid downloading files with suspicious extensions.",
                "Use a VPN to protect your online activity. Consider using a virtual private network (VPN) to encrypt your internet traffic.",
                "Avoid entering sensitive info on public Wi-Fi networks.Use antivirus software: Install and regularly update antivirus software to protect against malware."
            });
            //adding the sentimental replies to recognise key words
            replies.Add("worried", new List<string>
            {
                "It's completely understandable to feel that way. Scammers can be very convincing \nLet me share some tips to help stay safe online, please tell me which tips you would like."
            });
            replies.Add("curious", new List<string>
            {
                "Yea, sure. i can hopefully help you understand that more and provide tip on how to stay safe."
            });
            replies.Add("furstrated", new List<string>
            {
                "It's completely understandable to feel that way. Scammers can be very convincing \nLet me share some tips to help stay safe online, please tell me which tips you would like."
            });
            replies.Add("happy", new List<string>
            {
                "Thats great, hope i am of great help and please stay safe online and always stay very catious"
            });
            replies.Add("sad", new List<string>
            {
                "It's completely understandable to feel that way. Scammers can be very convincing \nLet me share some tips to help stay safe online, please tell me which tips you would like."
            });
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
                ignore.Add("more");
            }//end of storing ingored words methods
        }//end of class
}//end of namespace