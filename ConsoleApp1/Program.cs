using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Channels;

namespace ConsoleApp1
{
    internal class Program
    {

        // ================= Q2 =================
        const double AppVersion = 2.5;

        static readonly bool LoginEnabled = false;
        static readonly bool ExportEnabled = false;
        static readonly bool AdminPanelEnabled = true;

        static readonly double LoginMinVersion = 1.0;
        static readonly double ExportMinVersion = 3.0;
        static readonly double AdminPanelMinVersion = 2.0;

        static void Main(string[] args)
        {
            // ================= Q1 =================
            string dotNetVersion = Environment.Version.ToString();
            string os = RuntimeInformation.OSDescription;
            string cpuArch = RuntimeInformation.ProcessArchitecture.ToString();
            string framework = RuntimeInformation.FrameworkDescription;

            Console.WriteLine("--- Runtime Environment Info ---");
            Console.WriteLine($" .NET Version      : {dotNetVersion}");
            Console.WriteLine($" Operating System  : {os}");
            Console.WriteLine($" CPU Architecture  : {cpuArch}");
            Console.WriteLine($" Framework         : {framework}");

            string runtimeType = framework switch
            {
                string r when r.Contains(".NET Core") || r.Contains(".NET")
                    => "Modern .NET Runtime",
                _ => "Legacy Runtime"
            };

            Console.WriteLine($"Runtime Type: {runtimeType}\n");

            // ================= Q2 =================
            Console.WriteLine("--- Feature Toggle System ---");
            Console.WriteLine($"Application Version: {AppVersion}\n");

            CheckFeature("Login", LoginEnabled, LoginMinVersion);
            CheckFeature("Export", ExportEnabled, ExportMinVersion);
            CheckFeature("Admin Panel", AdminPanelEnabled, AdminPanelMinVersion);

            // ================= Q3 =================
            Console.WriteLine("\n--- Number Classification Engine ---");

            List<int> numbers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();
            List<int> primeNumbers = new List<int>();

            ClassifyNumbers(numbers, evenNumbers, oddNumbers, primeNumbers);

            Console.Write("Even Numbers: ");
            PrintList(evenNumbers);

            Console.Write("Odd Numbers: ");
            PrintList(oddNumbers);

            Console.Write("Prime Numbers: ");
            PrintList(primeNumbers);

            // ================= Q4 =================
            Console.WriteLine("\n--- Memory Behavior Test ---");

            User user = new User { Name = "Ahmed" };
            UserSnapshot snapshot = new UserSnapshot { Name = "Ahmed" };

            Console.WriteLine("Before Method Call:");
            Console.WriteLine($"User Name: {user.Name}");
            Console.WriteLine($"Snapshot Name: {snapshot.Name}");

            Modify(user, snapshot);

            Console.WriteLine("\nAfter Normal Call:");
            Console.WriteLine($"User Name: {user.Name}");
            Console.WriteLine($"Snapshot Name: {snapshot.Name}");

            ModifyRef(ref user, ref snapshot);

            Console.WriteLine("\nAfter ref Call:");
            Console.WriteLine($"User Name: {user.Name}");
            Console.WriteLine($"Snapshot Name: {snapshot.Name}");
        }


        // ================= Q2 Helper =================
        static void CheckFeature(string featureName, bool isEnabled, double minVersion)
        {
            if (isEnabled && AppVersion >= minVersion)
            {
                string status = isEnabled ? "Enabled" : "Disabled";
                Console.WriteLine($"{featureName}: {status} ✔ (Available)");
            }
            else
            {
                Console.WriteLine($"{featureName}: Disabled ✖ (Not Available)");
            }
        }

        // ================= Q3 =================
        static void ClassifyNumbers(
            List<int> numbers,
            List<int> evens,
            List<int> odds,
            List<int> primes)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                int num = numbers[i];

                if (IsEven(num))
                    evens.Add(num);
                else
                    odds.Add(num);

                if (IsPrime(num))
                    primes.Add(num);
            }
        }

        static bool IsEven(int number) => number % 2 == 0;

        static bool IsPrime(int number)
        {
            if (number < 2) return false;

            for (int i = 2; i <= number / 2; i++)
                if (number % i == 0) return false;

            return true;
        }

        static void PrintList(List<int> list)
        {
            foreach (int num in list)
                Console.Write(num + " ");
            Console.WriteLine();
        }

        // ================= Q4 Methods =================
        // What changed?in normal method call class changed and struct not 
        // in ref method call both changed
        //Why?class is ref type =>When passed to a method normally, a copy of the reference is passed,Both the original variable and the method parameter point to the same object
        //struct is value type => When passed normally, a copy of the whole struct is created,Changes affect only the copy, not the original,The method receives a reference to the original struct Changes affect the actual variable
        //Stack vs Heap
        //stack=>Stores local variables, value types, and object references; it is fast and automatically cleared when the method ends.
        //Heap=>Stores objects created from classes; it is slower than the stack and managed by the Garbage Collector.
        static void Modify(User user, UserSnapshot snapshot)
        {
            user.Name = "Mohamed";
            snapshot.Name = "Mohamed";
        }

        static void ModifyRef(ref User user, ref UserSnapshot snapshot)
        {
            user.Name = "Youssif";
            snapshot.Name = "Youssif";
        }
    }
}
