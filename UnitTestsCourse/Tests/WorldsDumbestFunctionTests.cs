using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCourse.Tests
{
    public static class WorldsDumbestFunctionTests
    {
        //naming convention - ClassName_MethodName_ExpectedResult
        public static void WorldsDumbestFunction_ReturnsPikachuIfZero_ReturnString()    // neden static
        {
            try
            {
                //Arrange - Go get your varibles, whatever you need, you classes, go get functions   

                int num = 0;
                WorldsDumbestFunction worldsDumbest = new WorldsDumbestFunction();

                //Act - Execute this function
                string result = worldsDumbest.ReturnsPikachuIfZero(num);

                //Assert - Whatever ever is return is it what you want.
                if (result == "Pıkachu!")
                {
                    Console.WriteLine("PASSED: WorldsDumbestFunction.ReturnPikachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAİLED: WorldDumbestFunction.ReturnPikachuIfZero_ReturnsString");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }
    }
}
