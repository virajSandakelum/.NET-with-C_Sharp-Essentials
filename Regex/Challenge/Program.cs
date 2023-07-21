using System.Text.RegularExpressions;

static string ReverseDateFormat(string sourceDate){
    const int TIMEOUT = 1000;

    try{
        return Regex.Replace(sourceDate, @"^(?<mon>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{1,2})$"),"${year}-${mon}-${day}",RegexOptions.None);
    }catch(RegexMatchTimeoutException){
        return sourceDate;
    }
}


do{
    Console.WriteLine("Date to convert? (Use mm/dd/yyyy, or 'ext' to quit)");

    string inputStr = Console.ReadLine();

    if(inputStr == 'exit'){
        break;
    }

    DateTime result;

    if(DateTime.TryParse(inputStr, out result)){
        string reverseDate = ReverseDateFormat(inputStr);
        Console.WriteLine($"The reversed format is {reverseDate}");
    }else{
        Console.WriteLine("That's not a valid date,try again");
    }
}while(true);