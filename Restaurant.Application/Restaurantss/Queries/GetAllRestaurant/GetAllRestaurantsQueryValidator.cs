using FluentValidation;
using Restaurant.Application.Restaurantss.Dtos;

namespace Restaurant.Application.Restaurantss.Queries.GetAllRestaurant
{
    public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllRestaurantQuery>
    {
        //paginated validation
        private int[] allowPageSizes = [5, 10, 15, 30];

        //sorting validation
        private string[] allowedSortByColumnNames = [nameof(RestaurantDto.Name),
        nameof(RestaurantDto.Category),
        nameof(RestaurantDto.Description)];

        public GetAllRestaurantsQueryValidator()
        {
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize)
                .Must(value => allowPageSizes.Contains(value))
                .WithMessage($"Page size must be in [{string.Join(",", allowPageSizes)}]");

            RuleFor(r => r.SortBy)
           .Must(value => allowedSortByColumnNames.Contains(value))
           .When(q => q.SortBy != null)
           .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
