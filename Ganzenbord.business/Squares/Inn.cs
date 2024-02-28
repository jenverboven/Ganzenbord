namespace Ganzenbord.Business.Squares
{
    internal class Inn : ISquare
    {
        public int Position { get; set; }
        //private int TurnEntered;

        public void PlayerEntersSquare(Player player)
        {
            //TurnEntered = Game.Instance.Turn;
            player.SetCanMove(false);
            player.SetTurnsToSkip(1);
        }
    }
}