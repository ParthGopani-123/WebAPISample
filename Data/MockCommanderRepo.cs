using System.Collections.Generic;
using WebAPISample.Models;

namespace WebAPISample.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeteleCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var Command = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an Egg", Line="Boil Water", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut bread", Line="Get a knife", Platform="knife & chopping board"},
                new Command{Id=2, HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"},

            };

            return Command;                        
        }

        public Command GetCommandByID(int id)
        {
            return new Command{Id=0, HowTo="Boil an Egg" , Line="Boil Water", Platform="Kettle & Pan"};
        }

        public bool SaveChages()
        {
            throw new System.NotImplementedException();
        }
    }
}