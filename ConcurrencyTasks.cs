namespace compare_thrread_speed;

using System.Threading.Tasks;

public class ConcurrencyTasks
{
    public short[] GenerateRandomArray(int size = 10000)
    {
        short[] randomArray = new short[size];
        Random rnd = new Random();

        for (int i = 0; i < size; ++i)
        {
            short randomNum = (short)rnd.Next(-32768, 32767);
            randomArray[i] = randomNum;
        }

        return randomArray;
    }

    // public short FindMax(short[] arr)
    // {
    //     const int MIN_NUM_IN_ARRAY = 2;

    //     if (arr.Length <= MIN_NUM_IN_ARRAY)
    //     {
    //         return arr.Max();
    //     }

    //     int mid;
    //     if (arr.Length % 2 == 0)
    //     {
    //         mid = arr.Length / 2;
    //     }
    //     else
    //     {
    //         mid = (arr.Length / 2) + 1;
    //     }

    //     var left = arr[..mid];
    //     var right = arr[mid..];

    //     var taskLeft = Task.Run(() => FindMax(left));
    //     var taskRight = Task.Run(() => FindMax(right));

    //     Task.WaitAll(taskLeft, taskRight);

    //     var maxLeft = taskLeft.Result;
    //     var maxRight = taskRight.Result;

    //     return Math.Max(maxLeft, maxRight);
    // }

    public async Task<short> FindMax(short[] array, int start, int end)
    {
        if (start == end)
        {
            // Base case: single element
            return array[start];
        }

        if (start + 1 == end)
        {
            // Base case: two elements
            return (short)Math.Max(array[start], array[end]);
        }

        // Divide the array into two halves
        int mid = (start + end) / 2;

        // Find max in each half asynchronously
        Task<short> leftTask = Task.Run(() => FindMax(array, start, mid));
        Task<short> rightTask = Task.Run(() => FindMax(array, mid + 1, end));

        // Wait for both tasks to complete
        short[] results = await Task.WhenAll(leftTask, rightTask);

        // Return the maximum of both halves
        return (short)Math.Max(results[0], results[1]);
    }
}
