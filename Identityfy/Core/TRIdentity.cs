using System;

namespace Identityfy.Core
{
    public static class TRIdentity
    {
        const int TRINO_LENGTH = 11;

        /// <summary>
        ///  This method validate a Turkey Republic Identity Number,
        ///  TRINO : Turkey Republic Identity Number
        /// </summary>
        /// <param name="TRINO"> Turkey Republic Identity Number to validate </param>
        /// <returns> bool </returns>
        public static bool ValidateTRINO(string TRINO)
        {
            if (TRINO.Length != TRINO_LENGTH || TRINO[0] is '0') return false;

            int odd, even, ninth, tenth;
            odd = even = 0;

            for (int i = 0; i < 9; i++)
            {
                if (i % 2 is 0)
                    odd += GetNumericValue(TRINO[i]);
                else
                    even += GetNumericValue(TRINO[i]);
            }

            ninth = GetNumericValue(TRINO[9]);
            tenth = GetNumericValue(TRINO[10]);

            return (odd * 7 - even) % 10 == ninth ?
                (odd + even + ninth) % 10 == tenth : false;
        }

        /// <summary>
        ///  Generates a validate Turkey Republic Identity Number
        /// </summary>
        /// <returns> string </returns>
        public static string GetRandomValidTRINO()
        {
            string result = "";
            int odd, even, ninth, randomNumber;
            odd = even = 0;

            Random random = new Random();

            randomNumber = random.Next(9) + 1;
            result += randomNumber;
            odd += randomNumber;

            for (int i = 0; i < 8; i++)
            {
                randomNumber = random.Next(9);
                result += randomNumber;

                if (i % 2 is 0)
                    even += randomNumber;
                else
                    odd += randomNumber;
            }
            ninth = (odd * 7 - even) % 10;
            result += ninth;
            result += (odd + even + ninth) % 10;

            return result;
        }

        private static int GetNumericValue(char input)
        {
            return (int)Char.GetNumericValue(input);
        }

    }




}
