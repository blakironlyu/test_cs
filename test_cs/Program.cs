using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

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

            Thermo thermo = new Thermo();
            Heater heater = new Heater(50);
            Cooler cooler = new Cooler( 40 );
            thermo.OnChangeTemp += heater.OnTempChange;
            thermo.OnChangeTemp += cooler.OnTempChange;

            thermo.CurTemp = 20;


            Console.ReadLine();
        }
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
            return new Entity( key );
        }
    }
    public class Entity
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public Entity( int key)
        {
            Key = key;
            Value = 0;
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
