using System;
using System.Threading;

class Program
{
    static public void thfun() {
        Thread thr = Thread.CurrentThread;
        for (int i = 0; i < 10; i++) {

                Console.WriteLine(thr.Name + "=" + i);
                Thread.Sleep(1);
        }
    }

    // Testing code.
    public static void Main1() {
        Console.WriteLine("Start of Main");

        Thread tid1 = new Thread(new ThreadStart(thfun) );
        Thread tid2 = new Thread(new ThreadStart(thfun) );

        tid1.Name = "Thread 1";
        tid2.Name = "Thread 2";

        try {
                tid1.Start();
                tid2.Start();
        }
        catch (ThreadStateException te) {
                Console.WriteLine(te.ToString() );
        }

        tid1.Join();
        tid2.Join();
        //tid2.Join(new TimeSpan(0, 0, 1) );

        Console.WriteLine("End of Main");
    }

    // Testing code.
    public static void Main2() {
        Console.WriteLine("Start of Main");
        ThreadStart ths = new ThreadStart(thfun);

        Thread tid1 = new Thread(ths);
        Thread tid2 = new Thread(ths);

        tid1.Name = "Thread 1";
        tid2.Name = "Thread 2";

        try {
                tid1.Start();
                tid2.Start();
        }
        catch (ThreadStateException te) {
                Console.WriteLine(te.ToString() );
        }

        tid1.Join();
        tid2.Join();
        //tid2.Join(new TimeSpan(0, 0, 1) );

        Console.WriteLine("End of Main");
    }

    // Testing code.
    public static void Main3() {
        Console.WriteLine("Start of Main");
        ThreadStart ths = new ThreadStart(thfun);
        
        Thread tid1 = new Thread(ths);
        Thread tid2 = new Thread(ths);

        tid1.Name = "Thread 1";
        tid2.Name = "Thread 2";

        tid1.IsBackground = true;
        tid2.IsBackground = true;

        try {
                tid1.Start();
                tid2.Start();
        }
        catch (ThreadStateException te) {
                Console.WriteLine(te.ToString() );
        }
        Console.WriteLine("End of Main");
    }

 
       

    // Testing code.
    public static void Main4() {
        Console.WriteLine("Start of Main");
        
        
        ThreadStart ths = new ThreadStart(lockFunc);
        for (int i = 0; i < 10; i++){
                new Thread(ths).Start();
                Console.WriteLine(i);

        }
        Thread.Sleep(100);
        Console.WriteLine(count);
        Console.WriteLine("End of Main");
    }
   
        static void monitorFunc() {
                Monitor.Enter(_object);              
                {   
                        for(int i = 0;i<100;i++)
                                count += 1;
                }   
                Monitor.Exit(_object);
            }   
       
    public static void Main5() {
        Console.WriteLine("Start of Main");
        
        
        ThreadStart ths = new ThreadStart(monitorFunc);
        for (int i = 0; i < 10; i++){
                new Thread(ths).Start();
                Console.WriteLine(i);

        }
        Thread.Sleep(100);
        Console.WriteLine(count);
        Console.WriteLine("End of Main");
    }
   

        public static void One()
        {
                lock (_object) 
                {
                        for (int i = 0; i < 5; i++) {

                                Console.Write("One  ");
                                Monitor.Pulse(_object);  //  let  Two()  run   
                                Monitor.Wait(_object);  //  wait  for  Two()  to  complete   
                        }
                        
                        Monitor.Pulse(_object);  //  let  Two()  run   
                }
                
        }
        public static void Two()
        {
                lock (_object)
                {
                        for (int i = 0; i < 5; i++) {
                        
                                Console.WriteLine("Two ");
                                Monitor.Pulse(_object);  //  let  One()  run   
                                Monitor.Wait(_object);  //  wait  for  One()  to  complete   
                        }
                        
                        Monitor.Pulse(_object);  //  let  One()  run   

                }

        }    

        public static void Main6()
        {
            
            Thread mt1 = new Thread(One);
            Thread mt2 = new Thread(Two);
                mt1.Start();
                mt2.Start();
            mt1.Join();
            mt2.Join();
            Console.WriteLine("Clock  Stopped");
            Console.Read();
        }

        static Semaphore _pool;
        public static void Main()
        {
        // Create a semaphore that can satisfy up to three
        // concurrent requests. Use an initial count of zero,
        // so that the entire semaphore count is initially
        // owned by the main program thread.
        //
        _pool = new Semaphore(3);

        // Create and start five numbered threads. 
        //
        for(int i = 1; i <= 5; i++)
        {
            Thread t = new Thread(new ParameterizedThreadStart(Worker));

            // Start the thread, passing the number.
            //
            t.Start(i);
        }

        // Wait for half a second, to allow all the
        // threads to start and to block on the semaphore.
        //
        Thread.Sleep(500);

        // The main thread starts out holding the entire
        // semaphore count. Calling Release(3) brings the 
        // semaphore count back to its maximum value, and
        // allows the waiting threads to enter the semaphore,
        // up to three at a time.
        //

        Console.WriteLine("Main thread exits.");
    }

    private static void Worker(object num)
    {
        // Each worker thread begins by requesting the
        // semaphore.
        Console.WriteLine("Thread {0} begins " +
            "and waits for the semaphore.", num);
        _pool.Wait();


        Console.WriteLine("Thread {0} enters the semaphore.", num);
        
        // The thread's "work" consists of sleeping for 
        // about a second. Each thread "works" a little 
        // longer, just to make the output more orderly.
        //
        Thread.Sleep(1000);

        Console.WriteLine("Thread {0} releases the semaphore.", num);
        _pool.Signal();
    }

}

public class Semaphore
{
        private object _mutex = new object();
        private int _currAvail;
        private int _maxCapacity;
        public Semaphore(int capacity)
        {
                _currAvail​ = capacity;
                _maxCapacity = capacity;
        }
        public void Wait()
        {
                lock(_mutex)
                {
                        if (_currAvail == 0) 
                                Monitor.Wait(_mutex);
                                
                        _currAvail​ --;
                }
        }
        public void Signal()
        {
                lock(_mutex)
                {
                        if (_currAvail == _maxCapacity) {
                                throw new System.Exception("SemaphoreFullException");
                        }

                        _currAvail​ ++;
                        Monitor.Pulse(_mutex);
                }
        }
}
