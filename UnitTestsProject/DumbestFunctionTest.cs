using System;
using System.Threading.Tasks;

namespace UnitTestsProject
{

    public class DumbestFunction
    {
        public string ReturnsPikachuIfZero(int num)
        {
            if (num == 0)
            {
                return "PIKACHU!";
            }
            else
            {
                return "Squirtle";
            }
        }
    }
}
