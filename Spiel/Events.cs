using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Spiel.EventPool;

namespace Spiel
{
    internal class Events
    {
        public event Buttonpresshandler Buttonpress;

        public void OnButtonpress(object sender, EventArgs e)
        {
            Buttonpress?.Invoke(sender, e);
        }
    }
}
