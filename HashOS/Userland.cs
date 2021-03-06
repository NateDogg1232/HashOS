﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys=Cosmos.System;


namespace HashOS
{
    /// <summary>
    /// Create your programs here
    /// </summary>
    class Userland
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        /// <summary>
        /// Runs a userland program
        /// </summary>
        /// <param name="command">Command to run</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public int runCommand(string command, string[] args, string fullCommand)
        {
            Sys.Global.mDebugger.Send("Userland called!");
            if (command == "argumenttest")
            {
                runArgTestProgram(args, fullCommand);
                return 0;
            }
            if (command == "easteregg")
            {
                runEasterEgg();
                return 0;
            }
            if (command=="dir")
            {
                return getDirListing(args);
            }
            Console.WriteLine("Command is not implemented yet");
            return 2;
        }

        public void init()
        {
            Console.WriteLine("Setting up userland filesystem");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }

        #region Programs
        public void runArgTestProgram(string[] args, string fullCommand)
        {
            Console.WriteLine("Argument System Test Program");
            Console.WriteLine();
            Console.Write("Full command: ");
            Console.WriteLine(fullCommand);
            
                
            if (args.Length!=0)
            {
                Console.Write("Argument count: ");
                Console.WriteLine(args.Length);
                for (int i=0; i<args.Length;i++)
                {
                    Console.Write(i);
                    Console.Write(": ");
                    Console.WriteLine(args[i]);
                }
            }
        }
        public void runEasterEgg()
        {
            Console.WriteLine("Quit snooping around, please!");
            Console.WriteLine("Also, shoutout to COSMOS for making this easteregg possible xD!");
        }
        public int getDirListing(string[] args)
        {
            
            if (args.Length==0)
            {
                //HACK: Just use this for now, I guess...
                string[] tmparr = { GlobalVars.CurrentDir };
                args = tmparr;
                //return 1;
            }
            Console.Write("Listing of ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(args[0]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(':');
            foreach (var dir in Directory.GetDirectories(args[0]))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("<dir>\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(dir);
                
            }
            foreach (var file in Directory.GetFiles(args[0]))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("<file>\t");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(file);
                
            }
            return 0;

        }
        #endregion

    }
}
