using System.Linq;
using FluentValidation;

namespace ISIS.Schedule
{
    public static class RuleClassExtensions
    {

        public static IRuleBuilderOptions<T, string>
            EquipmentName<T>(this IRuleBuilderInitial<T, string> rule)
        {
            return rule.ShortString(
                "Please provide an equipment name.",
                "Equipment name can't be longer than 255 characters");
        }

        public static IRuleBuilderOptions<T, string>
            ShortString<T>(this IRuleBuilderInitial<T, string> rule,
            string emptyNullOrWhitespaceMessage,
            string lengthMessage)
        {
            return rule
                .NotEmpty()
                .WithMessage(emptyNullOrWhitespaceMessage)
                .Length(0, 255)
                .WithMessage(lengthMessage)
                .Must(s => s != null && !s.Any(c => char.IsControl(c)))
                .WithMessage("Illegal control characters.");
        }

        public static IRuleBuilderOptions<T, string>
            Abbreviation<T>(this IRuleBuilderInitial<T, string> rule,
            string emptyNullOrWhitespaceMessage,
            string lengthMessage,
            string noWhitespaceMessage,
            string numbersAndUppercaseOnlyMessage)
        {
            return rule
                .NotEmpty()
                .WithMessage(emptyNullOrWhitespaceMessage)
                .Length(0, 15)
                .WithMessage(lengthMessage)
                .Matches(@"^\S+$")
                .WithMessage(noWhitespaceMessage)
                .Matches(@"^[A-Z0-9]+$")
                .WithMessage(numbersAndUppercaseOnlyMessage);
        }

    }
}
