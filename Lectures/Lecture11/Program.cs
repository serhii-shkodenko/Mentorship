using Lecture11;
using static System.Console;

public class Program
{
    private static void Main(string[] args)
    {
        RunSimleExample();
        //ExampleWithIdenticalItems();
        //ExampleGetByHash();

        // General
        ReadLine();
    }

    private static void RunSimleExample()
    {
        var featureToInit = new[]
        {
            "Feature one",
            "Feature two",
        };

        var features = new ApplicationFeatures(featureToInit);
        var enumerator = features.GetEnumerator();

        while (enumerator.MoveNext())
        {
            WriteLine(enumerator.Current);
        }
    }

    private static void ExampleWithIdenticalItems()
    {
        var featureToInit = new[]
        {
            "Feature one",
            "Feature one",
        };

        var features = new ApplicationFeatures(featureToInit);
        var enumerator = features.GetEnumerator();

        while (enumerator.MoveNext())
        {
            WriteLine(enumerator.Current);
        }
    }

    private static void ExampleGetByHash()
    {
        var featureToInit = new[]
        {
            "Feature one",
            "Feature two",
        };

        var features = new ApplicationFeatures(featureToInit);

        //WriteLine(features[1]);
        WriteLine(features["Feature two".GetHashCode()]);
    }
}