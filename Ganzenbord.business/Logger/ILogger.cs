﻿namespace Ganzenbord.Business.Logger
{
    public interface ILogger
    {
        void LogMessage(string message);

        void LogError(string message);
    }
}