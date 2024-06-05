using RestApiGraphQL.GQLQueries;

namespace RestApiGraphQL.GQLSchemas
{
    public class EmployeeSchema : Schema
    { 
        public EmployeeSchema(IServiceProvider provider) :  base(provider)
        {
            Query = provider.GetRequiredService<EmployeeQuery>();
        }
    }
}
