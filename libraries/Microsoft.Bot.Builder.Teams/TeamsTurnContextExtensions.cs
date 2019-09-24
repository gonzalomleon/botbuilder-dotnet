﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Schema;
using Microsoft.Bot.Schema.Teams;

namespace Microsoft.Bot.Builder.Teams
{
    public static class TeamsTurnContextExtensions
    {
        public static async Task<ResourceResponse> TeamsSendToChannelAsync(this ITurnContext turnContext, string teamsChannelId, IActivity activity, CancellationToken cancellationToken = default)
        {
            var originalConversationId = turnContext.Activity.Conversation.Id;
            turnContext.Activity.Conversation.Id = teamsChannelId;
            var result = await turnContext.SendActivityAsync(activity, cancellationToken).ConfigureAwait(false);
            turnContext.Activity.Conversation.Id = originalConversationId;
            return result;
        }

        public static Task<ResourceResponse> TeamsSendToGeneralChannelAsync(this ITurnContext turnContext, IActivity activity, CancellationToken cancellationToken = default)
        {
            var teamId = turnContext.TeamsGetTeamId();
            return turnContext.TeamsSendToChannelAsync(teamId, activity, cancellationToken);
        }

        public static string TeamsGetTeamId(this ITurnContext turnContext)
        {
            var channelData = turnContext.Activity.GetChannelData<TeamsChannelData>();
            var teamId = channelData?.Team?.Id;

            if (string.IsNullOrEmpty(teamId))
            {
                throw new Exception("The current Activity was not sent from a Teams Team.");
            }

            return teamId;
        }
    }
}
