using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    [Serializable]
    public class Attack : ICommand
    {
        public Battle Battle { get; set; }

        public Attack(Battle battle)
        {
            this.Battle = battle;
        }

        public void Execute()
        {
            Battle.Compute();
        }

        public void Replay()
        {
            this.Execute();
        }
    }
}