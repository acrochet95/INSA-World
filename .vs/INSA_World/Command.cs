using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public abstract class Command
    {

        public void execute()
        {
            action();
        }

        public void replay()
        {
            action();
        }

        protected abstract void action();
    }
}