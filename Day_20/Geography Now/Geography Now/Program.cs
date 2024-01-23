using Geography_Now_;

try
{
    List<City> cityList = FileRead.fileReadMethod();

    Console.Write("Enter Country or City: ");
    string userChooseCountryOrCity = Console.ReadLine();

    if (userChooseCountryOrCity == "City")
    {
        Console.Write("Enter City Name: ");
        string userInputCity = Console.ReadLine();
        int indexOfEnteredCity = FindCityIndexMethod(cityList, userInputCity);
    try
    {
        Console.WriteLine(cityList[indexOfEnteredCity]);
    }
    catch
    {
        throw new Exception("You entered invalid city name!");
    }
    }
    else if (userChooseCountryOrCity == "Country")
    {
        Console.Write("Enter Country Name: ");
        string userInputCountry = Console.ReadLine();

        Country country = CreateCountyObject(cityList, userInputCountry);
        Console.WriteLine(country);
    }
    else
    {
        throw new Exception("You entered invalid answer, please enter just City or Country");
    }
}
catch (Exception ex)
{
    ErrorLog.ErrorLogInFile(ex.Message, ex.StackTrace);
}

int FindCityIndexMethod(List<City> cityList, string userInputCity)
{
    int indexOfEnteredCity = -1;
    for (int i = 0; i < cityList.Count; i++)
    {
        if (cityList[i].Name == userInputCity)
        {
            indexOfEnteredCity = cityList.IndexOf(cityList[i]);
        }
    }
    return indexOfEnteredCity;
}

Country CreateCountyObject(List<City> cityList, string userInputCountry)
{
    List<City> citiesOfCountry = new List<City>();

    int countCapitalCity = 0;

    foreach (City city in cityList)
    {
        if (city.Country == userInputCountry)
        {
            if (city.Capital)
            {
                city.Name = city.Name + "*";
                countCapitalCity++;
            }
            citiesOfCountry.Add(city);
        }
    }
    if (countCapitalCity > 1)
    {
        throw new Exception($"Country '{userInputCountry}' must have a single capital.");
    }
    Country country = new Country(userInputCountry, citiesOfCountry);
    return country;
}