using System.Text;

namespace Task_001;

internal class XmasCard
{
    public string Header { get; set; } = string.Empty;
    public string Footer { get; set; } = string.Empty;
    public int RowCount { get; set; } = 0;

    private int rowLength = 0;

    private string NewTreeRow(int rowIndex)
    {
        string row = new('*', rowLength);

        if (rowIndex > 0)
        {
            for (int j = 0; j < rowIndex; j++)
            {
                row = row.Remove(j, 1).Insert(j, " ");
            }

            for (int j = rowLength - 1; j > rowLength - 1 - rowIndex; j--)
            {
                row = row.Remove(j, 1).Insert(j, " ");
            }

            for (int j = rowIndex + 1; j < rowLength - 1 - rowIndex; j++)
            {
                row = row.Remove(j, 1).Insert(j, " ");
            }
        }

        return row;
    }

    private string GenerateTree()
    {
        if (RowCount <= 1) return "*";

        rowLength = (RowCount - 2) * 2 + 1;

        StringBuilder sb = new();

        for (int i = 0; i < RowCount - 1; i++)
            sb.Insert(0, NewTreeRow(i) + "\n");

        string treeBase = new(' ', rowLength);
        sb.AppendLine(treeBase.Remove(rowLength / 2, 1).Insert(rowLength / 2, "*"));

        return sb.ToString();
    }

    public string GenerateCard()
    {
        StringBuilder sb = new();
        if (Header != string.Empty)
            sb.AppendLine(Header);
        sb.AppendLine(GenerateTree());
        if (Footer != string.Empty)
            sb.AppendLine(Footer);
        return sb.ToString();
    }
}
