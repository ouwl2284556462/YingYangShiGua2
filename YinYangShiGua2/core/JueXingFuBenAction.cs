﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YinYangShiGua2.core
{
    /// <summary>
    /// 觉醒副本
    /// </summary>
    class JueXingFuBenAction : GuaAction
    {
        //点击副本入口图标步骤
        private const int STATUS_ENTER_ICON = 1;
        //选择觉醒之塔步骤
        private const int STATUS_SELECT_TOWER = 2;
        //选择关卡等级
        private const int STATUS_SELECT_LV = 3;
        //点击准备步骤
        private const int STATUS_READY = 4;
        //等待战斗完成步骤
        private const int STATUS_WAIT_FINISH = 5;

        private const String IMG_ENTRY_ICON = "jx_entry_icon.bmp";

        private const String IMG_TOWER_UI = "jx_tower_ui.bmp";

        private const String IMG_START = "jx_start.bmp";

        private const String IMG_READY = "jx_ready_btn.bmp";


        private int[,] towerPos = { { 189, 431 }, { 400, 479 }, { 620, 485 }, { 867, 486 } };

        private Random ran;

        private int count;

        private int? doCount;

        public JueXingFuBenAction(Gua gua, int? jueXingDoCount) : base(gua) {
            ran = new Random();
            count = 0;
            this.doCount = jueXingDoCount;
            log("开始觉醒副本");
        }

        /// <summary>
        /// 检查是否完成了指定次数
        /// </summary>
        /// <returns></returns>
        private bool checkFinishLimitCount()
        {
            if (doCount == null || doCount < 1)
            {
                return false;
            }

            return count >= doCount;
        }

        protected override bool update()
        {
            if (checkFinishLimitCount())
            {
                log("已完成指定次数");
                GlobalStatus.notifyStop();
                return false;
            }


            if (doClickEnterIcon() || doSelectTower() 
                                   || doLevelStart() 
                                   || doReady() 
                                   || doWaitFinish())
            {
                return true;
            }

            return false;
        }

        private bool doWaitFinish()
        {
            if (status != STATUS_WAIT_FINISH)
            {
                return false;
            }

            //点击屏幕中间
            gua.moveAndClick(579, 299);
            if (gua.findPic(IMG_START, 777, 414, 916, 470))
            {
                ++count;
                log("战斗完成,次数:" + count);
                //回到选择关卡步骤
                status = STATUS_SELECT_LV;
                return false;
            }

            return true;
        }

        private bool doReady()
        {
            if (status != STATUS_READY)
            {
                return false;
            }

            if (gua.findMoveAndClick(IMG_READY, 824, 423, 1134, 634, 0, -10))
            {
                log("doReady:已点击");
                status = STATUS_WAIT_FINISH;
                return true;
            }

            log("doReady:没找到图片");
            return false;
        }

        private bool doLevelStart()
        {
            if (status != STATUS_SELECT_LV)
            {
                return false;
            }

            if (gua.findMoveAndClick(IMG_START, 777, 414, 916, 470, 0, 0))
            {
                log("doLevelStart:已点击");
                status = STATUS_READY;
                return true;
            }

            log("doLevelStart:没找到图片");
            return false;
        }


        private bool doSelectTower()
        {
            if (status != STATUS_SELECT_TOWER)
            {
                return false;
            }

            if (!gua.findPic(IMG_TOWER_UI, 321, 495, 524, 568))
            {
                log("doSelectTower:没找到图片");
                return false;
            }

            int towerIndex = ran.Next(0, towerPos.GetLength(0));
            gua.moveAndClick(towerPos[towerIndex, 0], towerPos[towerIndex, 1]);
            status = STATUS_SELECT_LV;
            log("doSelectTower:已点击");
            return true;
        }

        private bool doClickEnterIcon()
        {
            if(status > 0){
                return false;
            }

            if (gua.findMoveAndClick(IMG_ENTRY_ICON, 33, 539, 139, 636, 0, 0))
            {
                log("doClickEnterIcon:已点击");
                status = STATUS_SELECT_TOWER;
                return true;
            }

            log("doClickEnterIcon:没找到图片");
            return false;
        }
    }
}
