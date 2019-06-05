using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    class Movie
    {
        public string Name { get; private set; } // Название фильма
        public string Duration { get; private set; } // Длительность фильма
        public string Genre { get; private set; } // Жанр фильма

        private List<Theatre> Theatres; // Список кинотеатров, в которых доступен к просмотру

        public Movie(string Name, string Duration, string Genre)
        {
            this.Name = Name;
            this.Genre = Genre;
            this.Theatres = new List<Theatre>();

            if (Regex.IsMatch(Duration, "^[0-9]{2}:[0-9]{2}:[0-9]{2}$")) // Формат хх:хх:хх
            {
                this.Duration = Duration;
            }
            else
            {
                throw new Exception("Invalid Duration in Movie.Movie(string Name, " +
                    "string Duration, string Genre)!");
            }
        }

        public Movie AddTheatre(Theatre Theatre) // Добавить кинотеатр в список
        {
            this.Theatres.Add(Theatre);
            return this; // Для чейнинга
        }

        public override string ToString() // Переопределенная ф-ция ToString
        {
            string TmpTheatres = "";
            foreach (Theatre obj in Theatres)
            {
                TmpTheatres += obj.Name + ", ";
            }

            return $"Фильм \"{this.Name}\".\n" +
                $"Жанр: {this.Genre}.\n" +
                $"Длительность: {this.Duration}.\n" +
                $"Доступен к показу в кинотеатрах ({Theatres.Count} шт.): {TmpTheatres}";
        }

        public IEnumerable<Theatre> GetTheatresStartedFrom(string Str)
        {
            return from TmpTheatre in Theatres
                   where TmpTheatre.Name.ToUpper().StartsWith(Str)
                   select TmpTheatre;
        }
    }
}
