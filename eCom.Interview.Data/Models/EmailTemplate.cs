using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCom.Interview.Data.Models
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