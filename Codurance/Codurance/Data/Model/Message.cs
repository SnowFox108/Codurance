using System;
using Codurance.Data.Infrastructure;

namespace Codurance.Data.Model
{
    public class Message : Entity
    {
        public string Text { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
