using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            //part 1
            Console.WriteLine("Part 1:");
            BadPupil bp = new BadPupil();
            GoodPupil gp = new GoodPupil();
            ExcelentPupil ep = new ExcelentPupil();
            Pupil p = new Pupil();

            ClassRoom test1 = new ClassRoom(p, bp, gp, ep);
            Console.WriteLine("Test 1:");
            test1.Print();

            ClassRoom test2 = new ClassRoom(bp, gp, ep);
            Console.WriteLine("\nTest 2:");
            test2.Print();

            ClassRoom test3 = new ClassRoom(bp, ep);
            Console.WriteLine("\nTest 3:");
            test3.Print();

            //part2
            Console.WriteLine("\nPart 2:");
            Vehicle v = new Vehicle(10, 25, 5000, 365, 1998);
            Console.WriteLine($"Vehicle: \n{v.ToString()}");

            Plane p1 = new Plane(v, 1000, 300);
            Console.WriteLine($"Plane 1: \n{p1.ToString()}");

            Plane p2 = new Plane(10, 25, 10000, 1000000, 6000, 2001, 200);
            Console.WriteLine($"Plane 2: \n{p2.ToString()}");

            Ship sh = new Ship(50, 35, 7500, 380, 2020, 35, "Taruga");
            Console.WriteLine($"Ship: \n{sh.ToString()}");

            Car cr = new Car(v);
            Console.WriteLine($"Car: \n{cr.ToString()}");

            //part3
            Console.WriteLine("\nPart 3:");

            string key;
            Console.WriteLine("Enter key:");
            key = Console.ReadLine();

            DocumentWorker dw = new DocumentWorker();

            if (key == "pro")
            {
                dw = new ProDocumentWorker();
            }
            else if (key == "exp")
            {
                dw = new ExpertDocumentWorker();
            }
            Console.Write($"OpenDocument: ");
            dw.OpenDocument();
            Console.Write($"\nEditDocument: ");
            dw.EditDocument();
            Console.Write($"\nSaveDocument: ");
            dw.SaveDocument();

            Console.Read();
        }
    }

    //part 1
    public class Pupil
    {
        public virtual void Study() { Console.Write("Defolt"); }
        public virtual void Read() { Console.Write("Defolt"); }
        public virtual void Write() { Console.Write("Defolt"); }
        public virtual void Relax() { Console.Write("Defolt"); }
    }

    public class ExcelentPupil : Pupil
    {
        public override void Study() { Console.Write("Very good"); }
        public override void Read() { Console.Write("Very fast"); }
        public override void Write() { Console.Write("Very clear"); }
        public override void Relax() { Console.Write("NEVER"); }
    }
    public class GoodPupil : Pupil
    {
        public override void Study() { Console.Write("Good"); }
        public override void Read() { Console.Write("Normaly"); }
        public override void Write() { Console.Write("Readable"); }
        public override void Relax() { Console.Write("Usually"); }
    }

    public class BadPupil : Pupil
    {
        public override void Study() { Console.Write("Bad"); }
        public override void Read() { Console.Write("Slow"); }
        public override void Write() { Console.Write("[Censored]"); }
        public override void Relax() { Console.Write("Constant Chill"); }
    }

    public class ClassRoom
    {
        Pupil[] _pupils;

        public ClassRoom(Pupil p1, Pupil p2)
        {
            _pupils = new Pupil[2] { p1, p2 };
        }
        public ClassRoom(Pupil p1, Pupil p2, Pupil p3)
        {
            _pupils = new Pupil[3] { p1, p2, p3 };
        }

        public ClassRoom(Pupil p1, Pupil p2, Pupil p3, Pupil p4)
        {
            _pupils = new Pupil[4] { p1, p2, p3, p4 };
        }

        public void Study() {
            Console.WriteLine("Pupils studing is :");
            for (int i = 0; i < _pupils.Length; ++i)
            {
                Console.Write($"  {i}) ");
                _pupils[i].Study();
            }
            Console.WriteLine();
        }
        public void Read()
        {
            Console.WriteLine("Pupils reading is :");
            for (int i = 0; i < _pupils.Length; ++i)
            {
                Console.Write($"  {i}) ");
                _pupils[i].Read();
            }
            Console.WriteLine();
        }
        public void Write()
        {
            Console.WriteLine("Pupils writing is :");
            for (int i = 0; i < _pupils.Length; ++i)
            {
                Console.Write($"  {i}) ");
                _pupils[i].Write();
            }
            Console.WriteLine();
        }
        public void Relax()
        {
            Console.WriteLine("Pupils relaxing is :");
            for (int i = 0; i < _pupils.Length; ++i)
            {
                Console.Write($"  {i}) ");
                _pupils[i].Relax();
            }
            Console.WriteLine();
        }

        public void Print()
        {
            this.Study(); this.Read(); this.Write(); this.Relax();
        }
    }

    //part2
    public class Vehicle
    {
        protected float _x, _y, _coast, _speed;
        protected int _year_of_craft;

        public Vehicle(float x, float y, float coast, float speed, int year_of_craft)
        {
            _x = x;
            _y = y;
            _coast = coast;
            _speed = speed;
            _year_of_craft = year_of_craft;
        }

        public Vehicle(Vehicle v)
        {
            _x = v._x;
            _y = v._y;
            _coast = v._coast;
            _speed = v._speed;
            _year_of_craft = v._year_of_craft;
        }

        public override string ToString()
        {
            return $"   Coordinats: {_x}; {_y}\n" +
                   $"   Coast: {_coast}\n" +
                   $"   Speed: {_speed}\n" +
                   $"   Made in {_year_of_craft}\n";
        }
    }

    public class Plane : Vehicle
    {
        float _hight;
        int _passagers;

        public Plane(float x, float y, float h, float coast, float speed, int year_of_craft, int passagers)
            : base(x, y, coast, speed, year_of_craft)
        {
            _hight = h;
            _passagers = passagers;
        }

        public Plane(Vehicle v, float h, int passagers)
            : base(v)
        {
            _hight = h;
            _passagers = passagers;
        }

        public override string ToString()
        {
            return $"   Coordinats: {_x}; {_y}; {_hight}\n" +
                   $"   Coast: {_coast}\n" +
                   $"   Speed: {_speed}\n" +
                   $"   Made in {_year_of_craft}\n" +
                   $"   Passgers: {_passagers}";
        }
    }

    public class Ship : Vehicle
    {
        int _passagers;
        string _port;

        public Ship(float x, float y, float coast, float speed, int year_of_craft, int passagers, string port)
            : base(x, y, coast, speed, year_of_craft)
        {
            _port = port;
            _passagers = passagers;
        }
        public Ship(Vehicle v, int passagers, string port)
            : base(v)
        {
            _port = port;
            _passagers = passagers;
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                   $"   Passgers: {_passagers}\n" +
                   $"   Port: {_port}";
        }
    }

    public class Car : Vehicle
    {
        public Car(float x, float y, float coast, float speed, int year_of_craft)
            : base(x, y, coast, speed, year_of_craft) { }

        public Car(Vehicle v)
            : base(v) { }
    }

    //part 3
    public class DocumentWorker
    {
        public virtual void OpenDocument() { Console.Write("Документ открыт"); }
        public virtual void EditDocument() { Console.Write("Редактирование документа доступно в версии Pro"); }
        public virtual void SaveDocument() { Console.Write("Сохранение документа доступно в версии"); }
    }

    public class ProDocumentWorker : DocumentWorker
    {
        public override void EditDocument() { Console.Write("Документ отредактирован"); }
        public override void SaveDocument() { Console.Write("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert"); }
    }

    public class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument() { Console.Write("Документ сохранен в новом формате"); }
    }
}
