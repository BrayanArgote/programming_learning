abstract class User
{
    private string userName;
    public string UserName
    {
        get { return userName; }
        set
        {
            if (!string.IsNullOrEmpty(value)) { userName = value; }
        }
    }
    private bool isActive;
    public bool IsActive {
        get { return isActive; }
    }

    public User(string userName)
    {
        UserName = userName;
        isActive = true;
    }

    public abstract bool GetPermissions(Actions action);

    public void Deactivate()
    {
         isActive = false; 
    }

}

