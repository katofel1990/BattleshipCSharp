namespace Battleship
{
    public class ComputerPlayer : Player
    {
        public override bool IsRandomPlacing => true;

        public ComputerPlayer(string name) : base (name)
        {
        }

    }
}