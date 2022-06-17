using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.UI
{
    public static class UIRules
    {
        public static IResult TextBoxesAreNotEmpty(params string[] textboxes)
        {
            foreach (var textbox in textboxes)
            {
                if (textbox == null)
                {
                    return new ErrorResult("Bütün Bilgilerinizi Doldurduğunuzdan Emin Olun!");
                }
            }
            return new SuccessResult();
        }
    }
}
