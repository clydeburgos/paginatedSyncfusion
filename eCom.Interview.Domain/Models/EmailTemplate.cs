using System;
using System.Collections.Generic;
using System.Text;

namespace eCom.Interview.Domain.Models
{
    public class EmailTemplate
    {
        public Guid Id { get; set; }
        public string EmailLabel { get; set; }
        public string FromAddress { get; set; }
        public string Subject { get; set; }
        public string TemplateText { get; set; }
        public string EmailType { get; set; }
        public bool Active { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool LoadDrafts { get; set; }
        public Guid ParentId { get; set; }
        public int VersionCount { get; set; }
        public bool IsDefault { get; set; }
        public string BccAddress { get; set; }

        public bool IsDraft
        {
            get { return Id != ParentId; }
        }

        public EmailTemplate[] Versions { get; set; }
    }
}
