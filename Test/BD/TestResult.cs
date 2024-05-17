using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BD
{
    public class TestResult
    {
        public int ID { get; set; }
        public int Grade {  get; set; }
        public string CorrectAnswer { get; set; }
        public Users user { get; set; }
    }
}
