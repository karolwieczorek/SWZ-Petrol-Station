using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SWZ_Petrol_Station.Models
{
    public class Petrol {
        public int price;
        public string type;
    }

    public enum AccountType { 
        Client = 0,
        Employee = 1,
        Admin = 2
    }
}