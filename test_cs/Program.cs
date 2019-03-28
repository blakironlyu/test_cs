using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections;
using System.IO;

namespace test_cs {
    class Program {
        static void Main( string[] args ) {
            //EntityDictionary<int, Entity, Factory> ed = new EntityDictionary<int, Entity, Factory>();
            //Entity entity = ed.NewValue( 10 );
            //Entity entity2 = ed.NewValue( 20 );

            //foreach(int i in ed.Keys )
            //{
            //    Entity e;
            //    ed.TryGetValue( i, out e );
            //    Console.WriteLine( "{0} {1}", e.Key, e.Value );
            //}

            //Func<int, int> func = (x) => { return x; };
            //Action<int> action = (x) => Console.WriteLine(x);
            //action( func( 10 ) );

            //ICompareThings<Fruit> fc = new FruitCompare();
            //Apple a1 = new Apple();
            //Apple a2 = new Apple();
            //Orange o1 = new Orange();
            //Fruit f1 = new Fruit();
            //Fruit f2 = new Fruit();
            //fc.FirstIsBetter( a1, a2 );
            //fc.FirstIsBetter( a1, o1 );
            //fc.FirstIsBetter( f1, f2 );
            //ICompareThings<Apple> ac = fc;
            //ac.FirstIsBetter( a1, a2 );
            ////ac.FirstIsBetter( a1, f1 );
            //ac = new FruitCompare();
            ////fc = ac;
            //Func<string, int> f = ( s ) => s.CompareTo( "haha" );
            //Action<string> a = ( s ) => Console.WriteLine( s );
            //Action<object> o = ( ob ) => Console.WriteLine( "obj" );
            //a = o;
            //a( 10 );

            //Expression<Func<string, int>> exp = ( s ) => s.CompareTo( "" );
            //Console.WriteLine( exp );

            //Thermo thermo = new Thermo();
            //Heater heater = new Heater(50);
            //Cooler cooler = new Cooler( 40 );
            //thermo.OnChangeTemp += heater.OnTempChange;
            //thermo.OnChangeTemp += cooler.OnTempChange;

            //thermo.CurTemp = 20;

            //var test = new
            //{
            //    one = "haha",
            //    two = "1234"
            //};

            //int[] arr = new int[] { 1,2,3,4,5};
            //IEnumerable<Heater> e = new Heater[] { new Heater(10), new Heater(20), new Heater(30), new Heater(40), new Heater(50) };
            //e = e.Where( i => i.Temp > 20 );
            //IEnumerable<string> s = e.Select( heater => string.Format("{0}", heater.Temp) );

            //foreach(string i in s)
            //{
            //    Console.WriteLine( i );
            //}

            //IEnumerable<int> items = new int[]{ 5,1,3,2,4 };
            //IEnumerable<int> items2 = items.OrderBy( i => i );

            //foreach( int j in items2)
            //{
            //    Console.WriteLine( j );
            //}
            //Console.WriteLine( "line: {0}", items.Count() );

            //Entity[] eList = { new Entity( 3, 5 ), new Entity( 1, 1 ), new Entity( 1,2 ), new Entity( 4, 2 ), new Entity( 1, 3 ) };
            //IEnumerable<Entity> eList2 = eList.OrderBy( entity => entity.Key ).ThenBy( entity => entity.Value );

            //foreach( Entity e in eList2 )
            //{
            //    Console.WriteLine( "{0} {1}", e.Key, e.Value );
            //}
            Employee[] emp = { new Employee( "name1", 1 ), new Employee( "name2", 1 ), new Employee( "name3", 2 ), new Employee( "name4", 2 ), new Employee( "name5", 3 ) };
            Department[] depart = { new Department( 1, "one" ), new Department( 2, "two" ), new Department( 3, "three" ) };

            //var data = emp.Join( depart, employee => employee.DepartNum, department => department.DepartNum, ( employee, department ) => new { employee.Name, department.DepartName } );
            //data = data.OrderBy( d => d.DepartName );
            //foreach( var d in data )
            //{
            //    Console.WriteLine( "{0} {1}", d.Name, d.DepartName );
            //}

            //IEnumerable<IGrouping<int, Employee>> group = emp.GroupBy( e => e.DepartNum );

            //foreach( IGrouping<int, Employee> g in group)
            //{
            //    Console.WriteLine("{0} {1}",g.Count(),g.Key );
            //}

            //var groupJoin = depart.GroupJoin( emp, d => d.DepartNum, e => e.DepartNum, ( d, e ) => new { d.DepartNum, d.DepartName, Employees = e } );

            //foreach( var group in groupJoin)
            //{
            //    Console.WriteLine( "{0} {1}", group.DepartNum, group.DepartName );
            //    foreach( Employee e in group.Employees )
            //    {
            //        Console.WriteLine( "\t{0}", e.Name );
            //    }
            //}

            var arr = new[] { new { Name="group1", Member=new string[] { "one", "two"} }, new { Name = "group2", Member = new string[] { "three", "four" } } };
            ////IEnumerable<string> sarr = arr.SelectMany( a => a.Member );
            //IEnumerable<char> sarr = emp.SelectMany( e => e.Name );

            //foreach( char s in sarr )
            //{
            //    Console.WriteLine( s );
            //}
            //int[] arr1 = new int[] { 1, 2, 3, 4, 5 };
            //IEnumerable<int> arr2 =
            //    from i in arr1
            //    where i < 5
            //    select i
            //    into j
            //        where j > 1
            //        select j;

            IEnumerable<string> name = ( from m in typeof( Enumerable ).GetMembers( System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public )
                         let n = m.Name
                         orderby n
                         select n ).Distinct();
            foreach(string i in name )
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }

    class Employee
    {
        static Employee()
        {
            EmpCount = 1;
        }
        public Employee(string name, int departNum)
        {
            EmpNum = EmpCount++;
            Name = name;
            DepartNum = departNum;
        }
        public static int EmpCount;

        public int EmpNum;
        public string Name;
        public int DepartNum;
    }

    class Department
    {
        public Department(int num, string name)
        {
            DepartNum = num;
            DepartName = name;
        }
        public int DepartNum;
        public string DepartName;
    }

    class Heater
    {
        public Heater( int temp )
        {
            Temp = temp;
        }
        public int Temp { get; set; }
        public void OnTempChange( int newTemp )
        {
            if( Temp > newTemp )
            {
                Console.WriteLine( "Heater: ON" );
            }
            else
            {
                Console.WriteLine( "Heater: OFF" );
            }
        }

        public override string ToString()
        {
            return string.Format( "Heater - Temp: {0}", Temp );
        }
    }
    class Cooler
    {
        public Cooler( int temp )
        {
            Temp = temp;
        }
        public int Temp { get; set; }
        public void OnTempChange( int newTemp )
        {
            if( Temp < newTemp )
            {
                Console.WriteLine( "Cooler: ON" );
            }
            else
            {
                Console.WriteLine( "Cooler: OFF" );
            }
        }
    }
    public class Thermo
    {
        class TempArgs : EventArgs
        {
            public int Temp { get; set; }
             public TempArgs(int temp)
            {
                Temp = temp;
                
            }
        }
        public Thermo()
        {
            CurTemp = 0;
        }

        public delegate void TempHandler( int temp );
        public event TempHandler OnChangeTemp = delegate { };

        public int CurTemp {
            get
            {
                return _CurTemp;
            }
            set
            {
                if( value != _CurTemp )
                {
                    _CurTemp = value;
                    if( OnChangeTemp != null )
                    {
                        OnChangeTemp( value );
                    }
                }
            }
        }
        private int _CurTemp;
    }

    class Fruit { };
    class Apple : Fruit {
        public string name { get; set; }
    };
    class Orange : Fruit { };
    interface ICompareThings<in T>
    {
        bool FirstIsBetter( T t1, T t2 );
    }
    class FruitCompare : ICompareThings<Fruit>
    {
        public bool FirstIsBetter( Fruit t1, Fruit t2 )
        {
            return true;
        }
    }

    public interface IFactory<Tkey, Tvalue>
    {
        Tvalue Create( Tkey key );
    }

    public class Factory : IFactory<int, Entity>
    {
        public Entity Create( int key )
        {
            return new Entity( key, 0 );
        }
    }
    public class Entity
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public Entity( int key, int value )
        {
            Key = key;
            Value = value;
        }
    }

    public class EntityDictionary< TKey, TValue, TFactory> : Dictionary<TKey, TValue>
        where TKey : IComparable<TKey>
        where TValue : Entity
        where TFactory : IFactory<TKey, TValue>, new()
    {
        private TFactory factory;

        public EntityDictionary()
        {
            factory = new TFactory();
        }
        public TValue NewValue( TKey key )
        {
            TValue value = factory.Create( key );
            Add( key, value );
            return value;
        }
    }

    public enum EnumTest
    {
        one, 
        two, 
        three
    }

    public struct StructTest
    {
        public StructTest(int i)
        {
            I = 1;
            S = "string";
            B = false;
        }
        public StructTest(int i, string s, bool b) 
        {
            I = 10;
            S = s;
            B = b;
        }

        public int I;
        public string S;
        public bool B;
    }

     static class StringTest
    {
        public static string Test(this IInter2 a)
        {
            return a.I + "10";
        }
    }
    class A<T> : IInter2
        where T: struct
    {
        private int a;
        public T Tvalue;

        public int I { get; set; }
        
        public virtual int V()
        {
            return 1;
        }

        public void Inter()
        {
            Console.WriteLine( "inter A" );
        }

        void IInter2.Inter2()
        {
            Console.WriteLine( "inter2 A" );
        }

        public A()
        {
            Console.WriteLine( "A" );
        }
    }
    class B : IInter3, IInter
    {
        public int b;
        public B() : base()
        {
            Console.WriteLine( "B" );
        }

        public int I { get; set; }

        public void Inter()
        {
            throw new NotImplementedException();
        }

        public void Inter3()
        {
            Console.WriteLine( "B Inter" );
        }

        public new virtual int V()
        {
            return 2;
        }

    }

    //class C : B
    //{
    //    public override int V()
    //    {
    //        return 3;
    //    }

    //}

    interface IInter
    {
        void Inter();
        int I { get; set; }
    }

    interface IInter2 : IInter
    {
        void Inter2();
    }
    interface IInter3
    {
        void Inter3();
    }
    class Employer
    {
        static Employer()
        {
            NextId = 10;   
        }
        public Employer()
        {
            FirstName = "NoName";
            LastName = "LastName";
            Title = "생성자";
            Id = NextId;
        }
        public Employer( string f, string l )
        {
            FirstName = f;
            LastName = l;
            Title = "2";
            Id = NextId;
        }

        public Employer( string f, string l, string title) : this( f, l) {
            Title = "3";
        }

        public string FirstName {
            get
            {
                return _FirstName;
            }
            private set
            {
                _FirstName = value;
            }
        }
        private string _FirstName = "first";

        public string LastName { get; set; }

        public string Name
        {
            get
            {
                return string.Format( "{0} {1}", FirstName, LastName );
            }
            set
            {
                string[] name = value.Split(new char[] {' '});
                if( name.Length == 2 )
                {
                    FirstName = name[0];
                    LastName = name[1];
                }
                else
                {
                    Console.WriteLine( "이름 부족" );
                }
            }
        }

        public string Title { get; set; }
        public string Salary { get; set; }
        public int Id { get; private set; }

        public static int NextId
        {
            get
            {
                return _NextId++;
            }
            set
            {
                _NextId = value;
            }
        }
        private static int _NextId;
    }

}
