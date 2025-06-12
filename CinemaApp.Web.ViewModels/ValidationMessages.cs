using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.Web.ViewModels
{
    public static class ValidationMessages
    {
        public static class Movie
        {
            public const string TitleRequiredMessage = "The title is required.";
            public const string TitleMinLengthMessage = $"The title must be at least 1 character long.";
            public const string TitleMaxLengthMessage = $"The title must not exceed ... characters.";

            public const string GenreRequiredMessage = "The genre is required.";
            public const string GenreMinLengthMessage = $"The genre must be at least 1 character long.";
            public const string GenreMaxLengthMessage = $"The genre must not exceed ... characters.";

            public const string DirectorRequiredMessage = "The director is required.";
            public const string DirectorMinLengthMessage = $"The director's name must be at least 1 character long.";
            public const string DirectorMaxLengthMessage = $"The director's name must not exceed ... characters.";

            public const string DescriptionRequiredMessage = "The description is required.";
            public const string DescriptionMinLengthMessage = $"The description must be at least 10 character long.";
            public const string DescriptionMaxLengthMessage = $"The description must not exceed ... characters.";

            public const string DurationDateRequiredMessage = "The duration is required.";
            public const string DurationRangeMessage = $"The duration must be between ... and ... minutes.";

            public const string ReleaseDateRequiredMessage = "The release date is required.";

            public const string ImageUrlMaxLengthMessage = $"The image URL must not exceed ... characters.";

            public const string ServiceCreateError = "Fatal error occurred while adding your movie! Please try again later!";
        }
    }
}
