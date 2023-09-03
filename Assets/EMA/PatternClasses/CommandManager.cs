using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EMA.PatternClasses
{
    public class CommandManager 
    {
        private int commandsCapacity;
        private Stack<PatternClasses.Command> undoCommands;

        private bool routine = false;
        public CommandManager(int commandsCapacity)
        {
            this.commandsCapacity = commandsCapacity;
            
            undoCommands = new Stack<PatternClasses.Command>(commandsCapacity);
        }


        public void AddCommands(PatternClasses.Command command)
        {
            undoCommands.Push(command);
            command.Execute();
        }
        
        public IEnumerator UndoCommands(int hmCommand)
        {
            if(routine)
                yield break;
            
            routine = true;
            
            for (int i = 0; i < hmCommand; i++)
            {
                if (undoCommands.Count <= 0)
                {
                    Debug.LogError("There is no any before command");
                    routine = false;
                    yield break;
                }
                
                var _command = undoCommands.Pop();
                _command.Undo();

                yield return null;
            }

            routine = false;
        }
    }
}
