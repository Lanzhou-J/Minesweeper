namespace Minesweeper
{
    public class Player
    {
        public Player()
        {
            State = PlayerState.Unknown;
        }

        public PlayerState State { get; set; }

        public override string ToString()
        {
            return $"{State}";
        }
    }
}