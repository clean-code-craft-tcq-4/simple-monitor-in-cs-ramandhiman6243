class Checker
{
    static int Main()
    {
        Localization.SetCurrentLanguage(LanguageName.German);

        Tests.PerformTests();
        return 0;
    }
}
