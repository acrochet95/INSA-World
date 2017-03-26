using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace INSA_World
{
    [Serializable]
    public class CommandManager
    {
        public List<ICommand> Commands { get; set; }
        private static CommandManager instance;

        private CommandManager()
        {
            this.Commands = new List<ICommand>();
        }

        public static CommandManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommandManager();

                return instance;
            }
        }

        public void ReplayAll()
        {
            // Replay all commands one by one
            foreach (ICommand command in Commands)
            {
                command.Replay();
            }
        }

        public Game Load(string fileName)
        {
            // Deserialize the game from the file fileName
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Game gameSaved = (Game)formatter.Deserialize(stream);
            stream.Close();

            // Deserialize the list of commands from the file commands.dat
            IFormatter formatter_cm = new BinaryFormatter();
            Stream stream_cm = new FileStream("commands.dat", FileMode.Open, FileAccess.Read, FileShare.Read);
            this.Commands = (List<ICommand>)formatter.Deserialize(stream_cm);
            stream_cm.Close();

            //return the game loaded
            return gameSaved;
        }

        public void Save(Game currentGame, string saveName = "defaultSave.dat")
        {
            // Seralize the current game and save it in the file fileName
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(saveName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, currentGame);
            stream.Close();

            // Seralize the list of commands and save it in the file commands.dat
            IFormatter formatter_cm = new BinaryFormatter();
            Stream stream_cm = new FileStream("commands.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter_cm.Serialize(stream_cm, Commands);
            stream_cm.Close();
        }

        public void StoreAndExecute(ICommand command)
        {
            // Store the command in the list
            this.Commands.Add(command);
            // Execute the command
            command.Execute();
        }
    }
}