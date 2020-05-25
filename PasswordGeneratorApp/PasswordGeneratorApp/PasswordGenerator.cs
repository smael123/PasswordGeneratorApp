using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGeneratorApp
{
    public class PasswordGenerator
    {
        private int _length;
        private bool _includeSpecialCharacters;
        private bool _includeNumbers;

        public PasswordGenerator()
        {
            _length = 8;
            _includeSpecialCharacters = true;
            _includeNumbers = true;
        }

        public PasswordGenerator(int length, bool includeSpecialCharacters, bool includeNumbers)
        {
            _length = length;
            _includeSpecialCharacters = includeSpecialCharacters;
            _includeNumbers = includeNumbers;
        }

        public string GeneratePassword() {
            //int applicableStart = 33;

            //var rangesToIgnore = new List<CharRange>();

            //rangesToIgnore.Add(new CharRange { Start = 0, End = 32 });

            //if (!_includeSpecialCharacters) {
            //    rangesToIgnore.AddRange(new CharRange[] {
            //        new CharRange { Start = 33, End = 47 },
            //        new CharRange { Start = 58, End = 64 },
            //        new CharRange { Start = 91, End = 96 },
            //        new CharRange { Start = 123, End = 126 }
            //    });
            //}

            //if (!_includeNumbers) {
            //    rangesToIgnore.Add(new CharRange { Start = 48, End = 57 });
            //}

            var applicableIndices = new List<int>();

            //65 to 90
            applicableIndices.AddRange(Enumerable.Range(65, 25));
            applicableIndices.AddRange(Enumerable.Range(97, 25));

            if (_includeNumbers) {
                applicableIndices.AddRange(Enumerable.Range(48, 9));
            }

            if (_includeSpecialCharacters) {
                applicableIndices.AddRange(Enumerable.Range(33, 14));
                applicableIndices.AddRange(Enumerable.Range(58, 6));
                applicableIndices.AddRange(Enumerable.Range(91, 5));
                applicableIndices.AddRange(Enumerable.Range(123, 3));
            }

            int maxRandomValue = applicableIndices.Count;

            var passwordStringBuilder = new StringBuilder(_length);

            for (int i = 0; i < _length; i++) {
                Random random = new Random();

                int num = random.Next(maxRandomValue);

                passwordStringBuilder.Append((char)(applicableIndices[num]));
            }

            return passwordStringBuilder.ToString();
        }
    }
}
