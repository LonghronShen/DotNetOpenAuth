using DotNetOpenAuth.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Web.UI
{

    public static class PageAsyncTaskFactory
    {

        public static PageAsyncTask Create(Func<Task> handler)
        {
#if NET40
            return new PageAsyncTask((object sender, EventArgs e, AsyncCallback callback, object data) =>
            {
                return TaskUtils.AsApm(handler(), callback, data);
            }, (ar) => { }, (ar) => { }, null);
#else
            return new PageAsyncTask(handler);
#endif
        }

        public static PageAsyncTask Create(Func<CancellationToken, Task> handler)
        {
            return Create(handler, CancellationToken.None);
        }

        public static PageAsyncTask Create(Func<CancellationToken, Task> handler, CancellationToken ct)
        {
#if NET40
            return new PageAsyncTask((object sender, EventArgs e, AsyncCallback callback, object data) =>
            {
                return TaskUtils.AsApm(handler(ct), callback, data);
            }, (ar) => { }, (ar) => { }, null);
#else
            return new PageAsyncTask(handler);
#endif
        }

    }

}