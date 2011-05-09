using System;
using ISIS.Scheduling;
using Ncqrs.Spec;

namespace ISIS.Schedule
{
    public class ChangeInstructorNameValidatorFixture
        : ConventionValidationFixture<ChangeInstructorName>
    {
        protected override ChangeInstructorName GetValidInstance()
        {
            return new ChangeInstructorName(
                Guid.NewGuid(),
                "FirstName",
                "LastName");
        }

        [Then]
        public void InstructurIdFollowsRules()
        {
            FollowsEventSourceIdRules(
                id => new ChangeInstructorName(id, "FirstName", "LastName"),
                cmd => cmd.InstructorId);
        }

        [Then]
        public void FirstNameFollowsStringRules()
        {
            FollowsShortStringRules(
                firstName => new ChangeInstructorName(Guid.NewGuid(), firstName, "LastName"),
                cmd => cmd.NewFirstName);
        }

        [Then]
        public void LastNameFollowsStringRules()
        {
            FollowsShortStringRules(
                lastName => new ChangeInstructorName(Guid.NewGuid(), "FirstName", lastName),
                cmd => cmd.NewLastName);
        }


    }
}
