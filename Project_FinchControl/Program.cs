using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{
    namespace Project_FinchControl
    {

        //Title: Finch Control - Menu Starter
        //Description: Starter Solution with helper methods,
        //             opening and closing menus as well as the menu itself
        //             that we will be expanding over the course.
        //Application Type: Console
        //Author: Guggisberg, Ashtyn
        //Date Created: 10-1-2020
        //Date Modified:

    }
    class Program
    {
        public static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();

            DisplayMenuScreen();

            DisplayClosingScreen();

        }
        //Setting up the Console Theme, Which is what determines the back ground colors, if the cursosr is visible, and the text colors as well
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;
            string menuTypes;

            Finch finchrobot = new Finch();
            bool v = false;
            do
            {
                DisplayScreenHeader("Menu Main");

                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc)Data Recorder");
                Console.WriteLine("\td)Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf)Disconnect Finch Robot");
                Console.WriteLine("\tq)Quit");
                Console.WriteLine("/t/tEnter Choice:");
                menuTypes = Console.ReadLine().ToLower();
                switch (menuTypes)
                {
                    case "a":
                        DisplayConnectFinch(finchrobot);
                        break;
                    case "b":
                        DisplayTalentShowMenuScreen(finchrobot);
                        break;
                    case "c":

                        break;
                    case "d":

                        break;
                    case "e":

                        break;
                    case "f":
                        DisplayDisconnectFinch(finchrobot);
                        break;
                    case "q":
                        DisplayDisconnectFinch(finchrobot);
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinueScreen();
                        break;
                }

            } while (v);
        }
        #region Talent Show
        static void DisplayTalentShowMenuScreen(Finch finchrobot)
        {
            Console.CursorVisible = true;

            bool quitTalentMenu = false;
            string Choice;
            do
            {
                DisplayScreenHeader("Talent Show Menu");

                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) ");
                Console.WriteLine("\tc) ");
                Console.WriteLine("\td) ");
                Console.WriteLine("\tq) Main Menu");
                Console.WriteLine("\t\tEnter Choice:");
                Choice = Console.ReadLine().ToLower();

                switch (Choice)
                {
                    case "a":
                        DisplayLightandSound(finchrobot);
                        break;
                    case "b":
                        break;
                    case "c":
                        break;
                    case "d":
                        break;
                    case "q":
                        quitTalentMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for menu choice");
                        break;
                }
            } while (!quitTalentMenu);
        }
        static void DisplayLightandSound(Finch finchrobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch Robot will now try and give you a seizure!! have Fun!!");
            DisplayContinueScreen();
            for (int lsLevel = 0; lsLevel < 255; lsLevel++)
            {
                finchrobot.setLED(lsLevel, lsLevel, lsLevel);
                finchrobot.noteOn(lsLevel * 100);
            }
            DisplayMenuScreen("Talent Show Menu");
        }
        #endregion
        #region Robot Management
        static void DisplayDisconnectFinch(Finch finchrobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinueScreen();

            finchrobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuScreen("Main Menu");
        }
        static bool DisplayConnectFinch(Finch finchrobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinueScreen();

            robotConnected = finchrobot.connect();



            DisplayMenuScreen("Main Menu");


            finchrobot.setLED(0, 0, 0);
            finchrobot.noteOff();

            return robotConnected;
        }
        #endregion
        #region Interface
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;


            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinueScreen();
        }

        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.ReadKey();

            DisplayContinueScreen();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinueScreen()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuScreen(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }
        #endregion
    }

}