using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Package
    {
        BigInteger n;
        BigInteger e;
        BigInteger d;
        BigInteger x;
        BigInteger s;
        String message;

        public BigInteger N { get => n; set => n = value; }
        public BigInteger E { get => e; set => e = value; }
        public BigInteger D { get => d; set => d = value; }
        public BigInteger X { get => x; set => x = value; }
        public BigInteger S { get => s; set => s = value; }
        public string Message { get => message; set => message = value; }

        public Package(string message)
        {
            int q = RSATool.GetRandomPrime();
            int p = RSATool.GetRandomPrime();
            N = RSATool.GetN(q, p);
            BigInteger phi = RSATool.GetPhi(q, p);
            E = RSATool.GetE(phi);
            D = RSATool.GetD(E, phi);
            X = RSATool.GetRandom();
            S = RSATool.GetS(X, (int)D, N);
            this.Message = message;
        }

        public Package(){}

        public void Parse(string data)
        {
            string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            N = BigInteger.Parse(lines[0]);
            E = BigInteger.Parse(lines[1]);
            D = BigInteger.Parse(lines[2]);
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
                   $"\n{RSATool.GetRandomPrime()}" +
                   $"\n{S}" +
                   $"\n{Message}";
        }
    }
}
