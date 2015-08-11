using System.Web;

namespace CodeHelpers.Web
{
	public class FakeHttpContext : HttpContextBase
	{
		public FakeHttpContext()
		{
			RequestBase = new FakeHttpRequest();
		}

		public FakeHttpRequest RequestBase { get; set; }
		public override HttpRequestBase Request { get { return RequestBase; } }
	}
}
