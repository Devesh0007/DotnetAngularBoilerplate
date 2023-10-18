using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAngularBoilerplate.Model.DataModel
{
    public class RegisterUserDataModel
    {
        public required string FirstName { get; set; }
        public required string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        [NotMapped]
        public string UserName { get { return Email; } set { UserName = Email; } }
        [PasswordPropertyText]
        public required string Password { get; set; }
        public required string Role { get; set; }

    }
}
