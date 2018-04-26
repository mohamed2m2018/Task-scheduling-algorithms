using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class fcfs
    {

    public static float fcfs_function (process[] x, int n,Scheduling s)
    {
        int t=0;
        int end = 0;
        int number_label=0;
        float average_waiting_time = 0;
        float average_turnaaround_time = 0;
        process exec = new process();
        PriorityQueue<process> q = new PriorityQueue<process>();
        for (int i = 0; i < n; i++)
        {
            x[i].priority = x[i].arrival_time;
            q.Enqueue(x[i]);
        }
        for (int i = 0; i < n; i++)
        {
            exec = q.Dequeue();
            if (i == 0 || exec.arrival_time > t)
                t = exec.arrival_time;
            Console.WriteLine(exec.name + " starts at " + t);
            average_waiting_time += (t - exec.arrival_time);
            if (i == 0)
            {

                if (t != 0)
                {
                    s.add_label("X", number_label, end);
                    number_label++;
                    s.add_label(exec.name, number_label, t);

                }
                else
                    s.add_label(exec.name, number_label, t);
            }
            else
            {
                number_label++;
                if (end != t)
                {
                    s.add_label("X", number_label, end);
                    number_label++;
                    s.add_label(exec.name, number_label, t);

                }
                else
                    s.add_label(exec.name, number_label, t);

            }
            t += exec.burst_time;
            Console.WriteLine(exec.name + " ends at " + t);
            end = t;
            if(i==n-1)
                s.add_last_time(number_label, t);
            average_turnaaround_time += (t - exec.arrival_time);

        }

        average_waiting_time = average_waiting_time / n;
        Console.WriteLine("average_waiting_time is " + average_waiting_time);
        average_turnaaround_time = average_turnaaround_time / n;
        Console.WriteLine("average_turnaround_time is " + average_turnaaround_time);
        return average_waiting_time;

    }

}

