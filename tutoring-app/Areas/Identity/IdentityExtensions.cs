using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using tutoring_app.Data;

namespace tutoring_app.Areas.Identity
{
    // extending the default IdentityUser with these new claims
    /*public static class IdentityExtensions
    {
        public static string FirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst(ClaimTypes.GivenName);
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string LastName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst(ClaimTypes.Surname);
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string Address(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst(ClaimTypes.StreetAddress);
            // Test for null to avoid issues during local testing
            return (claim != null) ? claim.Value : string.Empty;
        }
    }*/
}
