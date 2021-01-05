namespace Minesweeper
{
    public class Player
    {
        public Player()
        {
            State = PlayerState.Unknown;
        }

        public PlayerState State { get; private set; }

        public void SetStateToWin()
        {
            State = PlayerState.Win;
        }
        
        public void SetStateToLose()
        {
            State = PlayerState.Lose;
        }

        public override string ToString()
        {
            return $"{State}";
        }
    }
}