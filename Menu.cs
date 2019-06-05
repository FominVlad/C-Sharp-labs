using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    static class Menu
    {
        private static bool IsDone = false;
        private static bool IsDataDone = false;

        private static List<City> Cities = new List<City>();
        private static List<Theatre> Theatres = new List<Theatre>();
        private static List<Movie> Movies = new List<Movie>();

        private static void PrintMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Список действий:\n" +
                    "1. Создать город.\n" +
                    "2. Создать кинотеатр.\n" +
                    "3. Создать фильм.\n" +
                    "4. Купить фильм для кинотеатра.\n" +
                    "5. Вывести информацию о городе.\n" +
                    "6. Вывести информацию о кинотеатре.\n" +
                    "7. Вывести информацию о фильме.\n" +
                    "8. *Действия с выводом данных.\n" +
                    "m. Вызвать список действий.\n" +
                    "e. Завершить работу программы.\n" +
                    "import. Импортировать тестовые исходные данные.\n");
            Console.ResetColor();
        }

        private static void AddCity()
        {
            Console.WriteLine("Введите название города:\n");
            Cities.Add(new City(Console.ReadLine()));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Информация успешно добавлена!");
            Console.ResetColor();
        }

        private static void AddCinema()
        {
            Console.WriteLine("Укажите количество звёзд кинотеатра:");
            int tmp = Convert.ToInt32(Console.ReadLine());

            Rangs rang = Rangs.Default;
            switch (tmp)
            {
                case 1:
                    {
                        rang = Rangs.OneStar;
                        break;
                    }
                case 2:
                    {
                        rang = Rangs.OneStar;
                        break;
                    }
                case 3:
                    {
                        rang = Rangs.OneStar;
                        break;
                    }
                default:
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный код ранга! Информация будет отсутствовать!");
                        Console.ResetColor();
                        break;
                    }
            }

            Console.WriteLine("Введите название города, имя кинотеатра, кол-во мест и год постройки:\n");
            //TryParse!!!!!!
            Theatres.Add(new Theatre(Cities.Find(City => City.Name.Equals(Console.ReadLine())),
                                Console.ReadLine(), Convert.ToInt32(Console.ReadLine()),
                                Convert.ToInt32(Console.ReadLine()), rang));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Информация успешно добавлена!");
            Console.ResetColor();
        }

        private static void AddMovie()
        {
            Console.WriteLine("Введите название фильма, его длительность (Формат хх:хх:хх) и жанр:\n");
            Movies.Add(new Movie(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Информация успешно добавлена!");
            Console.ResetColor();
        }

        private static void PrintCityInfo()
        {
            Console.WriteLine("Введите название города:\n");
            string TmpStr = Console.ReadLine();
            Console.WriteLine((Cities.Find(City =>
                City.Name.Equals(TmpStr)) ?? new City("-----")).ToString());
        }

        private static void PrintTheatreInfo()
        {
            Console.WriteLine("Введите название кинотеатра:\n");
            string TmpStr = Console.ReadLine();
            Console.WriteLine((Theatres.Find(Theatre =>
                Theatre.Name.Equals(TmpStr)) ?? 
                new Theatre(new City("-----"), "-----", 0, 0, Rangs.OneStar)).ToString());
        }

        private static void PrintMovieInfo()
        {
            Console.WriteLine("Введите название фильма:\n");
            string TmpStr = Console.ReadLine();
            Console.WriteLine(((Movies.Find(Movie =>
                Movie.Name.Equals(TmpStr))) ??
                new Movie("-----", "00:00:00", "-----")).ToString());
        }

        private static void BuyMovie()
        {
            Console.WriteLine("Введите название кинотеатра, а затем фильма:\n");
            string TmpTheatre = Console.ReadLine();
            string TmpMovie = Console.ReadLine();
            Theatres.Find(Theatre => Theatre.Name.Equals(TmpTheatre))
                .AddMovie(Movies.Find(Movie => Movie.Name.Equals(TmpMovie)));
        }

        private static void Import()
        {
            Cities.Add(new City("Киев"));
            Cities.Add(new City("Умань"));

            Theatres.Add(new Theatre(Cities.Find(City => City.Name.Equals("Киев")),
                "IMAX", 100, 2013, Rangs.ThreeStar));
            Theatres.Add(new Theatre(Cities.Find(City => City.Name.Equals("Киев")),
                "Star", 55, 2008, Rangs.OneStar));
            Theatres.Add(new Theatre(Cities.Find(City => City.Name.Equals("Киев")),
                "Smart Plaza", 125, 2018, Rangs.ThreeStar));

            Theatres.Add(new Theatre(Cities.Find(City => City.Name.Equals("Умань")),
                "Комсомолец", 50, 1972, Rangs.OneStar));
            Theatres.Add(new Theatre(Cities.Find(City => City.Name.Equals("Умань")),
                "Премьера", 100, 2017, Rangs.ThreeStar));

            Movies.Add(new Movie("MARVEL", "01:15:27", "Мульт"));
            Movies.Add(new Movie("Соседи", "01:05:42", "Комедия"));
            Movies.Add(new Movie("Монгол", "00:52:31", "Драма"));
            Movies.Add(new Movie("Ярость", "01:27:13", "Драма"));
            Movies.Add(new Movie("Операция Ы", "01:17:54", "Комедия"));
        }

        private static void PrintDataMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Список действий:\n" +
                "0. Вернуться в главное меню.\n" +
                "1. Вывести все данные в консоль.\n" +
                "2. Вывести фильмы, которые начинаются на...\n" +
                "3. Вывести все данные, упорядоченные по алфавиту.\n" +
                "4. Вывести список кинотеатров и городов.\n" +
                "5. Вывести самый старый и самый новый кинотеатр.\n" +
                "6. Сгруппировать фильмы по жанрам.\n" +
                "7. Получиль кол-во всех элементов.\n" +
                "8. Получить список кинотеатров, которые вмещают больше среднего зрителей.\n" +
                "9. Получить ТОП-1 по вместительности и новизне кинотеатр.\n" +
                "10. Вывести все фильмы, упорядоченные в обратном алф. порядке.\n");
            Console.ResetColor();
        }

        private static void GetAllData()
        {
            var TmpCities = from City in Cities select City.Name;
            var TmpTheatres = from Theatre in Theatres select Theatre.Name;
            var TmpMovies = from Movie in Movies select Movie.Name;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список городов:");
            foreach (string tmp in TmpCities)
            {
                Console.WriteLine("- " + tmp);
            }
            Console.WriteLine("Список кинотеатров:");
            foreach (string tmp in TmpTheatres)
            {
                Console.WriteLine("- " + tmp);
            }
            Console.WriteLine("Список фильмов:");
            foreach (string tmp in TmpMovies)
            {
                Console.WriteLine("- " + tmp);
            }
            Console.ResetColor();
        }

        private static void GetMoviesStartWith(string str)
        {
            var TmpMovies = from Movie in Movies
                            where Movie.Name.ToUpper().StartsWith(str.ToUpper())
                            select Movie.Name;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Список фильмов, которые начинаются на \"{str}\" ({TmpMovies.Count()} шт.):");
            foreach (string tmp in TmpMovies)
            {
                Console.WriteLine("- " + tmp);
            }
            Console.ResetColor();
        }

        private static void GetAllDataOrderBy()
        {
            var TmpCities = from City in Cities orderby City.Name select City.Name;
            var TmpTheatres = from Theatre in Theatres
                              orderby Theatre.Name select Theatre.Name;
            var TmpMovies = from Movie in Movies orderby Movie.Name select Movie.Name;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список городов (Упор. в алф. пор.):");
            foreach (string tmp in TmpCities)
            {
                Console.WriteLine("- " + tmp);
            }
            Console.WriteLine("Список кинотеатров (Упор. в алф. пор.):");
            foreach (string tmp in TmpTheatres)
            {
                Console.WriteLine("- " + tmp);
            }
            Console.WriteLine("Список фильмов (Упор. в алф. пор.):");
            foreach (string tmp in TmpMovies)
            {
                Console.WriteLine("- " + tmp);
            }
            Console.ResetColor();
        }

        private static void GetTheatreCityList()
        {
            var TmpList = from City in Cities
                          join Theatre in Theatres on City.Name equals Theatre.City.Name
                          select new { City = City.Name, Theatre = Theatre.Name };

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список кинотеатров и городов:");
            foreach (var tmp in TmpList)
            {
                Console.WriteLine("- В городе {0} кинотеатр {1}", tmp.City, tmp.Theatre);
            }
            Console.ResetColor();
        }

        private static void GetOldNewTheatre()
        {
            var MaxTmp = Theatres.Max(Theatre => Theatre.BuildYear);
            var MinTmp = Theatres.Min(Theatre => Theatre.BuildYear);

            var OldTheatre = Theatres.Where(Theatre => Theatre.BuildYear == MinTmp);
            var NewTheatre = Theatres.Where(Theatre => Theatre.BuildYear == MaxTmp);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Самым старым является кинотеатр(ы) ");
            foreach (var tmp in OldTheatre)
            {
                Console.Write(tmp.Name + " ");
            }
            Console.Write("\nСамым новым является кинотеатр(ы) ");
            foreach (var tmp in NewTheatre)
            {
                Console.Write(tmp.Name + " ");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        private static void GetGroupedMovies()
        {
            var TmpMov = from Movie in Movies
                         group Movie by Movie.Genre;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Самым фильмов по жанрам:");
            foreach (IGrouping<string, Movie> tmp in TmpMov)
            {
                Console.WriteLine(tmp.Key);
                foreach (var obj in tmp)
                {
                    Console.WriteLine($"- {obj.Name}");
                }
            }
            Console.ResetColor();
        }

        private static void GetCountElements()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Кол-во городов = {Cities.Count()} | " +
                $"кинотеатров = {Theatres.Count()} | фильмов = {Movies.Count()}\n" +
                "Кол-во всех элементов = " +
                $"{Cities.Count() + Theatres.Count() + Movies.Count()}");
            Console.ResetColor();
        }

        private static void GetTheatreSitMore()
        {
            var TmpAvg = Theatres.Average(Theatre => Theatre.SeatsQuantity);
            var TmpList = from Theatre in Theatres
                          where Theatre.SeatsQuantity >= TmpAvg
                          select Theatre;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Среднее кол-во зрителей: {TmpAvg}.\nСписок кинотеатров:");
            foreach (var tmp in TmpList)
            {
                Console.WriteLine("- " + tmp.Name);
            }
            Console.ResetColor();
        }

        private static void GetTopTheatre()
        {
            var TmpList = (from Theatre in Theatres
                          orderby Theatre.SeatsQuantity descending, Theatre.BuildYear descending
                          select Theatre).Take(1);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("ТОП-1 кинотеатр: ");
            foreach (var tmp in TmpList)
            {
                Console.WriteLine(tmp.Name);
            }
            Console.ResetColor();
        }

        private static void GetMoviesOrderByDesc()
        {
            var TmpList = from Movie in Movies
                          orderby Movie.Name descending
                          select Movie;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Список фильмов, упор. в обратном алф. порядке: ");
            foreach (var tmp in TmpList)
            {
                Console.WriteLine($"- {tmp.Name}");
            }
            Console.ResetColor();
        }

        private static void GetData()
        {
            PrintDataMenu();
            while (!IsDataDone)
            {
                Console.WriteLine("Введите код действия:");
                switch (Console.ReadLine().ToLower())
                {
                    case "0":
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Возврат в главное меню...");
                            Console.ResetColor();
                            IsDataDone = !IsDataDone;
                            break;
                        }
                    case "1":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "1. Вывести все данные в консоль");
                            Console.ResetColor();
                            GetAllData();
                            break;
                        }
                    case "2":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "2. Вывести фильмы, которые начинаются на...");
                            Console.ResetColor();
                            Console.WriteLine("Введите начало названия фильма:");
                            
                            GetMoviesStartWith(Console.ReadLine());
                            break;
                        }
                    case "3":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "3. Вывести все данные, упорядоченные по алфавиту.");
                            Console.ResetColor();

                            GetAllDataOrderBy();
                            break;
                        }
                    case "4":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "4. Вывести список кинотеатров и городов.");
                            Console.ResetColor();
                            GetTheatreCityList();
                            break;
                        }
                    case "5":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "5.Вывести самый старый и самый новый кинотеатр.");
                            Console.ResetColor();
                            GetOldNewTheatre();
                            break;
                        }
                    case "6":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "6.Сгруппировать фильмы по жанрам.");
                            Console.ResetColor();
                            GetGroupedMovies();
                            break;
                        }
                    case "7":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "7. Получиль кол-во всех элементов.");
                            Console.ResetColor();
                            GetCountElements();
                            break;
                        }
                    case "8":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "8. Получить список кинотеатров, которые вмещают больше среднего зрителей.");
                            Console.ResetColor();
                            GetTheatreSitMore();
                            break;
                        }
                    case "9":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "9. Получить ТОП-1 по вместительности и новизне кинотеатр.");
                            Console.ResetColor();
                            GetTopTheatre();
                            break;
                        }
                    case "10":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "10. Вывести все фильмы, упорядоченные в обратном алф. порядке.");
                            Console.ResetColor();
                            GetMoviesOrderByDesc();
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверно указан код действия.");
                            Console.ResetColor();
                            break;
                        }

                }
            }
        }

        public static void Start()
        {
            PrintMenu();
            while (!IsDone)
            {
                Console.WriteLine("Введите код действия:");
                switch (Console.ReadLine().ToLower())
                {
                    case "e":
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Завершение работы....");
                            Console.ResetColor();
                            IsDone = true;
                            break;
                        }
                    case "m":
                        {
                            PrintMenu();
                            break;
                        }
                    case "1":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "1. Создать город.");
                            Console.ResetColor();
                            AddCity();
                            break;
                        }
                    case "2":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "2. Создать кинотеатр.\n");
                            Console.ResetColor();
                            AddCinema();
                            break;
                        }
                    case "3":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "3. Создать фильм.\n");
                            Console.ResetColor();
                            AddMovie();
                            break;
                        }
                    case "4":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "4. Купить фильм для кинотеатра.\n");
                            Console.ResetColor();
                            BuyMovie();
                            break;
                        }
                    case "5":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "5. Вывести информацию о городе.\n");
                            Console.ResetColor();
                            PrintCityInfo();
                            break;
                        }
                    case "6":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "6. Вывести информацию о кинотеатре.\n");
                            Console.ResetColor();
                            PrintTheatreInfo();
                            break;
                        }
                    case "7":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "7. Вывести информацию о фильме.\n");
                            Console.ResetColor();
                            PrintMovieInfo();
                            break;
                        }
                    case "8":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "8. *Действия с выводом данных.\n");
                            Console.ResetColor();
                            GetData();
                            IsDataDone = !IsDataDone;
                            break;
                        }
                    case "import":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Выбрано действие:\n" +
                                    "import. Импортировать тестовые исходные данные.\n");
                            Console.ResetColor();

                            Import();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Информация успешно добавлена!");
                            Console.ResetColor();
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неверно указан код действия.");
                            Console.ResetColor();
                            break;
                        }

                }
            }
        }

    }
}
