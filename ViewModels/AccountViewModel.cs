using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Сундучок.ViewModels
{
    public class AccountViewModel
    {
        public virtual string LoginUserName { get; set; }

        [DataType(DataType.Password)]
        public virtual string LoginPassword { get; set; }

        public virtual string RegisterUserName { get; set; }

        [DataType(DataType.Password)]
        public virtual string RegisterPassword { get; set; }

        public virtual bool RememberMe { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
    }
}
