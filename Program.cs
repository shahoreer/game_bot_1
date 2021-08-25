/* problem:
 Can't convert userinput into options/arry ********* ********* ********* *********

         +5,-9,*3,/8
            i=0
            j=2
            gap(j-i)=2

*/
using System;

namespace c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int unum = 0;
            string[] allnums;
            allnums=new string[4]; ///// work on here *******   *******  ******* something wrong
            Console.WriteLine("Current Arrows?");
            int current = int.Parse(Console.ReadLine()); //int.Parse(usnum); 
            Console.WriteLine("options? (Make sure all options end with , .... dont need to have extra , at the end)");
            string optnsstrng = Console.ReadLine();
            int optl = optnsstrng.Length;

            for(int i=0;i<optl;i++){
                char ck= char.Parse(optnsstrng.Substring(i,1));
                if(ck=='+' || ck=='-' || ck=='/' || ck=='*'){
                    for(int j=i+1;j<optl;j++){
                        if(optnsstrng.Substring(j,1)=="," || j==optl-1){
                            allnums[unum]=optnsstrng.Substring(i,j-i);
                            if(j==optl-1)
                                allnums[unum]=optnsstrng.Substring(i,j-i+1);
                            j=optl;
                            unum++;
                        }
                    }
                }
            }

            int bestindx = best(allnums, current);
            Console.WriteLine("choose: "+allnums[bestindx]);
        }
        static int best(string[] options, int current)
        {
            int ret=0;
            string symb = options[0].Substring(0, 1);
            int optnum = int.Parse(options[0].Substring(1, options[0].Length - 1));
            int bestsofar = actval(symb, optnum,current);

            for (int i = 1; i < options.Length; i++)
            {
                symb = options[i].Substring(0, 1); //////// errorrrrrrrrr ****
                optnum = int.Parse(options[i].Substring(1, options[i].Length - 1));
                int optionreturn = actval(symb, optnum, current);

                if (optionreturn>bestsofar)
                {
                    ret = i;
                    bestsofar = optionreturn;
                }
            }
            return ret;
        }
        static int actval(string symb, int num,int current)
        {
            int r;
            switch (symb)
            {
                case "+":
                    r = num + current;
                    break;
                case "-":
                    r = current - num;
                    break;
                case "*":
                    r = num*current;
                    break;
                default:
                    r = current / num;
                    break;
            }
            return r;
        }
    }
}
