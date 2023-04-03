namespace InnoGotchi.Core.Entities.RequestFeatures
{
    public class PetParameters : RequestParameters
    {
        public uint MinAge { get; set; }

        public DateTime MinDateOfBirth
        {
            get
            {
                if (MinAge == 0)
                    return DateTime.Now;
                return DateTime.Now.AddDays(-((MinAge * 7)));
            }
        }

        public uint MaxAge { get; set; } = int.MaxValue;

        public DateTime MaxDateOfBirth
        {
            get
            {
                if (MaxAge == int.MaxValue)
                    return DateTime.MinValue;
                return DateTime.Now.AddDays(-((MaxAge * 7)+6));
            }
        }

        public bool ValidAgeRange => MaxAge >= MinAge;

        public PetParameters() => OrderBy = "daysOfHappiness";
    }
}
