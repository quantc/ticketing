namespace Ticketing.CQRS.Commands
{
    public class CreateEventCommand : ICommand
    {
        public string Name { get; }
        public int SittingStage { get; }
        public int StandingStage { get; }
        public int StandingOpen { get; }

        public CreateEventCommand(string name, int sittingStage, int standingStage, int standingOpen)
        {
            Name = name;
            SittingStage = sittingStage;
            StandingStage = standingStage;
            StandingOpen = standingOpen;
        }
    }
}