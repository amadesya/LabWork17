using DatabaseLibrary;
VisitorService visitorService = new();

var visitors = await visitorService.GetVisitorsAsync();
foreach (var visitor in visitors)
    Console.WriteLine($"{visitor.IdVisitor} {visitor.Name} {visitor.PhoneNumber}");

