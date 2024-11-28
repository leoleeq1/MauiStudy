using System.Text;

namespace Core
{
    public static class PhonewordTranslator
    {
        public static string ToNumber(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw))
                return string.Empty;

            raw = raw.ToUpperInvariant();

            var newNumber = new StringBuilder(raw.Length);
            foreach (char c in raw)
            {
                if (" -0123456789".Contains(c))
                {
                    newNumber.Append(c);
                }
                else
                {
                    var result = TranslateNumber(c);
                    if (result == null)
                    {
                        return string.Empty;
                    }

                    newNumber.Append(result);
                }
            }

            return newNumber.ToString();
        }

        static readonly string[] digits = { "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ" };

        static int? TranslateNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                {
                    return 2 + i;
                }
            }

            return null;
        }
    }
}