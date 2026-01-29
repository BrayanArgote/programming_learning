class ClientUser : User
{

    public ClientUser(string userName) : base(userName) { }
    public override bool GetPermissions(Actions action)
    {
        bool isAuthorize = false;
        if (action == Actions.Delete || action == Actions.Read) { isAuthorize = false; }

        if (action == Actions.Deactive || action == Actions.Create) { isAuthorize = true; }

        return isAuthorize;
    }
}

