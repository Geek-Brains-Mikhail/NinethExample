using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13._11._22
{
    internal class Program
    {
        static bool Check(string[] fullName)
        {
            return fullName.Length != 0;
        }
        static void AddDossier(ref string[] fullName, ref string[] post, ref int[] salary, string tmpFullName, string tmpPost, int tmpSalary)
        {
            Array.Resize(ref fullName, fullName.Length + 1);
            Array.Resize(ref post, post.Length + 1);
            Array.Resize(ref salary, salary.Length + 1);
            fullName[fullName.Length - 1] = tmpFullName;
            post[fullName.Length - 1] = tmpPost;
            salary[fullName.Length - 1] = tmpSalary;
        }
        static void PrintDossier(string[] fullName, string[] post, int[] salary)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
            }
            Console.WriteLine();
        }
        static void PrintrWithRestrictions(string[] fullName, string[] post, int[] salary, int[] indexRestrictions)
        {
            bool isWork = false;
            for (int i = 0; i < fullName.Length; i++)
            {
                for (int g = 0; g < indexRestrictions.Length; g++)
                {
                    if (i == indexRestrictions[g])
                    {
                        isWork = true;

                    }
                }
                if (isWork)
                    Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
                isWork = false;

                Console.WriteLine();
            }
        }
        static void DeleteDossier(ref string[] fullName, ref string[] post, ref int[] salary, int index)
        {
            string[] tmpFullName = new string[fullName.Length - 1];
            string[] tmpPost = new string[post.Length - 1];
            int[] tmpSalary = new int[salary.Length - 1];
            for (int i = 0, g = 0; i < fullName.Length; i++, g++)
            {
                if (i != index)
                {
                    tmpFullName[g] = fullName[i];
                    tmpPost[g] = post[i];
                    tmpSalary[g] = salary[i];
                    continue;
                }
                if (i == index) g--;
            }
            Array.Resize(ref fullName, fullName.Length - 1);
            Array.Resize(ref post, post.Length - 1);
            Array.Resize(ref salary, salary.Length - 1);

            for (int i = 0; i < fullName.Length; i++)
            {
                fullName[i] = tmpFullName[i];
                post[i] = tmpPost[i];
                salary[i] = tmpSalary[i];
            }
        }
        static int[] SeacrhDossier(string surName, string[] fullName)
        {
            int[] allIndex = { };
            for (int i = 0; i < fullName.Length; i++)
            {
                string[] tmp = fullName[i].Split(' ');
                if (tmp[0].ToLower() == surName.ToLower())
                {
                    Array.Resize(ref allIndex, allIndex.Length + 1);
                    allIndex[allIndex.Length - 1] = i;
                }
            }
            return allIndex;
        }
        static void SearchWithRestrictionsAndPrint(string[] fullName, string[] post, int[] salary, string parameter)
        {
            char sign = parameter[0];
            int sum = Convert.ToInt32(parameter.Substring(1, parameter.Length - 1));
            if (sign == '>')
            {
                for (int i = 0; i < salary.Length; i++)
                {
                    if (salary[i] > sum)
                        Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
                }

            }
            else
            {
                for (int i = 0; i < salary.Length; i++)
                {
                    if (salary[i] < sum)
                        Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
                }
            }
            Console.WriteLine();
        }
        static void SearchCertainPostAndPrint(string[] fullName, string[] post, int[] salary, string postName)
        {
            for (int i = 0; i < post.Length; i++)
            {
                if (post[i].ToLower() == postName.ToLower())
                    Console.WriteLine("{0} - {1} - {2}", fullName[i], post[i], salary[i]);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //9. Программа для ведения досье работников. Есть 3 массива: фио, должность и зарплата.
            //В программе должна быть возможность добавить досье, вывести все досье в формате фио-должность-зп
            //(Иванов Иван Иванович – кассир – 25 000), удалить досье по номеру (номера начинаются с 1),
            //поиск досье по фамилии. Дополнительно: вывод всех досье с зп меньше или больше указанной,
            //вывод всех досье с указанной должностью. Можно придумать еще свои команды.

            string[] fullName = { };
            string[] post = { };
            int[] salary = { };
            bool isWork = true;
            Console.WriteLine("Добро пожаловать в программу для ведения досье работникв");
            while (isWork)
            {
                Console.Write("Add - добавить досье\n" +
                    "Print - вывести все досье\n" +
                    "Delete - удалить досье по номеру(начиная с 1)\n" +
                    "Search - поиск досье по фамилии\n" +
                    "SearchWithRestrictionsAndPrint - поиск по зарплате с ограничениями\n" +
                    "SearchCertainPostAndPrint  - поиск по  должности\n" +
                    "Clear -  очистить консоль\n" +
                    "Exit - выйти\n" +
                    "Напишите команду: ");
                string solution = Console.ReadLine();
                Console.WriteLine();

                switch (solution.ToLower())
                {
                    case "add":
                        Console.Write("Введите ФИО работника: ");
                        string tmpFullName = Console.ReadLine();
                        Console.Write("Введите должность сотрудника: ");
                        string tmpPost = Console.ReadLine();
                        Console.Write("Введите зарплату сотрудника: ");
                        int tmpSalary = Convert.ToInt32(Console.ReadLine());
                        AddDossier(ref fullName, ref post, ref salary, tmpFullName, tmpPost, tmpSalary);
                        Console.WriteLine("Досье добавлено!\n");
                        break;
                    case "print":
                        if (Check(fullName))
                            PrintDossier(fullName, post, salary);
                        else Console.WriteLine("Досье отсутствуют");
                        break;
                    case "delete":
                        if (Check(fullName))
                        {
                            Console.Write("Введите номер досье,которе хотите удалить: ");
                            int indexDelete = Convert.ToInt32(Console.ReadLine());
                            if (indexDelete <= fullName.Length && indexDelete > 0)
                            {
                                DeleteDossier(ref fullName, ref post, ref salary, indexDelete - 1);
                                Console.WriteLine("Удаление прошло успешно!\n");
                            }
                            else Console.WriteLine("Заданный номер вышел за границы списка досье\n");
                            break;
                        }
                        Console.WriteLine("Не ");
                        break;
                    case "search":
                        if (Check(fullName))
                        {
                            Console.Write("Введите фамилию работника: ");
                            string surName = Console.ReadLine();
                            int[] arrayIndexDossiers = SeacrhDossier(surName, fullName);
                            if (arrayIndexDossiers.Length != 0)
                            {
                                Console.WriteLine("Ваше досье: ");
                                PrintrWithRestrictions(fullName, post, salary, arrayIndexDossiers);
                            }
                            else
                                Console.WriteLine("Человек с такой фамилией не найден\n");
                        }
                        else Console.WriteLine("Досье отсутствует");
                        break;
                    case "exit":
                        isWork = false;
                        break;
                    case "searchwithrestrictionsandprint":
                        if (Check(fullName))
                        {
                            Console.Write("Введите сумма с ограничением(>100000): ");
                            string certain = Console.ReadLine();
                            SearchWithRestrictionsAndPrint(fullName, post, salary, certain);
                        }
                        else Console.WriteLine("Досье отсутствует");
                        break;
                    case "searchcertainpostandprint":
                        if (Check(fullName))
                        {
                            Console.Write("Введите должность работника: ");
                            string postName = Console.ReadLine();
                            SearchCertainPostAndPrint(fullName, post, salary, postName);
                        }
                        else Console.WriteLine("Досье отсутствует");
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Введена неправильная команда.Попробуйте снова!");
                        break;
                }
            }


        }
    }
}
