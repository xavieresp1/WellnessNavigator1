namespace WellnessNavigator1.Classes
{
    public abstract class Algorithms
    {
        public abstract string ComputeHash(string input);
        public abstract string ComputeHash(string password, byte[] salt);
    }

}
