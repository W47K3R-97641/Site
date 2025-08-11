namespace Site.CustomExceptions
{
    public class SkillNotFoundException : Exception
    {
        public IEnumerable<int> MissingSkillIds { get; }

        public SkillNotFoundException(IEnumerable<int> missingSkillIds)
            : base($"Skills not found: {string.Join(", ", missingSkillIds)}")
        {
            MissingSkillIds = missingSkillIds;
        }
    }

}
