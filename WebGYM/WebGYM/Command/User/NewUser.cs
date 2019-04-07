using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGYM.Models;

namespace WebGYM.Command.User
{
    public class NewUser : IRequest<Users>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string Contactno { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
