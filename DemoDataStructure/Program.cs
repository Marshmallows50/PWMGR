// See https://aka.ms/new-console-template for more information
using DemoDataStructure;

// Entries.Demonstration();

Entries group = new Entries("test");
int n = 1;


Entry e1 = new Entry("Ri", "Unh@ckab13PAsSW0rd", "coolwebsite.com", 1, "2410 Group Project");
group.add((Entry) e1);
group.add(new Entry("Gabe","l33tMar$All0ooooow","hello.com",n++, "2410 Group Project"));
group.add(new Entry("Hunter","CA1iTripp1n","goodbye.com",n++, "2410 Group Project"));


//footer
Console.ForegroundColor = ConsoleColor.DarkGray;
