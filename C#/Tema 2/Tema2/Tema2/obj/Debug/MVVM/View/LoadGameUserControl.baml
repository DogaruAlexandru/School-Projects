   M S B A M L   `   `   `  ����@  <Tema2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Tema2.MVVM.ViewTema2.MVVM.View  5      ;"clr-namespace:Tema2.MVVM.ViewModelTema2.MVVM.ViewModel  5      )    #Tema2.MVVM.View.LoadGameUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Tema2.MVVM.View     5      1VM"clr-namespace:Tema2.MVVM.ViewModel     5      $	��400��5	      $	��400��5
        � DataContext  5      %  Tema2.MVVM.ViewModel.LoadGameVM  5   
   .��5      � ��5   
   �� 5       �� 
StartPoint$	 0,0&�5       �� EndPoint$	 1,2&�5      .��5      �  � Color$ 	#FFB5DCFD��6    � Offset$	 0.0Q�61   � 5      $ 	#FF3ADFB8��6   $ 1Q�61   5       � RowDefinitions 5   
   �� 5      �� 5      $
��auto �6   .+�5   
   � $��0��5       5      �� 5      $
��auto �6    �� 5       .+�5"      �� $��	0,30,0,20q�5#      $��Center=�5$      $
��Bold"�5%      $��20(�5&      $��Saved Games��5'      5(      �� 5)      -   5         ��Name$ gamesListView��5*      $��1��5+      $��3q�5,      $��	30,0,30,0q�5-       �� SelectionMode$ Single=�5.      ��5/      �� *Games.Games+��50      �� 51       �� Color$ 	#CCD4EBFF��6&   53      54      �� 55   
   $��20,20,20,40q�56      $��1��57      	 �� Orientation$	 
Horizontal=�58      $��Center=�59      .+�5:      ��    myButtonTheme#��[  5;      $
��Back��5<      ��5=      �� *Back+5>      �� 5?      $
��Open��5@      ��5A      �� *Open+��5B      �� 
 �� ElementName$
 gamesListView�� �� Path$ SelectedItem���5C      �� 5D       �� 
TargetType" ��5E       �� BasedOn# [  5F       �� Triggers 5G      �� 5H       �� Binding 5I   !   �� $
 gamesListView��$ SelectedItem� �� Value 5J   !   Z� .a�5K   "   ��  �� Property � {� �� Value .  6>   5L      5N      5P      5Q      5R      5S      