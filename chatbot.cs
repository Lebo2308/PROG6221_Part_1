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
                    Console.WriteLine("Welcome to the Security Helper Program!");
                    Console.Write("Please enter your name: ");
                    string userName = Console.ReadLine();
                    Console.WriteLine($"Hello, {userName}! You can ask me questions about security. Type 'exit' to quit.");

                    // Call both methods to auto store the values
                    store_ignore();
                    store_replies();

                    string question;
                    do
                    {
                        // Prompt the user for their question
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("[Security Chatbot]: ");
                        Console.ResetColor();
                        Console.WriteLine("Please enter your question. Type 'exit' to quit.");

                        // Display the user's name in green before reading the question
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{userName}]: ");
                        Console.ResetColor();

                        question = Console.ReadLine()?.ToLower(); // Convert input to lowercase

                        // Exit condition
                        if (string.Equals(question, "exit", StringComparison.OrdinalIgnoreCase))
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("[Security Chatbot]: ");
                            Console.WriteLine("\nThank you for using the Security Helper Program. Goodbye!");
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
                        Console.Write("[Security Chatbot]: ");
                        Console.ResetColor();

                        Console.WriteLine(found ? $"Here are the answers I found:\n{message}" : "Search something related to security.");
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
                replies.Add("Passwords need to be protected and kept safe.");
                replies.Add("SQL injection is very low based on rate.");
                replies.Add("Attacking phones is based on phishing.");
            }//eend of storing answers method

            // Method for storing ignored words
            private void store_ignore()
            {

                ignore.Add("tell");
                ignore.Add("me");
                ignore.Add("about");
            }//end of storing ingored words methods
        }
}