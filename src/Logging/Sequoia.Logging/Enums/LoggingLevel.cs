﻿namespace Sequoia.Logging.Enums;

public enum LoggingLevel
{
    /// <summary>
    /// Anything and everything you might want to know about a running block of code.
    /// </summary>
    Verbose = 0,
    /// <summary>
    /// Internal system events that aren't necessarily observable from the outside.
    /// </summary>
    Debug = 1,
    /// <summary>
    /// The lifeblood of operational intelligence - things happen.
    /// </summary>
    Information = 2,
    /// <summary>
    ///  Service is degraded or endangered.
    /// </summary>
    Warning = 3,
    /// <summary>
    /// Functionality is unavailable, invariants are broken or data is lost.
    /// </summary>
    Error = 4,
    /// <summary>
    /// If you have a pager, it goes off when one of these occurs.
    /// </summary>
    Fatal = 5
}