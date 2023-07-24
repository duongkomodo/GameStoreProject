using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DataAccess.Utility
{
    public static class StringText
    {
        public static readonly string AvatarLink = @"Assets\blankAvatar.png";
        public static readonly string UploadImageKey = @"secret_kW15bYAFbGHU4Lap5NvRgRHaeYQ5";
    }

    public static class OutputStatus
    {
        public static readonly string Fail = @"Fail";
        public static readonly string Success = @"Success";
    }

    public static class OrderStatus
    { //Unpaid, Pending, Paid
        public static readonly int Unpaid = 0;
        public static readonly int Pending = 1;
        public static readonly int Paid = 2;
        public static readonly string UnpaidText = "Unpaid";
        public static readonly string PendingText = "Pending";
        public static readonly string PaidText = "Paid";
    }
    public enum Roles
    {
        Admin,
        Manager,
        Member
    }
}
