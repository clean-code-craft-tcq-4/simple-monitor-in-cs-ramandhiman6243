public class Language
{
    LanguageName name;
    Phrase[] phrases;

    public LanguageName Name { get => name; set => name = value; }

    public Phrase[] Phrases { get => phrases; set => phrases = value; }

    public Language(LanguageName name, Phrase[] phrases)
    {
        Name = name;
        Phrases = phrases;
    }
}

public enum LanguageName
{
    English,
    German
}

public class Phrase
{
    string phraseId;
    string translation;

    public string PhraseId { get => phraseId; set => phraseId = value; }
    public string Translation { get => translation; set => translation = value; }

    public Phrase(string phraseId, string translation)
    {
        PhraseId = phraseId;
        Translation = translation;
    }
}