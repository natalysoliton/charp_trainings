using NUnit.Framework;
using System.Text;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        // Генератор случайных строк
        /*public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }*/
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                int randomValue = Convert.ToInt32(rnd.NextDouble() * 62);

                if (randomValue < 26) // A-Z
                {
                    builder.Append(Convert.ToChar(65 + randomValue));
                }
                else if (randomValue < 52) // a-z
                {
                    builder.Append(Convert.ToChar(97 + (randomValue - 26)));
                }
                else // 0-9
                {
                    builder.Append(Convert.ToChar(48 + (randomValue - 52)));
                }
            }
            return builder.ToString();
        }
    }
}

