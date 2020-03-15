using System;
using System.Threading.Tasks;
namespace New_Async_Await_Task_FromResult
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Async n Await same as Multithreading, But Multithreading cannot pass paramter from one thread to another
            // Async n Await can pass paramter to one thread to another.
            // Async Assign function to Task
            // Task run Function on new thread
            // Await pass the parameter between threads

            Demo obj = new Demo();
            int result = 0;

            // Function 1 With 0 Input Param and Return Value
            Task.Run(async () =>
            {
                result = await obj.Function1();
                Console.WriteLine("Function 1 With 0 Input Param and Return Value " + result);
            }).Wait();

            // Function 2 With 1 Input Param and Return Value
            Task.Run(async () =>
            {
                result = await obj.Function2(80);
                Console.WriteLine("Function 2 With 0 Input Param and Return Value " + result);
            }).Wait();

            // Function 3 With 2 Input Param and Return Value
            Task.Run(async () =>
            {
                result = await obj.Function3(50, 60);
                Console.WriteLine("Function 3 With 2 Input Param and Return Value " + result);
            }).Wait();



            // Function 4 With 0 Input Param and No Return Value
            Task.Run(async () =>
            {
                await obj.Function4();

            }).Wait();

            // Function 5 With 2 Input Param and No Return Value
            Task.Run(async () =>
            {
                await obj.Function5(70, 110);

            }).Wait();

            Console.ReadLine();
        }



    }

    public class Demo
    {
        // New Way of return Value using FromResult<>
        // Function 1 With 0 Input Param and 1 Output Value
        public async Task<int> Function1()
        {
            return await Task.FromResult<int>(12594);
        }

        // New Way of return Value using FromResult<>
        // Function 2 With 1 Input Param and 1 Output Value
        public async Task<int> Function2(int x)
        {
            return await Task.FromResult<int>(x * 50);
        }

        // New Way of return Value using FromResult<>
        // Function 3 With 2 Input Param and 1 Output Value
        public async Task<int> Function3(int x, int y)
        {
            return await Task.FromResult<int>(x + y);
        }

        // Function 4 With 0 Input Param and No Output Value
        public async Task Function4()
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Function 4 With 0 Input Param and Not Return Value ");
            });
        }

        // Function 5 With 2 Input Param and No Output Value
        public async Task Function5(int x, int y)
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Function 4 With 0 Input Param and Not Return Value " + x + y);
            });
        }
    }
}
