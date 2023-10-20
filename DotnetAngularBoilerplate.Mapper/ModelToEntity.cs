using DotnetAngularBoilerplate.Model;
using DotnetAngularBoilerplate.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetAngularBoilerplate.Mapper
{
    public static class ModelToEntity
    {
        public static ApplicationUser Map(RegisterUserDataModel registerUserDataModel)
        {
            return new()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = registerUserDataModel.Email,
                UserName = registerUserDataModel.UserName,
                FirstName = registerUserDataModel.FirstName,
                LastName = registerUserDataModel.LastName,
                MiddleName = registerUserDataModel.MiddleName,
            };
        }
    }
}
