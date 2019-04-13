namespace Apresentacao.Data
{
    public class ApplicationDbContextBase 
    {
        public readonly ApplicationDbContext Context;
        public ApplicationDbContextBase(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}
