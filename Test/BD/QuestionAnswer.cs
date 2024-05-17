using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.BD
{
    public class QuestionAnswer
    {
        public int ID {  get; set; }
        public string Question { get; set; }
        public string TrueAnswer { get; set; }
        public string FalseAnswer { get; set; }
    }
}
