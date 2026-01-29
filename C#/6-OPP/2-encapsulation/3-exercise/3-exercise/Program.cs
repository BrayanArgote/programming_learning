/*
 Create a class that represents a UserProfile.

Name
Age
Email

Name cannot be empty.
Age must be 13 or more.
Email must contain @.

All fields must be private.
Access and validation must be done using properties only.

 */

class UserProfile
{
    private string name;
    public string Name 
    {
        get { return name; }
        set { 
            if (String.IsNullOrEmpty(value))
            {
                Console.WriteLine("Name can not be empty");
            }
            else
            {
                name = value;
            }
        }
    }

    private int age;
    public int Age
    {
        get { return age; }
        set {
            if (value >= 13)
            {
                age = value;
            }
            else {
                Console.WriteLine("Age can not less than 13");
            }
        }

    }

    private string email;
    public string Email
    {
        get { return email; }

        set {
            bool flag = false;
            foreach (char fe in value)
            {
                if (fe == '@')
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                email = value;
            }
            else
            {
                Console.WriteLine("Email addrees must contain an @");
            }
        }
    }

    public UserProfile()
    {
        name = "unknown";
        age = 13;
        email = "unknown@gmail.com";
    }
            
    static void Main(string[] args)
    {
        UserProfile userOne = new UserProfile();
        userOne.Name = "Juan";
        userOne.Age = 11;
        userOne.Email = "juan@gmail.com";

        Console.WriteLine(userOne.Name);
        Console.WriteLine(userOne.Age);
        Console.WriteLine(userOne.Email);

        Console.ReadKey();
    }
}


