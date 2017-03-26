using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class Attack : ICommand
    {
        public Attack(Battle battle)
        {
            throw new System.NotImplementedException();
        }
    
        public Battle Battle
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        protected override void execute()
        {
            throw new NotImplementedException();
        }

        public void replay()
        {
            throw new System.NotImplementedException();
        }
    }
}