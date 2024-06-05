using RestApiGraphQL.GQLTypes;

namespace RestApiGraphQL.GQLQueries
{
    public class EmployeeQuery : ObjectGraphType
    {
        public EmployeeQuery()
        {
            Models.Emp.RestApiGraphQldbContext emp = new Models.Emp.RestApiGraphQldbContext();
            Field<ListGraphType<EmployeeType>>(Name = "Employees", resolve: context => emp.EmpTbls.ToList());
        }
    }
}
