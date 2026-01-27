class AdminUser : User
{
    public AdminUser(string userName) : base(userName) { }
    public override bool GetPermissions(Actions action)
    {
        if (action == Actions.Create || action == Actions.Deactive || action == Actions.Delete || action == Actions.Read) { return true; }
        return false;
    }
}

