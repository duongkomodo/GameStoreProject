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
    public enum Roles
    {
        Admin,
        Manager,
        Member
    }
}
