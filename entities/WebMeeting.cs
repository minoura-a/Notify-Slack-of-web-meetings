using System;
using Newtonsoft.Json;

namespace dcinc.api.entities
{
    /// <summary>
    /// Web会議を表す
    /// </summary>
    public class WebMeeting
    {
        /// <summary>
        /// 既定のコンストラクタ
        /// </summary>
        public WebMeeting()
        {
            Id = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// 一意とするID
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        
        /// <summary>
        /// Web会議名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Web会議の開始日時
        /// </summary>
        [JsonProperty("StartDateTime")]
        public DateTime StartDateTime { get; set; }
        
        /// <summary>
        /// Web会議の日付
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.UnixDateTimeConverter))]
        public DateTime Date => StartDateTime.Date.ToUniversalTime();
        
        /// <summary>
        /// Web会議のURL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// 登録日時
        /// </summary>
        [JsonProperty("registeredAt")]
        public DateTime RegisteredAt { get; set; }
        
        /// <summary>
        /// 登録者
        /// </summary>
        [JsonProperty("registeredBy")]
        public string RegisteredBy { get; set; }
        
        /// <summary>
        /// 通知先のSlackチャンネル
        /// </summary>
        [JsonProperty("slackChannelId")]
        public string SlackChannelId { get; set; }

        /// <summary>
        /// Web会議の日付（Unix 時刻（秒））
        /// </summary>
        /// <returns>1970-01-01T00:00:00Z からの経過時間（秒）</returns>
        [JsonIgnore]
        public long DateUnixTimeSeconds => new DateTimeOffset(Date).ToUnixTimeSeconds();
    }
}