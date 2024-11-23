using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Represents a single word in the scripture
    public class Word
    {
        public string Text { get; private set; }
        public bool IsHidden { get; private set; }

        public Word(string text)
        {
            Text = text;
            IsHidden = false;
        }

        // Method to hide the word
        public void Hide()
        {
            IsHidden = true;
        }

        // Method to get the word, hidden or not
        public string GetDisplayText()
        {
            return IsHidden ? new string('_', Text.Length) : Text;
        }
    }

    // Represents the scripture reference (e.g., "John 3:16")
    public class Reference
    {
        public string Text { get; private set; }

        public Reference(string referenceText)
        {
            Text = referenceText;
        }
    }

    // Represents a scripture (including its reference and text)
    public class Scripture
    {
        public Reference Reference { get; private set; }
        public List<Word> Words { get; private set; }

        public Scripture(string referenceText, string scriptureText)
        {
            Reference = new Reference(referenceText);
            Words = scriptureText.Split(' ')
                .Select(word => new Word(word))
                .ToList();
        }

        // Method to display the full scripture with hidden words
        public void Display()
        {
            Console.Clear();
            Console.WriteLine(Reference.Text);
            Console.WriteLine(string.Join(" ", Words.Select(word => word.GetDisplayText())));
        }

        // Method to hide a random word
        public void HideRandomWord()
        {
            var hiddenWords = Words.Where(w => !w.IsHidden).ToList();
            if (hiddenWords.Count > 0)
            {
                var random = new Random();
                int index = random.Next(hiddenWords.Count);
                hiddenWords[index].Hide();
            }
        }

        // Method to check if all words are hidden
        public bool AllWordsHidden()
        {
            return Words.All(w => w.IsHidden);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example scripture
            string referenceText = "John 3:16";
            string scriptureText = "For God so loved the world that he gave his only begotten Son";

            // Create the scripture object
            Scripture scripture = new Scripture(referenceText, scriptureText);

            // Display the scripture initially
            scripture.Display();

            // Main program loop
            while (true)
            {
                // Prompt user to press enter or type 'quit'
                Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
                string input = Console.ReadLine().Trim();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                // Hide a random word and display the updated scripture
                scripture.HideRandomWord();
                scripture.Display();

                // Check if all words are hidden, then exit
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden! Memorization complete.");
                    break;
                }
            }
        }
    }
}

