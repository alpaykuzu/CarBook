using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AppUsers.Queries.GetCheckAppUser
{
    public class GetCheckAppUserQueryResponse
    {
        public int AppUserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int AppRoleID { get; set; }
        public string AppRoleName { get; set; }
        public bool IsExist { get; set; }
    }
}
