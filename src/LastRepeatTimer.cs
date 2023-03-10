using System;
using System.Diagnostics;

namespace RemapHotkeys
{

    /// <summary>
    /// Determines if an action has been repeated by comparing the last item to the current item.
    /// </summary>
    public class LastRepeatTimer<T>
    {
        protected T LastItem { get; set; }

        protected Stopwatch Timer { get; } = Stopwatch.StartNew();

        /// <summary>
        /// The number of milliseconds to elapse to allow a key to repeat
        /// </summary>
        public int RepeatMilliseconds { get; set; } = 500;


        public LastRepeatTimer()
        {
            
        }

        public LastRepeatTimer(int repeatMilliseconds)
        {
            RepeatMilliseconds = repeatMilliseconds;
        }



        /// <summary>
        /// The logic to compare the item to the last item checked.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual bool RepeatCheck(T item)
        {
            return Object.Equals(LastItem, item);
        }

        /// <summary>
        /// Resets the last invoke timer and sets the last item.
        /// </summary>
        /// <param name="item"></param>
        public void Reset(T item)
        {
            LastItem = item;
            Timer.Restart();
        }

        /// <summary>
        /// Returns true the item is the same as the previous item and invoked within the repeat timer.
        /// </summary>
        /// <param name="item"></param>
        public bool IsRepeat(T item)
        {
            if (RepeatCheck(item))
            {
                if (Timer.ElapsedMilliseconds < RepeatMilliseconds)
                {
                    return false;
                }
                else
                {
                    Timer.Restart();
                    return true;
                }
            }
            else
            {
                LastItem = item;
                Timer.Restart();
                return false;
            }
        }
    }
}