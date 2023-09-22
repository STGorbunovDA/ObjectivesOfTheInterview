using ConnTest.Infrastructure.Interfaces;

namespace ConnTest.Infrastructure
{
    internal static class SizeOf 
    {
        public static int DataTypeInBytes(string value)
        {
            int size = 0;

            if (value.Contains("double")) size = sizeof(double);
            else if (value.Contains("bool")) size = sizeof(bool);
            else if (value.Contains("int")) size = sizeof(int);

            // и тд.

            return size;
        }
    }
}
