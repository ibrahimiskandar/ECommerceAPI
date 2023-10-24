using ECommerceAPI.Application.Abstractions.Services;
using ECommerceAPI.Application.DTOs.User;
using ECommerceAPI.Application.Exceptions;
using ECommerceAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.Features.Commands.User.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
    {
        private readonly IUserService _userService;

        public RegisterUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            RegisterUserResponseDTO response = await _userService.RegisterUserAsync(new()
            {
                NameSurname = request.NameSurname,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm
            });
            return new()
            {
                IsSucceeded = response.IsSucceeded,
                Message = response.Message
            };
        }
    }
}
