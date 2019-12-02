using Dm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YinYangShiGua2.core
{
    class Gua
    {
        public enum GuaJiType
        {
            JUE_XING,
            YU_HUN,
            PU_TONG_FU_BEN,
            ZHONG_HE
        }


        public static String imgPath = @"F:\阴阳师挂2_图";
        //图片相似度
        public const double SIMILARITY = 0.7;

        private dmsoft dm;

        private Thread looper;

        private Boolean isLive;

        //循环间隔
        public const int DEFAULT_LOOP_INTERVAL = 1000;

        //当前执行动作
        private GuaAction curAction;

        public Gua()
        {}

        private void checkNeedInit()
        {
            if (dm != null)
            {
                return;
            }

            log("开始进行初始化");
            dm = new dmsoft();
            dm.SetPath(imgPath);
            dm.BindWindow(dm.FindWindow("", "阴阳师-网易游戏"),
              "normal",
              "dx",
              "dx",
              0);

            isLive = true;
            looper = new Thread(new ThreadStart(loop));
            looper.Start();
        }

        private void loop()
        {
            while (isLive)
            {
                if (null != curAction)
                {
                    curAction.loop();
                }

                Thread.Sleep(DEFAULT_LOOP_INTERVAL);
            }
        }


        internal void test()
        {
            if (findPic("test.bmp", 0, 0, 1000, 600))
            {
                GlobalStatus.setDeBugMsg("找到");
            }
            else
            {
                GlobalStatus.setDeBugMsg("找不到");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="picturePath"></param>
        /// <param name="x1">区域的左上X坐标</param>
        /// <param name="y1">区域的左上Y坐标</param>
        /// <param name="x2">区域的右下X坐标</param>
        /// <param name="y2">区域的右下Y坐标</param>
        /// <returns></returns>
        public bool findPic(String picturePath, int x1, int y1, int x2, int y2)
        {
            Object x;
            Object y;
            return dm.FindPic(x1, y1, x2, y2, picturePath, "000000", SIMILARITY, 0, out x, out y) >= 0;
        }

        /// <summary>
        /// 找到图片并点击
        /// </summary>
        /// <param name="picturePath"></param>
        /// <param name="x1">区域的左上X坐标</param>
        /// <param name="y1">区域的左上Y坐标</param>
        /// <param name="x2">区域的右下X坐标</param>
        /// <param name="y2">区域的右下Y坐标</param>
        /// <param name="relateX">点击时增加偏移x</param>
        /// <param name="relateY">点击时增加偏移y</param>
        /// <returns></returns>
        public bool findMoveAndClick(String picturePath, int x1, int y1, int x2, int y2, int relateX, int relateY)
        {
            Object x;
            Object y;
            if (dm.FindPic(x1, y1, x2, y2, picturePath, "000000", SIMILARITY, 0, out x, out y) < 0)
            {
                return false;
            }

            int t_x = (int)x + relateX;
            int t_y = (int)y + relateY;
            moveAndClick(t_x, t_y);
            return true;
        }

        public void moveAndClick(int x, int y)
        {
            dm.MoveTo(x, y);
            dm.LeftClick();
        }

        public void stop()
        {
            curAction = null;
            isLive = false;

            if (looper != null)
            {
                looper.Abort();
                looper = null;
            }

            if (dm != null)
            {
                dm.UnBindWindow();
                dm = null;
            }

            log("挂机停止");
        }


        private void doJueXingFuBen()
        {
            curAction = new JueXingFuBenAction(this);
        }

        public void startGuaJi(GuaJiType type)
        {
            checkNeedInit();
            switch (type)
            {
                case GuaJiType.JUE_XING:
                    doJueXingFuBen();
                    break;
                case GuaJiType.YU_HUN:
                    break;
                case GuaJiType.PU_TONG_FU_BEN:
                    break;
                case GuaJiType.ZHONG_HE:
                    break;
            }
        }

        private void log(String msg)
        {
            GlobalStatus.setDeBugMsg(msg);
        }

    }
}
