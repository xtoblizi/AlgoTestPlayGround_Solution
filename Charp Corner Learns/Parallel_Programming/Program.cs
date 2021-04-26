using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;

class Program
{
    static readonly BlockingCollection<string> Collection = new BlockingCollection<string>();
    private static int _count = 0;
    static void Main()
    {
        const int maxTasks = 5;//we are going to spawn 5 processes for our example.
        var tasks = new List<Task> {
            Task.Factory.StartNew(() => {
                for(var i = 0; i < 5; i++)
                {
                    Collection.Add(i.ToString(CultureInfo.InvariantCulture));//adding 5 items to the collection object.
                }
                Console.WriteLine("Spawning multiple processes completed. Now wait and see till all the jobs are completed.");
                Collection.CompleteAdding();
            }),
        };
        for (var i = 0; i < maxTasks; i++)
        {
            tasks.Add(Task.Factory.StartNew(UserTasks(i)));//Add new tasks
        }
        Task.WaitAll(tasks.ToArray()); // wait for completion
    }

    static Action UserTasks(int id)
    {
        // return a closure just so the id can get passed
        return () =>
        {
            while (true)
            {
                string item;
                if (Collection.TryTake(out item, -1))
                {
                    using (Process p = new Process())
                    {
                        p.StartInfo.FileName = "notepad.exe";
                        //p.StartInfo.Arguments = item;
                        p.Start();
                        p.WaitForExit();
                        var exitCode = p.ExitCode;
                        Console.WriteLine(exitCode == 0 ? "{0} exited successfully!!!" : "{0} exited failed!!!", p.Id);
                    }
                }
                else if (Collection.IsAddingCompleted)
                {
                    break; // exit loop
                }
            }
            Console.WriteLine("Consumer {0} finished", id);
            _count = _count + 1;
            if (_count == 4)
            {
                Console.ReadLine();
            }
        };
    }
}