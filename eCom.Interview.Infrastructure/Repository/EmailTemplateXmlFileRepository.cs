using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using eComEngine.Interview.Infrastructure.Private;
using eCom.Interview.Domain.Models;
using eCom.Interview.Application.Repository;

namespace eCom.Interview.Infrastructure.Repository
{
    /// <summary>
    /// This class is standard repository implementation allowing for data access, but instead of connecting
    /// to a database, it reads the templates from an XML file. 
    /// </summary>
    public class EmailTemplateXmlFileRepository : IRepository<EmailTemplate>
    {
        private readonly IList<EmailTemplate> templates;

        public EmailTemplateXmlFileRepository(string xmlFilePath)
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(EmailTemplateCollection));

            using (var fs = new System.IO.FileStream(xmlFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                this.templates = (EmailTemplateCollection)serializer.Deserialize(fs);
            }
        }

        /// <summary>
        /// Returns the single top-level EmailTemplate with the provided id or null if not found. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<EmailTemplate> Single(Guid id)
        {
            var template = templates.SingleOrDefault(t => t.Id.Equals(id));

            return Task.FromResult(template);
        }

        /// <summary>
        /// Returns all top-level EmailTemplates that match the provided selector. No results will return an empty collection.
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public Task<IQueryable<EmailTemplate>> Where(Expression<Func<EmailTemplate, bool>> selector)
        {
            var selected = this.templates.Where(selector.Compile());

            return Task.FromResult(selected.AsQueryable());
        }

        /// <summary>
        /// Returns all top-level EmailTemplates that match the provided selector with the provided sort order applied.
        /// No results will return an empty collection.
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public Task<IQueryable<EmailTemplate>> Where(Expression<Func<EmailTemplate, bool>> selector,
                                                     Expression<Func<IQueryable<EmailTemplate>, IQueryable<EmailTemplate>>> orderBy)
        {
            if (orderBy == null)
            {
                return this.Where(selector);
            }

            var selected = this.templates.Where(selector.Compile()).AsQueryable();

            var ordered = orderBy.Compile().Invoke(selected);

            return Task.FromResult(ordered);
        }
    }
}
namespace eComEngine.Interview.Infrastructure.Private
{
    /// <summary>
    /// This class is for serialization purposes ONLY and should only be used for that reason
    /// within this assembly. 
    /// </summary>
    public class EmailTemplateCollection : List<EmailTemplate>
    {
        public IList<EmailTemplate> EmailTemplates { get; set; }
    }
}