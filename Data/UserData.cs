namespace Backrooms.Data {
    public class DiscordCode {
        public string code { get; set; }
    }
    public class DiscordToken {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string scope { get; set; }
        public string refresh_token {get; set;}
    }
    public class UserData {
        public string id { get; set; }
        public string username { get; set; }
        public string discriminator { get; set; }
        public string avatar { get; set; }
        public string avatar_decoration { get; set; }
        public int public_flags { get; set; }
        public string locale { get; set; }
        public bool mfa_enabled { get; set; }
        public string accent_type { get; set; }
        public string banner { get; set; }
        public string banner_color { get; set; }
        public string avatar_url {get;set;}
    }
}

