// Labb 2 , Marcus Gustafsson

using System.Linq.Expressions;
using Labb2;
using System.Linq;

bool programActive = true;

List<KitchenAppliance> applianceList = new List<KitchenAppliance>();
KitchenAppliance appliance1 = new KitchenAppliance("Ugn", "Electrolux", true);
KitchenAppliance appliance2 = new KitchenAppliance("Micro", "Electrolux", true);
KitchenAppliance appliance3 = new KitchenAppliance("Matberedare", "Köksredskap AB", false);
applianceList.Add(appliance1);
applianceList.Add(appliance2);
applianceList.Add(appliance3);

void listAppliances()
{
    int index = 1;

    foreach(KitchenAppliance appliance in applianceList)
    {
        Console.WriteLine(index + ". " + appliance.Type);
        index++;
    }
}

void listAppliancesInfo()
{
    int index = 1;
    string skick = "Funkar";

    foreach (KitchenAppliance appliance in applianceList)
    {
        if(appliance.IsFunctioning == false)
        {
            skick = "Trasig";
        } else
        {
            skick = "Funkar";
        }
        Console.WriteLine(index + ". " + appliance.Type + ", " + appliance.Brand + ", skick: " + skick);
        index++;
    }
    Console.WriteLine("");
}

void addAppliance()
{
    Console.WriteLine("Ange typ: ");
    string typ = Console.ReadLine();
    Console.WriteLine("Ange märke: ");
    string märke = Console.ReadLine();
    Console.WriteLine("Ange om den funkar (j/n): ");
    string skick = Console.ReadLine();

    while(skick != "j" && skick != "n")
    {
        Console.WriteLine("Endast (j/n) är godkända val, vänligen ange om den funkar igen: ");
        skick = Console.ReadLine();
    }

    bool funkar = false;

    if(skick.Equals("j"))
    {
        funkar = true;
    }

    KitchenAppliance appliance = new KitchenAppliance(typ, märke, funkar);
    applianceList.Add(appliance);
    Console.WriteLine("Apparaten har lagts till i listan!");

}

void removeAppliance()
{
    int val = 0;
    while (!Int32.TryParse(Console.ReadLine(), out val) || !(val > 0 && val <= applianceList.Count))
    {
        Console.WriteLine("Ange ett nummer mellan 1 och " + applianceList.Count);
    }

    try
    {
        applianceList.RemoveAt(val - 1);
        Console.WriteLine("Apparaten har tagits bort från listan!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error info: " + ex.Message);
    }

}

void useAppliance()
{
    int val = 0;
    while (!Int32.TryParse(Console.ReadLine(), out val) || !(val > 0 && val <= applianceList.Count))
    {
        Console.WriteLine("Ange ett nummer mellan 1 och " + applianceList.Count);
    }

    try
    {
        applianceList.ElementAt(val - 1).Use();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error info: " + ex.Message);
    }
}

while (programActive)
{
    Console.WriteLine("1. Använd köksapparat \n" +
        "2. Lägg till köksapparat \n" +
        "3. Lista köksapparater \n" +
        "4. Ta bort köksapparat \n" +
        "5. Avsluta");

    int menuChoice = 0;
    Int32.TryParse(Console.ReadLine(), out menuChoice);
    
    switch (menuChoice)
    {
        case 1:
            Console.WriteLine("Välj köksapparat: ");
            listAppliances();
            useAppliance();
            break;
        case 2:
            addAppliance();
            break;
        case 3:
            listAppliancesInfo();
            break;
        case 4:
            listAppliances();
            Console.WriteLine("Välj vilken apparat du vill ta bort");
            removeAppliance();
            break;
        case 5:
            programActive = false;
            break;
        default:
            Console.WriteLine("Giltiga val är 1-5");
            break;
    }
}

class KitchenAppliance : IKitchenAppliance
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }
    public void Use()
    {
        if (IsFunctioning)
        {
            Console.WriteLine("Använder " + Type);
        } else
        {
            Console.WriteLine("Apparaten är trasig!");
        }
    }
    public KitchenAppliance(string type, string brand, bool isFunctioning)
    {
       Type = type;
       Brand = brand;
       IsFunctioning = isFunctioning;
    }
    
}

