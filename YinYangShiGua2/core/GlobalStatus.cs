using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YinYangShiGua2.core
{
    static class  GlobalStatus
    {
        //监听调试信息的Listener
        private static List<Action<String>> debugMsgChgListenerList = new List<Action<string>>();

        //监听停止信息
        private static List<Action> stopEvenListenerList = new List<Action>();

        //调试信息
        private static String debugMsg;

        //锁对象只用一个暂时没问题
        private static Object locker = new Object();


        public static void setDeBugMsg(String msg)
        {
            lock (locker)
            {
                debugMsg = msg;
            }

            onDebugMsgChg();
        }

        public static void setDeBugMsg(int p)
        {
            setDeBugMsg(Convert.ToString(p));
        }

        public static String getDeBugMsg()
        {
            return debugMsg;
        }

        public static void addMsgChgListener(Action<String> callback){
            lock (locker)
            {
                debugMsgChgListenerList.Add(callback);
            }
        }

        private static void onDebugMsgChg()
        {
            debugMsgChgListenerList.ForEach(cb =>{
                cb.Invoke(debugMsg);
            });
        }

        public static void addStopEvenListener(Action callback)
        {
            lock (locker)
            {
                stopEvenListenerList.Add(callback);
            }
        }

        public static void notifyStop()
        {
            stopEvenListenerList.ForEach(cb =>
            {
                cb.Invoke();
            });
        }



    }
}
