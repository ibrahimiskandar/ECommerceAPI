using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Application.DTOs.User
{
    public class RegisterUserResponseDTO
    {
        public bool IsSucceeded { get; set; }
        public string Message { get; set; }
    }
}
