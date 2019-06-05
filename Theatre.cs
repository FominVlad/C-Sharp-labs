using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    enum Rangs // Ранги кинотеатра
    {
        OneStar, // 1-звёздочный
        TwoStar, // 2-звёздочный
        ThreeStar, // 3-звёздночный
        Default // Без значения
    }
    class Theatre
    {
        public string Name { get; private set; } // Название кинотеатра
        public int SeatsQuantity { get; private set; } // Количество сидений
        public int BuildYear { get; private set; } // Год постройки
        public string Rang { get; private set; } // Ранг кинотеатра

        public City City { get; private set; } // Город, в котором размещён кинотеатр

        private List<Movie> Movies; // Список фильмов, доступных в кинотеатре

        public Theatre(City City, string Name, int SeatsQuantity, int BuildYear, Rangs Rang)
        {
            this.City = City;
            this.Name = Name;
            this.SeatsQuantity = SeatsQuantity;
            this.BuildYear = BuildYear;
            this.Movies = new List<Movie>();

            switch (Rang)
            {
                case Rangs.OneStar:
                    {
                        this.Rang = "Просмотр видеофильмов. Стерео звук.";
                        break;
                    }
                case Rangs.TwoStar:
                    {
                        this.Rang = "Просмотр широкоформатных фильмов. Стерео звук.";
                        break;
                    }
                case Rangs.ThreeStar:
                    {
                        this.Rang = "Просмотр 3D фильмов. Объемный звук.";
                        break;
                    }
                case Rangs.Default:
                    {
                        this.Rang = "Информация отсутствует!";
                        break;
                    }
            }
            City.AddTheatre(this);
        }

        public Theatre AddMovie(Movie Movie) // Добавить фильм в кинотеатр
        {
            this.Movies.Add(Movie);
            Movie.AddTheatre(this);
            return this; // Для чейнинга
        }

        public override string ToString() // Переопределённая ф-ция ToString
        {
            string Films = "";
            foreach (Movie obj in Movies)
            {
                Films += obj.Name + ", ";
            }
            
            return $"Кинотеатр расположен в городе {this.City.Name}.\n" +
                $"Название кинотеатра: {this.Name}.\n" +
                $"Построен в {this.BuildYear} году.\n" +
                $"Кинозал вмещает {this.SeatsQuantity} людей.\n" +
                $"Характеристики кинозала: {this.Rang}.\n" +
                $"Фильмы, которые доступны к просмотру ({Movies.Count} шт.): " + Films;
        }
    }
}
