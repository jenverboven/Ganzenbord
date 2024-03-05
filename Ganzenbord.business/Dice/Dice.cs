namespace Ganzenbord.Business.Dice
{
    public class Dice : IDice
    {
        private int AmountDice = 2;
        private static Random random = new Random();

        public Dice()
        { }

        public Dice(int amountDice = 2)
        {
            AmountDice = amountDice;
        }

        public virtual int[] RollDice()
        {
            int[] diceRolls = new int[AmountDice];

            for (int i = 0; i < AmountDice; i++)
            {
                diceRolls[i] = random.Next(1, 7);
            }

            return diceRolls;
        }
    }
}