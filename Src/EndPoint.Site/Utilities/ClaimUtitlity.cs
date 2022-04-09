using System.Security.Claims;

namespace EndPoint.Site.Utilities
{
    public static class ClaimUtitlity
    {
        public static int? GetUserId(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity.FindFirst(ClaimTypes.NameIdentifier) != null)
                {
                    int userId = int.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    return userId;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public static List<string> GetRoles(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;
                List<string> roles = new List<string>();
                foreach (var item in claimsIdentity.Claims.Where(p => p.Type.EndsWith("role")))
                {
                    roles.Add(item.Value);
                }
                return roles;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
