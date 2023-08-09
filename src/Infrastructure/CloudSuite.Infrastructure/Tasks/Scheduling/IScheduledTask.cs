﻿using System.Threading;
using System.Threading.Tasks;

namespace CloudSuite.Infrastructure.Tasks.Scheduling
{
    public interface IScheduledTask
    {
        string Schedule { get; }

        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
