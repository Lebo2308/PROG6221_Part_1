using System.IO;
using System;
using System.Collections.Generic;

namespace PROG6221_Part_1
{
    public class memoryRecall
    {
        private readonly string memoryFilePath;

        //constructor
        public memoryRecall(string fileName = "memory.txt")
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "");
            memoryFilePath = Path.Combine(basePath, fileName);

            // Ensure memory file exists
            if (!File.Exists(memoryFilePath))
            {
                File.WriteAllText(memoryFilePath, ""); // Create an empty file
            }
        }//end of constructor

        // Store memory entries when the chatbot detects "interest"
        public void StoreInterest(string userInput)
        {
            try
            {
                if (userInput.Contains("interest"))
                {
                    var memoryData = LoadMemory();
                    memoryData.Add(userInput);
                    File.WriteAllLines(memoryFilePath, memoryData);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Chatbot : ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("I'll remember your interest for future reference!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error storing memory: {ex.Message}");
            }
        }

        // Load previously stored memory
        public List<string> LoadMemory()
        {
            try
            {
                return File.Exists(memoryFilePath) ? new List<string>(File.ReadAllLines(memoryFilePath)) : new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading memory: {ex.Message}");
                return new List<string>();
            }
        }

    }//end of class
}//end of namespace 