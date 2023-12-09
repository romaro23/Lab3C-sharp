using Lab3;
AppContext.SetSwitch("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", true);
//1. Створити екземпляр класу T з непустим списком елементів, для якого передбачено 
//введення даних з консолі. Створити повну копію екземпляра за допомогою методу, що 
//використовує серіалізацію, та вивести на консоль вихідний (початковий) екземпляр та 
//його копію.
Employee employee = new Employee(new Person("!!!!", "?????", DateTime.Now), "middle", TimeWork.FullTime, 500);
employee.AddDiplomas(new Diploma());
Employee employeeCopy = employee.DeepCopy();
Console.WriteLine(employee);
Console.WriteLine(employeeCopy);
//2.Запропонувати користувачеві ввести ім'я файлу:
//• якщо файлу з введеним ім'ям немає, програма повинна повідомити про це та 
//створити файл;
//• якщо файл існує, викликати метод Load(string filename) для ініціалізації екземпляра 
//класу T даними з файлу.
Console.WriteLine("Enter the file name:");
string filename = Console.ReadLine();
if (!File.Exists(filename))
{
    if(!string.IsNullOrEmpty(filename))
    {
        Console.WriteLine($"File '{filename}' does not exist. Creating a new file.");
        File.Create(filename).Close();
    }
    else
    {
        Console.WriteLine("The string is empty");
        return;
    }
}
employee.Load(filename);
//3. Вивести екземпляр класу T на консоль
Console.WriteLine(employee);
//4.Для цього ж екземпляра класу T спочатку викликати метод AddFromConsole(), потім 
//метод Save(string filename). Вивести екземпляр класу T на консоль.
employee.AddFromConsole();
employee.Save(filename);
Console.WriteLine(employee);
//5.Викликати послідовно
//• статичний метод Load (string filename, T obj), передавши як параметри посилання 
//на той же екземпляр класу T і введене раніше ім'я файлу;
//• метод AddFromConsole();
//• статичний метод Save(string filename, T obj).
Employee.Load(filename, employee);
employee.AddFromConsole();
Employee.Save(filename, employee);
//6.Вивести екземпляр класу T на консоль.
Console.WriteLine(employee);

