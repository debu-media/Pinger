using System;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace Pinger
{
//Author: Patryk Buszman <www.debu.pl> 
//License: GPL
//Github debu-media
//Description: Check terminal connection and save log. 

    class Program
    {
        static void Main(string[] args)
        {
            ProMon proMon = new ProMon();
            Ping ping = new Ping();
            Loger loger = new Loger();
            bool isOkey = true;
            string[] IpAdress = File.ReadLines("c:\\Pinger\\ipadress.txt").ToArray();
            string[] ProcessName = File.ReadLines("C:\\Pinger\\processname.txt").ToArray();
            loger.SaveToFile("Pinger zaczyna działanie");
            while (isOkey)
            {
                foreach (var process in ProcessName)
                {
                    if (proMon.GetProcessStatus(process))
                    {
                        Console.WriteLine("Usługa: " + process + " działa");
                        loger.SaveToFile("Usługa: " + process + " działa");
                        System.Threading.Thread.Sleep(5000);
                    }
                    else
                    {
                        Console.WriteLine("Usługa: " + process + " nie działa");
                        loger.SaveToFile("Usługa: " + process + " nie działa");
                        System.Threading.Thread.Sleep(5000);
                    } 
                }
                foreach (var ip in IpAdress)
                {
                    string GetIp = ping.Send(ip).Status.ToString();
                    if (GetIp == "Success")
                    {
                        Console.WriteLine("Adres ip: " + ip + " odpowiada");
                        loger.SaveToFile("Adres ip: " + ip + " odpowiada");
                        System.Threading.Thread.Sleep(5000);
                    }
                    else
                    {
                        Console.WriteLine("Adres ip: " + ip + " nie odpowiada");
                        loger.SaveToFile("Adres ip: " + ip + " nie odpowiada");
                        System.Threading.Thread.Sleep(5000);
                    }
                }
                System.Threading.Thread.Sleep(5000);
            }

        }
    }
}
