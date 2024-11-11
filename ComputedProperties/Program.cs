using System;

namespace Coding.Exercise
{
    public class DailyAccountState
    {
        public int InitialState { get; }
        
        public int SumOfOperations { get;}
        
        public DailyAccountState(
            int initialState, 
            int sumOfOperations)
        {
            InitialState = initialState;
            SumOfOperations = sumOfOperations;
        }
        
        // computed properties
        public int EndOfDayState => InitialState + SumOfOperations;
        public string Report => $"Day: {DateTime.Now.Day}" + $", month: {DateTime.Now.Month}" + $", year: {DateTime.Now.Year}" + $", initial state: {InitialState}" + $", end of day state: {EndOfDayState}";

        // methods
        public int CalculateEndOfDayState() => InitialState + SumOfOperations;
        public string GetReport() => $"Day: {DateTime.Now.Day}" + $", month: {DateTime.Now.Month}" + $", year: {DateTime.Now.Year}" + $", initial state: {InitialState}" + $", end of day state: {EndOfDayState}";

        public static void Main()
        {
            DailyAccountState state1 = new DailyAccountState(2000, -200);

            // use of computed Properties to access dynamic values
            Console.WriteLine(state1.EndOfDayState);
            Console.WriteLine(state1.Report);

            // Use of methods to perform action
            Console.WriteLine(state1.CalculateEndOfDayState());
            Console.WriteLine(state1.GetReport());
        }        
    }
}