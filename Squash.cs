using System.Text;

namespace PlantInventory
{
    public class Squash : Vegetable
    {
        public enum BushHabitOptions { UNKNOWN, VINE_HABIT, BUSH_HABIT }
        private BushHabitOptions _bushHabit;

        public Squash(String commonName, String genus, String species) : base(commonName, genus, species)
        {
            _bushHabit = BushHabitOptions.UNKNOWN;
        }

        public BushHabitOptions BushHabit { get => _bushHabit; set => _bushHabit = value; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(base.ToString());

            builder.Append("\n                 Bush habit: ");
            switch (_bushHabit)
            {
                case BushHabitOptions.UNKNOWN:
                    {
                        builder.Append("Unknown");
                        break;
                    }
                case BushHabitOptions.BUSH_HABIT:
                    {
                        builder.Append("Bush");
                        break;
                    }
                case BushHabitOptions.VINE_HABIT:
                    {
                        builder.Append("Vine");
                        break;
                    }
            }

            return builder.ToString();
        }
    }
}
