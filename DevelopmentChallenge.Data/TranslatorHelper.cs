namespace DevelopmentChallenge.Data
{
    public static class TranslatorHelper
    {
        public static string GetTranslation(string key)
        {
            return language.ResourceManager.GetString(key);
        }
    }
}
