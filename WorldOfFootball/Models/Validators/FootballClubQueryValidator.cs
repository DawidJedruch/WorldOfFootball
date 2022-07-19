using FluentValidation;
using WorldOfFootball.Entities;

namespace WorldOfFootball.Models.Validators
{
    public class FootballClubQueryValidator : AbstractValidator<FootballClubQuery>
    {
        private int[] allowedPageSizes = new[] { 5, 10, 15 };

        private string[] allowedSortByColumnNames = 
            { nameof(FootballClub.Name), nameof(FootballClub.Nationality), nameof(FootballClub.Description),};
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

            RuleFor(f => f.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
