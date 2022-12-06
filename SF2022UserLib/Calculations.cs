namespace SF2022UserLib
{

    public class Calculations
    {
        public string[] AvailablePeriods(TimeSpan[] startTimes,
                                       int[] durations,
                                       TimeSpan beginWorkingTime,
                                       TimeSpan endWorkingTime,
                                       int consultationTime)
        {

            //превращем consultationTime заданнный как чилсо в минуты
            TimeSpan consultation = TimeSpan.FromMinutes(consultationTime);


            //создаем список и заполняем его переданными нам значениями начал занятых промежутков и превращаем их в строки
            List<string> protectIntervals = new List<string> {

                startTimes[0].ToString(),
                startTimes[1].ToString(),
                startTimes[2].ToString(),
                startTimes[3].ToString(),
                startTimes[4].ToString()

            };


            //создаем список и заполняем его переданными нам значениями продолжительности занятых промежутков (были массивами, стали списками)
            List<int> durations1 = new List<int>{

                durations[0],
                durations[1],
                durations[2],
                durations[3],
                durations[4]

            };


          
            List<string> Intervals = new List<string>();
            List<string> IntervalsReserve = new List<string>();



            //в список засовываем начала занятых промежутков и их продолжительности
            List<string> reserveTime = new List<string>(); // "10:00:00 60"

            for (int i = 0; i < protectIntervals.Count; i++)
            {
                reserveTime.Add($"{protectIntervals[i]} {durations1[i]}");
            }

            Console.WriteLine();
            Console.WriteLine("Резервные интервалы: ");
            //выводим все в консоль
            foreach (string interval in reserveTime)
            {
                Console.WriteLine(interval);
            }

            Console.WriteLine();


            while (true)
            {

                // если в списке начал занятых промежутков нет начала рабочего дня
                if (!protectIntervals.Contains(beginWorkingTime.ToString()))
                {

                    Console.WriteLine($"{beginWorkingTime:hh\\:mm} не содержится в резерве");

                    // если в период консультации есть резерв, то пропустить время для консультации
                    foreach (string str in protectIntervals) //проходимся по началам занятых временных промежутков
                    {
                        TimeSpan span = TimeSpan.Parse(str);  //превращаем каждую строку начал занятых промежутков в тип Время

                        //если начала рабочего дня меньше начала занятого промежутка (если работни кне начинает сразу работать) 
                        //И
                        //если начало рабочего дня + необходимое время (30 мин) больше начала занятого промежутка ( Негативно: 8:00 + 30 == 8:30 > 8:20 )
                        bool result = (beginWorkingTime < span) && ((beginWorkingTime + consultation) > span);


                        if (result == true)
                        {
                            Console.WriteLine($"{span} находится между {beginWorkingTime:hh\\:mm} и {(beginWorkingTime + consultation):hh\\:mm}");  //8:20 находится между 8 и 8:30 
                            beginWorkingTime = span;  //8 заменяем на 8:20
                            Console.WriteLine("Выход из цикла for");
                            Console.WriteLine($"{beginWorkingTime:hh\\:mm}"); //8:20
                            break; // выходим из цикла

                        }
                    }


                    //если в началых занятых промежутков нет начала рабочего времени
                    if (!protectIntervals.Contains(beginWorkingTime.ToString()))
                    {
                        // запись в массив разрешенных интервалов
                        Intervals.Add($"{beginWorkingTime:hh\\:mm}-{(beginWorkingTime + consultation):hh\\:mm}");// (8:00)-(8:00 + 30 = 8:30)
                        // обновление начала
                        beginWorkingTime = beginWorkingTime + consultation;  //8:00 = 8:00+30 = 8:30
                        Console.WriteLine($"Начало: {beginWorkingTime:hh\\:mm}"); //8:30
                    }

                }
                else
                // если в списке начал занятых промежутков есть начала рабочего дня
                {
                    Console.WriteLine($"{beginWorkingTime:hh\\:mm} содержится в резерве");
                    // если начало существует в резерве

                    // находим элемент, с которым начало совпало в резерве
                    foreach (string p in reserveTime)
                    {

                        if (beginWorkingTime == TimeSpan.Parse(p.Split(" ")[0]))
                        {
                            TimeSpan span = TimeSpan.Parse(p.Split(" ")[0]);
                            // вычисляем длительность резерва
                            // добавляем интервал в резервный массив
                            IntervalsReserve.Add($"{span:hh\\:mm}-{(span + TimeSpan.FromMinutes(Convert.ToInt32(p.Split(" ")[1]))):hh\\:mm}");
                            // вычисляем начало
                            beginWorkingTime = span + TimeSpan.FromMinutes(Convert.ToInt32(p.Split(" ")[1]));
                            Console.WriteLine($"Начало: {beginWorkingTime:hh\\:mm}");
                        }
                    }

                }

                if (beginWorkingTime >= endWorkingTime)
                {
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Разрешенные интервалы: ");

            int t = 0;
            string[] str1 = new string[Intervals.Count];

            foreach (string interval in Intervals)
            {
                Console.WriteLine(interval);
                str1[t] = interval;
                t++;
            }

            Console.WriteLine();
            Console.WriteLine("Зарезервированные интервалы: ");

            foreach (string interval in IntervalsReserve)
            {
                Console.WriteLine(interval);
            }

            return str1; // массив строк формата HH:mm - HH:mm
        }
    }

}