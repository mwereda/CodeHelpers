using System;
using System.Collections.Specialized;
using System.Web;

namespace CodeHelpers.Web
{
	public class FakeHttpRequest : HttpRequestBase
	{
		public Uri UrlBase { get; set; }
		public override Uri Url { get { return UrlBase; } }
		public override HttpCookieCollection Cookies { get { return new HttpCookieCollection(); } }
		public override NameValueCollection Form { get { return new NameValueCollection(); } }
	}
}
