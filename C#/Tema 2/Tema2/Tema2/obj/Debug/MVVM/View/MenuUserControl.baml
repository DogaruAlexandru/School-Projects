   M S B A M L   `   `   `  ����@  <Tema2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema2.MVVM.ViewTema2.MVVM.View  5      ;"clr-namespace:Tema2.MVVM.ViewModelTema2.MVVM.ViewModel  5      %    Tema2.MVVM.View.MenuUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Tema2.MVVM.View     5      1VM"clr-namespace:Tema2.MVVM.ViewModel     5      $	��280��5	      $	��300��5
        � DataContext  5      !  Tema2.MVVM.ViewModel.MenuVM  5   
   ��5      
� 5   
   .��5      �  � Color$ 	#FF86E0C2��5       � Offset$ 0.485Q�5      � 5      $ 	#FF9585A5��5      $ 1Q�5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5       $
��auto �6   �� 5!      .+�5$   
   �� $��1��5%      $��1��5&       �� Orientation$ Vertical=�5'      .+�5)      ��    myButtonTheme#��[  5*      $��New Game��5+      ��5,      �� *	NewGame+5-      �� 5.      #��[  5/      $��	Load Game��50      ��51      �� *
LoadGame+52      �� 53      $��0,20,0,0q�54      #��[  55      $��
Statistics��56      ��57      �� *
Statistics+58      �� 59      #��[  5:      $��Files Location��5;      ��5<      �� *FileLocation+5=      �� 5>      #��[  5?      $��About��5@      ��5A      �� *About+5B      �� 5C      $��0,20,0,0q�5D      #��[  5E      $
��Exit��5F      ��5G      �� *Exit+5H      5I      5J      5K      