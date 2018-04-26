using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class process : IComparable<process>
{   //data
    public string name;
    public int arrival_time;
    public int burst_time;
    public int priority;
    public int priority_input;
    public int slice;
    public int begin;
    public int end;
    public int temporary;
    public bool finished;

    public process(int n)
    {
        name = "p" + (++n);
        begin = 0;
        end = 0;
        arrival_time = 0;
        burst_time = 0;
        priority = 0;
        slice = 0;
        finished = false;
    }

    public process()
    {
        name = " ";
        begin = 0;
        end = 0;
        arrival_time = 0;
        burst_time = 0;
        priority = 0;
        slice = 0;
        finished = false;
    }

    public int CompareTo(process other)
    {
        if (this.priority < other.priority) return -1;
        else if (this.priority > other.priority) return 1;
        else return 0;
    }

    public override string ToString()
    {
        return "(" + name + ", " + priority.ToString() + ")";
    }
    public static process smallest(process[] p2, int index, int type, int n, int count)
    {   process smallest = new process();
        process temporary = new process();
        int flag_i = index;
         if (index != n)
                smallest = p2[index];
            else
                return null;


        if (type == 1)
        {
            for (int i = index + 1; i < n; i++)
                if ((smallest.burst_time > p2[i].burst_time) && (p2[i].arrival_time <= count))
                {
                    smallest = p2[i];
                    flag_i = i;
                }

        }
        else
        {

            for (int i = index + 1; i < n; i++)
                if ((smallest.priority_input > p2[i].priority_input) && (p2[i].arrival_time <= count))
                {
                    smallest = p2[i];
                    flag_i = i;
                }

        }
            //3lshan at5ls mn alas3'r wm3dish 3liha tany
        
            temporary = p2[index];
            p2[index] = p2[flag_i];
            p2[flag_i] = temporary;
        
     
        return smallest;
    }

    public void copy (process other)
    {
        this.name = other.name;
        this.priority = other.priority;
        this.slice = other.slice;
        this.begin = other.begin;
        this.end = other.end;
        this.burst_time = other.burst_time;
        this.arrival_time = other.arrival_time;
        this.priority_input = other.priority_input;
        this.finished = other.finished;
    } 
    public static void arr_by_burst(process[]p,int n,int index)
    {
        PriorityQueue<process> q = new PriorityQueue<process>();
        for (int i = index; i < n; i++)
        {
            p[i].priority = p[i].burst_time;
            q.Enqueue(p[i]);
        }
        for (int i = index; i < n; i++)
        {
            p[i] = q.Dequeue();

        }
    }
    public static void arr_by_arrival(process[] p, int n,int index)
    {
        PriorityQueue<process> q = new PriorityQueue<process>();
        for (int i = index; i < n; i++)
        {
            p[i].priority = p[i].arrival_time;
            q.Enqueue(p[i]);
        }
        for (int i = index; i < n; i++)
        {
            p[i] = q.Dequeue();
        }
    }

    
}

