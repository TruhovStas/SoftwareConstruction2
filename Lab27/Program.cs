using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Word
{
    public string Text { get; set; }
}

public class Sentence
{
    public List<Word> Words { get; } = new List<Word>();
    public string Punctuation { get; set; } // Знак препинания
}

public class TextBlock
{
    public List<Sentence> Sentences { get; } = new List<Sentence>();
}

public class AnalyzedText
{
    public List<TextBlock> Blocks { get; } = new List<TextBlock>();
}

public class TextParser
{
    public static AnalyzedText ParseText(string text)
    {
        AnalyzedText analyzedText = new AnalyzedText();
        string[] blockTexts = text.Split(new[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var blockText in blockTexts)
        {
            TextBlock block = new TextBlock();
            List<string> p = new List<string>();
            for(int i = 0; i < blockText.Length; i++)
            {
                Match match = Regex.Match(blockText[i].ToString(), @"[.!?]+");
                if (match.Success)
                {
                    p.Add(match.Value);
                }
            }
            
            string[] sentenceTexts = blockText.Split(new[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach (var sentenceText in sentenceTexts)
            {
                Sentence sentence = new Sentence();
                string[] words = sentenceText.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var wordText in words)
                {
                    Word word = new Word { Text = wordText };
                    sentence.Words.Add(word);
                }

                // Ищем знаки препинания в оригинальном предложении и сохраняем их
                sentence.Punctuation = p[count];
                count++;
                block.Sentences.Add(sentence);
            }

            analyzedText.Blocks.Add(block);
        }

        return analyzedText;
    }

    public static string RestoreText(AnalyzedText analyzedText)
    {
        StringBuilder originalText = new StringBuilder();

        foreach (var block in analyzedText.Blocks)
        {
            foreach (var sentence in block.Sentences)
            {
                foreach (var word in sentence.Words)
                {
                    originalText.Append(word.Text);
                    originalText.Append(' ');
                }

                // Восстанавливаем оригинальный знак препинания
                originalText.Remove(originalText.Length - 1, 1);
                originalText.Append(sentence.Punctuation);
                originalText.Append(' '); // Добавляем пробел после знака препинания
            }
            //originalText.Remove(originalText.Length - 2, 2); // Убираем лишние пробелы и знак препинания в конце блока
            originalText.Append("\n\n"); // Восстанавливаем разделители блоков
        }

        return originalText.ToString();
    }
}

public static class Tasks
{
    public static List<Sentence> SortSentencesByWordCount(AnalyzedText analyzedText)
    {
        List<Sentence> sentences = new List<Sentence>();

        foreach (var block in analyzedText.Blocks)
        {
            sentences.AddRange(block.Sentences);
        }

        sentences.Sort((s1, s2) => s1.Words.Count.CompareTo(s2.Words.Count));

        return sentences;
    }

    public static string FindUniqueWordInFirstSentence(AnalyzedText analyzedText)
    {
        if (analyzedText.Blocks.Count > 0 && analyzedText.Blocks[0].Sentences.Count > 0)
        {
            Sentence firstSentence = analyzedText.Blocks[0].Sentences[0];
            HashSet<string> uniqueWords = new HashSet<string>(firstSentence.Words.Select(w => w.Text));

            foreach (var block in analyzedText.Blocks)
            {
                foreach (var sentence in block.Sentences)
                {
                    if (sentence != firstSentence)
                    {
                        foreach (var word in sentence.Words)
                        {
                            uniqueWords.Remove(word.Text);
                        }
                    }
                }
            }

            if (uniqueWords.Count > 0)
            {
                return uniqueWords.First();
            }
            else return "В первом предложении нет уникальных слов";
        }

        return null;
    }

}


class Program
{
    static void Main(string[] args)
    {
        string inputText = "Нет Стас. Это да да!\n\n"
            + "Нет?";

        AnalyzedText analyzedText = TextParser.ParseText(inputText);
        string restoredText = TextParser.RestoreText(analyzedText);

        Console.WriteLine("Исходный текст:");
        Console.WriteLine(inputText);

        Console.WriteLine("\nВосстановленный текст:");
        Console.WriteLine(restoredText);
        Console.WriteLine("Предложения в порядке возрастания количества слов\n");
        foreach (var sentence in Tasks.SortSentencesByWordCount(analyzedText))
        {
            string s = string.Empty;
            foreach (var word in sentence.Words)
            {
                s += word.Text + " ";
            }
            s = s.Remove(s.Length - 1);
            s += sentence.Punctuation + "\n";
            Console.Write(s);
        }
        Console.WriteLine("Уникальное слово в первом предложении");
        Console.WriteLine(Tasks.FindUniqueWordInFirstSentence(analyzedText));
        Console.ReadLine();
    }
}
