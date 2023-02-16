using LetterManagement.Shared.Models;

namespace LetterManagement.Server.Controllers;

public static class SortTools
{
    public static void SortList(SortQueryString sortQueryString, List<Letter> inputList)
    {
        if(sortQueryString.SortBy == SortFields.ReceivedDate)
             inputList.Sort((a,b) =>a.ReceivedDate.GetValueOrDefault().CompareTo(b.ReceivedDate.GetValueOrDefault()));
        if(sortQueryString.SortBy == SortFields.FinishedDate)
             inputList.Sort((a,b) =>a.FinishedDate.GetValueOrDefault().CompareTo(b.FinishedDate.GetValueOrDefault()));
        else
        {
            inputList.Sort((a,b) =>a.CreatedAt.CompareTo(b.CreatedAt));
        }
        return;
    }
}