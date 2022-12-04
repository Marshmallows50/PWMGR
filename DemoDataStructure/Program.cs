// See https://aka.ms/new-console-template for more information
using DemoDataStructure;

// Entries.Demonstration();

Entries group = new Entries("test");
int n = 1;


Entry e1 = new Entry("c","Ri", "Unh@ckab13PAsSW0rd", "coolwebsite.com", n++, "2410 Group Project");
group.Add(e1);
Entry e2 = new Entry("b","Gabe","l33tMar$All0ooooow","hello.com",n++, "2410 Group Project");
group.Add(e2);
group.Add(new Entry("a","Hunter","CA1iTripp1n","goodbye.com",n++, "2410 Group Project"));
e1.Tags.Add("Kool");
e2.Tags.Add("King");

foreach (Entry el in group.SortByPassword()) 
{
    Console.WriteLine(el);
}
//footer
Console.ForegroundColor = ConsoleColor.DarkGray;
