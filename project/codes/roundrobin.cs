using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class roundrobin
    {

    List<string> chart = new List<string>();


    public static float func (process[] p, int n,int slice,Scheduling x)
    { int count = 0;
      int end=0;
      process exec = new process();
        int number = 0;
        int number_label = 0;
        float average_waiting_time = 0;
       // float average_turnaaround_time = 0;
        int flag = 0;
        int flag2 = 1;
        PriorityQueue<process> roundq = new PriorityQueue<process>();
      for (int i=0;i< n;i++)
      {
            p[i].priority = p[i].arrival_time;
            roundq.Enqueue(p[i]);

      }
        while (roundq.Count() != 0 || flag2 == 1 )
        {

            process temporary = new process();
            process temporary2 = new process();
            process temporary3 = new process();
            process temporary4 = new process();
            if (count == 0&&flag==0)
            {
                count = roundq.Peek().arrival_time;
                temporary.copy(roundq.Dequeue());
                exec.copy(temporary);
                Console.WriteLine(exec.name + " started  at " + count);
                if (count != 0)
                {
                    x.add_label("X", number_label, end);
                    number_label++;
                    x.add_label(exec.name, number_label, count);
                }
                else
                {
                    x.add_label(exec.name, number_label, count);

                }
                average_waiting_time += (count - exec.arrival_time);
                number++;
                exec.begin = count;
                flag = 1;
                if (roundq.Count() == 0)
                    flag2 = 1;

            }
            else if (exec.burst_time > slice)
            {   
                flag2 = 0;
                count += slice;
                exec.end = count;
                Console.WriteLine(exec.name + " finished  at " + count);
                end = count;
                temporary2.burst_time = exec.burst_time - (exec.end - exec.begin);
                temporary2.name = exec.name;
                temporary2.arrival_time = count;
                temporary2.priority = temporary2.arrival_time;
                if (temporary2.burst_time > slice && roundq.Count() == 0)
                    flag2 = 1;
                else
                    flag2 = 0;

                roundq.Enqueue(temporary2);
                temporary3.copy(roundq.Dequeue());
                exec.copy(temporary3);
                exec.begin = count;
                Console.WriteLine(exec.name + " started  at " + count);
                number_label++;
                if (end != count)
                {
                    x.add_label("X", number_label, end);
                    number_label++;
                    x.add_label(exec.name, number_label, count);

                }
                else
                x.add_label(exec.name, number_label, count);
                average_waiting_time += (count - exec.arrival_time);
                number++;

            }

            else if (exec.burst_time <= slice)  //5ly balak kman mn ysawy
            {
                flag2 = 0;
                count += exec.burst_time ;
                Console.WriteLine(exec.name + " finished  at " + count);
                end = count;
                if (roundq.Count() != 0)
                {
                    temporary4.copy(roundq.Dequeue());
                    exec.copy(temporary4);
                    if(roundq.Count()==0)
                    {
                        flag2 = 1;
                    }
                    if(exec.arrival_time>count)
                    {
                        count = exec.arrival_time;
                    }
                    exec.begin = count;
                    Console.WriteLine(exec.name + " started  at " + count);
                    number_label++;
                    if (end != count)
                    {
                        x.add_label("X", number_label, end);
                        number_label++;
                        x.add_label(exec.name, number_label, count);

                    }
                    else
                        x.add_label(exec.name, number_label, count);
                    average_waiting_time += (count - exec.arrival_time);
                    number++;
                }
                

            }

            if (exec.burst_time < slice && roundq.Count() == 0)
                flag2 = 0;
            if (roundq.Count() == 0 && flag2 != 1)
            {
                count += exec.burst_time;
                exec.end = count;
                Console.WriteLine(exec.name + " finished  at " + count);
                end = count;
                x.add_last_time(number_label, count);

            }
        }
        average_waiting_time = average_waiting_time / n;
        Console.WriteLine("average_waiting_time is " + average_waiting_time);
        return average_waiting_time;

    }



}

