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
    }
}
