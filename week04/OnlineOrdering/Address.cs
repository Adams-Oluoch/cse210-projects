public class Address
{
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _country;

    public Address(string street, string city, string stateProvince, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    
    public bool IsInUSA()
    {
        string c = _country.Trim().ToUpper();
        return c == "USA" || c == "US" || c == "UNITED STATES" || c == "UNITED STATES OF AMERICA";
    }

    
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateProvince}\n{_country}";
    }
}