using System.Diagnostics;

using compare_thrread_speed;

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


var ct = new ConcurrencyTasks();
short[] randomArray = ct.GenerateRandomArray();

var stopwatch = new Stopwatch();
stopwatch.Start();
Console.WriteLine("Starting timer now");
short result = await ct.FindMax(randomArray, 0, 9999);
stopwatch.Stop();
var elapsed_time = stopwatch.ToString();
Console.WriteLine("Finshed in {0} milliseconds", elapsed_time);
Console.WriteLine("The max in the array is : {0}", result.ToString());
