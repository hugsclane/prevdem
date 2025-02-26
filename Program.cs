using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace DemoRevitPlugin
{
  public class Program
  {
    public Result OnShutdown(UIControlledApplication application)
    {
      return Result.Succeeded;
    }
    public Result OnStartup( UIControlledApplication application)
    {
    RibbonPannel ribbonPannel = application.CreateRibbonPanel("UsefulTool");
    string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

    PushButtonData buttonData = new PushButtonData("cmdTest","Test",thisAssemblyPath,"DemoRevitPlugin.TestClass");
    Pushbutton PushButton = ribbonPannel.AddItem(buttonData) as PushButton;

    PushButton.ToolTip = "I'm a button that increases the likelyhood of hugo getting a job";

    Uri urlImage = new Uri(@"./button.png");
    BitmapImage bitmapImage = new BitmapImage(urlImage);

    return Result.Succeeded;
    }
  }
  [Transaction(transactionMode.Manual)]
public class TestClass : IExternalCommand
  {
  public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
      var uiapp = commandData.Application;
      var app  = uiapp.Application;
      var uidoc = uiapp.ActiveUIDocument;
      var doc = uidoc.Document;
      TaskDialog mainDialog = new TaskDialog("Important message");
      mainDialog.MainInstruction = "Hugo can make revit plugins!";
      mainDialog.MainContent =
          "If you are reading this then hugo has succeeded in making a revit plugin in C#"
          + "click the button below to communicate your satisfaction with this plugin";
      result Succeeded;
    }
  }
}

