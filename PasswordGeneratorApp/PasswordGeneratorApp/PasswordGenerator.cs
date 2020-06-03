using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGeneratorApp
{
    public class PasswordGenerator : IPasswordGenerator
    {
        public string GeneratePassword(int length, bool includeSpecialCharacters, bool includeNumbers)
        {
            var applicableIndices = new List<int>();

            //65 to 90
            applicableIndices.AddRange(Enumerable.Range(65, 25));
            applicableIndices.AddRange(Enumerable.Range(97, 25));

            if (includeNumbers)
            {
                applicableIndices.AddRange(Enumerable.Range(48, 9));
            }

            if (includeSpecialCharacters)
            {
                applicableIndices.AddRange(Enumerable.Range(33, 14));
                applicableIndices.AddRange(Enumerable.Range(58, 6));
                applicableIndices.AddRange(Enumerable.Range(91, 5));
                applicableIndices.AddRange(Enumerable.Range(123, 3));
            }

            int maxRandomValue = applicableIndices.Count;

            var passwordStringBuilder = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                Random random = new Random();

                int num = random.Next(maxRandomValue);

                passwordStringBuilder.Append((char)(applicableIndices[num]));
            }

            return passwordStringBuilder.ToString();
        }
    }
}
