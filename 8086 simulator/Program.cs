using System;
using System.Collections.Generic;

namespace _8086_simulator 
{
    internal class Program
    {


        static string[] arrOfCommands = {
            "MOV [register] [register | hexadecimalNumber] \n(Copies one register value and pastes it into another. hexadecimalNumber range is from 0 to FF)",
            "XCHG [register] [register] \n(Swap register values)",
            "CLEAR \n(clear terminal screan)",
            "EXIT  \n(shutdown program)",
            "SHOW \n(shows all registers` values)"
        };

        static void Main(string[] args)
        {

            Terminal terminal = new Terminal();

            Dictionary<string, HexNum> Registers = new Dictionary<string, HexNum>() {
                { "AL", new HexNum("af")},
                { "AH", new HexNum("cf")},
                { "BL", new HexNum()},
                { "BH", new HexNum()},
                { "CL", new HexNum()},
                { "CH", new HexNum()},
                { "DL", new HexNum()},
                { "DH", new HexNum()}
            };


            terminal.working = true;

            while (terminal.working)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nmade by Remigiusz Krupa, type 'help' for more informations :=>  ");
                MainColors();


                string[] input = Console.ReadLine().ToUpper().Split(' ');
                try
                {

                    switch (input[0])
                    {
                        case "MOV":
                            terminal.MOV(Registers, input[1], input[2]);
                            break;
                        case "XCHG":
                            terminal.XCHG(Registers, input[1], input[2]);
                            break;
                        case "SHOW":
                            terminal.SHOW(Registers);
                            break;
                        case "CLEAR":
                            Console.Clear();
                            break;
                        case "EXIT":
                            Environment.Exit(1);
                            break;
                        case "HELP":
                            terminal.SHOW(arrOfCommands);
                            break;
                        default:
                            info();
                            break;
                    }
                }
                catch (Exception e)
                {
                    info();
                }

            }

        }

        public static void DangerStart()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public static void MainColors()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public static void info()
        {
            DangerStart();


            Console.WriteLine("\n\nInvalid command!");
            Console.WriteLine("Write <[ HELP ]> if you don't know how to use this program or to check list of commands.\n");

            MainColors();
        }



    }
}