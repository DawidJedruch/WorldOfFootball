using FluentValidation;

namespace WorldOfFootball.Models.Validators
{
    public class FootballClubQueryValidator : AbstractValidator<FootballClubQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };
        public FootballClubQueryValidator()
        {
            RuleFor(f => f.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(f => f.PageSize).Custom((value, context) =>
            {
            if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("Pagesize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                }
            });
        }
    }
}
