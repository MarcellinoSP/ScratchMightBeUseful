using Validation;

namespace Comparer.Trial;

internal class Program
{
    static void Main()
    {
        String[] floor = new[] { "1", "1.11", "1.2", "1.1.1", "1.2.1", "1.5" };
        Array.Sort(floor, new CompareFloor());

        foreach (var f in floor)
        {
            Console.WriteLine(f);
        }
    }

    private class CompareFloor : IComparer<string>
    {
        public int Compare(string? floorA, string? floorB)
        {
            Verify.Operation(floorA is not null && floorB is not null, "Null reference found");
            String[] a = floorA.Split(".");
            String[] b = floorB.Split(".");

            int len = Math.Min(a.Length, b.Length);

            for (int i = 0; i < len; i++)
            {
                int numA = Convert.ToInt32(a[i]);
                int numB = Convert.ToInt32(b[i]);

                if (numA != numB)
                {
                    return numA.CompareTo(numB);
                }
            }

            return a.Length.CompareTo(b.Length);
        }
    }
}