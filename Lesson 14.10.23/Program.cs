using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_14._10._23
{
    internal class Program
    {
        enum AccountType
        {
            Current,
            Savings
        }
        class AccountBank
        {
            private static int accountCounter = 1000;// статическая переменная для генерации уникального номера счета
            private int AccountNumber;
            private double Balance;
            private AccountType AccountType;
            public AccountBank()
            {
                AccountNumber = accountCounter;
                accountCounter++;
                Balance = 0; 
                AccountType = AccountType.Current;  
            }
            public void SetData(int number, double balance, AccountType type)
            {
                AccountNumber = number;
                Balance = balance;
                AccountType = type;
            }
            public int GetAccountNumber()
            {
                return AccountNumber;
            }
            public double GetBalance()
            {
                return Balance;
            }
            public AccountType GetAccountType()
            {
                return AccountType;
            }
            public void SetBalance(double newBalance)
            {
                Balance = newBalance;
            }
            public void Deposit(double amount)
            {
                if (amount > 0)
                {
                    Balance += amount;
                    Console.WriteLine($"Депозит на {amount} выполнен.Новый баланс: {Balance}");
                }
                else
                {
                    Console.WriteLine("Ошибка!Увеличьте сумму для депозита.");
                }
            }
            public void Withdraw(double amount)
            {
                if (amount > 0 && Balance >= amount)
                {
                    Balance -= amount;
                    Console.WriteLine($"Списание {amount} выполнено.Новый баланс: {Balance}");
                }
                else if (amount <= 0)
                {
                    Console.WriteLine("Ошибка!Увеличьте сумму для списания.");
                }
                else
                {
                    Console.WriteLine("Недостаточно средств на счете.");
                }
            }

            public void PrintAccount()
            {
                Console.WriteLine($"Номер счета: {AccountNumber}");
                Console.WriteLine($"Баланс: {Balance}" );
                Console.WriteLine($"Тип счета: {AccountType}");
            }
        }
        public class Building
        {
            private int uniqueNumber;
            private int Height;
            private int Floors;
            private int Apartments;
            private int Entrances;

            public Building(int height, int floors, int apartments, int entrances)
            {
                Height = height;
                Floors = floors;
                Apartments = apartments;
                Entrances = entrances;
                uniqueNumber = getNextUniqueNumber();
            }
            private static int nextUniqueNumber = 1;
            public int GetUniqueNumber()
            {
                return uniqueNumber;
            }
            public int GetHeight()
            {
                return Height;
            }
            public int GetFloors()
            {
                return Floors;
            }
            public int GetApartments()
            {
                return Apartments;
            }
            public int GetEntrances()
            {
                return Entrances;
            }
            public int GetApartmentsOnFloor()
            {
                return Apartments / Floors;
            }
            public int GetApartmentsInEntrance()
            {
                return Apartments / Entrances;
            }
            public int GetFloorHeight()
            {
                return Height / Floors;
            }
            private static int getNextUniqueNumber()
            {
                int uniqueNumber = nextUniqueNumber;
                nextUniqueNumber++;
                return uniqueNumber;
            }
            public override string ToString()
            {
                return ($"Номер здания:{uniqueNumber}, высота:{Height}, этажность:{Floors}, количество квартир:{Apartments}, количество подъездов:{Entrances}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 7.1. Создать класс счет в банке с закрытыми полями: номер счета, баланс, тип банковского счета (использовать перечислимый тип из упр. 3.1). Предусмотреть методы для доступа к данным – заполнения и чтения. Создать объект класса, заполнить его поля и вывести информацию об объекте класса на печать.");
            AccountBank accountCounter = new AccountBank();
            accountCounter.SetData(123456789, 1000000, AccountType.Current);
            accountCounter.PrintAccount();
            Console.WriteLine("Упражнение 7.2.Изменить класс счет в банке из упражнения 7.1 таким образом, чтобы номер счета генерировался сам и был уникальным. Для этого надо создать в классе статическую переменную и метод, который увеличивает значение этого переменной.");
            AccountBank account1 = new AccountBank();
            account1.SetBalance(100000);
            AccountBank account2 = new AccountBank();
            account2.SetBalance(700000);
            account1.PrintAccount();
            account2.PrintAccount();
            Console.WriteLine("Упражнение 7.3. Добавить в класс счет в банке два метода: снять со счета и положить на счет. Метод снять со счета проверяет, возможно ли снять запрашиваемую сумму, и в случае положительного результата изменяет баланс.");
            account1.Deposit(777777);
            account2.Withdraw(5050505);
            Console.WriteLine("Домашнее задание 7.1. Реализовать класс для описания здания (уникальный номер здания, высота, этажность, количество квартир, подъездов). Поля сделать закрытыми,\r\nпредусмотреть методы для заполнения полей и получения значений полей для печати.Добавить методы вычисления высоты этажа, количества квартир в подъезде, количества квартир на этаже и т.д. Предусмотреть возможность, чтобы уникальный номер здания генерировался программно. Для этого в классе предусмотреть статическое поле, которое бы хранило последний использованный номер здания, и предусмотреть метод, который увеличивал бы значение этого поля.");
            Building building = new Building(20, 17, 345, 7);
            Console.WriteLine(building);
            Console.WriteLine($"Количество квартир на этаже:{building.GetApartmentsOnFloor()}");
            Console.WriteLine($"Количество квартир на этаже:{building.GetApartmentsInEntrance()}");
            Console.WriteLine($"Высота этажа:{ building.GetFloorHeight()}");
            Building building2 = new Building(30, 29, 200, 2);
            Console.WriteLine(building2);
            Console.WriteLine($"Количество квартир на этаже:{building2.GetApartmentsOnFloor()}");
            Console.WriteLine($"Количество квартир на этаже:{building2.GetApartmentsInEntrance()}");
            Console.WriteLine($"Количество квартир на этаже:{building2.GetFloorHeight()}");
            Building building3 = new Building(30, 29, 200, 2);
            Console.WriteLine(building3);
            Console.WriteLine($"Количество квартир на этаже:{building3.GetApartmentsOnFloor()}");
            Console.WriteLine($"Количество квартир на этаже:{building3.GetApartmentsInEntrance()}");
            Console.WriteLine($"Количество квартир на этаже:{building3.GetFloorHeight()}");
            Console.ReadKey();
        }
    }
}
