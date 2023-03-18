// See https://aka.ms/new-console-template for more information
using System;
using ConsoleApp2.Models;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            YoungerUser();
            Console.WriteLine("123");
        }
        
        public static bool Reg(string city, string street, string building, string name, string surname, string lastname, string mail, DateOnly birthday, string telephone, int address_id)
        {
            using (Gr601BokvaContext db = new Gr601BokvaContext())
            {
                Address address = new Address()
                {
                    City = city,
                    Street = street,
                    Building = building
                };
                
                Usertable usertable = new Usertable()
                {
                    Name = name,
                    Surname = surname,
                    Lastname = lastname,
                    Birthday = birthday,
                    AddressId = address.Id,
                    Email = mail,
                    Telephone = telephone
                };
                db.Usertables.Add(usertable);
                db.Addresses.Add(address);
                db.SaveChanges();
            }

            return true;
        } 

        public static void SearchToSurname(string surname)
        {
            using (Gr601BokvaContext db = new Gr601BokvaContext())
            {
                var users = db.Usertables.Where(e => e.Surname == surname).ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Surname}");
                }
            }
        }

        public static bool DeleteUser(int id)
        {
            using (Gr601BokvaContext db = new Gr601BokvaContext())
            {
                var userToDel = db.Usertables.Find(id);
                db.Usertables.Remove(userToDel);
                db.SaveChanges();
                return true;
            }
        }

        public static void YoungerUser()
        {
            using (Gr601BokvaContext db = new Gr601BokvaContext())
            {
                var yongerUser = db.Usertables.Where(e => e.Birthday == DateOnly.MinValue).ToList();
                foreach (var user in yongerUser)
                {
                    Console.WriteLine($"{user.Surname}");
                }
            }
        }

    }

}

