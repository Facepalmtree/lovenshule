using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;


namespace Model
{
    public class Hole
    {
        Unit currentUnit;
        DateTime timestamp;
        int spawnTime = 0;
        bool clicked = false;

        //Constructor
        public Hole()
        {
            this.currentUnit = null;
        }


        #region timer 1
        //Get these values however you like.
        static DateTime timeEnd = DateTime.Parse("20/5/2012 12:00:01 AM");
        static DateTime timeStart = DateTime.Now;

        //Calculate countdown timer.
        static TimeSpan t = timeEnd - timeStart;
        string countDown = string.Format("{0} Days, {1} Hours, {2} Minutes, {3} Seconds til launch.", t.Days, t.Hours, t.Minutes, t.Seconds);
        #endregion
        #region timer 2

        //public void StartTimer()
        //{
        //    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        //    timer.Tick += OnTimerTick();
        //    timer.Interval = 10000;
        //    timer.Start();
        //}
        //private void OnTimerTick(object sender, EventArgs e)
        //{
        //    // Modify GUI here.
        //}
        //private void OnTimerTick()
        //{
        //    // Modify GUI here.
        //}

        #endregion
        #region timer 3

        ////Console.WriteLine("Main thread: starting a timer"); 
        //Timer t = new Timer(ComputeBoundOp, 5, 0, 2000); 
        ////Console.WriteLine("Main thread: Doing other work here...");
        //Thread.Sleep(10000); // Simulating other work (10 seconds)
        //t.Dispose(); // Cancel the timer now

        //// This method's signature must match the TimerCallback delega
        //private static void ComputeBoundOp(Object state)
        //{
        //    // This method is executed by a thread pool thread 
        //    Console.WriteLine("In ComputeBoundOp: state={0}", state);
        //    Thread.Sleep(1000); // Simulates other work (1 second)
        //    // When this method returns, the thread goes back 
        //    // to the pool and waits for another task 
        //}

        #endregion
        #region timer 4
        
        //static public void Tick(Object stateInfo)
        //{
        //    //Console.WriteLine("Tick: {0}", DateTime.Now.ToString("h:mm:ss"));                                         
        //}

        //static void Spawn(int spawnTime)
        //{                                    
        //    TimerCallback callback = new TimerCallback(Tick);

        //    Console.WriteLine("Creating timer: {0}\n", 
        //                        DateTime.Now.ToString("h:mm:ss"));

        //    // create a one second timer tick
        //    Timer stateTimer = new Timer(callback, null, 0, 1000);

        //    // loop here forever
        //    for (int countdown = spawnTime ;countdown>0 ;countdown--)
        //    { 
        //    }
        //}


        #endregion





        public void SpawnUnit(int type)
        {
            switch (type)
            {
                //NORMAL
                case 1:
                    currentUnit = new UnitNormal(this);                    
                    break;
                //AVOID
                case 2:
                    currentUnit = new UnitAvoid(this);
                    break;
                //STRONG
                case 3:
                    currentUnit = new UnitStrong(this);
                    break;
                //FAT
                case 4:
                    currentUnit = new UnitFat(this);
                    break;
                //STAR
                case 5:
                    currentUnit = new UnitStar(this);
                    break;
                //RED
                case 6:
                    currentUnit = new UnitRed(this);
                    break;
                //GREEN
                case 7:
                    currentUnit = new UnitGreen(this);
                    break;
                //BLUE
                case 8:
                    currentUnit = new UnitBlue(this);
                    break;
                //YELLOW
                case 9:
                    currentUnit = new UnitYellow(this);
                    break;
                default:
                    currentUnit = new UnitNormal(this);
                    break;
            }
            if(currentUnit != null)
            {
                clicked = false;
                Timer timer1 = new Timer(TimerCallback, null, 0, 100);
                spawnTime = currentUnit.SpawnTime;
                Thread.Sleep(spawnTime*1000);
            }
        }

        //Check if the moles timer has run out or if it has been clicked
        public void TimerCallback(Object o)
        {
            TimeSpan span = DateTime.Now.Subtract(timestamp);
            if (span.Seconds >= spawnTime || clicked == true)
            {
                Attack();
                currentUnit = null;
            }
        }

        public void Attack()
        {

        }
    }
}
