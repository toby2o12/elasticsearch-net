﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;
using System.Threading;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <inheritdoc/>
		IExecutePainlessScriptResponse<TResult> ExecutePainlessScript<TResult>(Func<ExecutePainlessScriptDescriptor, IExecutePainlessScriptRequest> selector);

		/// <inheritdoc/>
		IExecutePainlessScriptResponse<TResult> ExecutePainlessScript<TResult>(IExecutePainlessScriptRequest request);

		/// <inheritdoc/>
		Task<IExecutePainlessScriptResponse<TResult>> ExecutePainlessScriptAsync<TResult>(Func<ExecutePainlessScriptDescriptor, IExecutePainlessScriptRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken));

		/// <inheritdoc/>
		Task<IExecutePainlessScriptResponse<TResult>> ExecutePainlessScriptAsync<TResult>(IExecutePainlessScriptRequest request, CancellationToken cancellationToken = default(CancellationToken));

	}
	public partial class ElasticClient
	{
		public IExecutePainlessScriptResponse<TResult> ExecutePainlessScript<TResult>(Func<ExecutePainlessScriptDescriptor, IExecutePainlessScriptRequest> selector) =>
			this.ExecutePainlessScript<TResult>(selector?.Invoke(new ExecutePainlessScriptDescriptor()));

		public IExecutePainlessScriptResponse<TResult> ExecutePainlessScript<TResult>(IExecutePainlessScriptRequest request) =>
			this.Dispatcher.Dispatch<IExecutePainlessScriptRequest, ExecutePainlessScriptRequestParameters, ExecutePainlessScriptResponse<TResult>>(
				request,
				this.LowLevelDispatch.ScriptsPainlessExecuteDispatch<ExecutePainlessScriptResponse<TResult>>
			);

		public Task<IExecutePainlessScriptResponse<TResult>> ExecutePainlessScriptAsync<TResult>(Func<ExecutePainlessScriptDescriptor, IExecutePainlessScriptRequest> selector,
			CancellationToken cancellationToken = default(CancellationToken)) =>
			this.ExecutePainlessScriptAsync<TResult>(selector?.Invoke(new ExecutePainlessScriptDescriptor()), cancellationToken);

		public Task<IExecutePainlessScriptResponse<TResult>> ExecutePainlessScriptAsync<TResult>(IExecutePainlessScriptRequest request, CancellationToken cancellationToken = default(CancellationToken)) =>
			this.Dispatcher.DispatchAsync<IExecutePainlessScriptRequest, ExecutePainlessScriptRequestParameters, ExecutePainlessScriptResponse<TResult>, IExecutePainlessScriptResponse<TResult>>(
				request,
				cancellationToken,
				this.LowLevelDispatch.ScriptsPainlessExecuteDispatchAsync<ExecutePainlessScriptResponse<TResult>>
			);
	}
}
