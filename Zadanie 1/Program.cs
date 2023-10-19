using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    internal class Program
    {
        abstract class TableBooking// Абстрактный класс для бронирования столиков
        {
            public string Name {get; set;}// Свойства
            public DateTime BookingDate {get; set;}
            public TableBooking(string name, DateTime bookingDate)// Конструктор
            {
                Name = name;
                BookingDate = bookingDate;
            }
            public abstract void ConfirmBooking();// Абстрактный метод
        }
        class TableBookingForGuests : TableBooking// Класс для бронирования столиков на определенное количество человек
        {
            public int NumberOfGuests {get; set;}// Свойство
            public TableBookingForGuests(string name, DateTime bookingDate, int numberOfGuests) : base(name, bookingDate)// Конструкторы
            {
                NumberOfGuests = numberOfGuests;
            }
            public TableBookingForGuests(string name, int numberOfGuests) : this(name, DateTime.Now, numberOfGuests)// Конструкторы
            {
            }
            public override void ConfirmBooking()// Методы
            {
                Console.WriteLine($"Столик для {NumberOfGuests} гостей забронирован на {BookingDate} для {Name}");
            }
            public void ChangeNumberOfGuests(int newNumberOfGuests)
            {
                NumberOfGuests = newNumberOfGuests;
                Console.WriteLine($"Количество гостей для бронирования изменено на {NumberOfGuests}");
            }
        }
        class TableBookingByTime : TableBooking// Класс для бронирования столиков по времени
        {
            public TimeSpan BookingTime {get; set;} // Свойство
            public TableBookingByTime(string name, DateTime bookingDate, TimeSpan bookingTime) : base(name, bookingDate)// Конструкторы
            {
                BookingTime = bookingTime;
            }
            public TableBookingByTime(string name, TimeSpan bookingTime) : this(name, DateTime.Now, bookingTime)
            {
            }
            public override void ConfirmBooking()// Методы
            {
                Console.WriteLine($"Столик забронирован на {BookingDate.ToShortDateString()} в {BookingTime} для {Name}");
            }
            public void ChangeBookingTime(TimeSpan newBookingTime)
            {
                BookingTime = newBookingTime;
                Console.WriteLine($"Время бронирования изменено на {BookingTime}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Написать программу, тема - Бронирование столиков в ресторане");
            Console.WriteLine("Изменение количества гостей и времени бронирования:");
            TableBookingForGuests booking1 = new TableBookingForGuests("Колесниковa Владимира", 3);// Создание объекта класса TableBookingForGuests
            booking1.ChangeNumberOfGuests(5);// Изменение количества гостей
            booking1.ConfirmBooking();// Подтверждение бронирования
            TableBookingForGuests booking2 = new TableBookingForGuests("Смирнова Олега", 2);
            booking2.ChangeNumberOfGuests(4);
            booking2.ConfirmBooking();
            TableBookingByTime booking3 = new TableBookingByTime("Анашиной Дарьи", new TimeSpan(15, 30, 0));// Создание объекта класса TableBookingByTime
            booking3.ChangeBookingTime(new TimeSpan(20, 0, 0));// Изменение времени бронирования
            booking3.ConfirmBooking(); // Подтверждение бронирования
            Console.ReadKey();
        }
    }
}
