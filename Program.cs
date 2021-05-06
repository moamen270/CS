using System;
namespace ConsoleApp3
{
    class Program
    { 
        // Every thing about the Key 
        public  class Key
        {
            public string sKey;
            public int[] intKey;
            
            // Constructor to create the key as a string 
            public Key(string sKey)
            {
                this.sKey = sKey;
                RgCheck();
                intKey = new int[10];
                arrMethKey();
            }
            // Method to Re-Entring the Key 
            public void KeyRe()
            {
                Console.WriteLine("Please Re-Enter The Key");
                sKey = Console.ReadLine();
                RgCheck();
                
            }
            // Checking the range of the key 
            public void RgCheck()
            {
                // the range is 10 no less no more 
               if (sKey.Length != 10)
                {
                    Console.WriteLine("NOT ALLOWED, ONLY 10 NUMBER FROM 0 TO 9 ");
                    // if the range less or more than 10 calling Re-Entring Method
                    KeyRe();
                }
            }
            
            // Convert StringKey to CharArray then grom CharrArray to intArray
            public void arrMethKey()
            {
                char[] v1 = new char[10];
                v1 = sKey.ToCharArray();
                for (int i = 0; i < 10; i++)
                {   // useing Try-Catch for Run time Error 
                    // if user entered Characters 
                    try
                    {   
                        // useing TOString to convert every single Char to string because Pares take string value only 
                         // useing Parse to convert from string to int 
                        intKey[i] = int.Parse(v1[i].ToString());
                    }
                    catch
                    {   
                        // if user enterd an character start the Method
                        intKeyCheck();
                    }
                }
                // start Method to Check the duplicate Numbers
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
                            // if we have one dublicateError break the loop and do action
                            Edup = 1;
                            break;
                        }
                    }
                    if (Edup == 1) break;

                }
                if (Edup==1)
                {
                    Console.WriteLine("Not Allowed,Key: duplicate number ");
                    // Call ReEntring Method then start From the beginning
                    KeyRe();
                    arrMethKey();
                    
                }
               
            }
            
            public void intKeyCheck()
            {
                    Console.WriteLine("NOT ALLOWED, Please Enter Numbers Only!");
                    // Call ReEntring Method then start From the beginning
                    KeyRe();
                    arrMethKey();
            }
        

        }
        //Every thing aboud the Message 
        public class Message
        {

            public string sMess;
            public int[] intMess;
            
            // constructor to create the message as a string
            public Message(string sMess)
            {
                this.sMess = sMess;
                intMess = new int[sMess.Length];
                arrMethMess();
            }
            // Method to Re-Entring the Message 
            public void messRe()
            {
                Console.WriteLine("Please Re-Enter The Message");
                sMess = Console.ReadLine();
            }
            public void arrMethMess()
            {
                
                char[] v2 = new char[sMess.Length];
                v2 = sMess.ToCharArray();
                // useing Try-Catch for Run time Error 
                // if user entered Characters 
                try 
                {
                    for (int i = 0; i < sMess.Length; i++)
                    {
                        // useing TOString to convert every single Char to string because Pares take string value only 
                        // useing Parse to convert from string to int 
                        string CTS = v2[i].ToString();
                        intMess[i] = int.Parse(CTS);
                    }
                }
                catch
                {
                     // if user enterd an character start the Method
                    intMessCheck();
                }

            }
            public void intMessCheck()
            {                
                    Console.WriteLine("NOT ALLOWED, Please Enter Numbers Only!");
                    // Call ReEntring Method 
                    messRe();
                    arrMethMess();              
            }
        }

        static void Main(string[] args)
        {
            //Rules
            Console.WriteLine("This is Encryption App");
            Console.WriteLine("Key and Message should be only Numbers");
            Console.WriteLine("Key's range is 10 Numbers from 0 to 9, Repetition is not allowed");
            Console.WriteLine("===================================================================");
            // Call the constructor and Entring the Key 
            Console.WriteLine("Enter The Key");
            Key S1 = new Key(Console.ReadLine());
            // Call the constructor and Entring the Message 
            Console.WriteLine("Enter the Message");
            Message S2 = new Message(Console.ReadLine());
            // Prossesing The Message by the Key and The Output
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
