using System;

namespace CrossCutting.Model
{
    public class Message
    {
        public string Text { get; set; }
        public User CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
