using System;
using System.Collections.Generic;
using System.IO;

/*
 * Name: Benjamin Amos Effiong
 * Instructor: John Reading
 * Project: Journal Application
 * 
 * Description:
 * A journal app for daily entries inspired by prompts. Features include:
 * - Adding new entries.
 * - Viewing all entries.
 * - Saving entries to a file.
 * - Loading entries from a file.
 */

public class Entry
{
    public string Date { get; private set; } // Date of the entry
    public string Prompt { get; private set; } // Prompt for the entry
    public string Response { get; private set; } // User's response to the prompt

    // Constructor for new entries (sets current date)
    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
    }

    // Constructor for loading entries (uses existing date)
    public Entry(string date, string prompt, string response)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
    }

    // Returns the formatted string representation of the entry
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>(); // List of journal entries
    private List<string> _prompts = new List<string> // Predefined prompts
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    // Adds a new entry based on a random prompt
    public void AddEntry()
    {
        try
        {
            var random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)]; // Select a random prompt
            Console.WriteLine($"\nPrompt: {prompt}");
            Console.Write("Your Response: ");
            string response = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(response))
            {
                Console.WriteLine("Response cannot be empty. Entry not added.");
                return;
            }

            _entries.Add(new Entry(prompt, response)); // Add new entry to the journal
            Console.WriteLine("Entry added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding entry: {ex.Message}");
        }
    }

    // Displays all journal entries
    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries to display.");
            return;
        }

        Console.WriteLine("\nJournal Entries:");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry); // Display each entry
        }
    }

    // Saves journal entries to a specified file
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    // Loads journal entries from a specified file
    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found!");
                return;
            }

            _entries.Clear();
            foreach (var line in File.ReadAllLines(filename))
            {
                string[] parts = line.Split('|'); // Split file line into parts
                if (parts.Length == 3)
                {
                    _entries.Add(new Entry(parts[0], parts[1], parts[2])); // Add entry
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}

public class Program
{
    private static Journal journal = new Journal(); // Journal instance

    public static void Main(string[] args)
    {
        while (true)
        {
            // Display the main menu
            Console.WriteLine("\nJournal App Menu:");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal to File");
            Console.WriteLine("4. Load Journal from File");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            // Handle user selection
            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
