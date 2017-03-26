using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public interface ICommand
    {
        // Execute the command
        void Execute();

        // Replay the command
        void Replay();
    }
}
