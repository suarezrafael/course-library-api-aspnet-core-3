using CourseLibrary.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseLibrary.API.ValidationAttributes
{
    public class CourseTitleMustBeDifferentFromDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, 
            ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is ICollection<CourseForCreationDto>)
            {
                foreach (var courseCreation in (validationContext.ObjectInstance as ICollection<CourseForCreationDto>))
                {
                    var course = (CourseForManipulationDto)courseCreation;

                    if (course.Title == course.Description)
                    {
                        return new ValidationResult(ErrorMessage,
                            new[] { nameof(CourseForManipulationDto) });
                    }
                }
            }
            else
            {
                var course = (CourseForManipulationDto)validationContext.ObjectInstance;

                if (course.Title == course.Description)
                {
                    return new ValidationResult(ErrorMessage,
                        new[] { nameof(CourseForManipulationDto) });
                }

            }

            return ValidationResult.Success;
        }
    }
}
