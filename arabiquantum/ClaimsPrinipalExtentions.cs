using System.Security.Claims;

namespace arabiquantum
{
    public static class ClaimsPrinipalExtentions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
