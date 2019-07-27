//-----------------------------------------------------------------------
// <copyright file="OAuthPrincipal.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth.OAuth.ChannelElements {
    using Microsoft.IdentityModel.Claims;
    using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Diagnostics.CodeAnalysis;
	using System.Linq;
	using System.Runtime.InteropServices;

	using Validation;

	/// <summary>
	/// Utilities for dealing with OAuth claims and principals.
	/// </summary>
	internal static class OAuthPrincipal {
        //
        // Summary:
        //     The default name claim type; System.Security.Claims.ClaimTypes.Name.
        public const string DefaultNameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        //
        // Summary:
        //     The default role claim type; System.Security.Claims.ClaimTypes.Role.
        public const string DefaultRoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        /// <summary>
        /// Creates a new instance of ClaimsPrincipal.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="roles">The roles.</param>
        /// <returns>
        /// A new instance of GenericPrincipal with a GenericIdentity, having the same username and roles as this OAuthPrincipal and OAuthIdentity
        /// </returns>
        internal static ClaimsPrincipal CreatePrincipal(string userName, IEnumerable<string> roles = null) {
			Requires.NotNullOrEmpty(userName, "userName");

			var claims = new List<Claim>();
			claims.Add(new Claim(ClaimsIdentity.DefaultNameClaimType, userName));
			if (roles != null) {
				claims.AddRange(roles.Select(scope => new Claim(DefaultRoleClaimType, scope)));
			}

			var claimsIdentity = new ClaimsIdentity(claims, "OAuth 2 Bearer");
			var principal = new ClaimsPrincipal(new IClaimsIdentity[] { claimsIdentity });
			return principal;
		}
	}
}
