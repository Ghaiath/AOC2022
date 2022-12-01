// Slower
var First = File.ReadAllText("./input.txt")
                 .Split("\r\n\r\n")
                 .Select((x, i) => new { Sum = x.Split("\r\n").Sum(y => int.Parse(y)), index = i++ }).OrderByDescending(x => x.Sum).First().Sum;


var Second = File.ReadAllText("./input.txt")
                 .Split("\r\n\r\n")
                 .Select((x, i) => new { Sum = x.Split("\r\n").Sum(y => int.Parse(y)), index = i++ }).OrderByDescending(x => x.Sum).Take(3).Sum(t => t.Sum);



// Faster
var input = File.ReadAllLines("./input.txt");
var list = new List<(int Id, int Amount)>();
var groupIndex = 1;
foreach (var line in input)
{
    if (string.IsNullOrEmpty(line))
    {
        groupIndex++;
    }
    else
    {
        list.Add((groupIndex, int.Parse(line)));
    }
};

var totals = list.GroupBy(x => x.Id).Select(g => (Id: g.Key, Sum: g.Sum(x => x.Amount))).OrderByDescending(x => x.Sum).Take(3).Sum(t => t.Sum);