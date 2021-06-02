using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    class Package
    {
        BigInteger n;
        BigInteger e;
        BigInteger x;
        BigInteger s;
        String message;

        public BigInteger N { get => n; set => n = value; }
        public BigInteger E { get => e; set => e = value; }
        public BigInteger X { get => x; set => x = value; }
        public BigInteger S { get => s; set => s = value; }
        public string Message { get => message; set => message = value; }

        public Package(string message)
        {
            int q = RSATool.GetRandomPrime();
            Console.WriteLine("q = " + q);
            int p = RSATool.GetRandomPrime();
            Console.WriteLine("p = " + p);
            N = RSATool.GetN(q, p);
            Console.WriteLine("n = " + n);
            BigInteger phi = RSATool.GetPhi(q, p);
            Console.WriteLine("phi = " + phi);
            E = RSATool.GetE(phi);
            Console.WriteLine("e = " + e);
            BigInteger d = RSATool.GetD(E, phi);
            Console.WriteLine("d = " + d);
            X = RSATool.GetRandom();
            Console.WriteLine("x = " + x);
            S = RSATool.GetS(X, (int)d, N);
            Console.WriteLine("s = " + s);
            this.Message = message;
            Console.WriteLine("message = " + message);
        }

        public void Parse(string data)
        {
            string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            N = BigInteger.Parse(lines[0]);
            E = BigInteger.Parse(lines[1]);
            X = BigInteger.Parse(lines[3]);
            S = BigInteger.Parse(lines[4]);

            Message = "";
            foreach(string line in lines)
            {
                Message += line;
            }
        }

        public override string ToString()
        {
            return $"{N}" +
                   $"\n{E}" +
                   $"\n{X}" +
                   $"\n{S}" +
                   $"\n{Message}";
        }
    }
}
