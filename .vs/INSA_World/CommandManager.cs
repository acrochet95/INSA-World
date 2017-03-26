using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INSA_World
{
    public class CommandManager
    {
        private static CommandManager INSTANCE;

        private CommandManager()
        {
            throw new System.NotImplementedException();
        }

        public List<ICommand> Commands
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public void replayAll()
        {
            throw new System.NotImplementedException();
        }

        public void save()
        {
            throw new System.NotImplementedException();
        }

        public void load()
        {
            throw new System.NotImplementedException();
        }

        public void storeAndExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}