namespace PuzzleSolverTest
{
    public class Puzzles
    {
        private string[] InputFileLines01 { get; set; }
        private Dictionary<string, string> NumDict;

        [SetUp]
        public void Setup()
        {
            InputFileLines01 = File.ReadAllLines(Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "day-1-input.txt"));
            string numstring = "zero=0;one=1;two=2;three=3;four=4;five=5;six=6;seven=7;eight=8;nine=9;ten=10;eleven=11;twelve=12;thirteen=13;fourteen=14;fifteen=15;sixteen=16;seventeen=17;eighteen=18;nineteen=19;twenty=20;thirty=30;fourty=40;fifty=50;sixty=60;seventy=70;eighty=80;ninety=90;hundred=100;thousand=1000;";
            NumDict = numstring.TrimEnd(';').Split(';').ToDictionary(item => item.Split('=')[0], item => item.Split('=')[1]);
        }

        // Read File and get first and last numbers
        [Test]
        public void Day01()
        {
            var combinationArray = new int[InputFileLines01.Length];

            for (int line = 0; line < InputFileLines01.Length; line++)
            {
                var first = InputFileLines01[line].First(c => char.IsDigit(c));
                var last = InputFileLines01[line].Last(c => char.IsDigit(c));
                combinationArray[line] = int.Parse($"{first}{last}");
            }

            var resultSum = combinationArray.Sum(c => c);
            Console.WriteLine(resultSum);
            Assert.That(resultSum, Is.Not.Zero);
        }

        // Read File and get first and last numbers, but checking words too
        [Test]
        public void Day02()
        {
            Assert.Pass();
        }
    }
}