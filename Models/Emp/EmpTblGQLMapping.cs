namespace RestApiGraphQL.Models.Emp
{
    public class EmpTblGQLMapping : ObjectGraphType<EmpTbl>
    {
        public EmpTblGQLMapping() {
            Field(emp => emp.Id);
            Field(emp => emp.Age);
            Field(emp => emp.City);
            Field(emp => emp.Email);
            Field(emp => emp.Name);
        }
    }

    public class EmpTblGQLQuery : ObjectGraphType {
        public EmpTblGQLQuery()
        {
            Field<ListGraphType<EmpTblGQLMapping>>(Name = "emp_tbl");
        }
    }

    public class EmpTblGQLSchema : Schema
    {
        public EmpTblGQLSchema(IServiceProvider serviceProvider) : base(serviceProvider) {
            Query = serviceProvider.GetRequiredService<EmpTblGQLQuery>();
        }
    }
}
