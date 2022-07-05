namespace Utils
{
    public static class Validators
    {
        public static bool ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            return true;
        }
    }
}