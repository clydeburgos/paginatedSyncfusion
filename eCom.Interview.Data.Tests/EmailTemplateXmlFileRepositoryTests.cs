using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace eComEngine.Interview.Data.Tests
{
    public class EmailTemplateXmlFileRepositoryTests
    {
        [Fact]
        public void Single_FindsExistingRecord_ById()
        {
            var repo = new EmailTemplateXmlFileRepository(Environment.EmailTemplateXmlFile);

            var template = repo.Single(Guid.Parse("ae99d53d-04d6-4962-ad26-44aec94ea690")).Result;

            Assert.NotNull(template);
            Assert.Equal("Email Template 73 - Revision 2", template.EmailLabel);
        }

        [Fact]
        public void Single_ReturnsNull_WhenIdNotFound()
        {
            var repo = new EmailTemplateXmlFileRepository(Environment.EmailTemplateXmlFile);

            var template = repo.Single(Guid.NewGuid()).Result;

            Assert.Null(template);
        }

        [Fact]
        public void Where()
        {
            var repo = new EmailTemplateXmlFileRepository(Environment.EmailTemplateXmlFile);

            var actual = repo.Where(t => t.EmailType.Equals("NotificationEmail", StringComparison.CurrentCultureIgnoreCase)).Result;

            Assert.Equal(1, actual.Count());
            Assert.Equal("f6612832-d405-4d7b-bd4d-c74cd7e75259", actual.Single().Id.ToString());
        }

        [Fact]
        public void Where_WithOrderBy()
        {
            var repo = new EmailTemplateXmlFileRepository(Environment.EmailTemplateXmlFile);

            var actual = repo.Where(t => t.EmailType.Equals("WelcomeEmail", StringComparison.CurrentCultureIgnoreCase),
                                        templates => templates.OrderBy(t => t.DateUpdated)).Result;

            Assert.Equal("ae99d53d-04d6-4962-ad26-44aec94ea690", actual.First().Id.ToString());
        }
    }

    public static class Environment
    {
        public static string EmailTemplateXmlFile = $"{System.IO.Directory.GetCurrentDirectory()}\\Data\\Templates.xml";
    }

}
