   M S B A M L   `   `   `  ????T  PTestAssignmentDesktop.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:TestAssignmentDesktop.WPF.Views.UserControls,TestAssignmentDesktop.WPF.Views.UserControls  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 6W   [2clr-namespace:TestAssignmentDesktop.WPF.ViewModels$TestAssignmentDesktop.WPF.ViewModels  5      E    ?TestAssignmentDesktop.WPF.Views.UserControls.CryptoCurrencyList   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:TestAssignmentDesktop.WPF.Views.UserControls     5      6sys&clr-namespace:System;assembly=mscorlib     6W   Avm2clr-namespace:TestAssignmentDesktop.WPF.ViewModels     5      .??5
      ? $??10,10,10,10q?6   $	??360??6    $	??Top=?6-     ? RowDefinitions  5   
   ?? 5      $
??50px ?6   ?? 5       ? ColumnDefinitions 5   
   ?? 5      .+?5   
   ??  ?? Orientation$ 
Horizontal=?6   $??0??5      $??1??5      $??Center=?5      $
??Left=?5      .+?5      ?? $??Show from top??6   $??25??5      $??16(?5      $??35,0,0,0q?5      ?? 5      $??10q?5      $??25??5       $??16(?5!      $??60??5"       ?? SelectedIndex$ 0??5#       ?? SelectedItem 5      ?? *ShownCurrenciesCount+??5%      ?? 5&       ?? Type" ??6   .s?5'      ??10??6(   ??5(      25??6(   ??5)      50??6(   ??5*      100??6)   ??5+      200??6)   5,      5.      ?? 50      $??Start typing to search??6   $??25??51      $??16(?52      $??20,0,0,0q?53      ?? 55      $??Center=?56      $??250px??57      $??10q?58      $??25??59      ??55      ?? *SearchingFilterText+ ?? UpdateSourceTrigger$ PropertyChanged=?59      5:      ?? 5<   
   -   5         ??Name$ BottomPanel??5<      $ 
Horizontal=?5=      $??1??5>      $??Center=?5?      $
??Left=?5@      .+?5B      ?? -   5        $ NavPanel??5B      $ Vertical=?5C      $??1??5D      $	??Top=?5E      $??Center=?5F      $	??200??5G      $??10q?5H      .+?5I      ?? -   5         ??Name$ Explanationlabel??5I      $??Selected currency:??5J      $
??18px(?5K      $??30??5L      $??20,0,0,0q?5M      ?? 5N      -   5        $ CurrencyCodeTextBlock??5N      $
??18px(?5P      $??30??5Q      $??20,0,0,0q?5R      ??5O      ?? *SelectedCurrencyModel.Name+5R      ?? 5S      -   5        	 ??Name$	 GoToDetails??5S      $??Show details??5U      $
??18px(?5V      $??30??5W      $	??150??5X      ??5T      ?? *ChangePageCommand+5X      5Y      &   System.Windows.Controls.DataGrid  5Z      -   5        
  Name$
 
MainLisBox??5\      $??1??5]      $??1??5^         AutoGenerateColumns$ False??5_      $??20.6px(?5`      $??Times New Roman)?5a      $	??300??5b      ??5Z      ?? *CurrenciesCollectionView+ 5[      ??  ?? Path$ SelectedCurrencyModel?   Columns 5c      0  *System.Windows.Controls.DataGridTextColumn  5d      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 65 6B      
IsReadOnly$
 True??6M      Header$
 Rank??6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   ?? *Rank+6_     5e      $	 150 6B   $
 True??6N   $
 Name??6`    6)   ?? *Name+6`     5f      $	 200 6B   $
 True??6N   $
 Code??6`    6)   ?? *Code+6`     5g      $	 130 6c   $
 True??6o   $ Value in USD??6?    6)   ?? *
USDValue+ ?? StringFormat$ {0:0.####} $??6?   ??5i      ?? 5j      .R?5k      $? 5l      5n      5o      5r      5s      