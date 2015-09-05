using Codurance.Data.Infrastructure;

namespace Codurance.Data.Repository
{
    public  abstract class Repository
    {
        protected IContentContext ContentContext;

        protected Repository(IContentContext contentContext)
        {
            ContentContext = contentContext;
        }
    }
}
