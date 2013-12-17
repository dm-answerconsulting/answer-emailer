using System.Collections.Generic;

namespace Answer.Emailer
{
    public class BaseMail
    {
        private readonly IList<string> _to = new List<string>();
        private readonly IList<string> _cc = new List<string>();
        private readonly IList<string> _bcc = new List<string>();
        
        public IList<string> To { get { return _to; } }
        public IList<string> Cc { get { return _cc; } }
        public IList<string> Bcc { get { return _bcc; } }

        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public bool Important { get; set; }
    }
}
