   M S B A M L   `   `   `  ����@  <Tema2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema2.MVVM.ViewTema2.MVVM.View  5      ;"clr-namespace:Tema2.MVVM.ViewModelTema2.MVVM.ViewModel  5      /clr-namespace:Tema2.ServicesTema2.Services  5      %    Tema2.MVVM.View.GameUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Tema2.MVVM.View     5      1VM"clr-namespace:Tema2.MVVM.ViewModel     5      1servicesclr-namespace:Tema2.Services     5        � DataContext  5      &   Tema2.MVVM.ViewModel.GameBoardVM  5   
   .��5      � ��5   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$ 	#FF87FFD7��6    � Offset$ 0Q�61   � 5      $ 	#FFD3AAFF��6   $ 1Q�61   5       � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      .+�5   
   &    Tema2.MVVM.View.BoardUserControl  $��30q�5      
���   �$��4q�5      5      �� 5!   
   $��1��5"       �� Orientation$ Vertical=�5#      $��Center=�5$      $��Center=�5%      $��
0,30,30,30q�5&      .+�5'      �� $��Center=�5)      $��Center=�5*      $��	10,5,10,0q�5+      $��16(�5,      $
��Bold"�5-      ��5(      �� *GameModeText+5.      �� 5/      $��Center=�51      $��Center=�52      $��
10,5,10,70q�53      $��16(�54      $
��Bold"�55      ��50      �� *PlayerTurnText+56      �� 57         myButtonTheme#��[  58      $��	Save Game��59      ��5:      �� *Save+5;      �� 5<      #��[  5=      $
��Menu��5>      ��5?      �� *
BackToMenu+5@      5A      5B      5C      