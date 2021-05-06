using System;
namespace ConsoleApp3
{
    class Program
    { 
        public  class Key
        {
            public string sKey;
            public int[] intKey;

            public Key(string sKey)
            {
                this.sKey = sKey;
                RgCheck();
                intKey = new int[10];
                arrMethKey();
            }
            public void KeyRe()
            {
                sKey = Console.ReadLine();
                RgCheck();
                
            }
            public void RgCheck()
            {
               if (sKey.Length != 10)
                {
                    Console.WriteLine("NOT ALLOWED, ONLY 10 NUMBER FROM 0 TO 9 ");
                    Console.WriteLine("Please Re-Enter The Key");
                    KeyRe();
                }
            }

            public void arrMethKey()
            {
                char[] v1 = new char[10];
                v1 = sKey.ToCharArray();
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        intKey[i] = int.Parse(v1[i].ToString());
                    }
                    catch
                    {
                        intKeyCheck();
                    }
                }
                KeyDupCheck();
            }
            public void KeyDupCheck()
            {   
                int Edup = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 9; j > i; j--)
                    {
                        if (intKey[i] == intKey[j])
                        {
                            Edup = 1;
                            break;
                        }
                    }
                    if (Edup == 1) break;

                }
                if (Edup==1)
                {
                    Console.WriteLine("Not Allowed,Key: duplicate number ");
                    Console.WriteLine("Please Re-Enter The Key");
                    KeyRe();
                    arrMethKey();
                    
                }
               
            }
            public void intKeyCheck()
            {
                    Console.WriteLine("NOT ALLOWED, Please Enter Numbers Only!");
                    Console.WriteLine("Please Re-Enter The Key");
                    KeyRe();
                    arrMethKey();
            }
        

        }
        public class Message
        {

            public string sMess;
            public int[] intMess;

            public Message(string sMess)
            {
                this.sMess = sMess;
                intMess = new int[sMess.Length];
                arrMethMess();
            }
           
            public void messRe()
            {
                sMess = Console.ReadLine();

            }
            public void arrMethMess()
            {
                char[] v2 = new char[sMess.Length];
                v2 = sMess.ToCharArray();
                try 
                {
                    for (int i = 0; i < sMess.Length; i++)
                    {
                        string CTS = v2[i].ToString();
                        intMess[i] = int.Parse(CTS);
                    }
                }
                catch
                {
                    intMessCheck();
                }

            }
            public void intMessCheck()
            {                
                    Console.WriteLine("NOT ALLOWED, Please Enter Numbers Only!");
                    Console.WriteLine("Please Re-Enter The Message");
                    messRe();
                    arrMethMess();              
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("This is Encryption App");
            Console.WriteLine("Key and Message should be only Numbers");
            Console.WriteLine("Key's range is 10 Numbers from 0 to 9, Repetition is not allowed");
            Console.WriteLine("===================================================================");
            Console.WriteLine("Enter The Key");
            Key S1 = new Key(Console.ReadLine());
            Console.WriteLine("Enter the Message");
            Message S2 = new Message(Console.ReadLine());
            int Count = 0;
            Console.WriteLine("Encrypted Message");
            for (int i = 0; i < S2.sMess.Length; i++)
            {
                if (Count == 10) Count = 0;
                Console.Write(S2.intMess[S1.intKey[Count]]);
                Count++;
            }
        }
    }
}
