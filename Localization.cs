public class Localization
{
    public class Phrases
    {
        public const string Temperature_OutOfRange = "Temperature_OutOfRange";
        public const string Temperature_ApproachingMinimum = "Temperature_ApproachingMinimum";
        public const string Temperature_ApproachingMaximum = "Temperature_ApproachingMaximum";

        public const string Soc_OutOfRange = "Soc_OutOfRange";
        public const string Soc_ApproachingMinimum = "Soc_ApproachingMinimum";
        public const string Soc_ApproachingMaximum = "Soc_ApproachingMaximum";

        public const string ChargeRate_OutOfRange = "ChargeRate_OutOfRange";
        public const string ChargeRate_ApproachingMaximum = "ChargeRate_ApproachingMaximum";

        public const string AllOk = "AllOk";
    }

    public const string UndefinedError = "Error: Undefined!!!";

    static Language[] languages = new Language[]
    {
        new Language(LanguageName.English, new Phrase[]
            {
                new Phrase(Phrases.Temperature_OutOfRange, "Temperature is out of range!"),
                new Phrase(Phrases.Temperature_ApproachingMinimum, "Warning: Approaching minimum temperature!"),
                new Phrase(Phrases.Temperature_ApproachingMaximum, "Warning: Approaching maximum temperature!"),

                new Phrase(Phrases.Soc_OutOfRange, "State of charge is out of range!"),
                new Phrase(Phrases.Soc_ApproachingMinimum, "Warning: Approaching minimum state of charge!"),
                new Phrase(Phrases.Soc_ApproachingMinimum, "Warning: Approaching minimum state of charge!"),
                new Phrase(Phrases.Soc_ApproachingMaximum, "Warning: Approaching maximum state of charge!"),

                new Phrase(Phrases.ChargeRate_OutOfRange, "Charge rate is out of range!"),
                new Phrase(Phrases.ChargeRate_ApproachingMaximum, "Warning: Approaching maximum charge rate!"),
                new Phrase(Phrases.AllOk, "All Okay!")
            }),
            new Language(LanguageName.German, new Phrase[]
            {
                new Phrase(Phrases.Temperature_OutOfRange, "Temperatur aus der Änderung!"),
                new Phrase(Phrases.Temperature_ApproachingMinimum, "Warnung: Annäherung an die Mindesttemperatur!"),
                new Phrase(Phrases.Temperature_ApproachingMaximum, "Warnung: Annäherung an die maximale Temperatur!"),

                new Phrase(Phrases.Soc_OutOfRange, "Ladezustand außerhalb des Bereichs!"),
                new Phrase(Phrases.Soc_ApproachingMinimum, "Achtung: Annäherung an minimalen Ladezustand!"),
                new Phrase(Phrases.Soc_ApproachingMaximum, "Achtung: Annäherung an maximalen Ladezustand!"),

                new Phrase(Phrases.ChargeRate_OutOfRange, "Der Ladestrom liegt außerhalb des zulässigen Bereichs!"),
                new Phrase(Phrases.ChargeRate_ApproachingMaximum, "Warnung: Annäherung an den maximalen Ladestrom!"),
                new Phrase(Phrases.AllOk, "Alles Okay!")
            })
    };

    static Language selectedLanguage = languages[0];

    public static void SetCurrentLanguage(LanguageName language)
    {
        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[i].Name == language)
            {
                selectedLanguage = languages[i];
            }
        }
    }

    public static string GetInSelectedLanguage(string phrase)
    {
        for (int i = 0; i < selectedLanguage.Phrases.Length; i++)
        {
            if (selectedLanguage.Phrases[i].PhraseId.Equals(phrase))
                return selectedLanguage.Phrases[i].Translation;
        }

        return UndefinedError;
    }
}