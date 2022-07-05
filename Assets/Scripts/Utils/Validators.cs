namespace Utils
{
    public static class Validators
    {
        public static bool ValidateName(string name)
        {
            return !string.IsNullOrEmpty(name);
        }
    }
}