using System;

namespace PasswordGen
{
    class PasswordGen
    {
        const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string specialChars = "!\"£$%^&*(){}[]@#\'.,\\?/";

        public static string Generate(int length, bool specialCharsAllowed, bool letterBias)
        {
            string generatedPsswd = "";
            Random rnd = new Random();
            for(int i = 0; i < length; i++)
            {
                int nextChar = specialCharsAllowed ? (letterBias ? rnd.Next(5) : rnd.Next(3)) : rnd.Next(2);
                switch(nextChar)
                {
                    case 0:
                    case 3:
                        int pos = rnd.Next(26);
                        generatedPsswd += lowerChars[pos];
                        break;
                    case 1:
                    case 4:
                        int pos2 = rnd.Next(26);
                        generatedPsswd += upperChars[pos2];
                        break;
                    case 2:
                        int pos3 = rnd.Next(specialChars.Length);
                        generatedPsswd += specialChars[pos3];
                        break;
                }
            }
            return generatedPsswd;
        }
    }
}
