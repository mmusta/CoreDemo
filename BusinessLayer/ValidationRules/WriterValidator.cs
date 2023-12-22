using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
			RuleFor(x => x.Mail).EmailAddress().WithMessage("Mail adresi uygun formatta olmalı");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.Password).Matches(@"[A-Z]+").WithMessage("Şifre en az bir tane büyük harf içermeli");
			RuleFor(x => x.Password).Matches(@"[a-z]+").WithMessage("Şifre en az bir tane küçük harf içermeli");
			RuleFor(x => x.Password).Matches(@"[0-9]+").WithMessage("Şifre en az bir tane rakam içermeli");
			RuleFor(x => x.Password).Matches(@"[\!\?\*\.]+").WithMessage("Şifre en az bir tane özel karakter içermeli");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalı");
			RuleFor(x => x.Password).MaximumLength(16).WithMessage("Şifre en fazla 16 karakter olmalı");
		}
    }
}
