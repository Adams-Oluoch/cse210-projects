using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(" "))
        {
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int wordsToHide)
    {
        // Only hide words that are NOT already hidden
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // Hide up to the requested number of visible words
        for (int i = 0; i < wordsToHide && visibleWords.Count > 0; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Remove so we don't hide the same word twice
        }
    }
    
    public bool RevealOneWord()
    {
        // Find all hidden words
        List<Word> hiddenWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (word.IsHidden())
            {
                hiddenWords.Add(word);
            }
        }
        
        if (hiddenWords.Count > 0)
        {
            int index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Reveal();
            return true;
        }
        
        return false;
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
                return false;
        }
        return true;
    }
    
    public double GetHiddenPercentage()
    {
        int hiddenCount = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
                hiddenCount++;
        }
        
        if (_words.Count == 0) return 0;
        return (double)hiddenCount / _words.Count * 100;
    }
    
    public int GetHiddenWordCount()
    {
        int count = 0;
        foreach (Word word in _words)
        {
            if (word.IsHidden())
                count++;
        }
        return count;
    }
    
    public int GetTotalWordCount()
    {
        return _words.Count;
    }

    public string GetDisplayText()
    {
        string text = "";

        foreach (Word word in _words)
        {
            text += word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()}\n{text}".Trim();
    }
}