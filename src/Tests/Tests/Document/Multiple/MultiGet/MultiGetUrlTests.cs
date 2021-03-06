﻿using System.Threading.Tasks;
using Elastic.Xunit.XunitPlumbing;
using Nest;
using Tests.Domain;
using Tests.Framework;
using static Tests.Framework.UrlTester;

namespace Tests.Document.Multiple.MultiGet
{
	public class MultiGetUrlTests : UrlTestsBase
	{
		[U] public override async Task Urls()
		{
			await POST("/_mget")
				.Fluent(c => c.MultiGet())
				.Request(c => c.MultiGet(new MultiGetRequest()))
				.FluentAsync(c => c.MultiGetAsync())
				.RequestAsync(c => c.MultiGetAsync(new MultiGetRequest()))
				;

			await POST("/project/_mget")
				.Fluent(c => c.MultiGet(m => m.Index<Project>()))
				.Request(c => c.MultiGet(new MultiGetRequest(typeof(Project))))
				.FluentAsync(c => c.MultiGetAsync(m => m.Index<Project>()))
				.RequestAsync(c => c.MultiGetAsync(new MultiGetRequest(typeof(Project))))
				;

			await POST("/project/doc/_mget")
				.Fluent(c => c.MultiGet(m => m.Index<Project>().Type<Project>()))
				.Request(c => c.MultiGet(new MultiGetRequest(typeof(Project), typeof(Project))))
				.FluentAsync(c => c.MultiGetAsync(m => m.Index<Project>().Type<Project>()))
				.RequestAsync(c => c.MultiGetAsync(new MultiGetRequest(typeof(Project), typeof(Project))))
				;

		}
	}
}
