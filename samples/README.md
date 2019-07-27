# DotNetOpenAuth samples

### Prerequisites:

*   Microsoft .NET 3.5
*   Visual Studio 2010 or IIS
*   Microsoft Windows (XP or Vista, or 2003 Server or later)
*   See the tools section further below for some helpful software

## Getting the samples running

### Testing the relying party/provider samples with each other

In this scenario you can use the Personal Web Server (PWS) that is included in Visual Studio 2010.

1.  Open the DotNetOpenAuth.sln or Samples.sln file in VS2010.
2.  Right-click on each web project under the Samples folder and click "View in Browser" to start PWS for each web site.
3.  Each web project will be dynamicly assigned a port number.  Find the port number on the URL of the browser window for the Provider. 
4.  Now log into the Relying Party sample web site with this OpenID: http://localhost:_providerport_/user/bob.
5.  When the provider prompts you for a password, type in 'test'.

### Testing with other relying party/provider sites on the Internet

*   You need to have a public IP address to test the Provider sample with other Relying Party web sites out on the Internet so they can find your Provider. 
*   You might need to configure your firewall and/or router to forward traffic to your computer.
*   Note that some OpenID-enabled sites block URLs that use just IP addresses.  You may need to get a DNS name to point at your public IP address in order for your scenario to work.
*   Ensure your firewall is configured to allow inbound and outbound TCP port 80 connections.
*   Since VS2010 Personal Web Server (PWS) does not allow web requests from other servers (as required by OpenID relying parties trying to log into your server), testing with external relying parties requires you to use IIS to host your server.

### Setting up the IIS Applications

*   Create an IIS web application for each sample. 
*   Check that IIS is responding to requests on the port that your router will be forwarding requests to you on, if applicable.
*   Enable anonymous access to each site.

Configure VS2010 to use IIS rather than PWS

1.  Right-click on one of the web projects within Solution Explorer.
2.  Select Property Pages.
3.  Select Start Options on the left.
4.  Under the Server section on the right, select Use Custom Server and fill in the Base URL.

## The demos

These will illustrate OpenID in action. You can debug the code to get a good idea of what's going on. The implementations are built on top of ASP.NET's forms authentication. So basically if you're unauthenticated and get to page requiring authentication, it takes you through the OpenID identity provider, tracks in session that you've left and then recognizes the user when they return to the relying party and only then logs them into FormsAuth and redirects them to their originally requested page.

### The Relying Party Demo

1.  Kill all session cookies
2.  Create an OpenID account with one of the Open Servers listed below OR use the demo Server as the identity provider - using http://[EXTERNAL IP]/OpenIdProviderWebForms/user/bob with the password 'test'
3.  Go to http://[EXTERNAL IP]/OpenIdRelyingPartyWebForms/default.aspx and enter the OpenIDURL
4.  You are required to authenticate with the provider. Some fields (eg Name, DoB, Country etc.) are requested, some required and some omitted. Your OpenID provider should prompt you for the relevant fields, or at least make you aware which fields its passing back. The exact page flow and auhentication mechanism will be implemented differently by different identity providers.
5.  After providing the required info and loggin in, you are taken back to the http://[EXTERNAL IP]/OpenIdRelyingPartyWebForms/default.aspx and the available profile information is displayed

### The Provider Demo

1.  Kill all session cookies
2.  Get the full openID url for a user based on whats in web.config. By default you can use http://[EXTERNAL IP]/OpenIdProviderWebForms/user/bob with the password 'test'
3.  Go to http://[EXTERNAL IP]/OpenIdRelyingPartyWebForms/default.aspx and enter the OpenIDURL of the local server
4.  The user is prompted for their password. The username field is propulated from the openid url and grayed out.
5.  The user is presentend with their identity url, a trust root (the site requiring authentication) and set of fields to complete. Only the requested or required fields are presented. Fields with * means the consumer requires it.
6.  The user completes the fields and clicks Yes and are taken to http://[EXTERNAL IP]/OpenIdRelyingPartyWebForms/default.aspx with their available profile information.

### Interesting classes and methods

#### Relying party

*   DotNetOpenAuth.OpenId.RelyingParty.**OpenIdRelyingParty** - programmatic access to everything a relying party web site needs.
*   DotNetOpenAuth.OpenId.RelyingParty.**OpenIdTextBox** - An ASP.NET control that is a bare-bones text input box with a LogOn method that automatically does all the OpenId stuff for you.
*   DotNetOpenAuth.OpenId.RelyingParty.**OpenIdLogin** - Like the OpenIdTextBox, but has a Login button and some other end user-friendly UI built-in.  Drop this onto your web form and you're all done!

#### Provider

*   DotNetOpenAuth.OpenId.Provider.**OpenIdProvider** - programmatic access to everything a provider web site needs.
*   DotNetOpenAuth.OpenId.Provider.**ProviderEndpoint** - An ASP.NET control that you can drop in and have an instant provider endpoint on your page.
*   DotNetOpenAuth.OpenId.Provider.**IdentityEndpoint** - An ASP.NET control that you can drop onto the page for your own or your customers' individual identity pages for discovery by Relying Parties.

### Development tips / Issues I found:

Here is a growing list of [OpenID enabled sites](http://openiddirectory.com/allcats.html) to test with.

Good sites to test with if you're developing a relying party:

*   [http://www.myopenid.com/](http://www.myopenid.com/)
*   [http://claimid.com/](http://claimid.com/) (supports registration extensions)
*   [http://www.freeyourid.com/](http://www.freeyourid.com/) (supports registration extensions)

Good sites to test with if you're developing a server:

*   [http://beta.zooomr.com/home](http://beta.zooomr.com/home)  *
*   [http://cr.unchy.com/](http://cr.unchy.com/)  (supports registration extensions)
*   [http://blog.identity20.eu](http://blog.identity20.eu)  *
*   [http://openiddirectory.com](http://openiddirectory.com)  *
*   [http://www.centernetworks.com/](http://www.centernetworks.com/)  (supports registration extensions)
*   [http://www.loudisrelative.com](http://www.loudisrelative.com)  (supports registration extensions)
*   [http://rssarchive.com/index.html](http://rssarchive.com/index.html) 
*   [http://www.jyte.com](http://www.jyte.com)  (supports registration extensions)
*   [http://dis.covr.us/](http://dis.covr.us/) 

* These sites seem to block outgoing traffic that is not on a non standard HTTP port like 80 and 443\. Therefore you'll need to host on a proper internet domain before doing any testing with them.

Useful tools:

*   [Fiddler](http://www.fiddlertool.com/fiddler/) - this will allow you to monitor HTTP traffic when using IE
*   [TamperIE](http://www.bayden.com/Other/) - allows you to change form data before posting it
*   [IE Developer toolbar](http://www.microsoft.com/downloads/details.aspx?familyid=E59C3964-672D-4511-BB3E-2D5E1DB91038&displaylang=en) - good tool for general IE UI development. Has some neat features for quickly clearing cookies etc.
*   [iMacros](http://www.iopus.com/download/) - good for automating web testing