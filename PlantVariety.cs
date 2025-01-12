using System.Text;

namespace PlantInventory
{
    public class PlantVariety
    {
        private String _genus;
        private String _species;
        private String _commonName;

        private ToxicStatus _toxicity;
        public enum ToxicStatus { UNKOWN_TOXICITY, KNOWN_TOXIC, NON_TOXIC }
        public PlantVariety(String commonName, String genus, String species)
        {
            _commonName = commonName;
            _genus = genus;
            _species = species;
        }
        public String Genus { get => _genus; set => _genus = value; }
        public String CommonName { get => _commonName; set => _commonName = value; }
        public String Species { get => _species; set => _species = value; }

        public ToxicStatus Toxicity { get => _toxicity; set => _toxicity = value; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Plant Variety || {CommonName} - {Genus} {Species} | Toxicity: ");

            switch (Toxicity)
            {
                case ToxicStatus.UNKOWN_TOXICITY:
                    {
                        builder.Append("Unknown");
                        break;
                    }
                case ToxicStatus.KNOWN_TOXIC:
                    {
                        builder.Append("Known Toxicity");
                        break;
                    }
                case ToxicStatus.NON_TOXIC:
                    {
                        builder.Append("Nontoxic");
                        break;
                    }
            }

            return builder.ToString();
        }
    }
}
