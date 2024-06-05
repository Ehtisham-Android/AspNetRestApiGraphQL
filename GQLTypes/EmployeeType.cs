using RestApiGraphQL.Models.Emp;

namespace RestApiGraphQL.GQLTypes
{
    public class EmployeeType: ObjectGraphType<EmpTbl>
    {
        public EmployeeType() {
            Field(emp => emp.Id);
            Field(emp => emp.Age);
            Field(emp => emp.City);
            Field(emp => emp.Name);
            Field(emp => emp.Email);
        }
    }
}
