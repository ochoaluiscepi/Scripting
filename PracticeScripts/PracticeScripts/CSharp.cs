using FluentAssertions.Common;
using PracticeScripts;
using System;
using System.Buffers.Text;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PracticeScripts.OOP
{

    #region OOP Principles
    /*
    Inheritance: With inheritance we can build new classes based on an existing class hierarchy

    Abstraction: Data Abstraction is the property by virtue of which only the essential details are exhibited to the user. 
    The trivial or the non-essentials units aren’t exhibited to the user.

    Encapsulation: Is defined as the wrapping up of data under a single unit. 
    It is the mechanism that binds together code and the data it manipulates. 
    Other way to think about encapsulation is, it is a protective shield that prevents the data from being accessed by the code outside this shield

    Polimorfism: The polimorfism refers to the ability for several classes derived from an ancestor to use the same method differently.
    */
    #endregion

    #region Coupling
    /*
     it refers to how related or dependent two classes/modules are toward each other. For low coupled classes, 
    changing something major in one class should not affect the other. High coupling would make it difficult to 
    change and maintain your code;

     */
    #endregion

    #region Cohesion
    /*
     Cohesion refers to what the class (or module) can do. Low cohesion would mean that the class does a great variety of actions - 
     it is broad, unfocused on what it should do. High cohesion means that the class is focused on what it should be doing,
     i.e. only methods
     */
    #endregion

    #region Value Type and Value Reference
    /*
    Value type stores the value in its memory space, whereas reference type stores the address of the value where it is stored.
    */
    #endregion

    #region DI -> Dependency Injection
    /*
    A dependency is any object that another object requires
    */
    public class ExampleDI
    {
        public ExampleDI(dbContext _MyDependenciInjection)
        {
            dbContext MyDependenciInjection = _MyDependenciInjection;
        }
    }

    #endregion

    #region Stack and Heap
    /*
    Stack:is used for static memory allocation(local variables)
    Heap:is used for dynamic memory allocation(instances of classes)
    */

    public class StackAndHEap
    {
        //Stack: 
        int numToSave = 10;
        //Heap:
        dbContext _db = new dbContext();
    }


    #endregion

    #region DataContext
    /*
    Its a linq class that keeps the connection between the object and the database
    */
    public class dbContextExample : IDisposable
    {
        dbContext _db;
        public dbContextExample(dbContext ctx)
        {
            _db = ctx;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region Middleware
    /*
     A middleware is nothing but a component (class) which is executed on every request in ASP.NET Core application. 
     In the classic ASP.NET, HttpHandlers and HttpModules were part of request pipeline. Middleware is similar to 
     HttpHandlers and HttpModules where both needs to be configured and executed in each request
     */
    #endregion

    #region Class
    /*
    A class is the abstract definition of an object, in it we can have events, methods and attributes
    */

    public class classExample
    {
        //Constructor
        public classExample()
        {

        }
    }

    #endregion

    #region Object
    /*
     An Object is the reference of a class
    */
    public class createObject
    {
        classExample obj = new classExample();
    }

    #endregion

    #region Overload and Override
    /*
     Overload: we can make a funtion method with the same name but with different parameters.
     Override:  we can rewrite a function but with different functionalities
    */
    public class PolimorfismExample
    {
        public int OverrideExample()
        {
            return 0;
        }
    }
    public class PolimorfismDerivedExample : PolimorfismExample
    {
        //Override
        public int OverrideExample()
        {
            return 10;
        }
        //Overload
        public int OverrideExample(int number)
        {
            return number;
        }

    }

    #endregion

    #region Reflection
    /*
      Reflection provides objects (of type Type) that describe assemblies, modules and types
     */
    public class ReflexionExample
    {
        public ReflexionExample()
        {
            var getObjectType = "Hello world";
            Type studentNameType = getObjectType.GetType();
            //Console.WriteLine("Type is: " + studentNameType);
            //Output: Type is: System.String
        }

    }



    #endregion

    #region Generics
    /*
     Generic we can build classes, methods, struchtures of data without a type of values. 
     */
    public class GenericClass<T>
    {
        public T Data { get; set; }
    }
    //Constraint in Generics
    //Constraints inform the compiler about the capabilities a type argument must have. Without any constraints, the type argument could be any type. 
    public class GenericList<T> where T : Employee
    {

    }
    #endregion

    #region Namespace
    //Namespaces are used in C# to organize and provide a level of separation of codes.
    #endregion

    #region Interface
    //An interface contains only the signatures of methods, properties, events or indexers
    public interface IMyInterface
    {
        public int MyExampleImplement();
    }
    public class ImplementingInterface() : IMyInterface
    {
        public int MyExampleImplement()
        {
            return 0;
        }
    }
    #endregion

    #region AbstractClass
    //We can't create instances of an abstract class. his purpose is give us a definition of a base class that several derived classes can share

    public abstract class AbstractClassExample
    {
        public int functionExample() { return 0; }
    }

    public class AbstractDerivedClass : AbstractClassExample
    {
        public int functionExample() { return 10; }
    }



    #endregion

    #region StaticClass
    //static class is a class that can't be instantiated. The sole purpose of the class is to provide blueprints of its inherited classes.
    public static class BluePrints
    {
        public static float PI = 3.14f;
        public static int cube(int n) { return n * n * n; }
    }
    public class BluePrintsDerivedClass
    {
        float piValue = BluePrints.PI;
        float cubeValue = BluePrints.cube(3);
    }


    #endregion

    #region Struct VS Class
    //struct it is kind for value and class is kind for reference

    struct Coordinate
    {
        public int x;
        public int y;
    }
    public class callingStruct
    {
        Coordinate point = new Coordinate();
    }




    #endregion

    #region Sealed Class
    //A sealed class cannot be used as a base class. For this reason, it cannot also be an abstract class. Sealed classes prevent derivation. Because they can never be used as a base class.
    public sealed class lastLevelEmployee : Employee
    {
    }
    //this is not possible
    //public class derivedFromSealedClass: lastLevelEmployee{ }


    #endregion

    #region Extension Methods
    //The extension methods on C# allow to create new methods to a objects like type string or int
    public static class ExtensionMethodExample
    {
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }
    }
    public class CallingAnExtendionMethod
    {
        public bool testExtencion(int valExtension = 0)
        {
            return valExtension.IsGreaterThan(5);
        }
    }
    #endregion

    #region Delegates
    /*
     The delegate is a reference type data type that defines the method signature. You can define variables of delegate, 
     just like other data type, that can refer to any method with the same signature as the delegate. 
     */

    public class DelegatesExamples
    {
        public delegate void Callback(string message);
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public void CallingDelegate()
        {
            Callback handler = DelegateMethod;
            // Call the delegate.
            handler("Hello World");
        }

    }
    #endregion

    #region Async and Await
    /*
     Sync: In synchronous programming, the execution flow is sequential, and methods must complete before the next one can start

     Async: In asynchronous programming, the await keyword allows the execution to yield control, enabling the program to continue without waiting for the async method to complete.

     Task: The Task class represents an asynchronous operation, which can be awaited using the await keyword. The Task-Based Asynchronous Pattern (TAP) is a standard pattern that promotes writing asynchronous code using Task and Task<TResult> objects.
      
     Threads: C# threading allows developers to create multiple threads
     */

    public class SyncAndAsync
    {
        // Synchronous method
        public int CalculateSum(int a, int b)
        {
            return a + b;
        }

        // Asynchronous method
        public async Task<int> CalculateSumAsync(int a, int b)
        {
            return await Task.Run(() => a + b);
        }
    }

    public class ThreadsExample
    {
        public void Starting()
        {
            // Main thread starts here.
            // Thread
            Thread backgroundThread = new Thread(new ThreadStart(ThreadsExample.DoSomeHeavyLifting));
            // Start thread
            backgroundThread.Start();

            // This method doesn't take anytime at all.
            ThreadsExample.DoSomething();
        }
        public static void DoSomeHeavyLifting()
        {
            Console.WriteLine("I'm lifting a truck!!");
            Thread.Sleep(1000);
            Console.WriteLine("Tired! Need a 1 sec nap.");
            Thread.Sleep(1000);
            Console.WriteLine("I'm awake.");
        }
        public static void DoSomething()
        {
            Console.WriteLine("Hey! DoSomething here!");
            for (int i = 0; i < 20; i++)
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine("I'm done.");
        }
    }


    #endregion

    #region Is and As
    /*
     “is” expression **is** type ? (type)expression : (type)null  

     “as” operator is like a cast operation. However, if the conversion isn't possible, as returns null instead of raising an exception. 
     */

    public class IsAndAsExample
    {
        public bool isExample()
        {
            string valueTesting = "Hello world!";

            if (valueTesting is string)
                return true;
            else
                return false;

        }
        public string? AsExample()
        {
            string valueTesting = "Hello world!";
            return valueTesting as string;
        }
    }

    #endregion

    #region IEnumerable
    //IEnumerable is an interface defining a single method GetEnumerator()
    public class EnumerableEcample
    {
        public IEnumerator Enumerate(IEnumerable enumerable)
        {
            // List implements IEnumerable, but could be any collection.
            List<string> list = new List<string>();

            foreach (string value in enumerable)
            {
                list.Add(value + "roxxors");
            }
            return list.GetEnumerator();
        }
    }

    #endregion

    #region Dictionary
    //is a collection of Keys and Values, where key is like word and value is like definition
    public class DictionaryExample
    {
        public Dictionary<int, string> Listing()
        {
            Dictionary<int, string> Names = new Dictionary<int, string>();
            Names.Add(1, "Luis");
            Names.Add(2, "Ochoa");

            return Names;
        }
    }


    #endregion

    #region HashTable
    //Represents a collection of key/value pairs that are organized based on the hash code of the key
    public class HashTableExample
    {
        public Hashtable hasExample()
        {
            Hashtable numberNames = new Hashtable();
            numberNames.Add(1, "One"); //adding a key/value using the Add() method
            numberNames.Add(2, "Two");

            return numberNames;
        }
    }
    #endregion

    #region Array
    //Arrays are strongly-typed collections of the same data type and have a fixed length that cannot be changed during runtime.
    public class arrayExample
    {
        public int[] arrValues()
        {
            // Declare a single-dimensional array of 5 integers.
            int[] array1 = new int[5];

            // Declare and set array element values.
            int[] array2 = [1, 2, 3, 4, 5, 6];

            // Declare a two dimensional array.
            int[,] multiDimensionalArray1 = new int[2, 3];

            // Declare and set array element values.
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Declare a jagged array.
            int[][] jaggedArray = new int[6][];

            // Set the values of the first array in the jagged array structure.
            jaggedArray[0] = [1, 2, 3, 4];

            return array1;
        }
    }

    #endregion

    #region ArrayList
    /*
     Array list is not a strongly-typed collection. It can store the values of different data types or same datatype. 
     The size of an array list increases or decreases dynamically so it can take any size of values from any data type 
     */
    public class arrayListExample
    {
        public ArrayList arrValues()
        {
            ArrayList arrlist = new ArrayList();
            arrlist.Add(1);
            arrlist.Add("Hello");
            arrlist.Add(true);

            return arrlist;
        }
    }
    #endregion

    #region ConcurrentDictionary
    /*
     Represents a thread-safe collection of key/value pairs that can be accessed by multiple threads concurrently. 
     */
    public class ConcurrentDictionaryExample
    {
        public ConcurrentDictionary<int, int> concurrentDictionaryValues()
        {
            int NUMITEMS = 64;
            int initialCapacity = 101;

            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            // Construct the dictionary with the desired concurrencyLevel and initialCapacity
            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);

            // Initialize the dictionary
            for (int i = 0; i < NUMITEMS; i++) cd[i] = i * i;

            return cd;
        }
    }
    #endregion

    #region Using
    //Is the fastest way of create and destroy an objetc, where only will be available inside of the using.
    public class UsingExample
    {
        public void usingExample()
        {
            //using (dbContext emp = new dbContext())
            //{
            //do something
            //}
        }
    }
    #endregion

    #region Exceptions (try,catch,finally, throw)
    //Exceptions provide a way to transfer control from one part of a program to another.
    //C# exception handling is built upon four keywords: try, catch, finally, and throw
    public class ExceptionsExample
    {
        public void ExceptionsFunctionExample()
        {
            try
            {
                //Operations
            }
            catch (Exception e)
            {
                throw new Exception("Error:" + e.Message);
            }
            finally
            {
                //Code execute always
            }
        }
    }
    #endregion

    #region Anonimous Types
    /*
     Is a type that doesn't have any name. C# allows you to create an object with the new keyword without defining its class. 
    An anonymous type is a temporary data type that is inferred based on the data that you include in an object initializer.
     */
    public class AnonimousTypesExample
    {
        public object Example()
        {
            return new { Id = 1, FirstName = "James", LastName = "Bond" };
        }
    }


    #endregion

    #region Ref and Out
    /*
     Ref: The ref keyword passes arguments by reference. It means any changes made to this argument in the method will be 
          reflected in that variable when control returns to the calling method.

     Out: passes arguments by reference.This is very similar to the ref keyword It is not compulsory to initialize a parameter 
          or argument before it is passed to an out.
     */

    public class RefAndOutExample
    {
        public object ExampleRef(ref int id)
        {
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }
        public object ExampleOut(out int id)
        {
            id = 1;
            string returnText = "Next-" + id.ToString();
            id += 1;
            return returnText;
        }
    }



    #endregion

    #region Nullable Type
    /*
     A nullable value type T? represents all values of its underlying value type T and an additional null value. For example, 
     you can assign any of the following three values to a bool? variable: true, false, or null. An underlying value type T 
     cannot be a nullable value type itself. 
     */
    public class NullableTypeExample
    {
        public void Example()
        {
            int? numberOrNull = null;
            string? text = null;
            bool? Truth = null;
            double? pi = 3.14;
            char? letter = 'a';
            int?[] arr = new int?[10];
        }
    }

    #endregion

    #region Parallel
    /*
     The Parallel class provides library-based data parallel replacements for common operations
     such as for loops, for each loops, and execution of a set of statements. 
     using System.Threading.Tasks; 
     */
    public class ParallelExample
    {
        static int N = 1000;
        public void Example()
        {
            // Using a named method.
            Parallel.For(0, N, Method2);

            // Using an anonymous method.
            Parallel.For(0, N, delegate (int i)
            {
                // Do Work.
            });

            // Using a lambda expression.
            Parallel.For(0, N, i =>
            {
                // Do Work.
            });
        }
        static void Method2(int i)
        {
            // Do work.
        }
    }
    #endregion

    #region Dynamic Types
    //dynamic avoids compile-time type checking. A dynamic type escapes type checking at compile-time; instead, it resolves type at run time.
    public class DynamicTypesExample
    {
        public void Example()
        {
            dynamic MyDynamicVar = 1;
            Console.WriteLine(MyDynamicVar.GetType());
            //Result System.int32
        }
    }

    #endregion

    #region Enum
    /*
     In C#, an enum (or enumeration type) is used to assign constant names to a group of numeric integer values. 
     It makes constant values more readable, for example, WeekDays.Monday is more readable then number 0 when 
     referring to the day in a week. 
     */
    public class EnumExample
    {
        public void Example()
        {
            Console.WriteLine(WeekDays.Monday);
            //Result: Monday
            Console.WriteLine((int)WeekDaysValue.Monday);
            //Result: 1
        }
        enum WeekDays
        {
            Monday,
            Tuesday,
            Wednesday
        }
        enum WeekDaysValue
        {
            Monday = 1,
            Tuesday = 2,
            Wednesda = 3
        }
    }
    #endregion

    #region Var
    /*
      By declaring a local variable, you can allow the compiler to infer the type of the variable from the initialization expression.
      To do this, use the var keyword instead of a type name.
     */
    public class VarExample
    {
        public void Example()
        {
            var greeting = "Hello";
            var a = 32;
            var xs = new List<double>();
        }
    }
    #endregion

    #region IDisposable
    /*
     The primary use of this interface is to release unmanaged resources. The garbage collector automatically releases the memory
     allocated to a managed object when that object is no longer used.  
     */
    #endregion

    #region Lambda
    //Lambda expression is a syntax to create delegates or expression trees
    //x => x * x

    //Expression Lambda 
    //(input-parameters) => expression

    //Instruction Lambda
    //(input-parameters) => { <sequence-of-statements> }
    public class LambdaExample
    {
        public void Example()
        {

            int[] numbers = { 2, 3, 4, 5 };
            var squaredNumbers = numbers.Select(x => x * x);

            //one parameter
            Func<double, double> cube = x => x * x * x;

            //two parameter
            Func<int, int, bool> testForEquality = (x, y) => x == y;

            //Instruction Lambda
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };
            greet("World");
        }
    }
    #endregion

    #region Yield
    //use the yield statement in an iterator to provide the next value or indicate the end of the iteration
    public class YieldExample
    {
        public void Example()
        {
            Console.WriteLine(string.Join(" ", TakeWhilePositive([2, 3, 4, 5, -1, 3, 4])));
            // Output: 2 3 4 5

            Console.WriteLine(string.Join(" ", TakeWhilePositive([9, 8, 7])));
            // Output: 9 8 7

            IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers)
            {
                foreach (int n in numbers)
                {
                    if (n > 0)
                    {
                        yield return n;
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
        }

    }
    #endregion

    #region Attributes
    /*
     Attributes are used for adding metadata, such as compiler instruction and other information such as comments, description, 
     methods and classes to a program 
     */

    #endregion

    #region Modifiers
    /*
     Public: Public access is the most permissive access level. There are no restrictions on accessing public members

     Private: Are accessible only within the body of the class or the struct in which they are declared

     Protected: A protected member is accessible within its class and by derived class instances.

     Internal: Are accessible only within files in the same assembly

     Protected internal: Cualquier código del ensamblado en el que se ha declarado, o desde cualquier clase derivada de otro ensamblado, puede acceder al tipo o miembro.
     
    Private protected: El código de la misma clase, o de un tipo derivado de esa clase, puede acceder al tipo o miembro solo dentro de su ensamblado que declara. 
     */

    public class ModifiersExample
    {
        public int example = 0;
        private int example2 = 0;
        protected int example3 = 0;
        internal int example4 = 0;

        public void Example()
        {

            
        }
    }

    #endregion

    #region ReadOnly

    //It indicates that the assignment to the fields is only the part of the declaration or in a constructor to the same class. 

    public class ReadOnlyExample
    {
        private readonly int _year;
        ReadOnlyExample(int year)
        {
            _year = year;
        }
        void ChangeYear()
        {
            //_year = 1967; // Compile error if uncommented.
        }
    }
    #endregion

    #region JWT Token

    //What are the main authentication schemes in .NET Core?

    //Cookie-Based Auth - Traditional method(e.g., ASP.NET Identity).
    //Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

    //JWT(Bearer Token) - Stateless, used for APIs.
    //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => { /* Configure JWT */ });

    //OAuth/OpenID Connect - Delegated auth(e.g., Google, Facebook).
    //services.AddAuthentication().AddGoogle(options => { /* ClientId/Secret */ });

    //How does JWT Authentication work in .NET Core?

    //Client sends credentials(e.g., username/password).
    //Server validates credentials → issues JWT.
    //Client includes JWT in Authorization: Bearer<token> header.
    //Server validates JWT signature, issuer, and expiry.

    // Code
    /*Example:
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = "YourIssuer",
            ValidateAudience = true,
            ValidAudience = "YourAudience",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey"))
        };
    });
    */
    #endregion


    internal class CSharp
    {
    }
}
