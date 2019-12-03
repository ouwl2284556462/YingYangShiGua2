using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YinYangShiGua2.core
{
    class YuHunFuBenAction : GuaAction
    {
        //点击副本入口图标步骤
        private const int STATUS_ENTER_ICON = 1;
        //选择御魂类型步骤
        private const int STATUS_SELECT_TYPE = 2;
        //选择关卡等级
        private const int STATUS_SELECT_LV = 3;
        //点击准备步骤
        private const int STATUS_READY = 4;
        //等待战斗完成步骤
        private const int STATUS_WAIT_FINISH = 5;

        private const String IMG_ENTRY_ICON = "yh_entry_icon.bmp";

        private const String IMG_TYPE_UI = "yh_type_ui.bmp";

        private const String IMG_START = "yh_start.bmp";

        private const String IMG_READY = "yh_ready_btn.bmp";


        private int count;
        //进行多少次
        private int? doCount;

        public YuHunFuBenAction(Gua gua, int? doCount)
            : base(gua)
        {
            this.doCount = doCount;
            count = 0;
            log("开始御魂副本");
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

            if (doClickEnterIcon() || doSelectType()
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
            if (gua.findPic(IMG_START, 784, 416, 916, 470))
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

            if (gua.findMoveAndClick(IMG_READY, 964, 425, 1120, 610, 0, -10))
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

            if (gua.findMoveAndClick(IMG_START, 784, 416, 916, 470, 0, 0))
            {
                log("doLevelStart:已点击");
                status = STATUS_READY;
                return true;
            }

            log("doLevelStart:没找到图片");
            return false;
        }


        private bool doSelectType()
        {
            if (status != STATUS_SELECT_TYPE)
            {
                return false;
            }

            if (!gua.findPic(IMG_TYPE_UI, 100, 422, 300, 481))
            {
                log("doSelectType:没找到图片");
                return false;
            }

            gua.moveAndClick(100, 422);
            status = STATUS_SELECT_LV;
            log("doSelectType:已点击");
            return true;
        }

        private bool doClickEnterIcon()
        {
            if (status > 0)
            {
                return false;
            }

            if (gua.findMoveAndClick(IMG_ENTRY_ICON, 134, 585, 224, 637, 0, 0))
            {
                log("doClickEnterIcon:已点击");
                status = STATUS_SELECT_TYPE;
                return true;
            }

            log("doClickEnterIcon:没找到图片");
            return false;
        }

    }
}
