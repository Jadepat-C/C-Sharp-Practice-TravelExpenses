var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();

/*ITravelExpensesDAO travelExpensesDAO = new TravelExpensesDAO();
List<TravelExpensesDTO> list = travelExpensesDAO.getAll();
Console.WriteLine($"ID: {list[1].id}");
Console.WriteLine($"Ref Number: {list[1].ref_number}");
Console.WriteLine($"Title: {list[1].title_en}");
Console.WriteLine($"Purpose: {list[1].purpose_en}");
Console.WriteLine($"Start Date: {list[1].start_date}");
Console.WriteLine($"End Date: {list[1].end_date}");
Console.WriteLine($"Airfare: {list[1].airfare}");
Console.WriteLine($"Other Transport: {list[1].other_transport}");
Console.WriteLine($"Meals: {list[1].meals}");
Console.WriteLine($"Other Expenses: {list[1].other_expenses}");
Console.WriteLine($"Total: {list[1].total}");

Console.WriteLine();

TravelExpensesDTO lookup = travelExpensesDAO.getByID(2);
Console.WriteLine($"ID: {lookup.id}");
Console.WriteLine($"Ref Number: {lookup.ref_number}");
Console.WriteLine($"Title: {lookup.title_en}");

TravelExpensesDTO updateItem = travelExpensesDAO.getByID(2);
updateItem.title_en = "Title";
travelExpensesDAO.Update(updateItem);
Console.WriteLine($"ID: {updateItem.id}");
Console.WriteLine($"Ref Number: {updateItem.ref_number}");
Console.WriteLine($"Title: {updateItem.title_en}");

updateItem.title_en = "Chair";
travelExpensesDAO.Update(updateItem);
Console.WriteLine($"ID: {updateItem.id}");
Console.WriteLine($"Ref Number: {updateItem.ref_number}");
Console.WriteLine($"Title: {updateItem.title_en}");

TravelExpensesDTO deleteItem = travelExpensesDAO.getByID(2);
travelExpensesDAO.Delete(deleteItem.id);
Console.WriteLine($"ID: {list[1].id}");
Console.WriteLine($"Ref Number: {list[1].ref_number}");
Console.WriteLine($"Title: {list[1].title_en}");
Console.WriteLine($"Purpose: {list[1].purpose_en}");
Console.WriteLine($"Start Date: {list[1].start_date}");
Console.WriteLine($"End Date: {list[1].end_date}");
Console.WriteLine($"Airfare: {list[1].airfare}");
Console.WriteLine($"Other Transport: {list[1].other_transport}");
Console.WriteLine($"Meals: {list[1].meals}");
Console.WriteLine($"Other Expenses: {list[1].other_expenses}");
Console.WriteLine($"Total: {list[1].total}");
Console.WriteLine("end delete");

travelExpensesDAO.Insert(deleteItem);
Console.WriteLine($"ID: {list[1].id}");
Console.WriteLine($"Ref Number: {list[1].ref_number}");
Console.WriteLine($"Title: {list[1].title_en}");
Console.WriteLine($"Purpose: {list[1].purpose_en}");
Console.WriteLine($"Start Date: {list[1].start_date}");
Console.WriteLine($"End Date: {list[1].end_date}");
Console.WriteLine($"Airfare: {list[1].airfare}");
Console.WriteLine($"Other Transport: {list[1].other_transport}");
Console.WriteLine($"Meals: {list[1].meals}");
Console.WriteLine($"Other Expenses: {list[1].other_expenses}");
Console.WriteLine($"Total: {list[1].total}");
Console.WriteLine("end insert");*/

/*foreach (var item in list)
{
    Console.WriteLine($"ID: {item.id}");
    Console.WriteLine($"Ref Number: {item.refNumber}");
    Console.WriteLine($"Title: {item.title}");
    Console.WriteLine($"Purpose: {item.purpose}");
    Console.WriteLine($"Start Date: {item.startDateString}");
    Console.WriteLine($"End Date: {item.endDateString}");
    Console.WriteLine($"Airfare: {item.airfare}");
    Console.WriteLine($"Other Transport: {item.otherTransport}");
    Console.WriteLine($"Meals: {item.meals}");
    Console.WriteLine($"Other Expenses: {item.otherExpenses}");
    Console.WriteLine($"Total: {item.total}");
    Console.WriteLine(); // Add a blank line for separation
}*/