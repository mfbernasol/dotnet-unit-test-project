using System;
using System.Threading.Tasks;

namespace UnitTestsProject.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public static class DumbestFunctionTests
    {
        // Naming Conventions - ClassName_MethodName_ExpectedResults
        public static void DumbestFunction_ReturnsPikachuIfZero_ReturnsString() {
            try{
                //Arrange -- Go get your vairables, whatever you need, your classes, get functions
                int num = 0;
                DumbestFunction dumbestFunction = new DumbestFunction();

                //Act - Execute Function 
                string result = dumbestFunction.ReturnsPikachuIfZero(num);


                //Assert- Whatever ever is returned is it what you want 
                if(result == "PIKACHU!")
                {
                    Console.WriteLine("PASSED: DumbestFunction.ReturnsPikachuIfZero_ReturnsString");
                }
                else
                {
                    Console.WriteLine("FAILED:PASSED: DumbestFunction.ReturnsPikachuIfZero_ReturnsString ");
                }



            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
