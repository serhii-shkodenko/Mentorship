using System;
using System.Collections.Generic;
using static System.Console;

public class Program
{
    private static readonly string _importantField = "Information";

    public static void Main(string[] args)
    {
        //RunAnonymMethodExample();
        //RunClosureExample();
        //RunLoopClosure();

        // General
        ReadLine();
    }

    public static void RunAnonymMethodExample()
    {
        var param = 3; //
        WriteLine(GetResultFromAnonymMethod(ref param));
    }

    public static void RunLoopClosure()
    {
        var actions = new List<Action>();

        for (var i = 0; i < 3; i++)
        {
            actions.Add(() => WriteLine(i));
        }

        foreach (var action in actions)
        {
            action.Invoke();
        }
    }

    public static void RunClosureExample()
    {
        var closure = GetClose();
        WriteLine(closure(1));
        WriteLine(closure(1));
        WriteLine(closure(1));
        WriteLine();

        closure = GetClose();
        WriteLine(closure(1));
        WriteLine(closure(1));
        WriteLine(closure(1));
    }

    private static string GetResultFromAnonymMethod(ref int param)
    {
        Func<string> anonymFunc = delegate
        {
            //var newValue = param;
            //var param = 3;
            //var param = _importantField;
            return "Some value";
        };

        return anonymFunc.Invoke();
    }

    private static Func<int, int> GetClose()
    {
        var internalValue = 10;

        Func<int, int> myFunc = delegate (int count)
        {
            int sum = default;

            for (var i = 0; i < count; i++)
            {
                sum = +i;
            }

            internalValue += internalValue;
            return sum + internalValue;
        };

        return myFunc;
    }
}