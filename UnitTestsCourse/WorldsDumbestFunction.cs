using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCourse
{
    public class WorldsDumbestFunction
    {
        public string ReturnsPikachuIfZero(int num)
        {
            if (num == 0) //eğer birisi burdaki sayıyı değiştirirse ve developer bunu fark etmezse istenilen sonuç elde edilemez ve süekli dongu true dönebilir bu yüzden test diye bir şey var
            {
                return "Pıkachu!";
            }
            else
            {
                return "Squirtle";
            }
        }
    }
}
