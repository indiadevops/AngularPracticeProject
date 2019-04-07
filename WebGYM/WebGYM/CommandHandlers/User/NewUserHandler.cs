using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebGYM.Command.User;
using WebGYM.Common;
using WebGYM.Interface;
using WebGYM.Models;

namespace WebGYM.CommandHandlers.User
{
    public class NewUserHandler : IRequestHandler<NewUser, Users>
    {
        private readonly IMapper _mapper;
        private readonly IUsers _users;
        public NewUserHandler(IMapper mapper,IUsers users)
        {
            _mapper = mapper;
            _users = users;
        }
        public Task<Users> Handle(NewUser request, CancellationToken cancellationToken)
        {
            var tempUsers = AutoMapper.Mapper.Map<Users>(request);
            tempUsers.CreatedDate = DateTime.Now;
            tempUsers.Createdby = 1;
            tempUsers.Password = EncryptionLibrary.EncryptText(request.Password);
            _users.InsertUsers(tempUsers);
            return Task.FromResult(tempUsers);
        }
    }
}
