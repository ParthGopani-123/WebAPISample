using System.Collections.Generic;
using WebAPISample.Models;


namespace WebAPISample.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandByID(int id);

        bool SaveChages();
        void CreateCommand(Command cmd);
        void DeteleCommand(Command cmd);
    }
}