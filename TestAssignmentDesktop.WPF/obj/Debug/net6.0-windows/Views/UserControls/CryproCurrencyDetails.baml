   M S B A M L   `   `   `  ????T  PTestAssignmentDesktop.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:TestAssignmentDesktop.WPF.Views.UserControls,TestAssignmentDesktop.WPF.Views.UserControls  5      H    BTestAssignmentDesktop.WPF.Views.UserControls.CryproCurrencyDetails   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:TestAssignmentDesktop.WPF.Views.UserControls     5      .??5	      ?   ? RowDefinitions  5
   
   ?? 5      $??100px ?6   ?? 5       ? ColumnDefinitions 5   
   ?? 5      $	??140 ?6   ?? 5      .+?5   
   ?? -   5         ??Name$ GoToHome??5      $
??Home??5      $
??18px(?5      $??30??5      $	??100??5      $??20q?5      ??5      ?? *ChangePageCommand+5      ?? 5   
    ?? Orientation$ 
Horizontal=?6   $??0??6.   $??1??6;   $??Center=?6K   .+?5      ?? -   5         ??Name$ CCName??5      $??20q?6)   $ Vertical=?65   .+?5      ?? $??Name:??6   $
??18px(?6)   ?? 5      $
??18px(?6H   ??6   ?? *SelectedCurrencyModel.Name+6H   5      ?? 5       -   5        $ CCCode??5       $??20q?6)   $ Vertical=?65   .+?5!      ?? $??Code:??6   $
??18px(?6)   ?? 5"      $
??18px(?6H   ??6   ?? *SelectedCurrencyModel.Code+6H   5#      ?? 5$      -   5        $ 
CCPriceUSD??5$      $??20q?6-   $ Vertical=?69   .+?5%      ?? $??
Price USD:??6   $
??18px(?6.   ?? 5&      $
??18px(?6i   ??6   ?? * SelectedCurrencyModel.USDValue+ ?? StringFormat$ {0:0.####} $??6i   5'      ?? 5(      -   5        $ CCVolume??5(      $??20q?6+   $ Vertical=?67   .+?5)      ?? $??Volume:??6   $
??18px(?6+   ?? 5*      $
??18px(?6c   ??6   ?? *SelectedCurrencyModel.Volume+$ {0:0.##}??6c   5+      ?? 5,      -   5        $ CCPriceChange??5,      $??20q?60   $ Vertical=?6<   .+?5-      ?? $??PriceChange:??6   $
??18px(?60   ?? 5.      $
??18px(?6j   ??6   ?? *#!SelectedCurrencyModel.PriceChange+$ 
{0:0.####}??6j   5/      50      ?? 52   
   $ Vertical=?6   $??1??6,   $??1??69   $	??Top=?6I   .+?53      ?? -   5        $ PriceComparer??53      $ 
Horizontal=?60   $	??Top=?6I   .+?54      ?? -   5        $ Instucrions??54      $??20q?62   $ Vertical=?6>   .+?55      ?? $'??!Choose currency to convert prices??6    $
??18px(?56      $	??200??57      $??WrapWithOverflow=?58      ?? 59       ?? DisplayMemberPath$
 Name??5;      $??0,20,0,0q?5<      ??59      ?? *CryptoCurrencyModels+ ?? SelectedItem 5:      ?? *$"SelectedForConversionCurrencyModel+5<      5=      ?? 5?      -	   5        $ Results??5?      $??20q?6.   $ Vertical=?6:   .+?5@      ??  ?? TextAlignment$ Center=?5A      $??Center=?5B      $
??18px(?5C      $	??400??5D      $??WrapWithOverflow=?5E      ??5@       ?? *ResultingString+5E      5F      5G      ?? 5H      -
   5        $ PriceComparer2??5H      $ 
Horizontal=?61   $	??Top=?6J   .+?5I      ?? $??20q?6   $ Vertical=?6)   .+?5J      ?? $ Center=?5K      $??Center=?5L      $
??Left=?5M      $
??18px(?5N      $	??200??5O      $??WrapWithOverflow=?5P      ??5J       ?? *RequestingString+5P      ?? 5Q      $??Center=?5R      $
??Left=?5S      $
??18px(?5T      $	??100??5U      $??0,20,0,0q?5V      ??5Q      ?? *
Quantity+	 ?? UpdateSourceTrigger$	 PropertyChanged=?5V      5W      ?? 5X      -   5        $ Results2??5X      $??20q?6/   $ Vertical=?6;   .+?5Y      ?? $ Center=?5Z      $??Center=?5[      $
??18px(?5\      $	??400??5]      $??WrapWithOverflow=?5^      ??5Y       ?? * ResultingStringDefinedQuantity+5^      5_      5`      5a      5b      5c      