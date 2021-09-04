using System;
namespace ConsoleApp3
{
    class Program
    {
        // Every thing about the Key 
        public class Key
        {
            public string key;
           


            // Constructor to create the key as a string 
            public Key(string key)
            {
                this.key = key;
                RangeCheck();
                FormatCheck();
            }


            // Method to Re-Make the Key 
            public void KeyRemake()
            {
                Console.WriteLine("Please Re-Enter The Key");
                key = Console.ReadLine();
                RangeCheck();

            }



            // Check range of the key 
            public void RangeCheck()
            {
                // the range is 10 no less no more 
                if (key.Length != 10)
                {
                    Console.WriteLine("NOT ALLOWED, ONLY 10 NUMBER FROM 0 TO 9 ");
                    // if the range less or more than 10 call Re-Entring Method
                    KeyRemake();
                }
            }



            public void FormatCheck()
            {
                for (int i = 0; i < 10; i++)
                {
                    if (!char.IsNumber(key[i]))                       
                        WrongFormat();
                }
                // start Method to Check the duplicate Numbers
                KeyDupCheck();
            }



            public void KeyDupCheck()
            {
                bool Edup = false;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 9; j > i; j--)
                    {
                        if (key[i] == key[j])
                        {
                            // if we have one dublicateError break the loop and do action
                            Edup = true;
                            break;
                        }
                    }
                    if (Edup == true) break;

                }
                if (Edup == true)
                {
                    Console.WriteLine("Not Allowed,Key: duplicate number ");
                    // Call Entring Method then start From the beginning
                    KeyRemake();
                    FormatCheck();
                }

            }




            public void WrongFormat()
            {
                Console.WriteLine("NOT ALLOWED, Please Enter Numbers Only!");
                // Call ReEntring Method then start From the beginning
                KeyRemake();
                FormatCheck();
            }


        }



        //Every thing aboud the Message 
        public class Message
        {

            public string message;

            // constructor to create the message as a string
            public Message(string Message)
            {
                this.message = Message;
                RangeCheck();
                WrongFormatCheck();
            }

            public void RangeCheck()
            {
                // the range is 10 no less no more 
                if (message.Length % 10 != 0)
                {
                    Console.WriteLine("NOT ALLOWED, ONLY 10 NUMBER FROM 0 TO 9 ");
                    // if the range less or more than 10 call Re-Entring Method
                    MessageRemake();                   
                }
            }
            // Method to Re-Entring the Message 
            public void MessageRemake()
            {
                Console.WriteLine("Please Re-Enter The Message");
                message = Console.ReadLine();
                RangeCheck();
            }


            public void WrongFormatCheck()
            {
                for(int i=0; i<message.Length;i++)
                {
                    if (!char.IsNumber(message[i]))                                         
                        WrongFormat();
                }
            }


            public void WrongFormat()
            {

                Console.WriteLine("NOT ALLOWED, Please Enter Numbers Only!");
                // Call ReEntring Method 
                MessageRemake();
                WrongFormatCheck();
            }
        }

        static void Main(string[] args)
        {
            //Rules
            Console.WriteLine("\tThis is Encryption App");
            Console.WriteLine("\tKey and Message should be only Numbers");
            Console.WriteLine("\tKey range is 10 Numbers from 0 to 9, Repetition is not allowed");
            Console.WriteLine("==========================================================================");
            
            // Call the constructor and Entring the Key 
            Console.WriteLine("\tEnter The Key");
            Key S1 = new Key(Console.ReadLine());

            Console.WriteLine("\n==========================================================================");
            Console.WriteLine("\tMessage should be only Numbers");
            Console.WriteLine("\tMessage range shuld be any multiple of 10");
            Console.WriteLine("==========================================================================");
            // Call the constructor and Entring the Message 
            Console.WriteLine("\tEnter the Message");
            Message S2 = new Message(Console.ReadLine());
            Console.WriteLine("==========================================================================");
            // Prossesing The Message by the Key and The Output            
            Console.WriteLine("\tEncrypted Message");
            int Counter = 0;
            int round = 0;
            int t = 0;
            for (int i = 0; i < S2.message.Length; i++)
            {
                if (Counter > 9)
                {
                    Counter = 0;
                    round++;
                }
                t = int.Parse(S1.key[Counter].ToString());
                Console.Write(S2.message[t+(round*10)]);
                Counter++;
            }
        }
    }
}
