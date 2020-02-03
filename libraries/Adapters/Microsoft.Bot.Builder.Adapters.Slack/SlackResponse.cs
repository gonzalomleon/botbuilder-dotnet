﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Bot.Builder.Adapters.Slack
{
    /// <summary>
    /// SlackResponse class.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SlackResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the Ok status is true or false.
        /// </summary>
        /// <value>The ok status of the response.</value>
        public bool Ok { get; set; }

        /// <summary>
        /// Gets or sets the Channel property.
        /// </summary>
        /// <value>The channel.</value>
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the Ts property.
        /// </summary>
        /// <value>The timestamp.</value>
        public string Ts { get; set; }

        /// <summary>
        /// Gets or sets the Message property.
        /// </summary>
        /// <value>The message.</value>
        public SlackMessage Message { get; set; }
    }
}
