
namespace CommonFramework.Components
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Board
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("desc")]
        public string Desc { get; set; }

        [JsonProperty("descData")]
        public object DescData { get; set; }

        [JsonProperty("closed")]
        public bool Closed { get; set; }

        [JsonProperty("idOrganization")]
        public string IdOrganization { get; set; }

        [JsonProperty("idEnterprise")]
        public object IdEnterprise { get; set; }

        [JsonProperty("pinned")]
        public bool Pinned { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("shortUrl")]
        public Uri ShortUrl { get; set; }

        [JsonProperty("prefs")]
        public Prefs Prefs { get; set; }

        [JsonProperty("labelNames")]
        public LabelNames LabelNames { get; set; }

        [JsonProperty("limits")]
        public Limits Limits { get; set; }
    }

    public partial class LabelNames
    {
        [JsonProperty("green")]
        public string Green { get; set; }

        [JsonProperty("yellow")]
        public string Yellow { get; set; }

        [JsonProperty("orange")]
        public string Orange { get; set; }

        [JsonProperty("red")]
        public string Red { get; set; }

        [JsonProperty("purple")]
        public string Purple { get; set; }

        [JsonProperty("blue")]
        public string Blue { get; set; }

        [JsonProperty("sky")]
        public string Sky { get; set; }

        [JsonProperty("lime")]
        public string Lime { get; set; }

        [JsonProperty("pink")]
        public string Pink { get; set; }

        [JsonProperty("black")]
        public string Black { get; set; }
    }

    public partial class Limits
    {
    }

    public partial class Prefs
    {
        [JsonProperty("permissionLevel")]
        public string PermissionLevel { get; set; }

        [JsonProperty("hideVotes")]
        public bool HideVotes { get; set; }

        [JsonProperty("voting")]
        public string Voting { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("invitations")]
        public string Invitations { get; set; }

        [JsonProperty("selfJoin")]
        public bool SelfJoin { get; set; }

        [JsonProperty("cardCovers")]
        public bool CardCovers { get; set; }

        [JsonProperty("isTemplate")]
        public bool IsTemplate { get; set; }

        [JsonProperty("cardAging")]
        public string CardAging { get; set; }

        [JsonProperty("calendarFeedEnabled")]
        public bool CalendarFeedEnabled { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }

        [JsonProperty("backgroundImage")]
        public object BackgroundImage { get; set; }

        [JsonProperty("backgroundImageScaled")]
        public object BackgroundImageScaled { get; set; }

        [JsonProperty("backgroundTile")]
        public bool BackgroundTile { get; set; }

        [JsonProperty("backgroundBrightness")]
        public string BackgroundBrightness { get; set; }

        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; }

        [JsonProperty("backgroundBottomColor")]
        public string BackgroundBottomColor { get; set; }

        [JsonProperty("backgroundTopColor")]
        public string BackgroundTopColor { get; set; }

        [JsonProperty("canBePublic")]
        public bool CanBePublic { get; set; }

        [JsonProperty("canBeEnterprise")]
        public bool CanBeEnterprise { get; set; }

        [JsonProperty("canBeOrg")]
        public bool CanBeOrg { get; set; }

        [JsonProperty("canBePrivate")]
        public bool CanBePrivate { get; set; }

        [JsonProperty("canInvite")]
        public bool CanInvite { get; set; }
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}


