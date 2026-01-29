class Magazine : Item
{
    private string issueNumber;
    public string IssueNumber
    {
        get { return issueNumber; }
        set { if (!string.IsNullOrEmpty(value)) { issueNumber = value; } else { issueNumber = "00-000"; } }
    }
}
  

