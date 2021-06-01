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
        BigInteger d;
        BigInteger x;
        BigInteger s;
        String message;

        public Package(string message)
        {
            int q = RSATool.GetRandomPrime();
            int p = RSATool.GetRandomPrime();
            n = RSATool.GetN(q, p);
            BigInteger phi = RSATool.GetPhi(q, p);
            e = RSATool.GetE(phi);
            d = RSATool.GetD(e, phi);
            x = RSATool.GetRandom();
            s = RSATool.GetS(x, (int)d, n);
            this.message = message;
        }

        public void Parse(string data)
        {
            string[] lines = data.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            n = BigInteger.Parse(lines[0]);
            e = BigInteger.Parse(lines[1]);
            d = BigInteger.Parse(lines[2]);
            x = BigInteger.Parse(lines[3]);
            s = BigInteger.Parse(lines[4]);

            message = "";
            foreach(string line in lines)
            {
                message += line;
            }
        }

        public override string ToString()
        {
            return $"{n}" +
                   $"\n{e}" +
                   $"\n{RSATool.GetRandomPrime()}" +
                   $"\n{s}" +
                   $"\n{message}";
        }
    }
}
