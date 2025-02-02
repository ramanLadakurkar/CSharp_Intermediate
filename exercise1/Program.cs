﻿/*Design a class called Stopwatch.The job of this class is to simulate a stopwatch.It should
provide two methods: Start and Stop.We call the start method first, and the stop method next.
Then we ask the stopwatch about the duration between start and stop. Duration should be a
value in TimeSpan.Display the duration on the console.
We should also be able to use a stopwatch multiple times.So we may start and stop it and then
start and stop it again. Make sure the duration value each time is calculated properly.
We should not be able to start a stopwatch twice in a row (because that may overwrite the initial
start time). So the class should throw an InvalidOperationException if its started twice. */


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace exercise1
{
    public class StopWatch
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _running;

        public void Start()
        {
            if(_running)
                throw new InvalidOperationException("Stopwatch is already running");

            _startTime = DateTime.Now;
            _running = true;
        }

        public void Stop()
        {
            if (!_running)
                throw new InvalidOperationException("Stopwatch is not running");


            _endTime = DateTime.Now;
            _running = false;
        }

        public TimeSpan GetInterval()
        {
            return _endTime - _startTime;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = new StopWatch();

            while(true)
            {
                stopWatch.Start();
                Thread.Sleep(1000);
                stopWatch.Stop();

                Console.WriteLine("Duration : " + stopWatch.GetInterval());

                Console.WriteLine("Press Enter to run the stopwatch one more time");
                Console.ReadLine();
            }
        }
    }
}
