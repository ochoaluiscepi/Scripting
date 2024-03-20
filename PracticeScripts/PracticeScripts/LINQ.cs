using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using PracticeScripts;

namespace PracticeScripts
{
    internal class LINQ
    {
        /*
         * 
          The Language Integrated Query is a Microsoft programming model and methodology 
          that essentially adds formal query capabilities into .NET.  
        
         */
        public void Sintax()
        {
            #region Objects
            int[] IntArray = { 10, 20, 30, 40, 50, 60 };
            int[] IntArray2 = { 70, 80, 5, 90, 100 };
            List<int> intList = new List<int>() { 10, 45, 35, 29, 100, 69, 58, 50 };
            var data = new List<object>()
            {
                "Luis", "Ramiro", 15000, "Ochoa", "Torres", 10000, 20000, 30000, 40000
            };
            dbContext dbContext = new dbContext();
            #endregion

            //Query Sintax Example
            var recordSet = from art in dbContext.Art
                            join price in dbContext.Price on art.Id equals price.ArtId
                            where art.Estatus == "Active"
                            && art.Descripcion.Contains("Example")
                            select art;

            //Method Sintax Example
            var recordSets = dbContext.Art.Join(dbContext.Price, article => article.Id,
                                                          price => price.ArtId,
                                                          (article, price) => new { Article = article, Price = price })
                                                    .Where(c => c.Article.Estatus == "Active"
                                                          && c.Article.Descripcion.Contains("Example"));


            #region Select(): It is used to format the result of the query as per our requirement

            var MethodSyntax = Employee.Select((fruit, index) => new { index, str = fruit });

            var QuerySyntax = from emp in Employee.GetAllEmployees() select emp;

            #endregion

            #region Where(): It is used to Filter a sequence on a based condition

            var MethodSyntaxWhere = IntArray.Where(whr => whr > 30);

            var QuerySyntaxWhere = from num in IntArray where num > 30 select num;
            #endregion

            #region Distinct(): It is used to remove the duplicate elements from a sequence (list)and returns the distinct elements from a single data source.

            var MethodSyntaxDistinct = IntArray.Distinct();

            var QuerySyntaxDistinct = (from num in IntArray select num).Distinct();
            #endregion

            #region ElementAt(): It is used to return the element at a specified index in a sequence.

            var MethodSyntaxElementAt = IntArray.ElementAt(3);

            var QuerySyntaxElementAt = (from num in IntArray select num).ElementAt(4);
            #endregion

            #region ElementAtOrDefault(): This method is used to result out a specific element from the respective collection by specifying the specific index.

            var MethodSyntaxElementAtOrDefault = IntArray.ElementAtOrDefault(-1);

            var QuerySyntaxElementAtOrDefault = (from num in IntArray select num).ElementAtOrDefault(2);
            #endregion

            #region Empty(): It is used to return an empty collection(i.e.IEnumerable) of a specified type.
            #endregion

            #region DefaultIfEmpty(): It is used to handle empty collections.

            var MethodSyntaxDefaultIfEmpty = IntArray.DefaultIfEmpty();

            var QuerySyntaxDefaultIfEmpty = (from num in IntArray select num).DefaultIfEmpty();
            #endregion

            #region Contains(): It is used to check whether a sequence or collection(i.e.data source) contains a specified element or not.

            var MethodSyntaxContains = IntArray.Contains(30);

            var QuerySyntaxContains = (from num in IntArray select num).Contains(30);
            #endregion

            #region Single(): It is used to return the single element from the collection, which satisfies the condition.

            var MethodSyntaxSingle = IntArray.Single();

            var QuerySyntaxSingle = (from num in IntArray select num).Single();
            #endregion

            #region SingleOrDefault(): It is used to return a single element from a data source, or you can say from a sequence.

            var MethodSyntaxSingleOrDefault = IntArray.SingleOrDefault(x => x == 20);

            var QuerySyntaxSingleOrDefault = (from num in IntArray select num).SingleOrDefault(num => num == 10);
            #endregion

            #region First(): It is used to return the first element from a data source or from a collection.

            var MethodSyntaxFirst = IntArray.First();

            var QuerySyntaxFirst = (from num in IntArray select num).First();
            #endregion

            #region FirstOrDefault(): It is used to return the first element of a sequence or a default value if the element isn't there.

            var MethodSyntaxFirstOrDefault = IntArray.FirstOrDefault();

            var QuerySyntaxFirstOrDefault = (from num in IntArray select num).FirstOrDefault();
            #endregion

            #region Last(): It is used to return the last element from a data source or from a collection.

            var MethodSyntaxLast = IntArray.Last();

            var QuerySyntaxLast = (from num in IntArray select num).Last();
            #endregion

            #region LastOrDefault(): It is used to return the last element of a sequence or a default value if the element isn't there.

            var MethodSyntaxLastOrDefault = IntArray.LastOrDefault();

            var QuerySyntaxLastOrDefault = (from num in IntArray select num).LastOrDefault();
            #endregion

            #region All(): It is used to check whether all the elements of a data source satisfy a given condition or not.

            var resultAll = Employee.GetAllEmployees().All(whr => whr.Salary >= 10000);

            #endregion

            #region Any(): It is used to check whether at least one of the elements of a data source satisfies a given condition or not.

            var result = Employee.GetAllEmployees().Any(x => x.Salary > 20000 && x.Department == "IT");

            #endregion

            #region OrderBy(): It is used to sort the data in Ascending Order.

            var MethodSyntaxOrderBy = IntArray.OrderBy(num => num);

            var QuerySyntaxOrderBy = (from num in IntArray orderby num select num).ToList();
            #endregion

            #region OrderByDescending(): It is used to sort the data in Descending order.

            var MethodSyntaxOrderByDescending = intList.OrderByDescending(num => num);

            var QuerySyntaxOrderByDescending = (from num in intList orderby num descending select num).ToList();
            #endregion

            #region ThenBy(): It is used to sort the data in Ascending order from the second level onwards.

            var MethodSyntaxThenBy = Employee.GetAllEmployees().OrderBy(ord => ord.Department).ThenBy(x => x.Name);

            var QuerySyntaxThenBy = (from emp in Employee.GetAllEmployees() orderby emp.Department, emp.Name select emp);
            #endregion

            #region ThenByDescending() - It is used to sort the data in Descending order also from the second level onwards.

            var MethodSyntaxThenByDescending = Employee.GetAllEmployees().OrderByDescending(ord => ord.Salary).ThenByDescending(x => x.Name);

            var QuerySyntaxThenByDescending = (from emp in Employee.GetAllEmployees() where emp.Department == "Sales" orderby emp.Salary descending, emp.Name descending select emp).ToList();
            #endregion

            #region Reverse(): It is used to reverse the data stored in a data source.

            var MethodSyntaxReverse = intList.Select((key, val) => key).Reverse();

            var QuerySyntaxReverse = (from num in intList select num).Reverse();
            #endregion

            #region Average(): It is used to calculate the average of numeric values from the collection on which it is applied.

            var MethodSyntaxAvgValue = IntArray.Average();

            var QuerySyntaxAvgValue = (from num in IntArray select num).Average();
            #endregion

            #region Min(),  Max(): It returns the largest and smallest number in the list, respectively.

            var MethodSyntaxMax = intList.Max();
            var MethodSyntaxMin = intList.Min();

            var QuerySyntaxMax = (from num in intList select num).Max();
            var QuerySyntaxMin = (from num in intList select num).Min();
            #endregion

            #region Sum(): It is used to calculate the total or sum of numeric values in the collection.

            var MethodSyntaxSum = intList.Sum();

            var QuerySyntaxSum = (from num in intList select num).Sum();
            #endregion

            #region Skip(): It is used to skip or bypass the first n number of elements from a data source or sequence and then returns the remaining elements from the data source as output.

            var MethodSyntaxSkip = intList.Skip(4).ToList();

            var QuerySyntaxSkip = (from num in intList select num).Skip(4).ToList();
            #endregion

            #region SkipWhile(): It is used to skip all the elements from a data source or a sequence.

            var MethodSyntaxSkipWhile = intList.SkipWhile(num => num < 40).ToList();

            var QuerySyntaxSkipWhile = (from num in intList select num).SkipWhile(num => num < 40).ToList();
            #endregion

            #region Take(): It is used to fetch the first "n" number of elements from the data source, where "n" is an integer that is passed as a parameter to the LINQ Take method

            var MethodSyntaxTake = IntArray.Take(3).ToList();

            var QuerySyntaxTake = (from num in IntArray select num).Take(3).ToList();
            #endregion

            #region TakeWhile(): It is used to fetch all the elements from a data source or a sequence, or a collection until a specified condition is true.

            var MethodSyntaxTakeWhile = intList.TakeWhile(num => num < 40).ToList();

            var QuerySyntaxTakeWhile = (from num in intList select num).TakeWhile(num => num < 40).ToList();
            #endregion

            #region Concat(): It is used to concatenate two sequences into one sequence.

            var MethodSyntaxConcat = IntArray.Concat(IntArray2);

            var QuerySyntaxConcat = (from num in IntArray select num).Concat(IntArray2);
            #endregion

            #region Union(): It is used to combine multiple data sources into one data source by removing duplicate elements.

            var MethodSyntaxUnion = IntArray.Union(IntArray2);

            var QuerySyntaxUnion = (from num in IntArray select num).Union(IntArray2);
            #endregion

            #region Count(): It is used to return the number of elements present in the collection or the number of elements that have satisfied a given condition.

            var MethodSyntaxCount = IntArray.Count();

            var QuerySyntaxCount = (from num in IntArray select num).Count();
            #endregion

            #region Range(): It is used to Generate a sequence of integral(integer) numbers within a specified range.

            var MethodSyntaxRange = Enumerable.Range(1, 10);
            #endregion

            #region ToLookup(): It is used for grouping data based on key / value pair.

            var MethodSyntaxToLookup = Employee.GetAllEmployees().ToLookup(x => x.Department);

            var QuerySyntaxToLookup = (from emp in Employee.GetAllEmployees() select emp).ToLookup(x => x.Department);
            #endregion

            #region Intersect(): It is used to return the common elements from both collections.

            var MethodSyntaxIntersect = IntArray.Intersect(IntArray2).ToList();

            var QuerySyntaxIntersect = (from num in IntArray select num).Intersect(IntArray2).ToList();
            #endregion

            #region Except(): It is used to return the elements which are present in the first data source but not in the second data source.

            var MethodSyntaxExcept = IntArray.Except(IntArray2).ToList();

            var QuerySyntaxExcept = (from num in IntArray select num).Except(IntArray2).ToList();
            #endregion

            #region Repeat(): It is used to generate a sequence or a collection with a specified number of elements, and each element contains the same value.

            var MethodSyntaxRepeat = Enumerable.Repeat("Vishal Yelve", 5);
            #endregion

            #region  OfType(): It is used to filter specific type data from a data source based on the data type we passed to this operator.

            var MethodSyntaxOfType = data.OfType<string>().ToList();

            var QuerySyntaxOfType = (from emp in data.OfType<int>() select emp);
            #endregion

            #region GroupJoin(): It is used to produce hierarchical data structures.

            var groupJoinMethodSyntax = Employee.GetAllEmployees().GroupJoin(Employee.GetAllEmployees(),
                                dept => dept.ID, emp => emp.Salary, (dept, emp) => new { dept, emp });

            var GroupJoinQuerySyntax = (from dept in Employee.GetAllEmployees()
                                        join emp in Employee.GetAllEmployees() on dept.ID equals emp.Salary
                                        into EmployeeGroups
                                        select new { dept, EmployeeGroups });
            #endregion

            #region GroupBy(): allows us to organize elements of a collection into groups based on a specified key value

            var QuerySyntaxGroupBy = from number in IntArray group number by number % 2;

            var MethodSyntaxGroupBy = IntArray.GroupBy(number => number % 2);

            //Multiple keys

            //Using Method Syntax
            var GroupByMultipleKeysMS = Employee.GetAllEmployees()
                .GroupBy(x => new { x.Name, x.Salary })
                .Select(g => new
                {
                    Branch = g.Key.Name,
                    Gender = g.Key.Salary,
                    Students = g.OrderBy(x => x.Name)
                }); ;

            //Using Query Syntax
            var GroupByMultipleKeysQS = (from std in Employee.GetAllEmployees()
                                         group std by new
                                         {
                                             std.Name,
                                             std.Salary
                                         } into stdGroup
                                         select new
                                         {
                                             Branch = stdGroup.Key.Name,
                                             Gender = stdGroup.Key.Salary,
                                             //Sort the Students of Each group by Name in Ascending Order
                                             Students = stdGroup.OrderBy(x => x.Name)
                                         });

            #endregion

            #region Aggregate() method applies a function to all the elements of the source sequence and calculates a cumulative result that takes into account the return value of each function call.

            int resultAggregate = IntArray.Aggregate((sum, val) => sum + val);

            #endregion

            #region Prepend(): adds a single element to the beginning of a sequence.

            List<int> newnumberSequence = IntArray.Prepend(50).ToList();

            #endregion

            #region Append(): adds a single element to the end of an IEnumerable<T> sequence.
            List<int> newintSequence = IntArray.Append(5).ToList();
            #endregion


        }

    }
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> listEmployees = new List<Employee>()
            {
                new Employee{ID= 101,Name = "Pooja", Salary = 10000, Department = "IT"},
                new Employee{ID= 102,Name = "Priyanka", Salary = 15000, Department = "Sales"},
                new Employee{ID= 103,Name = "Manoj", Salary = 25000, Department = "Sales"},
                new Employee{ID= 104,Name = "Santosh", Salary = 20000, Department = "IT"},
                new Employee{ID= 105,Name = "Vishal", Salary = 30000, Department = "IT"},
                new Employee{ID= 106,Name = "Sandhya", Salary = 25000, Department = "IT"},
                new Employee{ID= 107,Name = "Mahesh", Salary = 35000, Department = "IT"},
                new Employee{ID= 108,Name = "Manoj", Salary = 11000, Department = "Sales"},
                new Employee{ID= 109,Name = "Pradeep", Salary = 20000, Department = "Sales"},
                new Employee{ID= 110,Name = "Saurav", Salary = 25000, Department = "Sales"}
            };
            return listEmployees;
        }

        internal static object Select(Func<object, object, object> value)
        {
            throw new NotImplementedException();
        }
    }
    public class dbContext
    {
        public List<Art> Art { get; set; }
        public List<Price> Price { get; set; }
    }
    public class Art
    {
        public int Id { get; set; }
        public string Estatus { get; set; }
        public string Descripcion { get; set; }
        internal IEnumerable<object> Join(Price price, Func<object, object> value1, Func<object, object> value2, Func<object, object, object> value3)
        {
            throw new NotImplementedException();
        }
    }
    public class Price
    {
        public int Id { get; set; }
        public int ArtId { get; set; }
    }
}
