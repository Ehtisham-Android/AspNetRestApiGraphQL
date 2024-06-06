using RestApiGraphQL.Models.Emp;

namespace RestApiGraphQL.GQLTypes
{
    public class EmployeeType: ObjectGraphType<EmpTbl>
    {
        public EmployeeType() {
            Models.Invoices.RestApiGraphQldbContext invoices = new Models.Invoices.RestApiGraphQldbContext();

            Field(emp => emp.Id);
            Field(emp => emp.Age);
            Field(emp => emp.City);
            Field(emp => emp.Name);
            Field(emp => emp.Email);
            Field<InvoicesType>("dept", resolve: context => invoices.InvoicesTbls.SingleOrDefault(context.Source.Age < 50));
        }
    }
}
