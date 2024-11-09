
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace SimpleCollectionView;
public partial class MainViewModel : ObservableObject
{
    private static List<Person> longPeople = new List<Person>() {
        new Person("First","Person", 0),
        new Person("Bob","Smith"),
        new Person("Jim","Brown"),
        new Person("Fred","Robinson"),
        new Person("Famous","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Duplicate","Person"),
        new Person("Last","Person"),
    };
    private static List<Person> shortPeople = new List<Person>() { 
        new Person("First","Person", 0),
        new Person("Last","Person"),
    };

    public List<Person> People => IsLongList ? longPeople : shortPeople;

    [ObservableProperty]
    private Person? selectedItem;

    [ObservableProperty]
    private string commandType = "";

    [ObservableProperty]
    private string? commandParameter = null;

    [ObservableProperty]
    private string priorCommandType = "";

    [ObservableProperty]
    private string? priorCommandParameter = "";

    [ObservableProperty]
    private bool templateSelector = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(People))]
    private bool isLongList = false;

    [ObservableProperty]
    private int firstVisibleItemIndex;

    [ObservableProperty]
    private int lastVisibleItemIndex;

    public void ShowCommandInfo(string t, object commandParam)
    {
        PriorCommandType = CommandType;
        PriorCommandParameter = CommandParameter;
        CommandType = t;
        if (commandParam is Person p)
            CommandParameter = p.Name;
        else if (commandParam is null)
            CommandParameter = "null";
        else if (commandParam is string s)
            CommandParameter = "\"" + s + "\"";
        else
            CommandParameter = commandParam.ToString();
    }

    [RelayCommand]
    private void ShowTouch(object commandParam) => ShowCommandInfo("Touch", commandParam);
    [RelayCommand]
    private void ShowTap(object commandParam) => ShowCommandInfo("Tap", commandParam);
    [RelayCommand]
    private void ShowSwipe(object commandParam) => ShowCommandInfo("Swipe", commandParam);
    private void ShowLongPress(object commandParam)
    {
        ShowCommandInfo("Long Press", commandParam);
        TemplateSelector = !TemplateSelector;
    }
    private ICommand? showLongPressCommand = null;
    public ICommand ShowLongPressCommand => showLongPressCommand ??= new Command(ShowLongPress);
}

public class Person
{
    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        number = count++;
    }
    public Person(string firstName, string lastName, int number)
    {
        count = number;
        // Duplicate the simple constructor
        this.firstName = firstName;
        this.lastName = lastName;
        number = count++;
    }

    string firstName;
    string lastName;
    private int number;
    public static int count = 0;
    public string Name => lastName + ", " + firstName +" ["+ number +"]";
    public string FirstName => firstName;
    public string LastName => lastName;
    public int Number => number;
}
