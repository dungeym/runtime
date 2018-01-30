﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;
using System.Threading.Tasks;

namespace System.ServiceProcess.Tests
{
    public enum PipeMessageByteCode
    {
        Start = 0,
        Continue = 1,
        Pause = 2,
        Stop = 3,
        OnCustomCommand = 4
    };

    public static class TaskTimeoutExtensions
    {
        public static async Task TimeoutAfter(this Task task, int millisecondsTimeout)
        {
            var cts = new CancellationTokenSource();

            if (task == await Task.WhenAny(task, Task.Delay(millisecondsTimeout, cts.Token)))
            {
                cts.Cancel();
                await task;
            }
            else
            {
                throw new TimeoutException($"Task timed out after {millisecondsTimeout}");
            }
        }
    }
}
