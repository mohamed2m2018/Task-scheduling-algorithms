using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class periority
    {
    public static float nonpreemptive(process[] p, int n,Scheduling x)
    {
        // process[] touchable = new process[n];
        PriorityQueue<process> q = new PriorityQueue<process>();
        int count = 0;
        int end = 0;
        int number_label = 0;
        float average_waiting_time = 0;
        float average_turnaaround_time = 0;
        process temporary = new process();
        process exec = new process();
        process.arr_by_arrival(p, n, 0);


        for (int i = 0; i < n; i++)
        {
            if (p[i].arrival_time < count)  //lw fih 7aga gt wna lsa m5lstsh ..7shoof as3'r 7aga gt wa5liha tbtdy b3d mana a5ls
            {
                process smallest = new process();
                smallest = process.smallest(p, i, 2, n, count);
                Console.WriteLine(smallest.name + " starts at " + count);
                number_label++;
                if (end != count)
                {
                    x.add_label("X", number_label, end);
                    number_label++;
                    x.add_label(smallest.name, number_label, count);

                }
                else
                    x.add_label(smallest.name, number_label, count);

                average_waiting_time += (count - smallest.arrival_time);
                exec = smallest;
                count += smallest.burst_time;
                Console.WriteLine(smallest.name + " ends at " + count);
                end = count;
                if (i == n - 1)
                    x.add_last_time(number_label, count);
                average_turnaaround_time += (count - smallest.arrival_time);

            }
            else //lw awl mra aw 5lst w gt 7aga 3ady..
            {
                    if (i != n - 1)
                    if ((p[i].arrival_time==p[i+1].arrival_time)&&(p[i+1].priority_input<p[i].priority_input))
                {
                    temporary.copy(p[i]);
                    p[i].copy( p[i + 1]);
                    p[i + 1].copy(temporary);
                }
                count = p[i].arrival_time;
                Console.WriteLine(p[i].name + " starts at " + count);
                if (i == 0)
                {
                    if (count != 0)
                    {
                        x.add_label("X", number_label, end);
                        number_label++;
                        x.add_label(p[i].name, number_label, count);

                    }
                    else
                        x.add_label(p[i].name, number_label, count);
                }
                else
                {
                    number_label++;
                    if (end != count)
                    {
                        x.add_label("X", number_label, end);
                        number_label++;
                        x.add_label(p[i].name, number_label, count);

                    }
                    else
                        x.add_label(p[i].name, number_label, count);

                }
                average_waiting_time += (count - p[i].arrival_time);
                exec = p[i];
                count += p[i].burst_time;
                Console.WriteLine(p[i].name + " ends at " + count);
                end = count;
                if (i == n - 1)
                    x.add_last_time(number_label, count);
                average_turnaaround_time += (count - p[i].arrival_time);

            }

        }
        average_waiting_time = average_waiting_time / n;
        Console.WriteLine("average_waiting_time is " + average_waiting_time);
        average_turnaaround_time = average_turnaaround_time / n;
        Console.WriteLine("average_turnaround_time is " + average_turnaaround_time);
        return average_waiting_time;

    }


    public static float preemptive(process[] p, int n,Scheduling x)
    {
        // process[] touchable = new process[n];
        int count = 0;
        int end = 0;
        int number_label = 0;
        process exec = new process();


        process.arr_by_arrival(p, n, 0);
        PriorityQueue<process> arrival = new PriorityQueue<process>();
        PriorityQueue<process> waiting = new PriorityQueue<process>();
        process temporary7 = new process();
        int flag = 0;
        float average_waiting_time = 0;
      //  float average_turnaaround_time = 0;

        for (int i = 0; i < n; i++)
        {
            p[i].priority = p[i].arrival_time;
            arrival.Enqueue(p[i]);
        }
        temporary7 = arrival.Peek();
        int temporary6 = 0;
        int number = 0;

        while (arrival.Count() != 0 || (waiting.Count() != 0 || count == 0))
        {
            process smallest = new process();
            process temporary2 = new process();
            process temporary3 = new process();
            process temporary5 = new process();
            int temporary4 = 0;
            process temporary = new process();
            int temporary8 = 0;
            int temporary9 = 0;
            int temporary10;
            process temporary11 = new process();
            int temporary12;
            process temporary13 = new process();
            process temporary14 = new process();


            if (arrival.Count() != 0 && flag != 0)
                temporary8 = arrival.Peek().arrival_time;//hy7sbly awl wa7ed mstny bkam 
                while (count > temporary8 && flag != 0&& arrival.Count() != 0)  //lw gh w2t awl wa7ed
                {
                    if (arrival.Count() != 0)
                    {
                        temporary14 = new process();
                        temporary14.copy(arrival.Dequeue()); //5ragoh
                        temporary14.priority = temporary14.priority_input;
                        waiting.Enqueue(temporary14); //7otaha f elready

                    }
                if(arrival.Count()!=0)
                temporary8 = arrival.Peek().arrival_time;//hy7sbly awl wa7ed mstny bkam 

            }


            if (arrival.Count() != 0 && flag != 0)
                temporary6 = arrival.Peek().arrival_time;//hy7sbly awl wa7ed mstny bkam 


                while (count == temporary6 && flag != 0&& arrival.Count() != 0)  //lw gh w2t awl wa7ed
                {
                    if (arrival.Count() != 0)
                    {
                         smallest = new process();
                        smallest.copy(arrival.Dequeue()); //5ragoh
                        smallest.priority = smallest.priority_input;
                        waiting.Enqueue(smallest); //7otaha f elready
                        if (arrival.Count() == 0 && waiting.Count() == 1 && count > (exec.burst_time + exec.begin))  //3ashan a5er 2a7d bbtzn2
                        {
                            exec.copy(waiting.Dequeue());
                            exec.begin = count;
                            Console.WriteLine(exec.name + " started at " + count);
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
               
                else
                    {
                        break;
                    }
                if (arrival.Count() != 0)
                    temporary6 = arrival.Peek().arrival_time;
            }

           
            if (count == temporary7.arrival_time)
            {

                temporary2.copy(arrival.Dequeue());
                temporary10 = arrival.Peek().priority_input;
                temporary12 = arrival.Peek().arrival_time;
                if ((temporary10 < temporary2.priority_input) && temporary7.arrival_time == temporary12)
                {
                    temporary11.copy(arrival.Dequeue());
                    arrival.Enqueue(temporary2);
                    exec.copy(temporary11);
                    exec.priority = exec.priority_input;
                    temporary13.copy(temporary2);
                    temporary13.priority = temporary13.priority_input;
                    waiting.Enqueue(temporary13);
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
                    waiting.Dequeue();
                    flag = 1;
                }
                else
                {
                    exec.copy(temporary2);
                    exec.priority = exec.priority_input;
                    temporary2.priority = temporary2.priority_input;
                    waiting.Enqueue(temporary2);
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
                    waiting.Dequeue();
                    flag = 1;

                }

            }
            if (waiting.Count() != 0 && flag != 0)
                temporary4 = waiting.Peek().priority_input;
            if (waiting.Count() != 0 && flag != 0)
                temporary9 = waiting.Peek().arrival_time;

            if (exec.priority_input > temporary4 && exec.arrival_time != temporary9 && waiting.Count() != 0 && flag != 0 && exec.finished != true) //l2it wa7ed as3'rs
            {
                exec.end = count;
                Console.WriteLine(exec.name + " finished  at " + count);
                exec.finished = true;
                end = count;
                temporary.burst_time = exec.burst_time - (exec.end - exec.begin);
                temporary.name = exec.name;
                temporary.arrival_time = count;
                temporary.priority = exec.priority_input;
                temporary.finished = false;
                if ((exec.burst_time + exec.begin != count))
                {
                    temporary.priority = exec.priority_input;
                    waiting.Enqueue(temporary);  //7d5l elgdida f elready
                }
                if (waiting.Count() != 0)
                {
                    temporary3 = waiting.Dequeue();
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
            }

            else if (waiting.Count() != 0)
            {
                if (((exec.begin + exec.burst_time == count) || ((exec.begin + exec.burst_time < count) && (count == waiting.Peek().arrival_time))) && flag != 0)
                {
                    if (exec.finished != true)
                    {
                        exec.end = count;
                        Console.WriteLine(exec.name + " finished  at " + count);
                        end = count;
                        exec.finished = true;
                        if (waiting.Count() != 0)
                        {
                            temporary5 = waiting.Dequeue();
                            exec.copy(temporary5);
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
                            exec.begin = count;
                        }
                    }
                    else
                    {
                        if (waiting.Count() != 0)
                        {
                            temporary5 = waiting.Dequeue();
                            exec.copy(temporary5);
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
                            exec.begin = count;
                        }

                    }
                }
            }
            else if ((exec.begin + exec.burst_time == count) && flag != 0)
            {
                if (exec.finished != true)
                {
                    exec.end = count;
                    Console.WriteLine(exec.name + " finished  at " + count);
                    end = count;
                    exec.finished = true;
                    if (waiting.Count() != 0)
                    {
                        temporary5 = waiting.Dequeue();
                        exec.copy(temporary5);
                        Console.WriteLine(exec.name + " started  at " + count);
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
                        exec.begin = count;
                    }
                }
            }
            count++;

            

            if (arrival.Count() == 0 && waiting.Count() == 0 && flag != 0)
            {
                int finish = exec.begin + exec.burst_time;
                Console.WriteLine(exec.name + " finished at " + finish);
                exec.finished = true;
                end = finish;
                x.add_last_time(number_label, finish);

            }




        }
        average_waiting_time = average_waiting_time / n;
        Console.WriteLine("average_waiting_time is " + average_waiting_time);
        /*average_turnaaround_time = average_turnaaround_time / n;
        Console.WriteLine("average_turnaround_time is " + average_turnaaround_time);
        */
        return average_waiting_time;
    }




}

