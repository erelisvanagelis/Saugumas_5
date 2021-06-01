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
            int p = RSATool.GetRandomPrime();
            N = RSATool.GetN(q, p);
            BigInteger phi = RSATool.GetPhi(q, p);
            E = RSATool.GetE(phi);
            BigInteger D = RSATool.GetD(E, phi);
            X = RSATool.GetRandom();
            S = RSATool.GetS(X, (int)D, N);
            this.Message = message;
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
