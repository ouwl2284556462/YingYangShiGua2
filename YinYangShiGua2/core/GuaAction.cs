using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YinYangShiGua2.core
{
    abstract class GuaAction
    {
        protected int status;

        protected Gua gua;

        public GuaAction(Gua gua)
        {
            this.gua = gua;
            status = -1;
        }

        public void loop()
        {
            if (checkNoTiLi() || update())
            {}
        }

        private bool checkNoTiLi()
        {
            if (gua.findPic("common_buy_ti_li.bmp", 503, 172, 636, 220))
            {
                //通知停止
                GlobalStatus.notifyStop();
                return true;
            }
            return false;
        }

        protected abstract bool update();

        protected void log(String msg)
        {
            GlobalStatus.setDeBugMsg(msg);
        }
    }
}
