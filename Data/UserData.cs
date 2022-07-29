namespace Backrooms.Data {
    public class DiscordCode {
        public string code { get; set; }
    }
    public class DiscordToken {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
    }
    public class UserData {
        public string username { get; set; }
        public string avatar_url { get; set; }
        public bool bot_is_on { get; set; }
    }
}

