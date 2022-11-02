using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public delegate void AccountHandler(string message);
    public class Class1
    {
        public int sum;
        // Создаем переменную делегата
        AccountHandler taken;
        public Class1(int sum) => this.sum = sum;
        public Class1() { }
        // Регистрируем делегат
        public void RegisterHandler(AccountHandler del)
        {
            taken = del;
        }
        public void Add(int sum) => this.sum += sum;
        public void Take(int sum)
        {
            if (this.sum >= sum)
            {
                this.sum -= sum;
                // вызываем делегат, передавая ему сообщение
                taken?.Invoke($"Со счета списано {sum} у.е.");
            }
            else
            {
                taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
            }
        }

        class AccountEventArgs
        {
            // Сообщение
            public string Message { get; }
            // Сумма, на которую изменился счет
            public int Sum { get; }
            public AccountEventArgs(string message, int sum)
            {
                Message = message;
                Sum = sum;
            }
        }

        class Account
        {
            public delegate void AccountHandler(Account sender, AccountEventArgs e);
            public event AccountHandler Notify;

            public int Sum { get; private set; }

            public Account(int sum) => Sum = sum;

            public void Put(int sum)
            {
                Sum += sum;
                Notify?.Invoke(this, new AccountEventArgs($"На счет поступило {sum}", sum));
            }
            public void Take(int sum)
            {
                if (Sum >= sum)
                {
                    Sum -= sum;
                    Notify?.Invoke(this, new AccountEventArgs($"Сумма {sum} снята со счета", sum));
                }
                else
                {
                    Notify?.Invoke(this, new AccountEventArgs("Недостаточно денег на счете", sum));
                }
            }
        }
    }
}
