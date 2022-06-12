using AdvertisementApp.UI.Models;
using FluentValidation;
using System;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        //[Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola min 3 karakter olmalı");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Password not match");
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();

            RuleFor(x => x.Username).MinimumLength(3);
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("Username containse Firstname").When(x => x.Username != null && x.Firstname != null);

            RuleFor(x => x.GenderId).NotEmpty();


        }

        private bool CanNotFirstname(string username, string firstname)
        {
            return !username.Contains(firstname);
        }


    }
}
