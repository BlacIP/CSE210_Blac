using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        library.AddScripture(new Scripture(new ScriptureReference("John 3:16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
        library.AddScripture(new Scripture(new ScriptureReference("Proverbs 3:5-6"), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
        library.AddScripture(new Scripture(new ScriptureReference("Psalm 23:1"), "The Lord is my shepherd, I lack nothing."));
        library.AddScripture(new Scripture(new ScriptureReference("Romans 8:28"), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."));

        Random random = new Random();

        while (library.HasScriptures())
        {
            Scripture scripture = library.GetRandomScripture();
            scripture.Display();

            while (scripture.HasHiddenWords())
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                scripture.HideRandomWords();
                scripture.Display();
            }

            library.RemoveScripture(scripture);
        }
    }
}

class ScriptureLibrary
{
    private Scripture[] scriptures;
    private int count;
    private Random random;

    public ScriptureLibrary()
    {
        scriptures = new Scripture[10]; // Initializing with a fixed size
        count = 0;
        random = new Random();
    }

    public void AddScripture(Scripture scripture)
    {
        if (count < scriptures.Length)
        {
            scriptures[count] = scripture;
            count++;
        }
        else
        {
            // This Handles the case where the array is full
            
        }
    }

    public bool HasScriptures()
    {
        return count > 0;
    }

    public Scripture GetRandomScripture()
    {
        int index = random.Next(count);
        return scriptures[index];
    }

    public void RemoveScripture(Scripture scripture)
    {
        int index = Array.IndexOf(scriptures, scripture);
        if (index >= 0)
        {
            scriptures[index] = scriptures[count - 1];
            scriptures[count - 1] = null;
            count--;
        }
    }
}

class Scripture
{
    private ScriptureReference reference;
    private Word[] words;
    private bool[] hiddenWords;

    public Scripture(ScriptureReference reference, string text)
    {
        this.reference = reference;
        string[] wordArray = text.Split(' ');
        words = new Word[wordArray.Length];
        hiddenWords = new bool[wordArray.Length];

        for (int i = 0; i < wordArray.Length; i++)
        {
            words[i] = new Word(wordArray[i]);
        }
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(reference.ToString());

        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords[i])
                Console.Write("_____ ");
            else
                Console.Write(words[i].Text + " ");
        }

        Console.WriteLine();
    }

    public bool HasHiddenWords()
    {
        foreach (bool hidden in hiddenWords)
        {
            if (!hidden)
                return true;
        }
        return false;
    }

    public void HideRandomWords()
    {
        Random random = new Random();

        for (int i = 0; i < words.Length; i++)
        {
            if (!hiddenWords[i] && random.Next(2) == 0)
            {
                hiddenWords[i] = true;
            }
        }
    }
}

class ScriptureReference
{
    public string Reference { get; private set; }

    public ScriptureReference(string reference)
    {
        Reference = reference;
    }

    public override string ToString()
    {
        return Reference;
    }
}

class Word
{
    public string Text { get; private set; }

    public Word(string text)
    {
        Text = text;
    }
}
