using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    class City
    {
        public string Name { get; private set; } // Название города

        private List<Theatre> Theatres; // Кинотеатры

        public City(string Name)
        {
            this.Name = Name;
            Theatres = new List<Theatre>();
        }

        public override string ToString() // Переопределённая ф-ция toString
        {
            string TmpTheatres = "";
            foreach (Theatre obj in Theatres)
            {
                TmpTheatres += obj.Name + ", ";
            }

            return $"Город: {this.Name}\nКинотеатры ({Theatres.Count} шт.): {TmpTheatres}";
        }

        public City AddTheatre (Theatre Theatre) // Добавить кинотеатр в город
        {
            this.Theatres.Add(Theatre);
            return this; // Для чейнинга
        }
    }
}
