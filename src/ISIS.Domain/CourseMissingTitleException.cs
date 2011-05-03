namespace ISIS.Domain
{
    public class CourseMissingTitleException : InvalidAggregateStateException
    {

        public CourseMissingTitleException()
            : base("Your attempt to create a template failed because the course is missing a title.")
        {
        }

    }
}