using TestAssignmentDesktop.Business.CrytoInfoReceiver;

var receiver = new CoinCapReceiver();

var list = receiver.ReceiveAllAssets().Result;

foreach (var item in list)
{
    Console.WriteLine(item.ToString());
}

Console.ReadLine();