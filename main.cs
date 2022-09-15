using System;
using System.Collections.Generic;
using System.Linq;
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

            Console.Read();
        }
    }

    //part 1
    public class Pupil
    {
        /*string _study, _read, _write, _relax;

        public Pupil(string stud, string read, string writ, string relx)
        {
            _study = stud;
            _read = read;
            _write = writ;
            _relax = relx;
        }*/
        public virtual void Study() { }
        public virtual void Read() { }
        public virtual void Write() { }
        public virtual void Relax() { }
    }

    public class ExcelentPupil: Pupil
    {
        public override void Study() { Console.Write("Very good"); };
        public override void Read() { Console.Write("Very fast"); }
        public override void Write() { Console.Write("Very clear"); }
        public override void Relax() { Console.Write("NEVER"); }
    }
    public class GoodPupil : Pupil
    {
        public override void Study() { Console.Write("Good"); };
        public override void Read() { Console.Write("Normaly"); }
        public override void Write() { Console.Write("Readable"); }
        public override void Relax() { Console.Write("Usually"); }
    }

    public class BadPupil : Pupil
    {
        public override void Study() { Console.Write("Bad"); };
        public override void Read() { Console.Write("Slow"); }
        public override void Write() { Console.Write("f#@&!l"); }
        public override void Relax() { Console.Write("Constant Chill"); }
    }

    public class ClassRoom
}
