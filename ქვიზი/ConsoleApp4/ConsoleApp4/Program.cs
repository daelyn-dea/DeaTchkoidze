//ფაილების დაბეჭდვა რეკურსიულად
//დაწერეთ კონსოლ აპლიკაცია, რომელიც პირველ რიგში დაბეჭდავს შემდეგ ტექსტს: To turn off
//program type "exit" otherwise enter the directory path რაც ნიშნავს შემდეგს: სანამ სიტყვა exit - ს არ
//შეიყვანს მომხმარებელი, მანამ პროგრამას უნდა შეეძლოს ფუნქციონირება, ხოლო სიტყვა exit - ის
//აკრეფის შემდეგ უნდა დაასრულოს მუშაობა. იმ შემთხვევაში როცა მომხმარებელი შეიტანს
//კონკრეტული დირექტორიის მისამართს, ასეთის არ არსებობის შემთხვევაში პროგრამამ უნდა
//გამოიტანოს შეტყობინება: The directory(შემოტანილი დირექტორია) does not exist! სხვა შემთხვავაში
//კი რეკურსიული მექანიზმის გამოყენებით უნდა დაბეჭდოს ამ დირექქტორიის ქვეშ არსებული ყველა
//ფაილის დასახელება.

Console.WriteLine("To turn off program type \"exit\" otherwise enter the directory path");
bool trueorfalse = true;
while (trueorfalse == true)
{
    string directory = Console.ReadLine();
    if (directory == "exit")
    {
        trueorfalse = false;
        break;
    }
    Function1(directory);
}


void Function1(string directory)
{
    int index = 0;
    if (Directory.Exists(directory) == false)
    {
        Console.WriteLine("does not exist!");
        return;
    }
    string[] array = Directory.GetDirectories(directory); //ფოლდერებს წამოღებს.
    string[] array1 = Directory.GetFiles(directory);// ფაილებს წამოიღებს
    for (int i = 0; i < array1.Length; i++)
    {
        Console.WriteLine(array1[i]);
    }
    for (int i = 0; i < array.Length; i++)
    {
        // Console.WriteLine(array[i]);
        directory = array[i];
        Function1(directory);
    }
}