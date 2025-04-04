using System.Collections;
using System.Linq;
using System.Text;
using System;

namespace PROG6221_Part_1
{
    public class chatbot
    {
        
            // Variable declaration
            ArrayList replies = new ArrayList();
            ArrayList ignore = new ArrayList();

            // Constructor
            public chatbot()
            {
                try
                {
                    // Display welcome message and ask for the user's name
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Welcome to the Molebogeng's Cybersecurity Chatbot Program!");
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.Write("Chatbot: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Please enter your name: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("USER: ");
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
                        StringBuilder message = new StringBuilder();

                        // Filter replies for matches using LINQ
                        foreach (string word in filteredWords)
                        {
                            var matchingReplies = replies.Cast<string>().Where(reply => reply.ToLower().Contains(word)); // Ignore case in replies
                            foreach (string reply in matchingReplies)
                            {
                                if (!message.ToString().Contains(reply))
                                {
                                    message.AppendLine(reply);
                                    found = true;
                                }
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
                replies.Add("Passwords need to be protected and kept safe.");
                replies.Add("SQL injection is very low based on rate.");
                replies.Add("Attacking phones is based on phishing.");
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
        }
}