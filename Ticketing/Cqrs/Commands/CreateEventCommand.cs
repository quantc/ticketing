namespace Ticketing.CQRS.Commands
{
    public class CreateEventCommand : ICommand
    {
        public string Name { get; set; }
        public int SittingStage { get; set; }
        public int StandingStage { get; set; }
        public int StandingOpen { get; set; }

        public CreateEventCommand(string name, int sittingStage, int standingStage, int standingOpen)
        {
            Name = name;
            SittingStage = sittingStage;
            StandingStage = sittingStage;
            StandingOpen = standingOpen;
        }
    }
}
