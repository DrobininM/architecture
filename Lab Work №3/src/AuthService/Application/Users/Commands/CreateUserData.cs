using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands
{
    public class CreateUserData
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }
    }
}
